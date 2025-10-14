<script setup lang="ts">
import { RouterLink } from 'vue-router'
</script>

<template>
  <section class="about">
    <h2>Migration reference</h2>
    <p>
      Use this workspace to stand up feature-by-feature replacements for the Angular client. Consult the migration playbook in
      <code>docs/MIGRATING_TO_VUE3.md</code> for deeper guidance on porting routing, guards, services, and styling.
    </p>

    <p>
      As you replace Angular modules, mirror their directory structure inside <code>src/</code> (for example,
      <code>src/modules/work-orders</code>). You can register new routes in <code>src/router/index.ts</code> and share state using
      Pinia stores under <code>src/stores/</code> (see <code>useAppConfigStore</code> for a lightweight example).
    </p>

    <p>
      Remove any placeholder content once the real feature pages are in place. The Vue build pipeline already matches the old
      project's package name so that deployment scripts can be swapped in without major changes.
    </p>

    <RouterLink class="return-home" to="/">Back to migration checklist</RouterLink>
  </section>
</template>

<style scoped>
.about {
  display: grid;
  gap: 1.5rem;
}

.return-home {
  justify-self: start;
  padding: 0.75rem 1.25rem;
  border-radius: 999px;
  background: var(--color-background-mute);
  text-decoration: none;
  color: inherit;
  border: 1px solid var(--color-border);
}

.return-home:hover {
  background: var(--color-background-soft);
}
</style>
