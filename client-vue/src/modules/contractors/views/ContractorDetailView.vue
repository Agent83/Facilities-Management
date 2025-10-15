<script setup lang="ts">
import { computed } from 'vue'
import { useRoute } from 'vue-router'

const route = useRoute()
const contractorId = computed(() => route.params.id as string)
</script>

<template>
  <section class="view">
    <header class="view__header">
      <div>
        <h1>Contractor details</h1>
        <p>Mirror Angular's <code>ContractorDeatialsComponent</code> with Vue components.</p>
      </div>
    </header>

    <div class="view__placeholder">
      <p>Viewing contractor ID: <strong>{{ contractorId }}</strong>.</p>
      <p>
        Populate this screen with contact history, trade specialities, and compliance documents.
      </p>
    </div>
  </section>
</template>

<style scoped>
@import '../../viewsShared.css';
</style>
