<script setup lang="ts">
import { storeToRefs } from 'pinia'
import { useUiStateStore } from '../stores/uiState'

const uiState = useUiStateStore()
const { isLoading, message } = storeToRefs(uiState)
</script>

<template>
  <transition name="spinner" appear>
    <div v-if="isLoading" class="spinner-overlay" role="status" aria-live="polite">
      <div class="spinner-overlay__content">
        <svg class="spinner-overlay__icon" viewBox="0 0 50 50" aria-hidden="true">
          <circle class="spinner-overlay__track" cx="25" cy="25" r="20" />
          <circle class="spinner-overlay__indicator" cx="25" cy="25" r="20" />
        </svg>
        <p class="spinner-overlay__message">{{ message }}</p>
      </div>
    </div>
  </transition>
</template>

<style scoped>
.spinner-enter-active,
.spinner-leave-active {
  transition: opacity 0.2s ease;
}

.spinner-enter-from,
.spinner-leave-to {
  opacity: 0;
}

.spinner-overlay {
  position: fixed;
  inset: 0;
  display: grid;
  place-items: center;
  background: rgba(20, 20, 20, 0.4);
  z-index: 9999;
}

.spinner-overlay__content {
  display: grid;
  gap: 1rem;
  padding: 2.5rem clamp(1.5rem, 4vw, 3rem);
  border-radius: 1.25rem;
  background: var(--color-background);
  color: var(--color-text);
  box-shadow:
    0 10px 30px rgba(0, 0, 0, 0.12),
    0 6px 16px rgba(0, 0, 0, 0.08);
  min-width: min(22rem, 90vw);
}

.spinner-overlay__icon {
  width: clamp(3rem, 8vw, 4.5rem);
  height: clamp(3rem, 8vw, 4.5rem);
}

.spinner-overlay__track {
  fill: none;
  stroke: color-mix(in srgb, var(--color-border) 35%, transparent);
  stroke-width: 6;
}

.spinner-overlay__indicator {
  fill: none;
  stroke: var(--vt-c-indigo);
  stroke-linecap: round;
  stroke-width: 6;
  stroke-dasharray: 125;
  stroke-dashoffset: 100;
  animation: spin 1.2s linear infinite;
}

.spinner-overlay__message {
  text-align: center;
  font-weight: 600;
  letter-spacing: 0.01em;
}

@keyframes spin {
  from {
    transform: rotate(0deg);
  }
  to {
    transform: rotate(360deg);
  }
}
</style>
