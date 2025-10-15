<script setup lang="ts">
import { computed } from 'vue'
import { useRoute } from 'vue-router'

const route = useRoute()
const username = computed(() => route.params.userName as string)
</script>

<template>
  <section class="view">
    <header class="view__header">
      <div>
        <h1>Member profile</h1>
        <p>Map Angular's <code>MemberDetailsComponent</code> to Vue.</p>
      </div>
    </header>

    <div class="view__placeholder">
      <p>Viewing profile for: <strong>{{ username }}</strong>.</p>
      <p>
        Use Vue Router route params to load member information and tie into the same API endpoints consumed by the Angular
        component.
      </p>
    </div>
  </section>
</template>

<style scoped>
@import '../../viewsShared.css';
</style>
