# Migrating the Client from Angular to Vue 3

This guide outlines the steps required to replace the existing Angular 11 front-end with a Vue 3 implementation while keeping the .NET 6 back-end intact. It assumes familiarity with both frameworks and highlights how to translate project-specific concepts.

## 1. Analyse the Existing Angular Application

1. Inventory Angular modules, components, services, guards, and interceptors in `client/src/app`.
2. Record routing structure from `app-routing.module.ts`, noting lazy-loaded modules, route guards, and resolvers.
3. Document global styles (`styles.css`, `theme.less`) and reusable directives (e.g. contents of `_directives`).
4. Extract API interaction patterns from `_services` and interceptors to understand authentication, error handling, and base URLs defined in `environments/`.

## 2. Bootstrap a Vue 3 + Vite Project

1. From the repository root run `npm create vue@latest client-vue` and select TypeScript, Vue Router, Pinia (or your preferred state manager), ESLint, and Prettier options.
2. Update the generated `package.json` name and version to match the existing client.
3. Configure the dev server proxy in `vite.config.ts` so that API calls to `/api` route to the ASP.NET back-end (e.g. `target: 'https://localhost:5001'`).

## 3. Recreate Application Structure

1. Map Angular feature modules (e.g. `members`, `premiseTasks`, `contractor`) to Vue directories under `src/modules/` or `src/views/`.
2. Convert Angular components to Vue single-file components (`.vue`). Move template HTML to the `<template>` block, component logic to `<script setup lang="ts">`, and styles to `<style scoped>` where appropriate.
3. Replace Angular directives (e.g. `*ngIf`, `ngFor`) with Vue equivalents (`v-if`, `v-for`) and translate custom directives into Vue directives located in `src/directives/`.
4. Translate Angular pipes into Vue composables or filters as needed.

## 4. Implement Routing and Navigation Guards

1. Recreate the Angular routing table in `src/router/index.ts` using Vue Router, including nested routes and dynamic segments.
2. Re-implement guards (e.g. `AuthGuard`, `AdminGuard`) as navigation guards that consult Pinia stores or authentication services before allowing entry.
3. Port Angular resolvers to `beforeEnter` hooks or to component-level async loaders.

## 5. Port State Management and Services

1. Move Angular services in `_services` to Vue composables or Pinia stores. Replace RxJS Observables with `async/await` or `ref`/`computed` constructs.
2. Rebuild HTTP interceptors as Axios interceptors or wrapper functions to attach tokens, handle errors, and refresh authentication.
3. Replicate the DTOs and interfaces from `_models` as TypeScript interfaces used in the Vue project.

## 6. Recreate Forms and Validation

1. For Angular reactive forms, use `@vueuse/form`, `vee-validate`, or native Composition API patterns to manage state and validation.
2. Implement reusable form components for inputs, select lists, and modals that align with the existing UI/UX.
3. Port Angular Material or custom component styling to Vue component libraries (e.g. PrimeVue, Vuetify) or reimplement with Tailwind/Bootstrap as required.

## 7. Handle Authentication and Authorization

1. Re-implement login, registration, and role-based UI logic using Pinia stores that persist tokens (e.g. via `localStorage`).
2. Ensure secure storage and refresh logic mirrors the Angular JWT handling currently implemented in interceptors and guards.
3. Update server-side CORS settings if the Vue project runs on a different origin during development.

## 8. Migrate Global Styling and Assets

1. Copy assets from `client/src/assets` to `client-vue/src/assets` and adjust import paths.
2. Move global CSS and Less files into `src/assets/styles/` and import them in `main.ts` or the root component.
3. Replace Angular-specific theming (e.g. Material theming) with Vue-compatible styles.

## 9. Integrate with the .NET Build Pipeline

1. Update the solution to build the Vue client. Replace Angular CLI commands in CI scripts with Vite equivalents (`npm install`, `npm run build`).
2. Configure the .NET project to serve the Vue build output (usually `client-vue/dist`). Adjust `UseSpaStaticFiles` or equivalent middleware.
3. Update Dockerfiles or deployment scripts to copy the Vue build artifacts instead of `client/dist`.

## 10. Decommission Angular Artifacts

1. Remove the `client/` Angular project once the Vue implementation reaches feature parity.
2. Update documentation and onboarding scripts to refer to the Vue project.
3. Clean up unused npm dependencies and lock files.

## 11. Testing and Verification

1. Recreate existing Angular unit and end-to-end tests using Vue Test Utils and Cypress/Playwright.
2. Ensure all critical user flows (authentication, task management, contractor management) are tested before deployment.

---

By following these steps incrementally—feature-by-feature—you can replace the Angular client with a Vue 3 application while preserving the existing back-end contracts.
