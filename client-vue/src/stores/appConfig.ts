import { computed, ref } from 'vue'
import { defineStore } from 'pinia'

export const useAppConfigStore = defineStore('app-config', () => {
  const apiBaseUrl = ref('/api')
  const isSecureConnection = computed(() => apiBaseUrl.value.startsWith('https://'))

  function setApiBaseUrl(url: string) {
    apiBaseUrl.value = url
  }

  return { apiBaseUrl, isSecureConnection, setApiBaseUrl }
})
