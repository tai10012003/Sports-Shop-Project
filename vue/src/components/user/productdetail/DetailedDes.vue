<template>
  <div class="detail-description">
    {{ product.moTaChiTiet }}
  </div>
</template>

<script setup>
defineProps({
  product: Object
})
</script>

<style scoped>
.detail-description {
    color: #444;
    line-height: 1.8;
    font-size: 1rem;
}

.detail-description h5 {
    color: var(--dark-color);
    font-size: 1.2rem;
    font-weight: 600;
    margin: 1.5rem 0 1rem;
    padding-bottom: 0.5rem;
    border-bottom: 2px solid var(--light-color);
}
</style>