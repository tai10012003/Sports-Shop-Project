<script setup>
import { computed, watchEffect } from 'vue'
import { useRoute } from 'vue-router'
import Header from './components/Header.vue'
import Footer from './components/Footer.vue'
import LoadingSpinner from './components/LoadingSpinner.vue'

const route = useRoute()
const isAuthPage = computed(() => ['/dang-nhap', '/dang-ky'].includes(route.path))
watchEffect(() => {
  if (isAuthPage.value) {
    document.body.classList.add('no-header')
  } else {
    document.body.classList.remove('no-header')
  }
})
</script>

<template>
  <LoadingSpinner />
  <Header v-if="!isAuthPage" />
  <router-view />
  <Footer v-if="!isAuthPage" />
</template>

<style>
/* Component-specific styles only */
</style>
