import { createRouter, createWebHistory, type NavigationGuardNext, type RouteLocationNormalized, type RouteRecordRaw } from 'vue-router'
import { useAuthStore } from '../stores/auth'
import { useUiStateStore } from '../stores/uiState'

const navigationTaskId = 'navigation'

const routes: RouteRecordRaw[] = [
  {
    path: '/',
    alias: ['/login'],
    name: 'login',
    component: () => import('../modules/auth/views/LoginView.vue'),
    meta: { title: 'Login', layout: 'public' },
  },
  {
    path: '/members',
    name: 'members',
    component: () => import('../modules/members/views/MemberListView.vue'),
    meta: { title: 'Members', requiresAuth: true },
  },
  {
    path: '/members/:userName',
    name: 'member-detail',
    component: () => import('../modules/members/views/MemberDetailView.vue'),
    meta: { title: 'Member details', requiresAuth: true },
  },
  {
    path: '/lists',
    name: 'lists',
    component: () => import('../modules/lists/views/SavedListsView.vue'),
    meta: { title: 'Lists', requiresAuth: true },
  },
  {
    path: '/notes',
    name: 'notes',
    component: () => import('../modules/notes/views/NotesView.vue'),
    meta: { title: 'Notes', requiresAuth: true },
  },
  {
    path: '/create-premise',
    name: 'premise-create',
    component: () => import('../modules/premises/views/PremiseCreateView.vue'),
    meta: { title: 'Create premise', requiresAuth: true },
  },
  {
    path: '/premises',
    name: 'premise-list',
    component: () => import('../modules/premises/views/PremiseListView.vue'),
    meta: { title: 'Premises', requiresAuth: true },
  },
  {
    path: '/premises/:id',
    name: 'premise-detail',
    component: () => import('../modules/premises/views/PremiseDetailView.vue'),
    meta: { title: 'Premise details', requiresAuth: true },
  },
  {
    path: '/premises/edit/:id',
    name: 'premise-edit',
    component: () => import('../modules/premises/views/PremiseEditView.vue'),
    meta: { title: 'Edit premise', requiresAuth: true },
  },
  {
    path: '/create-contractor',
    name: 'contractor-create',
    component: () => import('../modules/contractors/views/ContractorCreateView.vue'),
    meta: { title: 'Create contractor', requiresAuth: true },
  },
  {
    path: '/lists-contractor',
    name: 'contractor-list',
    component: () => import('../modules/contractors/views/ContractorListView.vue'),
    meta: { title: 'Contractors', requiresAuth: true },
  },
  {
    path: '/contractor/:id',
    name: 'contractor-detail',
    component: () => import('../modules/contractors/views/ContractorDetailView.vue'),
    meta: { title: 'Contractor details', requiresAuth: true },
  },
  {
    path: '/contractor/edit/:id',
    name: 'contractor-edit',
    component: () => import('../modules/contractors/views/ContractorEditView.vue'),
    meta: { title: 'Edit contractor', requiresAuth: true },
  },
  {
    path: '/admin',
    name: 'admin',
    component: () => import('../modules/admin/views/AdminPanelView.vue'),
    meta: { title: 'Admin', requiresAuth: true, requiresAdmin: true },
  },
  {
    path: '/errors',
    name: 'test-error',
    component: () => import('../modules/errors/views/TestErrorView.vue'),
    meta: { title: 'Error playground', layout: 'public' },
  },
  {
    path: '/server-error',
    name: 'server-error',
    component: () => import('../modules/errors/views/ServerErrorView.vue'),
    meta: { title: 'Server error', layout: 'public' },
  },
  {
    path: '/not-found',
    name: 'not-found',
    component: () => import('../modules/errors/views/NotFoundView.vue'),
    meta: { title: 'Not found', layout: 'public' },
  },
  {
    path: '/access-denied',
    name: 'access-denied',
    component: () => import('../modules/errors/views/AccessDeniedView.vue'),
    meta: { title: 'Access denied', layout: 'public' },
  },
  {
    path: '/:pathMatch(.*)*',
    redirect: { name: 'not-found' },
  },
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
})

router.beforeEach((to, _from, next) => {
  const uiState = useUiStateStore()
  uiState.beginTask(navigationTaskId, 'Loading view…')

  guardRoute(to, next)
})

router.afterEach((to) => {
  const uiState = useUiStateStore()
  uiState.endTask(navigationTaskId)

  if (to.meta?.title) {
    document.title = `${to.meta.title} · Facilities Management`
  }
})

router.onError(() => {
  const uiState = useUiStateStore()
  uiState.endTask(navigationTaskId)
})

function guardRoute(to: RouteLocationNormalized, next: NavigationGuardNext) {
  const authStore = useAuthStore()
  const isAuthenticated = authStore.isAuthenticated
  const isAdmin = authStore.isAdmin

  if (to.meta?.requiresAuth && !isAuthenticated) {
    next({ name: 'login', query: { redirect: to.fullPath } })
    return
  }

  if (to.meta?.requiresAdmin && !isAdmin) {
    next({ name: 'access-denied' })
    return
  }

  if (to.name === 'login' && isAuthenticated) {
    next({ name: 'premise-list' })
    return
  }

  next()
}

export default router
