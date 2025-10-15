<script setup lang="ts">
import { computed } from 'vue'
import { RouterLink, useRoute, useRouter } from 'vue-router'
import { storeToRefs } from 'pinia'
import { useAuthStore } from '../../stores/auth'

const authStore = useAuthStore()
const router = useRouter()
const route = useRoute()

const { isAuthenticated, isAdmin, displayName } = storeToRefs(authStore)

const isOnLogin = computed(() => route.name === 'login')
const brandTarget = computed(() => (isAuthenticated.value ? { name: 'premise-list' } : { name: 'login' }))

function handleLogout() {
  authStore.signOut()
  router.push({ name: 'login' })
}
</script>

<template>
  <nav class="primary-nav" aria-label="Primary navigation">
    <div class="primary-nav__brand">
      <RouterLink :to="brandTarget" class="primary-nav__logo">
        Facilities Management
      </RouterLink>
      <p class="primary-nav__tagline">Vue client parity with the Angular SPA</p>
    </div>

    <div class="primary-nav__links" role="menubar">
      <RouterLink v-if="isAuthenticated" :to="{ name: 'premise-list' }" role="menuitem">Properties</RouterLink>
      <RouterLink v-if="isAuthenticated" :to="{ name: 'contractor-list' }" role="menuitem">Contractors</RouterLink>
      <RouterLink v-if="isAdmin" :to="{ name: 'admin' }" role="menuitem">Admin</RouterLink>
      <RouterLink
        v-if="!isAuthenticated"
        :class="['primary-nav__cta', { 'primary-nav__cta--active': isOnLogin }]"
        :to="{ name: 'login' }"
      >
        Login
      </RouterLink>
    </div>

    <div class="primary-nav__actions">
      <div v-if="isAuthenticated" class="user-menu">
        <span class="user-menu__greeting">Welcome {{ displayName }}</span>
        <button type="button" class="user-menu__logout" @click="handleLogout">Logout</button>
      </div>
    </div>
  </nav>
</template>

<style scoped>
.primary-nav {
  display: grid;
  grid-template-columns: minmax(0, 1fr) auto auto;
  align-items: center;
  gap: clamp(1rem, 4vw, 2.5rem);
  padding: clamp(1rem, 3vw, 1.75rem) clamp(1.5rem, 5vw, 3rem);
}

.primary-nav__brand {
  display: grid;
  gap: 0.25rem;
}

.primary-nav__logo {
  font-size: clamp(1.25rem, 2vw, 1.75rem);
  font-weight: 700;
  text-decoration: none;
  color: inherit;
}

.primary-nav__tagline {
  font-size: 0.9rem;
  color: var(--color-text-soft);
  margin: 0;
}

.primary-nav__links {
  display: flex;
  align-items: center;
  gap: clamp(0.5rem, 1.5vw, 1.25rem);
  flex-wrap: wrap;
}

.primary-nav__links a {
  text-decoration: none;
  color: inherit;
  padding: 0.45rem 0.95rem;
  border-radius: 999px;
  border: 1px solid transparent;
  transition:
    background-color 0.2s ease,
    border-color 0.2s ease,
    color 0.2s ease;
}

.primary-nav__links a.router-link-active {
  background: var(--color-background-mute);
  border-color: var(--color-border);
}

.primary-nav__links a:hover {
  border-color: var(--color-border);
}

.primary-nav__cta {
  border-color: var(--color-border);
  font-weight: 600;
}

.primary-nav__cta--active {
  background: var(--color-background-mute);
}

.primary-nav__actions {
  display: flex;
  justify-content: flex-end;
}

.user-menu {
  display: flex;
  gap: 0.75rem;
  align-items: center;
  padding: 0.35rem 0.75rem;
  border-radius: 999px;
  background: var(--color-background-mute);
  border: 1px solid var(--color-border);
}

.user-menu__greeting {
  font-weight: 600;
}

.user-menu__logout {
  border: none;
  background: var(--vt-c-indigo);
  color: white;
  font-weight: 600;
  padding: 0.35rem 0.95rem;
  border-radius: 999px;
  cursor: pointer;
  transition: filter 0.2s ease;
}

.user-menu__logout:hover {
  filter: brightness(0.95);
}

@media (max-width: 900px) {
  .primary-nav {
    grid-template-columns: 1fr;
  }

  .primary-nav__brand {
    order: -1;
  }

  .primary-nav__actions {
    justify-content: flex-start;
  }
}
</style>
