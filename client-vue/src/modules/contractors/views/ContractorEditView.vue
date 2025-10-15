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
        <h1>Edit contractor</h1>
        <p>Translate Angular's <code>ContractorEditComponent</code> form logic into Vue.</p>
      </div>
    </header>

    <div class="view__placeholder">
      <p>Editing contractor ID: <strong>{{ contractorId }}</strong>.</p>
      <p>
        Use <code>beforeRouteLeave</code> or a form guard composable to replicate <code>PreventUnsavedChangesGuard</code>.
      </p>
    </div>
  </section>
</template>

<style scoped>
@import '../../viewsShared.css';
</style>
