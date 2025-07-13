<template>
  <section class="about-values">
    <div class="container">
      <h2 class="section-title mb-5">GIÁ TRỊ CỐT LÕI</h2>
      <div class="row g-5">
        <div class="col-md-4" v-for="(value, index) in values" :key="index">
          <div class="value-card">
            <div class="value-icon">
              <i :class="value.icon" aria-hidden="true"></i>
            </div>
            <h3 class="value-title">{{ value.title }}</h3>
            <p class="value-description">{{ value.description }}</p>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script setup>
defineProps({
  values: {
    type: Array,
    required: true
  }
})
</script>

<style scoped>
.about-values {
  padding: 80px 0;
}

.value-card {
  padding: 40px 25px;
  background: #ffffff;
  border-radius: 20px;
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.06);
  text-align: center;
  transition: all 0.4s ease;
  height: 100%;
  overflow: hidden;
}
.value-card:hover {
  transform: translateY(-10px);
}

.value-icon {
  width: 70px;
  height: 70px;
  margin: 0 auto 30px;
  background: linear-gradient(135deg, #367cd7, #34a853);
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  color: #ffffff;
  font-size: 2rem;
  transition: transform 0.4s ease, box-shadow 0.4s ease;
}

.value-card:hover .value-icon {
  transform: scale(1.15) rotate(5deg);
}

.value-title {
  font-size: 1.5rem;
  font-weight: 700;
  color: #2c3e50;
  margin-bottom: 15px;
  transition: color 0.3s ease;
}

.value-card:hover .value-title {
  color: #367cd7;
}

.value-description {
  line-height: 1.7;
  color: #666;
}
</style>