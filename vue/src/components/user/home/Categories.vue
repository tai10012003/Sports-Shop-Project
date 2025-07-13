<script setup>
const categories = [
  { icon: 'bi bi-bicycle', title: 'Thiết bị tập gym', desc: 'Dụng cụ tập luyện chuyên nghiệp' },
  { icon: 'bi bi-dribbble', title: 'Thể thao đồng đội', desc: 'Bóng đá, bóng rổ, cầu lông' },
  { icon: 'bi bi-smartwatch', title: 'Phụ kiện thể thao', desc: 'Đồng hồ, găng tay, phụ kiện' }
]
</script>

<template>
  <section class="categories bg-light" style="padding: 100px 0 50px 0;">
    <div class="container">
      <h2 class="section-title">DANH MỤC SẢN PHẨM</h2>
      <div class="row g-5">
        <div v-for="(cat, index) in categories" :key="index" class="col-lg-3 col-md-6">
          <div class="category-card text-center p-4 hover-shadow">
            <i :class="cat.icon + ' display-4 text-primary mb-3'"></i>
            <h5>{{ cat.title }}</h5>
            <p>{{ cat.desc }}</p>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped>
.category-card {
  border: 1px solid black;
  border-radius: 20px;
  transition: all 0.3s ease;
  background: white;
  padding: 2rem;
}

.category-card h5 {
  margin: 15px 0;
  color: #003780;
  font-weight: bold;
}
</style>