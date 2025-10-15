<template>
  <section class="view">
    <header class="view__header">
      <div>
        <h1>Contractors</h1>
        <p>Translate the contractor list from Angular's <code>contractor-list</code> feature.</p>
      </div>
      <RouterLink class="view__action" :to="{ name: 'contractor-create' }">Add contractor</RouterLink>
    </header>

    <div class="view__placeholder">
      <p>
        Implement filtering, contact badges, and pagination using Vue components backed by the same endpoints as
        <code>client/src/app/contractor/contractor-list</code>.
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
