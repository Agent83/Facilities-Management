<template>
  <section class="view">
    <header class="view__header">
      <div>
        <h1>Admin panel</h1>
        <p>Port the administrative dashboard guarded by <code>AdminGuard</code> in Angular.</p>
      </div>
    </header>

    <div class="view__placeholder">
      <p>
        Restrict this page using the <code>requiresAdmin</code> meta flag in the router and by checking roles provided by the Vue
        auth store.
      </p>
      <p>
        Recreate the management tables and controls found in <code>client/src/app/admin/admin-panel</code>.
      </p>
    </div>
  </section>
</template>

<style scoped>
@import '../../viewsShared.css';
</style>
