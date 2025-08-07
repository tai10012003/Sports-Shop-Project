<template>
  <div v-if="product">
    <GeneralInfor :product="product" />
    <div class="detail-tabs">
      <ul class="nav nav-tabs detail-tab-nav" role="tablist">
        <li class="nav-item"><a class="nav-link active" data-bs-toggle="tab" href="#description">Mô tả chi tiết</a></li>
        <li class="nav-item"><a class="nav-link" data-bs-toggle="tab" href="#specifications">Thông số kỹ thuật</a></li>
        <li class="nav-item"><a class="nav-link" data-bs-toggle="tab" href="#reviews">Đánh giá</a></li>
      </ul>
      <div class="detail-tab-content">
        <div class="tab-content">
          <DetailedDes :product="product" />
          <Specifications :product="product" />
          <ProductReview :product="product" :reviews="reviews" :is-logged-in="isLoggedIn" />
        </div>
      </div>
    </div>
    <RelatedProduct :related-products="relatedProducts" />
  </div>
  <div v-else>Loading...</div>
</template>

<script setup>
import { ref, onMounted, watch } from 'vue'
import GeneralInfor from '@/components/user/productdetail/GeneralInfor.vue'
import DetailedDes from '@/components/user/productdetail/DetailedDes.vue'
import Specifications from '@/components/user/productdetail/Specifications.vue'
import ProductReview from '@/components/user/productdetail/ProductReview.vue'
import RelatedProduct from '@/components/user/productdetail/RelatedProduct.vue'
import ProductService from '@/services/ProductService'

const props = defineProps({
  slug: String
})

const product = ref(null)
const reviews = ref([])
const relatedProducts = ref([])
const isLoggedIn = ref(!!localStorage.getItem('user_id'))

const fetchProductData = async (slugValue) => {
  try {
    const productData = await ProductService.getProductDetail(slugValue)
    product.value = productData

    if (product.value) {
      const reviewRes = await ProductService.getProductReviews(product.value.id)
      reviews.value = reviewRes

      const relatedRes = await ProductService.getRelatedProducts(slugValue)
      relatedProducts.value = relatedRes
    }
  } catch (error) {
    console.error('Error fetching product data:', error)
    product.value = null
  }
}

onMounted(() => {
  if (props.slug) fetchProductData(props.slug)
})

watch(() => props.slug, (newSlug) => {
  if (newSlug) fetchProductData(newSlug)
})
</script>
<style scoped>
/* Enhanced Product Detail Tabs */
.detail-tabs {
    background: white;
    border-radius: 15px;
    box-shadow: 0 5px 20px rgba(0,0,0,0.05);
    margin: 2.5rem 0;
    overflow: hidden;
}

.detail-tab-nav {
    background: var(--light-color);
    padding: 0;
    border: none;
    position: relative;
}

.detail-tab-link {
    font-size: 1rem;
    font-weight: 600;
    color: #555;
    padding: 1rem 1.5rem;
    border-radius: 10px 10px 0 0;
    border: none;
    transition: all 0.3s ease;
    position: relative;
    overflow: hidden;
}

.detail-tab-link::before {
    content: '';
    position: absolute;
    bottom: 0;
    left: 50%;
    width: 0;
    height: 2px;
    background: var(--gradient);
    transition: all 0.3s ease;
    transform: translateX(-50%);
}

.detail-tab-link.active {
    color: var(--primary-color);
    background: white !important;
}

.detail-tab-link.active::before {
    width: 100%;
}

.detail-tab-link:hover:not(.active) {
    color: var(--primary-color);
    transform: translateY(-2px);
}

.detail-tab-content {
    padding: 2rem;
}

</style>