# Facilities Management Vue client

This project replaces the Angular SPA located in [`client/`](../client/) with a Vue 3 + Vite implementation. It keeps the same
package name so that build and deployment scripts can be swapped in with minimal changes while the migration is underway.

## Getting started

```sh
npm install
npm run dev
```

The dev server proxies API calls to the ASP.NET back end (see [`vite.config.ts`](./vite.config.ts)). Update the proxy target if
your API runs on a different port or protocol.

## Recommended next steps

1. Recreate the Angular routing table inside [`src/router/index.ts`](./src/router/index.ts) and point each route at either a new
   view component or a placeholder while the feature is being rebuilt.
2. Translate Angular services and shared state from `client/src/app/_services` into [Pinia stores](https://pinia.vuejs.org/) or
   Vue composables inside [`src/stores`](./src/stores/) and [`src/composables`](./src/composables/).
3. Move feature-specific modules into directories under [`src`](./src/) that mirror the Angular layout (e.g.
   `src/modules/work-orders`).
4. Delete the placeholder views once production-ready pages are in place.

Consult [`docs/MIGRATING_TO_VUE3.md`](../docs/MIGRATING_TO_VUE3.md) for a detailed playbook that maps Angular features to their
Vue counterparts.

## Scripts

| Command             | Description                                                            |
| ------------------- | ---------------------------------------------------------------------- |
| `npm run dev`       | Start the Vite dev server with hot module replacement.                 |
| `npm run build`     | Type-check the project and generate a production build in `dist/`.     |
| `npm run preview`   | Serve the build output locally for final verification.                 |
| `npm run lint`      | Run ESLint to validate code style and catch common issues.             |
| `npm run lint:fix`  | Auto-fix lint problems where possible.                                 |
| `npm run type-check`| Run the Vue-aware TypeScript compiler without generating build output. |
| `npm run format`    | Format source files with Prettier.                                     |

To integrate the build into CI/CD, replace Angular CLI commands with the equivalent scripts above.
