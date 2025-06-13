<script setup>
import { ref, onMounted, onUnmounted } from 'vue'
import { addToCart, handleScroll, handleParallax } from '@/assets/js/main'
import ProductService from '@/services/ProductService'
// Import slider images
import slider1 from '@/assets/images/sliders/slider1.jpg'
import slider2 from '@/assets/images/sliders/slider2.jpg'
import slider3 from '@/assets/images/sliders/slider3.jpg'

// Data sections
const categories = [
  {
    icon: 'bi bi-bicycle',
    title: 'Thiết bị tập gym',
    desc: 'Dụng cụ tập luyện chuyên nghiệp'
  },
  {
    icon: 'bi bi-dribbble',
    title: 'Thể thao đồng đội',
    desc: 'Bóng đá, bóng rổ, cầu lông'
  },
  {
    icon: 'bi bi-smartwatch',
    title: 'Phụ kiện thể thao',
    desc: 'Đồng hồ, găng tay, phụ kiện'
  }
]

const brands = [
  { image: new URL('@/assets/images/brands/nike.png', import.meta.url).href, name: 'Nike' },
  { image: new URL('@/assets/images/brands/adidas.png', import.meta.url).href, name: 'Adidas' },
  { image: new URL('@/assets/images/brands/puma.png', import.meta.url).href, name: 'Puma' },
  { image: new URL('@/assets/images/brands/under-armour.png', import.meta.url).href, name: 'Under Armour' }
]

const features = [
  {
    icon: 'bi bi-truck',
    title: 'Giao Hàng Miễn Phí',
    desc: 'Cho đơn hàng từ 500.000₫'
  },
  {
    icon: 'bi bi-shield-check',
    title: 'Bảo Hành 12 Tháng',
    desc: 'Đổi trả trong 30 ngày'
  },
  {
    icon: 'bi bi-headset',
    title: 'Hỗ Trợ 24/7',
    desc: 'Tư vấn chuyên nghiệp'
  }
]

const whyChooseUs = [
  {
    icon: 'bi bi-patch-check-fill',
    title: 'Sản Phẩm Chính Hãng',
    desc: '100% sản phẩm được nhập khẩu trực tiếp từ nhà sản xuất với chứng nhận chính hãng'
  },
  {
    icon: 'bi bi-currency-dollar',
    title: 'Giá Cả Hợp Lý',
    desc: 'Cam kết giá tốt nhất thị trường với nhiều chương trình khuyến mãi hấp dẫn'
  },
  {
    icon: 'bi bi-headset',
    title: 'Hỗ Trợ 24/7',
    desc: 'Đội ngũ tư vấn chuyên nghiệp, nhiệt tình hỗ trợ khách hàng mọi lúc'
  },
  {
    icon: 'bi bi-arrow-repeat',
    title: 'Chính Sách Đổi Trả',
    desc: 'Đổi trả miễn phí trong 30 ngày nếu sản phẩm có lỗi từ nhà sản xuất'
  }
]

const statistics = [
  {
    number: '5000+',
    label: 'Khách hàng hài lòng'
  },
  {
    number: '1000+',
    label: 'Sản phẩm đa dạng'
  },
  {
    number: '15+',
    label: 'Năm kinh nghiệm'
  },
  {
    number: '50+',
    label: 'Thương hiệu hợp tác'
  }
]

const featuredProducts = ref([])

onMounted(async () => {
  // Fetch featured products from API
  try {
    const products = await ProductService.getFeaturedProducts()
    featuredProducts.value = products.map(p => ({
      ...p,
      avg_rating: p.avg_rating || 0,
      total_reviews: p.total_reviews || 0
    }))
  } catch (error) {
    console.error('Error fetching products:', error)
  }
})

// Methods
const formatPrice = (price) => {
  return new Intl.NumberFormat('vi-VN').format(price)
}

const handleAddToCart = async (product) => {
  const cartCount = await addToCart(product.id)
  if (cartCount) {
    // Update cart badge if needed
  }
}

const handleParallaxEffects = () => {
  const scrolled = window.pageYOffset;
  const heroImages = document.querySelectorAll(".carousel-item img");
  const heroCaptions = document.querySelectorAll(".carousel-caption");

  heroImages.forEach((img) => {
    img.style.transform = `translateY(${scrolled * 0.3}px)`;
  });

  heroCaptions.forEach((caption) => {
    caption.style.transform = "translateY(50%)";
    caption.style.opacity = `${1 - scrolled * 0.002}`;
  });
}

// Lifecycle hooks
onMounted(() => {
  // Scroll and parallax effects
  window.addEventListener('scroll', handleScroll)
  window.addEventListener('scroll', handleParallax)
  window.addEventListener("scroll", handleParallaxEffects);

  // Intersection Observer for animations
  const observer = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
      if (entry.isIntersecting) {
        entry.target.classList.add('fade-in')
        observer.unobserve(entry.target)
      }
    })
  }, { threshold: 0.1 })

  document.querySelectorAll('.product-card, .feature-box').forEach(el => {
    observer.observe(el)
  })

  // Add smooth scroll
  document.querySelectorAll('a[href^="#"]').forEach((anchor) => {
    anchor.addEventListener("click", function (e) {
      const href = this.getAttribute("href");
      if (href !== "#") {
        e.preventDefault();
        const target = document.querySelector(href);
        if (target) {
          target.scrollIntoView({
            behavior: "smooth"
          });
        }
      }
    });
  });
})

onUnmounted(() => {
  window.removeEventListener('scroll', handleScroll)
  window.removeEventListener('scroll', handleParallax)
  window.removeEventListener("scroll", handleParallaxEffects);
})
</script>

<template>
  <!-- Hero Carousel -->
  <div id="heroCarousel" class="carousel slide" data-bs-ride="carousel">
    <div class="carousel-indicators">
      <button v-for="n in 3" :key="n" type="button" data-bs-target="#heroCarousel" 
              :data-bs-slide-to="n-1" :class="{ active: n === 1 }"></button>
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
      <span class="carousel-control-prev-icon"></span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#heroCarousel" data-bs-slide="next">
      <span class="carousel-control-next-icon"></span>
    </button>
  </div>

  <!-- Categories Section -->
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

    <!-- Brands Section -->
  <section class="brands py-5">
    <div class="container">
      <h2 class="section-title">THƯƠNG HIỆU NỔI TIẾNG</h2>
      <div class="row align-items-center">
        <div v-for="(brand, index) in brands" :key="index" class="col-lg-2 col-md-4 col-6">
          <img :src="brand.image" :alt="brand.name" class="img-fluid brand-logo">
        </div>
      </div>
    </div>
  </section>

  <!-- Featured Products Section -->
  <section class="featured-products bg-light">
    <div class="container">
      <h2 class="section-title">SẢN PHẨM NỔI BẬT</h2>
      <div class="row g-4">
        <div v-for="product in featuredProducts" :key="product.id" class="col-lg-3 col-md-6">
          <div class="product-card">
            <div class="product-badge" v-if="product.giaKhuyenMai">
              -{{ Math.round((1 - product.giaKhuyenMai/product.gia) * 100) }}%
            </div>
            <div class="product-image" v-if="product.mainImage">
              <router-link :to="'/san-pham/' + product.slug">
                <img :src="product.mainImage" :alt="product.tenSanPham">
              </router-link>
              <div class="product-actions">
                <button class="btn btn-light btn-sm" @click="handleAddToCart(product)">
                  <i class="bi bi-cart-plus"></i>
                </button>
                <button class="btn btn-light btn-sm">
                  <i class="bi bi-heart"></i>
                </button>
                <router-link :to="'/san-pham/' + product.slug" class="btn btn-light btn-sm">
                  <i class="bi bi-eye"></i>
                </router-link>
              </div>
            </div>
            <div class="product-info">
              <router-link :to="'/san-pham/' + product.slug" class="text-decoration-none">
                <h3 class="product-title">{{ product.tenSanPham }}</h3>
              </router-link>
              <div class="product-price">
                <span class="price-new">{{ formatPrice(product.giaKhuyenMai || product.gia) }}₫</span>
                <span class="price-old" v-if="product.giaKhuyenMai">{{ formatPrice(product.gia) }}₫</span>
              </div>
              <div class="product-rating">
                <i v-for="n in 5" :key="n" 
                   :class="['bi', n <= Math.floor(product.avg_rating || 0) ? 'bi-star-fill' : 
                          n - (product.avg_rating || 0) <= 0.5 ? 'bi-star-half' : 'bi-star']"
                   class="text-warning"></i>
                <span class="rating-count">
                  ({{ (product.avg_rating || 0).toFixed(1) }} - {{ product.total_reviews || 0 }} đánh giá)
                </span>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- Statistics Counter -->
  <section class="stats-counter py-5">
    <div class="container">
      <div class="row g-4">
        <div v-for="(stat, index) in statistics" :key="index" class="col-md-3 col-6">
          <div class="counter-box text-center">
            <div class="counter-number">{{ stat.number }}</div>
            <div class="counter-label">{{ stat.label }}</div>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- Features Section -->
  <section class="features bg-light">
    <div class="container">
      <div class="row g-4 text-center">
        <div v-for="(feature, index) in features" :key="index" class="col-md-4">
          <i :class="feature.icon + ' display-4 text-primary'"></i>
          <h3 class="mt-3">{{ feature.title }}</h3>
          <p>{{ feature.desc }}</p>
        </div>
      </div>
    </div>
  </section>

  <!-- Why Choose Us Section -->
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
/* General Styles */
.section-title {
  font-size: 2rem;
  background: linear-gradient(120deg, #367cd7, #34a853);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  font-weight: 700;
  margin-bottom: 40px;
  text-align: center;
}

.gradient-text {
  background: linear-gradient(270deg, #003780, #34a853);
  background-size: 200% auto;
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  animation: shine 2s linear infinite;
}

/* Hero Carousel */
.carousel-item {
  height: 700px;
  position: relative;
  overflow: hidden;
}

.carousel-item img {
  width: 100%;
  height: 100%;
  object-fit: cover;
  object-position: center;
  filter: brightness(0.8);
  transform: scale(1.1);
  will-change: transform;
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
  will-change: transform, opacity;
  backface-visibility: hidden;
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

/* Categories Section */
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

/* Products Section */
.featured-products {
  padding: 70px 0;
}

.product-card {
  border: none;
  border-radius: 20px;
  overflow: hidden;
  transition: all 0.4s cubic-bezier(0.4, 0, 0.2, 1);
  box-shadow: 0 5px 15px rgba(0,0,0,0.08);
  background: rgba(255,255,255,0.95);
  backdrop-filter: blur(10px);
  height: 450px;
  margin-bottom: 30px;
}

.product-image {
  height: 280px;
  position: relative;
  overflow: hidden;
}

.product-image img {
  width: 100%;
  height: 100%;
  object-fit: cover;
  transition: transform 0.5s ease;
}

.product-card:hover {
  transform: translateY(-15px) scale(1.02);
  box-shadow: 0 20px 40px rgba(0,0,0,0.12);
}

.product-card:hover img {
  transform: scale(1.1);
}

.product-info {
  padding: 1.25rem;
  display: flex;
  flex-direction: column;
  flex: 1;
}

.product-title {
  font-size: 1.1rem;
  font-weight: 600;
  color: #333;
  margin-bottom: 0.5rem;
  line-height: 1.4;
  height: 3.1em;
  overflow: hidden;
  display: -webkit-box;
  -webkit-line-clamp: 2;
  -webkit-box-orient: vertical;
}

.product-price {
  font-weight: 700;
  color: #003780;
  font-size: 1.2rem;
  margin-bottom: 0.5rem;
}

.price-old {
  text-decoration: line-through;
  color: #999;
  font-size: 0.9rem;
  margin-left: 0.5rem;
}

.product-rating {
  color: #ffc107;
  font-size: 0.9rem;
}

.product-rating .bi {
  margin-left: 4px;
}

.product-rating .rating-count {
  margin-left: 4px;
}

.product-badge {
  position: absolute;
  top: 10px;
  left: 10px;
  background: #003780;
  color: white;
  padding: 0.25rem 0.75rem;
  border-radius: 20px;
  font-size: 0.85rem;
  z-index: 1;
}

.product-actions {
  position: absolute;
  right: 10px;
  top: 50%;
  transform: translateY(-50%);
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
  opacity: 0;
  transition: all 0.3s ease;
}

.product-card:hover .product-actions {
  opacity: 1;
  right: 20px;
}

/* Features Section */
.why-choose-us {
  padding: 10px 0 60px 0;
  background: #f8f9fa;
}

.features {
  background: #f8f9fa;
  padding: 70px 0;
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

/* Animations */
@keyframes fadeInDown {
  from { opacity: 0; transform: translateY(-30px); }
  to { opacity: 1; transform: translateY(0); }
}

@keyframes fadeInUp {
  from { opacity: 0; transform: translateY(30px); }
  to { opacity: 1; transform: translateY(0); }
}

@keyframes shine {
  to { background-position: 200% center; }
}

/* Media Queries */
@media (max-width: 768px) {
  .counter-box {
    padding: 1.5rem;
  }
  
  .counter-number {
    font-size: 2.2rem;
  }
  
  .counter-label {
    font-size: 0.9rem;
  }
}
</style>
