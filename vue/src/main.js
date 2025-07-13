import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { createPinia } from 'pinia'
import { onMounted, onUnmounted } from 'vue'

import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap'
import 'bootstrap/dist/js/bootstrap.bundle.min.js'
import 'bootstrap-icons/font/bootstrap-icons.css'
import './assets/styles/main.css'

const app = createApp(App)
const pinia = createPinia()

app.use(router)
app.use(pinia)

const globalStore = useGlobalStore(pinia)
onMounted(() => {
  if (!globalStore.isInitialized) {
    globalStore.initializeListeners()
  }
})

onUnmounted(() => {
  globalStore.cleanupListeners()
})

app.mount('#app')

import { useGlobalStore } from '@/stores/global'