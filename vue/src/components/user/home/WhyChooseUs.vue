<script setup>
const whyChooseUs = [
  { icon: 'bi bi-patch-check-fill', title: 'Sản Phẩm Chính Hãng', desc: '100% sản phẩm được nhập khẩu trực tiếp từ nhà sản xuất với chứng nhận chính hãng' },
  { icon: 'bi bi-currency-dollar', title: 'Giá Cả Hợp Lý', desc: 'Cam kết giá tốt nhất thị trường với nhiều chương trình khuyến mãi hấp dẫn' },
  { icon: 'bi bi-headset', title: 'Hỗ Trợ 24/7', desc: 'Đội ngũ tư vấn chuyên nghiệp, nhiệt tình hỗ trợ khách hàng mọi lúc' },
  { icon: 'bi bi-arrow-repeat', title: 'Chính Sách Đổi Trả', desc: 'Đổi trả miễn phí trong 30 ngày nếu sản phẩm có lỗi từ nhà sản xuất' }
]
</script>

<template>
  <section class="why-choose-us bg-light">
    <div class="container">
      <h3 class="section-title">TẠI SAO CHỌN SPORT ELITE ?</h3>
      <div class="row g-4">
        <div v-for="(item, index) in whyChooseUs" :key="index" class="col-lg-3 col-md-6">
          <div class="feature-box">
            <i :class="item.icon + ' feature-icon'"></i>
            <h5>{{ item.title }}</h5>
            <p>{{ item.desc }}</p>
          </div>
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