<template>
  <section class="about-mission bg-light">
    <div class="container">
      <div class="row g-4">
        <div class="col-md-4" v-for="(mission, index) in missions" :key="index">
          <div class="mission-card">
            <div class="icon-box">
              <i :class="mission.icon"></i>
            </div>
            <h3>{{ mission.title }}</h3>
            <p>{{ mission.description }}</p>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script setup>
defineProps({
  missions: {
    type: Array,
    required: true
  }
})
</script>

<style scoped>
.about-mission {
  padding-bottom: 50px;
}

.mission-card {
  text-align: center;
  background: white;
  padding: 50px 30px;
  border-radius: 20px;
  transition: all 0.3s ease;
  height: 100%;
}

.mission-card:hover {
  transform: translateY(-10px);
}

.icon-box {
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

.mission-card:hover .icon-box {
  transform: scale(1.15) rotate(5deg);
}

.mission-card h3 {
  font-size: 1.5rem;
  font-weight: 700;
  color: #2c3e50;
  margin-bottom: 15px;
  transition: color 0.3s ease;
}

.mission-card:hover h3 {
  color: #367cd7;
}

.mission-card p {
  line-height: 1.7;
  color: #666;
}
</style>