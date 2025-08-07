<template>
  <div class="product-detail">
    <nav aria-label="breadcrumb">
      <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="/">Trang chủ</a></li>
        <li class="breadcrumb-item"><a href="/san-pham">Sản phẩm</a></li>
        <li class="breadcrumb-item active">{{ product.tenSanPham }}</li>
      </ol>
    </nav>

    <div class="row">
      <!-- Gallery Section -->
      <div class="col-lg-5">
        <div class="detail-gallery">
          <div class="detail-main-image">
            <img :src="mainImage" alt="Main Product Image" id="main-product-image">
          </div>
          <div class="detail-thumbnails">
            <img v-for="(img, index) in product.images" :key="index" :src="img" :alt="'Thumbnail ' + (index + 1)"
                 class="detail-thumbnail" :class="{ 'active': index === 0 }" @click="changeMainImage(img)">
          </div>
        </div>
      </div>

      <!-- Product Info Section -->
      <div class="col-lg-7">
        <div class="detail-info-wrapper">
          <h1 class="detail-product-title">{{ product.tenSanPham }}</h1>

          <div class="detail-meta-info">
            <div class="detail-meta-item">
              <span class="detail-meta-label">Mã sản phẩm:</span>
              <span>{{ product.maSanPham }}</span>
            </div>
            <div class="detail-meta-item">
              <span class="detail-meta-label">Danh mục:</span>
              <span>{{ product.tenDanhMuc }}</span>
            </div>
            <div class="detail-meta-item">
              <span class="detail-meta-label">Thương hiệu:</span>
              <span>{{ product.tenThuongHieu }}</span>
            </div>
            <div class="detail-meta-item" v-if="product.luotXem">
              <span class="detail-meta-label">Lượt xem:</span>
              <span>{{ formatNumber(product.luotXem) }}</span>
            </div>
            <div class="detail-meta-item">
              <span class="detail-meta-label">Đánh giá:</span>
              <span class="d-flex align-items-center">
                <div class="star-rating me-2">
                  <i v-for="i in 5" :key="i" :class="['bi', i <= product.averageRating ? 'bi-star-fill text-warning' : (i - product.averageRating <= 0.5 ? 'bi-star-half text-warning' : 'bi-star')]"></i>
                </div>
                <span>({{ product.averageRating }}/5 - {{ product.totalReviews }} đánh giá)</span>
              </span>
            </div>
          </div>

          <div class="detail-price-wrapper">
            <span class="detail-current-price">{{ formatPrice(product.giaKhuyenMai || product.gia) }}₫</span>
            <span class="detail-old-price" v-if="product.giaKhuyenMai">{{ formatPrice(product.gia) }}₫</span>
            <span class="detail-discount" v-if="product.giaKhuyenMai">
              -{{ Math.round(((product.gia - product.giaKhuyenMai) / product.gia) * 100) }}%
            </span>
          </div>

          <form v-if="product.tinhTrang && product.soLuong > 0" @submit.prevent="addToCart" class="detail-add-cart-form">
            <input type="hidden" name="product_id" :value="product.id">
            <div class="detail-quantity-control">
              <label class="detail-quantity-label">Số lượng:</label>
              <div class="input-group">
                <button type="button" class="btn btn-outline-secondary" @click="updateQuantity('decrease')">-</button>
                <input type="number" class="form-control text-center" v-model="quantity" min="1" :max="product.soLuong">
                <button type="button" class="btn btn-outline-secondary" @click="updateQuantity('increase')">+</button>
              </div>
              <span class="detail-stock-info">(Còn {{ product.soLuong }} sản phẩm)</span>
            </div>

            <div class="product-variations mt-4 mb-4" v-if="product.mauSac || product.kichThuoc">
              <div class="variation-group mb-4" v-if="product.mauSac">
                <label class="form-label">Màu sắc:</label>
                <div class="btn-group" role="group">
                  <input v-for="(color, index) in (product.mauSac ? product.mauSac.split(',') : [])" :key="index" type="radio" class="btn-check" :id="'color_' + color.trim()"
                         :value="color?.trim?.()"  v-model="selectedColor" required>
                  <label :for="'color_' + (color?.trim?.() || '')" class="btn btn-outline-dark" style="margin-left: 20px">{{ color?.trim?.() }}</label>
                </div>
              </div>
              <div class="variation-group" v-if="product.kichThuoc">
                <label class="form-label">Kích thước:</label>
                <div class="btn-group" role="group">
                  <input v-for="(size, index) in (product.kichThuoc ? product.kichThuoc.split(',') : [])" :key="index" type="radio" class="btn-check" :id="'size_' + (size?.trim?.() || '')"
                         :value="size?.trim?.()"  v-model="selectedSize" required>
                  <label :for="'size_' + (size?.trim?.() || '')" class="btn btn-outline-dark" style="margin-left: 20px">{{ size?.trim?.() }}</label>
                </div>
              </div>
            </div>

            <div class="detail-buttons">
              <button type="submit" class="detail-add-to-cart">
                <i class="bi bi-cart-plus"></i> Thêm vào giỏ hàng
              </button>
              <button type="button" class="detail-add-to-wishlist">
                <i class="bi bi-heart"></i> Thêm vào yêu thích
              </button>
            </div>
          </form>
          <div v-else class="alert alert-warning mt-3" role="alert">
            <i class="bi bi-exclamation-triangle-fill me-2"></i>
            <strong>{{ !product.tinhTrang ? 'Sản phẩm tạm ngừng kinh doanh!' : 'Sản phẩm đã hết hàng!' }}</strong>
            <p class="mb-0 mt-2">Vui lòng quay lại sau hoặc liên hệ với chúng tôi để biết thêm thông tin!</p>
          </div>

          <div class="detail-social-share">
            <a href="#" class="detail-social-btn detail-facebook"><i class="bi bi-facebook"></i></a>
            <a href="#" class="detail-social-btn detail-twitter"><i class="bi bi-twitter"></i></a>
            <a href="#" class="detail-social-btn detail-pinterest"><i class="bi bi-pinterest"></i></a>
          </div>

          <div class="detail-short-desc">
            <h5 class="detail-short-desc-title">Mô tả sản phẩm</h5>
            <div class="detail-short-desc-content">
              {{ product.moTa }}
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'

const props = defineProps({
  product: Object
})

const product = props.product

const mainImage = ref('')
const quantity = ref(1)
const selectedColor = ref('')
const selectedSize = ref('')

const formatPrice = (price) => new Intl.NumberFormat('vi-VN').format(price)

const changeMainImage = (src) => {
  mainImage.value = src
}

const updateQuantity = (action) => {
  const max = parseInt(product.soLuong)
  if (action === 'increase' && quantity.value < max) quantity.value++
  else if (action === 'decrease' && quantity.value > 1) quantity.value--
}

const addToCart = () => {
  console.log('Adding to cart:', {
    productId: product.id,
    quantity: quantity.value,
    color: selectedColor.value,
    size: selectedSize.value
  })
  alert('Đã thêm vào giỏ hàng: ' + product.tenSanPham)
}

onMounted(() => {
  mainImage.value = product.images?.[0] || '/WebbandoTT/app/public/images/no-image.jpg'
})
</script>

<style scoped>
.product-detail {
    padding: 30px 150px;
    background: var(--light-color);
}

/* Breadcrumb styles */
.product-detail .breadcrumb {
    background: transparent;
    padding: 0.5rem 0 1.5rem;
}

.product-detail .breadcrumb-item a {
    color: var(--primary-color);
    font-size: 0.95rem;
}

.product-detail .breadcrumb-item.active {
    color: #666;
}

/* Gallery Section */
.detail-gallery {
    background: white;
    border-radius: 15px;
    box-shadow: 0 8px 25px rgba(0,0,0,0.08);
    position: sticky;
    top: 90px;
    transition: all 0.3s ease;
    padding: 1rem;
}

.detail-main-image {
    border-radius: 12px;
    overflow: hidden;
    margin-bottom: 1rem;
    background: #f8f9fa;
    text-align: center;
    height: 600px; /* Tăng từ 500px lên 600px */
    display: flex;
    align-items: center;
    justify-content: center;
}

.detail-main-image img {
    width: 100%;
    height: 100%;
    transition: transform 0.4s ease;
}

.detail-main-image:hover img {
    transform: scale(1.02);
}

.detail-thumbnails {
    display: grid;
    grid-template-columns: repeat(4, 1fr);
    gap: 12px;
    padding: 0.5rem;
}

.detail-thumbnail {
    width: 100%;
    aspect-ratio: 1;
    border-radius: 8px;
    cursor: pointer;
    padding: 5px;
    background: white;
    border: 2px solid #eee;
    transition: all 0.3s ease;
}

.detail-thumbnail img {
    width: 100%;
    height: 100%;
    object-fit: contain;
    border-radius: 6px;
}

.detail-thumbnail:hover {
    border-color: var(--primary-color);
    transform: translateY(-2px);
}

.detail-thumbnail.active {
    border-color: var(--primary-color);
    box-shadow: 0 3px 10px rgba(0,55,128,0.15);
    transform: translateY(-2px);
}

.detail-info-wrapper {
    background: white;
    border-radius: 15px;
    padding: 1.5rem;
    height: 100%;
    box-shadow: 0 3px 10px rgba(0,0,0,0.05);
}

.detail-product-title {
    font-size: 22px;
    font-weight: 600;
    color: var(--dark-color);
    margin-bottom: 1rem;
    line-height: 1.4;
}

.detail-meta-item {
    display: flex;
    justify-content: space-between;
    padding: 15px 0;
    color: #555;
    font-size: 0.95rem;
    border-bottom: 1px solid rgba(0,0,0,0.05);
}

.detail-meta-item:last-child {
    border-bottom: none;
}

.detail-meta-label {
    font-weight: 500;
    color: var (--dark-color);
}

/* Price Section */
.detail-price-wrapper {
    margin: 10px 0;
    display: flex;
    align-items: center;
    gap: 1.5rem;
    flex-wrap: wrap;
}

.detail-current-price {
    font-size: 20px;
    font-weight: 600;
    color: red;
}

.detail-old-price {
    font-size: 1.2rem;
    text-decoration: line-through;
    color: #999;
}

.detail-discount {
    background: #dc3545;
    color: white;
    padding: 0.25rem 0.75rem;
    border-radius: 15px;
    font-size: 0.85rem;
    font-weight: 500;
}

/* Quantity Control */
.detail-quantity-control {
    display: flex;
    align-items: center;
    gap: 1rem;
    margin: 25px 0;
}

.detail-quantity-label {
    font-weight: 500;
    color: var(--dark-color);
    font-size: 0.95rem;
    min-width: 80px;
}

.detail-quantity-control .input-group {
    width: 155px;
}

.detail-quantity-control .form-control {
    text-align: center;
    font-weight: 500;
}

.detail-stock-info {
    color: #666;
    font-size: 0.9rem;
}

.detail-buttons {
    display: flex;
    gap: 1rem;
    margin: 1rem 0;
}
/* Add to Cart Button */
.detail-add-to-cart {
    width: 100%;
    padding: 8px;
    font-size: 1rem;
    margin: 1rem 0;
    background: var(--gradient);
    border: none;
    border-radius: 12px;
    color: white;
    font-weight: 500;
    display: flex;
    align-items: center;
    justify-content: center;
    gap: 0.75rem;
    transition: all 0.3s ease;
}

.detail-add-to-cart:hover {
    transform: translateY(-2px);
    box-shadow: 0 8px 20px rgba(0,0,0,0.15);
}

.detail-add-to-cart i {
    font-size: 1.2rem;
}

.detail-add-to-cart,
.detail-add-to-wishlist {
    width: 100%;
    padding: 8px;
    font-size: 1rem;
    margin: 1rem 0;
    border: none;
    border-radius: 12px;
    color: white;
    font-weight: 500;
    display: flex;
    align-items: center;
    justify-content: center;
    gap: 0.75rem;
    transition: all 0.3s ease;
}

.detail-add-to-cart {
    background: var(--gradient);
    color: white;
}

.detail-add-to-wishlist {
    background: white;
    color: var(--primary-color);
    border: 2px solid var(--primary-color);
}

.detail-add-to-cart:hover,
.detail-add-to-wishlist:hover {
    transform: translateY(-2px);
    box-shadow: 0 8px 20px rgba(0,0,0,0.15);
}

.detail-add-to-wishlist:hover {
    background: var(--primary-color);
    color: white;
}

.detail-add-to-cart i,
.detail-add-to-wishlist i {
    font-size: 1.2rem;
}

/* Product Tabs */
.detail-tabs {
    margin-top: 2rem;
    background: white;
    border-radius: 15px;
    overflow: hidden;
    box-shadow: 0 3px 10px rgba(0,0,0,0.05);
}

.detail-tab-nav {
    background: var(--light-color);
    padding: 0.75rem 0.75rem 0;
    border: none;
}

.detail-tab-link {
    padding: 0.875rem 1.5rem;
    font-weight: 500;
    font-size: 0.95rem;
    color: #555;
    border-radius: 8px 8px 0 0;
    border: none;
    transition: all 0.3s ease;
}

.detail-tab-link.active {
    background: white !important;
    color: var(--primary-color) !important;
    font-weight: 500;
}

.detail-tab-content {
    padding: 1.5rem;
}

.detail-description {
    color: #444;
    line-height: 1.7;
    font-size: 0.95rem;
}

.detail-description h5 {
    font-size: 1.1rem;
    font-weight: 500;
    margin: 1.5rem 0 1rem;
    color: var(--dark-color);
}

/* Alert Styles */
  .alert {
      border: none;
      background: white;
  }
  
  .alert-success {
      background: #d4edda;
      color: #155724;
      border-left: 4px solid #28a745;
  }
  
  .alert-danger {
      background: #f8d7da;
      color: #721c24;
      border-left: 4px solid #dc3545;
  }

/* Social Share */
.detail-social-share {
    margin-top: 1.5rem;
    display: flex;
    gap: 0.75rem;
}

.detail-social-btn {
    width: 36px;
    height: 36px;
    border-radius: 50%;
    display: flex;
    align-items: center;
    justify-content: center;
    color: white;
    font-size: 1rem;
    transition: all 0.2s ease;
}

.detail-social-btn:hover {
    transform: translateY(-3px);
    opacity: 0.9;
}

.detail-facebook { background: #1877f2; }
.detail-twitter { background: #1da1f2; }
.detail-pinterest { background: #bd081c; }

.detail-short-desc {
    margin-top: 1.5rem;
    padding-top: 1.5rem;
    border-top: 1px solid #dedede;
}

.detail-short-desc-title {
    font-size: 1.1rem;
    font-weight: 600;
    color: var(--dark-color);
    margin-bottom: 1rem;
    position: relative;
    padding-bottom: 0.75rem;
}

.detail-short-desc-title::after {
    content: '';
    position: absolute;
    left: 0;
    bottom: 0;
    width: 40px;
    height: 2px;
    background: var(--gradient);
    border-radius: 2px;
}

.detail-short-desc-content {
    color: #555;
    line-height: 1.8;
    font-size: 0.95rem;
    text-align: justify;
}
</style>