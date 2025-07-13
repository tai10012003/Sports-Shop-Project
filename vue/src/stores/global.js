import { defineStore } from 'pinia'
import { onMounted, onUnmounted } from 'vue'
import { handleScroll, handleParallax } from '@/assets/js/main'

export const useGlobalStore = defineStore('global', {
  state: () => ({
    isInitialized: false
  }),
  actions: {
    initializeListeners() {
      // Intersection Observer cho animation
      const observer = new IntersectionObserver(
        (entries) => {
          entries.forEach((entry) => {
            if (entry.isIntersecting) {
              entry.target.classList.add('fade-in')
              observer.unobserve(entry.target)
            }
          })
        },
        { threshold: 0.1 }
      )
      document.querySelectorAll('.product-card, .feature-box').forEach((el) => {
        observer.observe(el)
      })

      // Smooth scroll cho các anchor link
      document.querySelectorAll('a[href^="#"]').forEach((anchor) => {
        anchor.addEventListener('click', function (e) {
          const href = this.getAttribute('href')
          if (href !== '#') {
            e.preventDefault()
            const target = document.querySelector(href)
            if (target) {
              target.scrollIntoView({ behavior: 'smooth' })
            }
          }
        })
      })

      // Lắng nghe scroll
      window.addEventListener('scroll', handleScroll)
      window.addEventListener('scroll', handleParallax)

      this.isInitialized = true
    },
    cleanupListeners() {
      window.removeEventListener('scroll', handleScroll)
      window.removeEventListener('scroll', handleParallax)
      this.isInitialized = false
    }
  }
})