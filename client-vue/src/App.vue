<script setup lang="ts">
import { computed } from 'vue'
import { RouterView, useRoute } from 'vue-router'
import GlobalSpinner from './components/GlobalSpinner.vue'
import PrimaryNav from './components/navigation/PrimaryNav.vue'

const route = useRoute()

const layoutClass = computed(() => {
  const layout = route.meta.layout
  if (layout === 'public') {
    return 'app-shell--public'
  }

  return 'app-shell--secure'
})
</script>

<template>
  <div class="app-shell" :class="layoutClass">
    <GlobalSpinner />

    <header class="app-shell__header">
      <PrimaryNav />
    </header>

    <main class="app-shell__content">
      <RouterView />
    </main>
  </div>
</template>

<style scoped>
.app-shell {
  min-height: 100vh;
  display: grid;
  grid-template-rows: auto 1fr;
  background: var(--color-background-soft);
}

.app-shell__header {
  position: sticky;
  top: 0;
  z-index: 10;
  backdrop-filter: blur(12px);
  background: color-mix(in srgb, var(--color-background) 92%, transparent);
  border-bottom: 1px solid var(--color-border);
}

.app-shell__content {
  padding: clamp(1.5rem, 4vw, 3rem);
}

.app-shell--public .app-shell__content {
  display: grid;
  align-items: center;
  justify-items: center;
  padding-block: clamp(3rem, 8vw, 6rem);
}
</style>
