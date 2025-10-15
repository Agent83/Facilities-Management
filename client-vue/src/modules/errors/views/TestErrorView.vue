<template>
  <section class="view">
    <header class="view__header">
      <div>
        <h1>Error playground</h1>
        <p>Port Angular's <code>TestErrorComponent</code> helpers to test API error handling.</p>
      </div>
    </header>

    <div class="view__placeholder">
      <p>
        Wire up the same service used in the Angular client to intentionally trigger HTTP 400/401/500 responses so that Axios
        interceptors can be verified.
      </p>
    </div>
  </section>
</template>

<style scoped>
@import '../../viewsShared.css';
</style>
