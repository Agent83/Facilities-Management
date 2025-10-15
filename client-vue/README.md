# Facilities Management Vue client

This project replaces the Angular SPA located in [`client/`](../client/) with a Vue 3 + Vite implementation. The Vue workspace
now mirrors the Angular module layout so that screens can be ported feature-by-feature without breaking existing deployments.

## Getting started

```sh
npm install
npm run dev
```

The dev server proxies API calls to the ASP.NET back end (see [`vite.config.ts`](./vite.config.ts)). Update the
`VITE_API_PROXY_TARGET` environment variable if your API runs on a different port or protocol.

## Project layout

```
src/
├─ App.vue                # Global spinner + navigation shell shared by every route
├─ components/            # Reusable UI such as the primary navigation bar
├─ modules/
│  ├─ admin/              # Admin panel placeholder mirroring `client/src/app/admin`
│  ├─ auth/               # Login screen that will host the JWT flow
│  ├─ contractors/        # Contractor CRUD placeholders (`contractor-*` Angular components)
│  ├─ members/            # Member list/detail placeholders
│  ├─ notes/              # Notes screen scaffold
│  ├─ lists/              # Saved list placeholder
│  ├─ premises/           # Premises list/detail/edit/create scaffolds
│  └─ errors/             # 404/500/test error views
├─ router/index.ts        # Vue Router table that mirrors `app-routing.module.ts`
├─ stores/
│  ├─ auth.ts             # Pinia store for authentication (replace `signInMock` during migration)
│  └─ uiState.ts          # Loading indicator manager used by the global spinner
└─ assets/                # Global styles imported by `main.ts`
```

Each view component contains guidance pointing to the Angular source directory it should replicate. Replace the placeholder
content with production-ready Vue code as you migrate each feature.

## Routing and guards

`src/router/index.ts` recreates the Angular route hierarchy including authentication and admin guards. Meta fields control both
the document title and whether the route participates in the secure shell. Update the guard logic once the real authentication
API is wired up.

## Navigation shell and spinner

`App.vue` renders a global spinner and the primary navigation bar so that the Vue client feels like the existing Angular SPA
while screens are rebuilt. The spinner is driven by `useUiStateStore`; call `beginTask`/`endTask` around async work to reuse the
loading overlay.

## Next steps

1. Replace `authStore.signInMock` with the real login workflow and persist JWT tokens the same way the Angular client does.
2. Port services from `client/src/app/_services` into Pinia stores or composables under `src/stores`.
3. Move shared form controls and modals into Vue components so that the premises, contractors, and notes flows can be rebuilt.
4. Remove the placeholder messaging once each module reaches feature parity with the Angular implementation.

Consult [`docs/MIGRATING_TO_VUE3.md`](../docs/MIGRATING_TO_VUE3.md) for a step-by-step migration plan that maps Angular features
to their Vue counterparts.

## Scripts

| Command              | Description                                                            |
| -------------------- | ---------------------------------------------------------------------- |
| `npm run dev`        | Start the Vite dev server with hot module replacement.                 |
| `npm run build`      | Type-check the project and generate a production build in `dist/`.     |
| `npm run preview`    | Serve the build output locally for final verification.                 |
| `npm run lint`       | Run ESLint to validate code style and catch common issues.             |
| `npm run lint:fix`   | Auto-fix lint problems where possible.                                 |
| `npm run type-check` | Run the Vue-aware TypeScript compiler without generating build output. |
| `npm run format`     | Format source files with Prettier.                                     |

To integrate the build into CI/CD, replace Angular CLI commands with the equivalent scripts above.
