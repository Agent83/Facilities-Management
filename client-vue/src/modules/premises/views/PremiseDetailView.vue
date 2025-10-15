<script setup lang="ts">
import { computed } from 'vue'
import { useRoute } from 'vue-router'

const route = useRoute()
const premiseId = computed(() => route.params.id as string)
</script>

<template>
  <section class="view">
    <header class="view__header">
      <div>
        <h1>Premise details</h1>
        <p>Mirror the Angular <code>PremiseDetailComponent</code> UI and interactions here.</p>
      </div>
    </header>

    <div class="view__placeholder">
      <p>Requested premise ID: <strong>{{ premiseId }}</strong>.</p>
      <p>
        Load premise data using the same service the Angular app calls from
        <code>client/src/app/premises/premise-detail</code>, then render contact, lease, and compliance panels.
      </p>
    </div>
  </section>
</template>

<style scoped>
@import '../../viewsShared.css';
</style>
