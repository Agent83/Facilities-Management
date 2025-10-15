import { computed, ref } from 'vue'
import { defineStore } from 'pinia'

export const useUiStateStore = defineStore('ui-state', () => {
  const activeTasks = ref<string[]>([])
  const message = ref('Loading…')

  function beginTask(taskId = 'global', taskMessage?: string) {
    if (!activeTasks.value.includes(taskId)) {
      activeTasks.value.push(taskId)
    }

    if (taskMessage) {
      message.value = taskMessage
    }
  }

  function endTask(taskId = 'global') {
    activeTasks.value = activeTasks.value.filter((task) => task !== taskId)

    if (activeTasks.value.length === 0) {
      message.value = 'Loading…'
    }
  }

  const isLoading = computed(() => activeTasks.value.length > 0)

  return { beginTask, endTask, isLoading, message }
})
