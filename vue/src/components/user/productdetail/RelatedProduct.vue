<template>
  <div class="related-products">
    <h3 class="section-title">SẢN PHẨM LIÊN QUAN</h3>
    <div class="row g-4">
      <div v-for="related in relatedProducts" :key="related.id" class="col-lg-3 col-md-4 col-sm-6">
        <div class="product-card">
          <div v-if="related.giaKhuyenMai > 0" class="product-badge">
            -{{ Math.round(((related.gia - related.giaKhuyenMai) / related.gia) * 100) }}%
          </div>
          <div class="product-image">
            <a :href="'/san-pham/' + related.maSanPham" class="product-link">
              <img :src="related.mainImage || '/WebbandoTT/app/public/images/no-image.jpg'" :alt="related.tenSanPham" class="img-fluid">
            </a>
            <div class="product-actions">
              <button class="btn btn-light btn-sm add-to-cart" :data-product-id="related.id" :data-product-name="related.tenSanPham" :data-product-price="related.giaKhuyenMai || related.gia">
                <i class="bi bi-cart-plus"></i>
              </button>
              <button class="btn btn-light btn-sm btn-wishlist">
                <i class="bi bi-heart"></i>
              </button>
              <a :href="'/san-pham/' + related.maSanPham" class="btn btn-light btn-sm">
                <i class="bi bi-eye"></i>
              </a>
            </div>
          </div>
          <div class="product-info">
            <a :href="'/san-pham/' + related.maSanPham" class="text-decoration-none">
              <h3 class="product-title">{{ related.tenSanPham }}</h3>
            </a>
            <div class="product-category">
              {{ related.tenDanhMuc }} | {{ related.tenThuongHieu }}
            </div>
            <div class="product-price">
              <span class="price-new">{{ formatPrice(related.giaKhuyenMai || related.gia) }}₫</span>
              <span v-if="related.giaKhuyenMai" class="price-old">{{ formatPrice(related.gia) }}₫</span>
            </div>
            <div class="product-rating">
              <i v-for="i in 5" :key="i" :class="['bi', i <= related.averageRating ? 'bi-star-fill text-warning' : (i - related.averageRating <= 0.5 ? 'bi-star-half text-warning' : 'bi-star')]"></i>
              <span class="rating-count">({{ related.averageRating }} - {{ related.totalReviews }} đánh giá)</span>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'

defineProps({
  relatedProducts: Array
})

const formatPrice = (price) => new Intl.NumberFormat('vi-VN').format(price)
</script>

<style scoped>
/* Related Products Section */
.related-products {
    margin-top: 2rem;
    padding-top: 2rem;
    border-top: 1px solid var(--light-color);
}

.related-products .section-title {
    font-size: 1.8rem;
    font-weight: 700;
    text-align: center;
    margin-bottom: 2.5rem;
    position: relative;
    padding-bottom: 1rem;
    background: var(--gradient);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
}

.related-products .section-title::after {
    content: '';
    position: absolute;
    bottom: 0;
    left: 50%;
    transform: translateX(-50%);
    width: 80px;
    height: 3px;
    background: var(--gradient);
    border-radius: 2px;
}

.related-products .product-category {
    font-size: 0.85rem;
    color: #666;
    margin: 0.5rem 0;
}

.related-products .stars {
    display: inline-flex;
    gap: 2px;
}

.related-products .rating-count {
    font-size: 0.85rem;
    margin-left: 5px;
}

.related-products .product-card {
    height: 100%;
    margin-bottom: 0;
}
</style>