<template>
  <div class="about-page">
    <!-- Hero Section -->
    <div class="about-hero">
      <div class="container">
        <h1 class="about-title">GIỚI THIỆU SPORT ELITE</h1>
        <p class="about-subtitle">Đồng hành cùng đam mê thể thao của bạn</p>
      </div>
    </div>

    <!-- Story Section -->
    <section class="about-story">
      <div class="container">
        <div class="row align-items-center">
          <div class="col-lg-6">
            <div class="about-content">
              <h2>CÂU CHUYỆN CỦA CHÚNG TÔI</h2>
              <p class="lead mb-4">Sport Elite - Hành trình 15 năm đồng hành cùng người yêu thể thao Việt Nam</p>
              <p>Được thành lập vào năm 2008, Sport Elite đã không ngừng phát triển và khẳng định vị thế là một trong những đơn vị hàng đầu trong lĩnh vực cung cấp thiết bị thể thao cao cấp tại Việt Nam.</p>
              <p>Chúng tôi tự hào là đối tác chính thức của các thương hiệu thể thao hàng đầu thế giới, mang đến cho khách hàng những sản phẩm chất lượng cao với giá cả hợp lý nhất.</p>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- Mission Section -->
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

    <!-- Values Section -->
    <section class="about-values">
      <div class="container">
        <h2 class="section-title mb-5">GIÁ TRỊ CỐT LÕI</h2>
        <div class="row g-4">
          <div class="col-md-4" v-for="(value, index) in values" :key="index">
            <div class="value-card">
              <div class="value-icon">
                <i :class="value.icon"></i>
              </div>
              <h3>{{ value.title }}</h3>
              <p>{{ value.description }}</p>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- Counter Section -->
    <section class="stats-counter">
      <div class="container">
        <div class="row g-4">
          <div class="col-md-3 col-6" v-for="(stat, index) in stats" :key="index">
            <div class="counter-box">
              <div class="counter-number">{{ stat.number }}</div>
              <div class="counter-label">{{ stat.label }}</div>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- CTA Section -->
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
  </div>
</template>

<script>
export default {
  name: 'AboutView',
  data() {
    return {
      missions: [
        {
          icon: 'bi bi-bullseye',
          title: 'Tầm Nhìn',
          description: 'Trở thành thương hiệu số 1 về thiết bị thể thao cao cấp tại Việt Nam.'
        },
        {
          icon: 'bi bi-flag',
          title: 'Sứ Mệnh',
          description: 'Nâng cao chất lượng cuộc sống của cộng đồng thông qua thể thao.'
        },
        {
          icon: 'bi bi-heart',
          title: 'Giá Trị Cốt Lõi',
          description: 'Chất lượng - Uy tín - Tận tâm - Sáng tạo.'
        }
      ],
      values: [
        {
          icon: 'bi bi-heart-fill',
          title: 'Tận Tâm',
          description: 'Luôn đặt khách hàng làm trọng tâm trong mọi hoạt động'
        },
        {
          icon: 'bi bi-shield-check',
          title: 'Uy Tín',
          description: 'Cam kết chất lượng và độ tin cậy trong từng sản phẩm'
        },
        {
          icon: 'bi bi-lightning-charge',
          title: 'Năng Động',
          description: 'Không ngừng đổi mới để mang lại trải nghiệm tốt nhất'
        }
      ],
      stats: [
        { number: '5000+', label: 'Khách hàng hài lòng' },
        { number: '1000+', label: 'Sản phẩm đa dạng' },
        { number: '15+', label: 'Năm kinh nghiệm' },
        { number: '50+', label: 'Thương hiệu hợp tác' }
      ]
    }
  }
}
</script>

<style scoped>
.about-hero {
      background: linear-gradient(rgba(0,0,0,0.7), rgba(0,0,0,0.7)), url('../images/about/hero-bg.jpg');
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
      font-size: 3.5rem;
      font-weight: 800;
      margin-bottom: 1rem;
      animation: fadeInDown 1s ease;
      text-shadow: 2px 4px 8px rgba(0,0,0,0.3);
  }
  
  .about-subtitle {
      font-size: 1.2rem;
      opacity: 0.9;
      animation: fadeInUp 1s ease;
      text-shadow: 1px 2px 4px rgba(0,0,0,0.3);
  }
  
  .about-story {
      padding: 100px 0;
      background: var(--light-color);
  }
  
  .about-image {
      position: relative;
      border-radius: 20px;
      overflow: hidden;
      box-shadow: 0 20px 40px rgba(0,0,0,0.1);
  }
  
  .about-image img {
      transition: transform 0.5s ease;
  }
  
  .about-image:hover img {
      transform: scale(1.05);
  }
  
  .about-content {
      padding: 2rem;
  }
  
  .about-content h2 {
      font-size: 2.5rem;
      font-weight: 700;
      margin-bottom: 1.5rem;
      background: var(--gradient);
      -webkit-background-clip: text;
      -webkit-text-fill-color: transparent;
  }
  
  .about-features {
      list-style: none;
      padding: 0;
      margin-top: 2rem;
  }
  
  .about-features li {
      margin-bottom: 1rem;
      font-size: 1.1rem;
      display: flex;
      align-items: center;
  }
  
  .about-features i {
      color: var(--primary-color);
      margin-right: 1rem;
      font-size: 1.2rem;
  }
  
/* Stats Counter */
.stats-counter {
  padding: 4rem 0;
  background: linear-gradient(120deg, #367cd7, #34a853);
  position: relative;
  overflow: hidden;
}

.counter-box {
  text-align: center;
  position: relative;
  padding: 2rem;
  background: rgba(255,255,255,0.1);
  border-radius: 15px;
  backdrop-filter: blur(5px);
  transition: transform 0.3s ease;
}

.counter-number {
  font-size: 3rem;
  font-weight: 800;
  margin-bottom: 1rem;
  background: linear-gradient(to right, #fff, rgba(255,255,255,0.8));
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
}

.counter-label {
  color: white;
  font-size: 1.1rem;
  font-weight: 500;
  opacity: 0.9;
}
  .about-stats {
      padding: 80px 0;
      background: var(--gradient);
      color: white;
      position: relative;
      overflow: hidden;
  }
  
  .stat-card {
      text-align: center;
      padding: 2rem;
      background: rgba(255,255,255,0.1);
      border-radius: 15px;
      backdrop-filter: blur(10px);
      transition: transform 0.3s ease;
  }
  
  .stat-card:hover {
      transform: translateY(-5px);
  }
  
  .stat-number {
      font-size: 3rem;
      font-weight: 800;
      margin-bottom: 0.5rem;
      background: linear-gradient(to right, #fff, rgba(255,255,255,0.8));
      -webkit-background-clip: text;
      -webkit-text-fill-color: transparent;
  }
  .experience-badge {
      position: absolute;
      bottom: -25px;
      right: 30px;
      background: var(--gradient);
      color: white;
      padding: 20px;
      border-radius: 15px;
      text-align: center;
      box-shadow: 0 10px 30px rgba(0,0,0,0.1);
  }
  
  .experience-badge .number {
      display: block;
      font-size: 2.5rem;
      font-weight: 800;
      line-height: 1;
  }
  
  .experience-badge .text {
      font-size: 0.9rem;
      opacity: 0.9;
  }
  
  .achievement-grid {
      display: grid;
      grid-template-columns: repeat(3, 1fr);
      gap: 20px;
      margin-top: 30px;
  }
  
  .achievement-item {
      text-align: center;
      padding: 20px;
      background: var(--light-color);
      border-radius: 15px;
      transition: all 0.3s ease;
  }
  
  .achievement-item:hover {
      transform: translateY(-5px);
      box-shadow: 0 10px 20px rgba(0,0,0,0.1);
  }
  
  .achievement-item i {
      font-size: 2rem;
      color: var(--primary-color);
      margin-bottom: 10px;
  }
  
  .achievement-item h4 {
      font-size: 1.5rem;
      font-weight: 700;
      margin-bottom: 5px;
  }
  
  .mission-card {
      text-align: center;
      background: white;
      padding: 40px 30px;
      border-radius: 20px;
      transition: all 0.3s ease;
      height: 100%;
  }
  
  .mission-card:hover {
      transform: translateY(-10px);
      box-shadow: 0 20px 40px rgba(0,0,0,0.1);
  }
  
  .mission-card .icon-box {
      width: 80px;
      height: 80px;
      margin: 0 auto 20px;
      background: var(--gradient);
      border-radius: 50%;
      display: flex;
      align-items: center;
      justify-content: center;
      font-size: 2rem;
      color: white;
  }
  
  .service-card {
      border-radius: 20px;
      overflow: hidden;
      box-shadow: 0 10px 30px rgba(0,0,0,0.1);
      transition: all 0.3s ease;
      height: 100%;
  }
  
  .service-card:hover {
      transform: translateY(-10px);
      box-shadow: 0 20px 40px rgba(0,0,0,0.15);
  }
  
  .service-card img {
      width: 100%;
      height: 250px;
      object-fit: cover;
  }
  
  .service-content {
      padding: 30px;
      background: white;
  }
  
  .about-cta {
      padding: 100px 0;
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
      background: url('../images/about/pattern.png');
      opacity: 0.1;
  }
  
  /* About Page Refined Styles */
  .about-hero {
      padding: 120px 0;
      height: 400px;
      display: flex;
      align-items: center;
      margin-bottom: 0;
  }
  
  .about-title {
      font-size: 50px;
      margin-bottom: 1.5rem;
  }
  
  .about-subtitle {
      margin-bottom: 0;
      line-height: 1.4;
  }
  
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
  }
  
  .about-content .lead {
      font-size: 1.2rem;
      margin-bottom: 2rem;
      color: #444;
  }
  
  .about-content p {
      line-height: 1.8;
      color: #666;
      margin-bottom: 1.5rem;
  }
  
  .achievement-grid {
      gap: 30px;
      margin-top: 50px;
  }
  
  .achievement-item {
      padding: 30px;
      background: white;
      box-shadow: 0 15px 30px rgba(0,0,0,0.08);
  }
  
  .achievement-item i {
      font-size: 2.5rem;
      margin-bottom: 1rem;
  }
  
  .achievement-item h4 {
      font-size: 2rem;
      margin-bottom: 1rem;
  }
  
  .about-mission {
    padding-bottom: 50px;
  }
  
  .mission-card {
      padding: 50px 30px;
      margin-bottom: 30px;
  }
  
  .mission-card .icon-box {
      width: 100px;
      height: 100px;
      margin-bottom: 30px;
  }
  
  .mission-card h3 {
      font-size: 27px;
      margin-bottom: 1.5rem;
  }
  
  .mission-card p {
      line-height: 1.7;
      color: #666;
  }
  
  .about-values {
      padding: 100px 0;
      background: white;
  }
  
  .value-card {
      padding: 40px 30px;
      height: 100%;
  }
  
  .value-icon {
      width: 90px;
      height: 90px;
      margin-bottom: 2rem;
  }
  
  .about-services {
      padding: 100px 0;
      background: var(--light-color);
  }
  
  .service-card {
      height: 100%;
      background: white;
  }
  
  .service-card img {
      height: 300px;
  }
  
  .service-content {
      padding: 2rem;
  }
  
  .service-content h4 {
      font-size: 1.5rem;
      margin-bottom: 1rem;
      color: var(--primary-color);
  }
  
  .service-content p {
      margin-bottom: 1.5rem;
      line-height: 1.7;
  }
  
  .about-team {
      padding: 120px 0;
  }
  
  .team-card img {
      height: 400px;
  }
  
  .team-info {
      padding: 2rem;
  }
  
  .team-info h4 {
      font-size: 1.5rem;
      margin-bottom: 0.5rem;
  }
  
  .about-stats {
      padding: 100px 0;
  }
  
  .stat-card {
      padding: 3rem 2rem;
  }
  
  .stat-number {
      font-size: 3.5rem;
      margin-bottom: 1rem;
  }
  
  .stat-label {
      font-size: 1.2rem;
  }
  
  .about-partners {
      padding: 100px 0;
      background: white;
  }
  
  .partner-logos img {
      max-height: 60px;
      width: auto;
      filter: grayscale(100%);
      transition: all 0.3s ease;
      opacity: 0.7;
  }
  
  .partner-logos img:hover {
      filter: grayscale(0);
      opacity: 1;
  }
  
  .about-cta {
      padding: 120px 0;
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
  .about-team {
      padding: 20px 0 100px;
      background: var(--light-color);
      position: relative;
      overflow: hidden;
  }
  
  .team-card {
      position: relative;
      border-radius: 20px;
      overflow: hidden;
      background: white;
      box-shadow: 0 15px 35px rgba(0,0,0,0.1);
      transition: all 0.4s cubic-bezier(0.4, 0, 0.2, 1);
      height: 400px;
  }
  
  .team-card:hover {
      transform: translateY(-10px) scale(1.02);
      box-shadow: 0 20px 40px rgba(0,0,0,0.2);
  }
  
  .team-card img {
      width: 100%;
      height: 100%;
      object-fit: cover;
      transition: transform 0.5s ease;
  }
  
  .team-card:hover img {
      transform: scale(1.1);
  }
  
  .team-info {
      position: absolute;
      bottom: 0;
      left: 0;
      right: 0;
      padding: 2rem;
      background: linear-gradient(
          transparent,
          rgba(0,0,0,0.8) 40%,
          rgba(0,0,0,0.95)
      );
      color: white;
      transform: translateY(100px);
      transition: all 0.4s cubic-bezier(0.4, 0, 0.2, 1);
  }
  
  .team-card:hover .team-info {
      transform: translateY(0);
  }
  
  .team-info h4 {
      font-size: 1.5rem;
      font-weight: 700;
      margin-bottom: 0.5rem;
      color: white;
      opacity: 0;
      transform: translateY(20px);
      transition: all 0.4s ease 0.1s;
  }
  
  .team-info p {
      color: rgba(255,255,255,0.9);
      font-size: 1rem;
      margin: 0;
      opacity: 0;
      transform: translateY(20px);
      transition: all 0.4s ease 0.2s;
  }
  
  .team-card:hover .team-info h4,
  .team-card:hover .team-info p {
      opacity: 1;
      transform: translateY(0);
  }
  
  .team-social {
      margin-top: 1rem;
      display: flex;
      gap: 1rem;
      opacity: 0;
      transform: translateY(20px);
      transition: all 0.4s ease 0.3s;
  }
  
  .team-card:hover .team-social {
      opacity: 1;
      transform: translateY(0);
  }
  
  .team-social a {
      width: 35px;
      height: 35px;
      border-radius: 50%;
      background: rgba(255,255,255,0.2);
      display: flex;
      align-items: center;
      justify-content: center;
      color: white;
      font-size: 1rem;
      transition: all 0.3s ease;
  }
  
  .team-social a:hover {    
      background: var(--primary-color);
      transform: translateY(-3px);
  }
</style>