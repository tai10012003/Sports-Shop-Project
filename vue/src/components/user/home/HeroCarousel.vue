<script setup>
import { onMounted, onUnmounted } from 'vue'
import slider1 from '@/assets/images/sliders/slider1.jpg'
import slider2 from '@/assets/images/sliders/slider2.jpg'
import slider3 from '@/assets/images/sliders/slider3.jpg'

const handleParallaxEffects = () => {
  const scrolled = window.pageYOffset
  const heroImages = document.querySelectorAll("#heroCarousel .carousel-item img")
  const heroCaptions = document.querySelectorAll("#heroCarousel .carousel-caption")
  heroImages.forEach((img) => {
    if (img.closest('.carousel-item.active')) {
      img.style.transform = `translateY(${scrolled * 0.3}px) scale(1.1)`
    }
  })
  heroCaptions.forEach((caption) => {
    if (caption.closest('.carousel-item.active')) {
      caption.style.transform = "translateY(50%)"
      caption.style.opacity = `${1 - scrolled * 0.002}`
    }
  })
}

onMounted(() => {
  window.addEventListener('scroll', handleParallaxEffects)
})

onUnmounted(() => {
  window.removeEventListener('scroll', handleParallaxEffects)
})
</script>

<template>
  <div id="heroCarousel" class="carousel slide carousel-fade" data-bs-ride="carousel" data-bs-interval="5000">
    <div class="carousel-indicators">
      <button v-for="n in 3" :key="n" type="button" data-bs-target="#heroCarousel" :data-bs-slide-to="n-1" :class="{ active: n === 1 }" aria-label="'Slide ' + n"></button>
    </div>
    <div class="carousel-inner">
      <div class="carousel-item active">
        <img :src="slider1" class="d-block w-100" alt="Sports Equipment">
        <div class="carousel-caption">
          <h1>Thiết Bị Thể Thao Cao Cấp</h1>
          <p class="d-none d-md-block">Nâng tầm đẳng cấp tập luyện của bạn</p>
          <router-link to="/san-pham" class="btn btn-light btn-lg">Khám Phá Ngay</router-link>
        </div>
      </div>
      <div class="carousel-item">
        <img :src="slider2" class="d-block w-100" alt="Training">
        <div class="carousel-caption">
          <h1>Dụng Cụ Tập Luyện</h1>
          <p>Nâng cao hiệu quả tập luyện</p>
        </div>
      </div>
      <div class="carousel-item">
        <img :src="slider3" class="d-block w-100" alt="Accessories">
        <div class="carousel-caption">
          <h1>Phụ Kiện Thể Thao</h1>
          <p>Đa dạng - Chất lượng - Bền bỉ</p>
        </div>
      </div>
    </div>
    <button class="carousel-control-prev" type="button" data-bs-target="#heroCarousel" data-bs-slide="prev">
      <span class="carousel-control-prev-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Previous</span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#heroCarousel" data-bs-slide="next">
      <span class="carousel-control-next-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Next</span>
    </button>
  </div>
</template>

<style scoped>
.carousel-item {
  height: 700px;
  position: relative;
  overflow: hidden;
}
.carousel-item img {
  width: 100%;
  height: 100%;
  object-fit: cover;
  transition: opacity 0.5s ease-in-out;
  object-position: center;
  filter: brightness(0.8);
}
.carousel-item::after {
  content: '';
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: linear-gradient(rgba(0,0,0,0.2), rgba(0,0,0,0.5));
  z-index: 1;
}
.carousel-caption {
  position: absolute;
  bottom: 50%;
  transform: translateY(50%);
  z-index: 2;
  text-align: center;
  width: 100%;
  left: 0;
  right: 0;
  padding: 0 15%;
  transition: opacity 0.5s ease-in-out;
}
.carousel-caption h1 {
  font-size: 4rem;
  font-weight: 800;
  margin-bottom: 1.5rem;
  text-shadow: 2px 4px 8px rgba(0,0,0,0.3);
  animation: fadeInDown 1s ease-out;
}
.carousel-caption p {
  font-size: 1.5rem;
  margin-bottom: 2rem;
  text-shadow: 1px 2px 4px rgba(0,0,0,0.3);
  animation: fadeInUp 1s ease-out;
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