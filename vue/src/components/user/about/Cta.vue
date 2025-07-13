<template>
  <section class="about-cta bg-primary text-white">
    <div class="container text-center">
      <h2 class="mb-4">Bắt đầu hành trình của bạn cùng Sport Elite</h2>
      <p class="lead mb-4">Hãy để chúng tôi đồng hành cùng bạn trên con đường chinh phục mục tiêu tập luyện</p>
      <div class="cta-buttons">
        <router-link to="/contact" class="btn btn-light btn-lg me-3">
          Liên hệ ngay
        </router-link>
        <router-link to="/products" class="btn btn-outline-light btn-lg">
          Xem sản phẩm
        </router-link>
      </div>
    </div>
  </section>
</template>

<script setup>
</script>

<style scoped>
.about-cta {
  padding: 120px 0;
  background: var(--gradient);
  position: relative;
  overflow: hidden;
}

.about-cta::before {
  content: '';
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: url('../../images/about/pattern.png');
  opacity: 0.1;
}

.about-cta h2 {
  font-size: 30px;
  margin-bottom: 2rem;
}

.about-cta .lead {
  margin-bottom: 3rem;
  opacity: 0.9;
}

.cta-buttons .btn {
  padding: 15px 25px;
}
</style>