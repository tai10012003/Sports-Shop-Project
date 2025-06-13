import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

// Import Bootstrap and its styles
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap-icons/font/bootstrap-icons.css'

// Import global styles
import './assets/styles/main.css'

const app = createApp(App)
app.use(router)
app.mount('#app')
