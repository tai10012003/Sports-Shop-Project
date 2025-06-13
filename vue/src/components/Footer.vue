<script setup>
const usefulLinks = [
  { path: '/gioi-thieu', text: 'Về chúng tôi' },
  { path: '/chinh-sach-van-chuyen', text: 'Chính sách vận chuyển' },
  { path: '/chinh-sach-doi-tra', text: 'Chính sách đổi trả' },
  { path: '/chinh-sach-bao-hanh', text: 'Chính sách bảo hành' },
  { path: '/chinh-sach-bao-mat', text: 'Chính sách bảo mật' },
  { path: '/dieu-khoan-su-dung', text: 'Điều khoản sử dụng' }
]

const categories = [
  { path: '/danh-muc/1', text: 'Thiết bị tập gym' },
  { path: '/danh-muc/3', text: 'Thể thao đồng đội' },
  { path: '/danh-muc/4', text: 'Phụ kiện thể thao' }
]

const contactInfo = [
  {
    icon: 'bi bi-geo-alt-fill',
    title: 'Địa chỉ',
    text: '123 Nguyễn Văn A, Phường X, Quận Y, TP.HCM'
  },
  {
    icon: 'bi bi-telephone-fill',
    title: 'Hotline',
    text: '0123.456.789 - 0987.654.321'
  },
  {
    icon: 'bi bi-envelope-fill',
    title: 'Email',
    text: 'contact@sportelite.com'
  },
  {
    icon: 'bi bi-clock-fill',
    title: 'Giờ làm việc',
    text: '08:00 - 21:00 (Thứ 2 - Chủ nhật)'
  }
]

const scrollToTop = () => {
  window.scrollTo({
    top: 0,
    behavior: 'smooth'
  })
}
</script>

<template>
  <footer class="footer">
    <div class="footer-top py-5">
      <div class="container">
        <div class="row g-4">
          <div class="col-lg-3 col-md-6">
            <div class="footer-widget">
              <h4 class="widget-title">Về Sport Elite</h4>
              <div class="footer-logo mb-3">
                <span class="gradient-text">Sport</span><strong>Elite</strong>
              </div>
              <p class="mb-4">Chuyên cung cấp các sản phẩm thể thao chính hãng với chất lượng cao nhất. Đảm bảo uy tín và dịch vụ tốt nhất cho khách hàng.</p>
            </div>
          </div>

          <div class="col-lg-3 col-md-6">
            <div class="footer-widget">
              <h4 class="widget-title">Thông Tin Hữu Ích</h4>
              <ul class="footer-links">
                <li v-for="(link, index) in usefulLinks" :key="index">
                  <router-link :to="link.path">
                    <i class="bi bi-chevron-right"></i> {{ link.text }}
                  </router-link>
                </li>
              </ul>
            </div>
          </div>

          <div class="col-lg-3 col-md-6">
            <div class="footer-widget">
              <h4 class="widget-title">Danh Mục Sản Phẩm</h4>
              <ul class="footer-links">
                <li v-for="(category, index) in categories" :key="index">
                  <router-link :to="category.path">
                    <i class="bi bi-chevron-right"></i> {{ category.text }}
                  </router-link>
                </li>
              </ul>
            </div>
          </div>

          <div class="col-lg-3 col-md-6">
            <div class="footer-widget">
              <h4 class="widget-title">Thông Tin Liên Hệ</h4>
              <div class="contact-info">
                <div v-for="(item, index) in contactInfo" :key="index" class="contact-item mb-3">
                  <i :class="item.icon"></i>
                  <div class="contact-text">
                    <h5>{{ item.title }}:</h5>
                    <p>{{ item.text }}</p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="footer-bottom py-3">
      <div class="container">
        <div class="row align-items-center">
          <div class="col-md-12">
            <p class="mb-md-0 text-center">© {{ new Date().getFullYear() }} Sport Elite. All rights reserved.</p>
          </div>
        </div>
      </div>
    </div>
  </footer>

  <button 
    class="btn btn-primary back-to-top" 
    @click="scrollToTop"
    v-show="showBackToTop"
  >
    <i class="bi bi-arrow-up"></i>
  </button>
</template>

<style scoped>
footer {
      background: #202124;
      color: rgba(255,255,255,0.8);
      position: relative;
  }
  
  .footer::before {
      content: '';
      position: absolute;
      top: 0;
      left: 0;
      right: 0;
      bottom: 0;
      background: linear-gradient(45deg, #003780, #34a853);
      opacity: 0.05;
  }
  
  .footer-top {
      position: relative;
      border-bottom: 1px solid rgba(255,255,255,0.1);
  }
  
  .footer-widget {
      position: relative;
      margin-bottom: 30px;
  }
  
  .widget-title {
      font-size: 1.25rem;
      font-weight: 600;
      margin-bottom: 1.5rem;
      position: relative;
      padding-bottom: 0.75rem;
  }
  
  .widget-title::after {
      content: '';
      position: absolute;
      left: 0;
      bottom: 0;
      width: 50px;
      height: 2px;
      background: linear-gradient(120deg, #367cd7, #34a853);
      border-radius: 2px;
  }
  
  .footer-logo {
      font-size: 1.8rem;
      font-weight: 700;
  }
  
  .footer-logo .gradient-text {
      background: linear-gradient(45deg, #fff, rgba(255,255,255,0.8));
      -webkit-background-clip: text;
      -webkit-text-fill-color: transparent;
  }
  
  .footer-logo strong {
      color: white;
  }
  
  .footer-social {
      display: flex;
      gap: 1rem;
      margin-top: 1.5rem;
  }
  
  .social-link {
      width: 36px;
      height: 36px;
      display: flex;
      align-items: center;
      justify-content: center;
      background: rgba(255,255,255,0.1);
      color: white;
      border-radius: 50%;
      transition: all 0.3s ease;
  }
  
  .social-link:hover {
      background: linear-gradient(120deg, #367cd7, #34a853);
      transform: translateY(-3px);
      color: white;
  }
  
  .footer-links {
      list-style: none;
      padding: 0;
      margin: 0;
  }
  
  .footer-links li {
      margin-bottom: 0.75rem;
  }
  
  .footer-links a {
      color: rgba(255,255,255,0.8);
      text-decoration: none;
      transition: all 0.3s ease;
      display: flex;
      align-items: center;
  }
  
  .footer-links a i {
      font-size: 0.8rem;
      margin-right: 0.5rem;
      transition: transform 0.3s ease;
  }
  
  .footer-links a:hover {
      color: white;
      transform: translateX(5px);
  }
  
  .footer-links a:hover i {
      transform: translateX(3px);
      color: #34a853;
  }
  
  .contact-info {
      color: rgba(255,255,255,0.8);
  }
  
  .contact-item {
      display: flex;
      align-items: flex-start;
      margin-bottom: 1.25rem;
  }
  
  .contact-item i {
      font-size: 1.2rem;
      color: #34a853;
      margin-right: 1rem;
      margin-top: 0.25rem;
  }
  
  .contact-text h5 {
      color: white;
      font-size: 1rem;
      margin-bottom: 0.25rem;
  }
  
  .contact-text p {
      margin: 0;
      font-size: 0.9rem;
  }
  
  .footer-bottom {
      background: rgba(0,0,0,0.2);
      position: relative;
  }
  
  .payment-methods img {
      height: 24px;
      margin-left: 0.75rem;
      opacity: 0.8;
      transition: opacity 0.3s ease;
  }
  
  .payment-methods img:hover {
      opacity: 1;
  }
  
  .back-to-top {
      position: fixed;
      right: 30px;
      bottom: 30px;
      width: 44px;
      height: 44px;
      border-radius: 50%;
      background: linear-gradient(120deg, #367cd7, #34a853);
      color: white;
      display: flex;
      align-items: center;
      justify-content: center;
      font-size: 1.2rem;
      cursor: pointer;
      transition: all 0.3s ease;
      opacity: 0;
      visibility: hidden;
      z-index: 99;
  }
  
  .back-to-top.show {
      opacity: 1;
      visibility: visible;
      transform: translateY(0);
  }
  
  .back-to-top:hover {
      transform: translateY(-5px);
      box-shadow: 0 5px 15px rgba(0,0,0,0.3);
  }
</style>
