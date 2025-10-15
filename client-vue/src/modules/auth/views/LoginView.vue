<script setup lang="ts">
import { reactive, computed } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { useAuthStore } from '../../../stores/auth'

const router = useRouter()
const route = useRoute()
const authStore = useAuthStore()

const form = reactive({
  username: '',
  password: '',
})

const canSubmit = computed(() => form.username.trim().length > 0 && form.password.trim().length > 0)

function handleSubmit() {
  authStore.signInMock(form.username, form.password)

  if (!authStore.isAuthenticated) {
    return
  }

  const redirect = typeof route.query.redirect === 'string' ? route.query.redirect : '/premises'
  router.push(redirect)
}
</script>

<template>
  <section class="login-card">
    <header class="login-card__header">
      <h1>Facilities Management</h1>
      <p>Please sign in to access properties and contractor information.</p>
    </header>

    <form class="login-card__form" @submit.prevent="handleSubmit" novalidate autocomplete="off">
      <label class="login-card__field">
        <span>Username</span>
        <input v-model="form.username" name="username" type="text" placeholder="jane.doe" required />
      </label>

      <label class="login-card__field">
        <span>Password</span>
        <input v-model="form.password" name="password" type="password" placeholder="••••••••" required />
      </label>

      <p class="login-card__hint">
        This form currently simulates authentication. Replace <code>authStore.signInMock</code> with a real API call and persist the
        JWT the same way the Angular client does.
      </p>

      <button type="submit" :disabled="!canSubmit">Login</button>
    </form>
  </section>
</template>

<style scoped>
.login-card {
  width: min(32rem, 100%);
  padding: clamp(2rem, 5vw, 3rem);
  border-radius: 1.5rem;
  border: 1px solid var(--color-border);
  background: var(--color-background);
  box-shadow:
    0 25px 45px rgba(0, 0, 0, 0.08),
    0 15px 25px rgba(0, 0, 0, 0.05);
  display: grid;
  gap: 1.75rem;
}

.login-card__header {
  display: grid;
  gap: 0.35rem;
  text-align: center;
}

.login-card__header h1 {
  font-size: clamp(1.75rem, 2.6vw, 2.5rem);
}

.login-card__form {
  display: grid;
  gap: 1rem;
}

.login-card__field {
  display: grid;
  gap: 0.45rem;
}

.login-card__field span {
  font-weight: 600;
}

.login-card__field input {
  border-radius: 0.75rem;
  border: 1px solid var(--color-border);
  padding: 0.75rem 1rem;
  font-size: 1rem;
  background: var(--color-background-soft);
}

.login-card__field input:focus {
  outline: 2px solid color-mix(in srgb, var(--vt-c-indigo) 45%, transparent);
  outline-offset: 1px;
}

.login-card__hint {
  font-size: 0.9rem;
  color: var(--color-text-soft);
}

button[type='submit'] {
  border: none;
  border-radius: 999px;
  background: var(--vt-c-indigo);
  color: white;
  font-weight: 600;
  padding: 0.85rem 1.75rem;
  cursor: pointer;
  transition: filter 0.2s ease;
}

button[type='submit']:hover:not(:disabled) {
  filter: brightness(1.05);
}

button[type='submit']:disabled {
  opacity: 0.6;
  cursor: not-allowed;
}
</style>
