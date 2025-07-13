import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import About from '@/views/About.vue'
import Product from '@/views/Product.vue'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/gioi-thieu',
    name: 'About',
    component: About
  },
  {
    path: '/san-pham',
    name: 'Product',
    component: Product
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
