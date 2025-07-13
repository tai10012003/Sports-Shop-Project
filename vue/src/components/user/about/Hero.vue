<template>
  <div class="about-hero">
    <div class="container">
      <h1 class="about-title">GIỚI THIỆU SPORT ELITE</h1>
      <p class="about-subtitle">Đồng hành cùng đam mê thể thao của bạn</p>
    </div>
  </div>
</template>

<script setup>
</script>

<style scoped>
.about-hero {
    padding: 120px 0;
    margin-bottom: 0;
  background: linear-gradient(rgba(0,0,0,0.7), rgba(0,0,0,0.7)), url('../../images/about/hero-bg.jpg');
  background-size: cover;
  background-position: center;
  height: 400px;
  display: flex;
  align-items: center;
  text-align: center;
  color: white;
  position: relative;
  z-index: 1;
}

.about-title {
    font-size: 50px;
    margin-bottom: 1.5rem;
    font-weight: 800;
    animation: fadeInDown 1s ease;
    text-shadow: 2px 4px 8px rgba(0, 0, 0, 0.3);
}

.about-subtitle {
    margin-bottom: 0;
    line-height: 1.4;
    font-size: 1.2rem;
    opacity: 0.9;
    animation: fadeInUp 1s ease;
    text-shadow: 1px 2px 4px rgba(0, 0, 0, 0.3);
}

@keyframes fadeInDown {
  from { opacity: 0; transform: translateY(-30px); }
  to { opacity: 1; transform: translateY(0); }
}

@keyframes fadeInUp {
  from { opacity: 0; transform: translateY(30px); }
  to { opacity: 1; transform: translateY(0); }
}
</style>