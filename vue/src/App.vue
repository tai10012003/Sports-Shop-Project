<script setup>
import Header from './components/Header.vue'
import Footer from './components/Footer.vue'
import LoadingSpinner from './components/LoadingSpinner.vue'
</script>

<template>
  <LoadingSpinner />
  <Header />
  <router-view></router-view>
  <Footer />
</template>

<style>
/* Component-specific styles only */
</style>
