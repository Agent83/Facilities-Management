<script setup lang="ts">
import { computed } from 'vue'
import { RouterLink } from 'vue-router'
import { storeToRefs } from 'pinia'
import { useMigrationSteps } from '../composables/useMigrationSteps'
import { useAppConfigStore } from '../stores/appConfig'

const { steps } = useMigrationSteps()
const firstSteps = computed(() => steps.slice(0, 3))

const appConfigStore = useAppConfigStore()
const { apiBaseUrl, isSecureConnection } = storeToRefs(appConfigStore)
const { setApiBaseUrl } = appConfigStore
</script>

<template>
  <section class="home">
    <h2>Start translating Angular features</h2>
    <p>
      This Vue workspace mirrors the Angular client's name and build targets so that you can incrementally port routes, services,
      and shared UI patterns. Replace these placeholders with real layouts as you migrate modules.
    </p>

    <section class="api-config">
      <h3>API configuration</h3>
      <p>
        Requests default to <code>{{ apiBaseUrl }}</code>. Update <code>VITE_API_PROXY_TARGET</code> or call
        <code>setApiBaseUrl()</code> from a Pinia action to match your environment.
      </p>
      <p>
        <strong>{{ isSecureConnection ? 'HTTPS' : 'HTTP' }}</strong>
        proxy traffic is enabled to keep parity with the Angular development server.
      </p>
      <div class="config-actions">
        <button type="button" @click="setApiBaseUrl('/api')">Use HTTPS proxy</button>
        <button type="button" @click="setApiBaseUrl('http://localhost:5000/api')">Use HTTP port 5000</button>
      </div>
    </section>

    <ol class="migration-steps">
      <li v-for="step in firstSteps" :key="step.title">
        <h3>{{ step.title }}</h3>
        <p>{{ step.summary }}</p>
      </li>
    </ol>

    <RouterLink class="view-guide" to="/about">Read the migration overview</RouterLink>
  </section>
</template>

<style scoped>
.home {
  display: grid;
  gap: 2rem;
}

.api-config {
  border: 1px solid var(--color-border);
  border-radius: 0.75rem;
  padding: 1.25rem;
  background: var(--color-background-soft);
  display: grid;
  gap: 0.75rem;
}

.config-actions {
  display: flex;
  flex-wrap: wrap;
  gap: 0.75rem;
}

.config-actions button {
  padding: 0.5rem 1rem;
  border-radius: 999px;
  border: 1px solid var(--color-border);
  background: var(--color-background);
  cursor: pointer;
  transition: background 0.2s ease;
}

.config-actions button:hover {
  background: var(--color-background-mute);
}

.migration-steps {
  display: grid;
  gap: 1.25rem;
  padding: 0;
  list-style: none;
}

.migration-steps li {
  border: 1px solid var(--color-border);
  border-radius: 0.75rem;
  padding: 1.25rem;
  background: var(--color-background-soft);
}

.migration-steps h3 {
  margin-bottom: 0.5rem;
}

.view-guide {
  justify-self: start;
  padding: 0.75rem 1.25rem;
  border-radius: 999px;
  background: var(--color-background-mute);
  text-decoration: none;
  color: inherit;
  border: 1px solid var(--color-border);
}

.view-guide:hover {
  background: var(--color-background-soft);
}
</style>
