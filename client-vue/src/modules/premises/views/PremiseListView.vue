<template>
  <section class="view">
    <header class="view__header">
      <div>
        <h1>Premises</h1>
        <p>Recreate <code>PremiseListComponent</code> from the Angular client in this view.</p>
      </div>
      <RouterLink class="view__action" :to="{ name: 'premise-create' }">Create premise</RouterLink>
    </header>

    <div class="view__placeholder">
      <p>
        Use this workspace to port list filters, table layouts, and map visualisations from
        <code>client/src/app/premises/premise-list</code>.
      </p>
    </div>
  </section>
</template>

<script setup lang="ts">
import { RouterLink } from 'vue-router'
</script>

<style scoped>
@import '../../viewsShared.css';
</style>
