<script setup>
const brands = [
  { image: new URL('@/assets/images/brands/nike.png', import.meta.url).href, name: 'Nike' },
  { image: new URL('@/assets/images/brands/adidas.png', import.meta.url).href, name: 'Adidas' },
  { image: new URL('@/assets/images/brands/puma.png', import.meta.url).href, name: 'Puma' },
  { image: new URL('@/assets/images/brands/under-armour.png', import.meta.url).href, name: 'Under Armour' }
]
</script>

<template>
  <section class="brands py-5">
    <div class="container">
      <h2 class="section-title">THƯƠNG HIỆU NỔI TIẾNG</h2>
      <div class="row align-items-center">
        <div v-for="(brand, index) in brands" :key="index" class="col-lg-2 col-md-4 col-6">
          <img :src="brand.image" :alt="brand.name" class="img-fluid brand-logo">
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped>
/* No specific styles for brands section in original code, but keeping scoped for consistency */
.brand-logo {
  max-width: 100%;
  height: auto;
}
</style>