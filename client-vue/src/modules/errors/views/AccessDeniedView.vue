<template>
  <section class="view">
    <header class="view__header">
      <div>
        <h1>Access denied</h1>
        <p>This route requires admin privileges.</p>
      </div>
    </header>

    <div class="view__placeholder">
      <p>
        Redirect authenticated users without the <code>Admin</code> role back to an appropriate page after showing this message.
      </p>
    </div>
  </section>
</template>

<style scoped>
@import '../../viewsShared.css';
</style>
