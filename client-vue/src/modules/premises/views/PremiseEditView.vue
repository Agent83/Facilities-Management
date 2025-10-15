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
        <h1>Edit premise</h1>
        <p>Port the reactive form from Angular's <code>PremiseEditComponent</code> into Vue.</p>
      </div>
    </header>

    <div class="view__placeholder">
      <p>Editing premise ID: <strong>{{ premiseId }}</strong>.</p>
      <p>
        Use <code>defineProps</code> or route params with a form library to guard against unsaved changes similar to
        <code>PreventUnsavedChangesGuard</code>.
      </p>
    </div>
  </section>
</template>

<style scoped>
@import '../../viewsShared.css';
</style>
