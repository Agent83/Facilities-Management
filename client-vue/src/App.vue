<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <div class="app-shell">
    <header class="app-header">
      <div class="branding">
        <h1>Facilities Management Vue Client</h1>
        <p class="tagline">
          Start migrating Angular screens into Vue single-file components while keeping routing, API calls, and shared state
          consistent.
        </p>
      </div>

      <nav class="primary-nav">
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/about">About</RouterLink>
      </nav>
    </header>

    <main class="app-content">
      <RouterView />
    </main>
  </div>
</template>

<style scoped>
.app-shell {
  min-height: 100vh;
  display: flex;
  flex-direction: column;
}

.app-header {
  background: var(--color-background-soft);
  border-bottom: 1px solid var(--color-border);
  padding: 2rem clamp(1rem, 5vw, 3rem);
  display: flex;
  flex-direction: column;
  gap: 1.5rem;
}

.branding h1 {
  font-size: clamp(1.75rem, 2vw + 1.25rem, 2.5rem);
  margin-bottom: 0.5rem;
}

.branding .tagline {
  max-width: 60ch;
  margin: 0;
  color: var(--color-text-soft);
}

.primary-nav {
  display: flex;
  gap: 1rem;
  flex-wrap: wrap;
}

.primary-nav a {
  padding: 0.5rem 1rem;
  border-radius: 999px;
  border: 1px solid var(--color-border);
  color: inherit;
  text-decoration: none;
  transition: background 0.2s ease;
}

.primary-nav a.router-link-active {
  background: var(--color-background-mute);
}

.primary-nav a:hover {
  background: var(--color-background-mute);
}

.app-content {
  flex: 1;
  padding: 2rem clamp(1rem, 5vw, 3rem) 3rem;
}
</style>
