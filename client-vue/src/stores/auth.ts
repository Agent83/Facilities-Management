import { computed, ref } from 'vue'
import { defineStore } from 'pinia'

type Role = 'Admin' | 'User'

export interface UserProfile {
  userName: string
  roles: Role[]
}

function toTitleCase(value: string) {
  return value.replace(/\w\S*/g, (word) => word.charAt(0).toUpperCase() + word.slice(1).toLowerCase())
}

export const useAuthStore = defineStore('auth', () => {
  const user = ref<UserProfile | null>(null)

  const isAuthenticated = computed(() => user.value !== null)
  const isAdmin = computed(() => user.value?.roles.includes('Admin') ?? false)
  const displayName = computed(() => (user.value ? toTitleCase(user.value.userName) : ''))

  function setUser(profile: UserProfile | null) {
    user.value = profile
  }

  function signOut() {
    user.value = null
  }

  function signInMock(username: string, password: string) {
    const trimmedName = username.trim()

    if (!trimmedName || !password.trim()) {
      return
    }

    const inferredRoles: Role[] = trimmedName.toLowerCase().includes('admin') ? ['Admin'] : ['User']

    user.value = {
      userName: trimmedName,
      roles: inferredRoles,
    }
  }

  return { user, isAuthenticated, isAdmin, displayName, setUser, signInMock, signOut }
})
