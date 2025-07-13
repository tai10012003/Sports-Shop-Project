<template>
  <section class="about-story">
    <div class="container">
      <div class="row align-items-center">
        <div class="col-lg-6">
          <div class="about-content">
            <h2>CÂU CHUYỆN CỦA CHÚNG TÔI</h2>
            <p class="leads mb-4">Sport Elite - Hành trình 15 năm đồng hành cùng người yêu thể thao Việt Nam</p>
            <p>Được thành lập vào năm 2008, Sport Elite đã không ngừng phát triển và khẳng định vị thế là một trong những đơn vị hàng đầu trong lĩnh vực cung cấp thiết bị thể thao cao cấp tại Việt Nam.</p>
            <p>Chúng tôi tự hào là đối tác chính thức của các thương hiệu thể thao hàng đầu thế giới, mang đến cho khách hàng những sản phẩm chất lượng cao với giá cả hợp lý nhất.</p>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script setup>
</script>

<style scoped>
.about-story {
  padding: 100px 0;
  background: var(--light-color);
}

.about-content {
  padding: 2rem 3rem;
}

.about-content h2 {
  font-size: 35px;
    margin-bottom: 2rem;
  font-weight: 700;
  background: var(--gradient);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
}

.about-content .leads {
  font-size: 1.2rem;
  margin-bottom: 2rem;
  color: #333;
}

.about-content p {
  line-height: 1.8;
  margin-bottom: 1.5rem;
}
</style>