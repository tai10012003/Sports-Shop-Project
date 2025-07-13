<script setup>
const statistics = [
  { number: '5000+', label: 'Khách hàng hài lòng' },
  { number: '1000+', label: 'Sản phẩm đa dạng' },
  { number: '15+', label: 'Năm kinh nghiệm' },
  { number: '50+', label: 'Thương hiệu hợp tác' }
]
</script>

<template>
  <section class="stats-counter py-5">
    <div class="container">
      <div class="row g-4">
        <div v-for="(stat, index) in statistics" :key="index" class="col-md-3 col-6">
          <div class="counter-box text-center">
            <div class="counter-number">{{ stat.number }}</div>
            <div class="counter-label">{{ stat.label }}</div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped>
.stats-counter {
  padding: 4rem 0;
  background: linear-gradient(120deg, #367cd7, #34a853);
  position: relative;
  overflow: hidden;
}

.counter-box {
  text-align: center;
  position: relative;
  padding: 2rem;
  background: rgba(255,255,255,0.1);
  border-radius: 15px;
  backdrop-filter: blur(5px);
  transition: transform 0.3s ease;
}

.counter-number {
  font-size: 3rem;
  font-weight: 800;
  margin-bottom: 1rem;
  background: linear-gradient(to right, #fff, rgba(255,255,255,0.8));
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
}

.counter-label {
  color: white;
  font-size: 1.1rem;
  font-weight: 500;
  opacity: 0.9;
}
</style>