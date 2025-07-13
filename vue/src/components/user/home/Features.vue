<script setup>
const features = [
  { icon: 'bi bi-truck', title: 'Giao Hàng Miễn Phí', desc: 'Cho đơn hàng từ 500.000₫' },
  { icon: 'bi bi-shield-check', title: 'Bảo Hành 12 Tháng', desc: 'Đổi trả trong 30 ngày' },
  { icon: 'bi bi-headset', title: 'Hỗ Trợ 24/7', desc: 'Tư vấn chuyên nghiệp' }
]
</script>

<template>
  <section class="features bg-light">
    <div class="container">
      <div class="row g-4 text-center">
        <div v-for="(feature, index) in features" :key="index" class="col-md-4">
          <i :class="feature.icon + ' display-4 text-primary'"></i>
          <h3 class="mt-3">{{ feature.title }}</h3>
          <p>{{ feature.desc }}</p>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped>
.why-choose-us {
  padding: 10px 0 60px 0;
  background: #f8f9fa;
}

.features {
  background: #f8f9fa;
  padding: 70px 0;
}

.feature-box {
  padding: 2rem;
  border-radius: 20px;
  background: white;
  box-shadow: 0 10px 30px rgba(0,0,0,0.08);
  transition: all 0.3s ease;
}

.feature-icon {
  font-size: 2.8rem;
  background: linear-gradient(120deg, #367cd7, #34a853);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  margin-bottom: 1.5rem;
  display: inline-block;
}

.feature-box:hover {
  transform: translateY(-10px);
  box-shadow: 0 15px 35px rgba(0,0,0,0.12);
}
</style>