<script setup>
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <nav class="navbar bg-primary" data-bs-theme="dark">
    <div class="container-fluid">
      <a class="navbar-brand" href="#">Beaches To Visit</a>
    </div>
  </nav>
  <div class="container">
    <RouterView />
  </div>
</template>

<style scoped>

</style>
