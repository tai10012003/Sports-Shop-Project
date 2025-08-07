<template>
  <div class="review-form mb-4">
    <div v-if="isLoggedIn" class="mb-3">
      <form @submit.prevent="submitReview">
        <input type="hidden" name="sanPhamId" :value="product.id">
        <div class="mb-3">
          <label class="form-label">Đánh giá của bạn</label>
          <div class="rating-input">
            <input v-for="i in 5" :key="i" type="radio" :id="'star' + i" :value="i" v-model="rating" required>
            <label v-for="i in 5" :key="i" :for="'star' + i"><i class="bi bi-star-fill"></i></label>
          </div>
        </div>
        <div class="mb-3">
          <label class="form-label">Nhận xét của bạn</label>
          <textarea class="form-control" v-model="reviewContent" rows="3" required></textarea>
        </div>
        <button type="submit" class="btn btn-primary">Gửi đánh giá</button>
      </form>
    </div>
    <div v-else class="alert alert-info">
      Vui lòng <a href="/WebbandoTT/dang-nhap">đăng nhập</a> để viết đánh giá
    </div>

    <div class="reviews-list mt-4">
      <div v-if="reviews.length" class="review-item mb-4 p-3 border rounded bg-light" v-for="review in reviews" :key="review.id">
        <div class="review-header d-flex justify-content-between align-items-center mb-2">
          <div class="reviewer-info">
            <span class="reviewer-name fw-bold">{{ review.tenNguoiDung }}</span>
            <small class="text-muted ms-2">{{ formatDate(review.createdAt) }}</small>
          </div>
          <div class="star-rating">
            <i v-for="i in 5" :key="i" :class="['bi', i <= review.diemDanhGia ? 'bi-star-fill text-warning' : 'bi-star']"></i>
          </div>
        </div>
        <div class="review-content">
          {{ review.noiDung }}
        </div>
      </div>
      <div v-else class="text-center p-4">
        <div class="mb-3"><i class="bi bi-chat-square-text" style="font-size: 2rem;"></i></div>
        <p class="text-muted">Chưa có đánh giá nào cho sản phẩm này</p>
        <p v-if="isLoggedIn">Hãy là người đầu tiên đánh giá sản phẩm!</p>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'

defineProps({
  product: Object,
  reviews: Array,
  isLoggedIn: Boolean
})

const rating = ref(0)
const reviewContent = ref('')

const formatDate = (dateStr) => new Date(dateStr).toLocaleString('vi-VN', { day: '2-digit', month: '2-digit', year: 'numeric', hour: '2-digit', minute: '2-digit' })

const submitReview = () => {
  // Logic gửi API
  console.log('Submitting review:', { productId: product.id, rating: rating.value, content: reviewContent.value })
  alert('Đánh giá đã được gửi!')
  rating.value = 0
  reviewContent.value = ''
}
</script>

<style scoped>
/* Reviews Section */
.review-form {
    padding: 0.5rem;
    border-radius: 15px;
    margin-bottom: 2rem;
}

.review-form h5 {
    font-size: 1.2rem;
    font-weight: 600;
    margin-bottom: 1.5rem;
    color: var(--dark-color);
}

.rating-input {
    display: flex;
    justify-content: start;
    flex-direction: row-reverse;
    gap: 1rem;
    margin: 10px 0 15px 0;
}

.rating-input input {
    display: none;
}

.rating-input label {
    cursor: pointer;
    font-size: 1.5rem;
    color: #ddd;
    transition: all 0.2s ease;
}

.rating-input label:hover,
.rating-input label:hover ~ label,
.rating-input input:checked ~ label {
    color: #ffc107;
}

.reviews-list {
    margin-top: 2rem;
}

.review-item {
    background: white;
    border-radius: 12px;
    padding: 1.5rem;
    margin-bottom: 1.5rem;
    border: 1px solid #c0c0c0;
    transition: transform 0.3s ease;
}

.review-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 1rem;
}

.reviewer-name {
    font-weight: 600;
    color: var (--dark-color);
    font-size: 1.1rem;
}

.review-date {
    color: #666;
    font-size: 0.9rem;
}

.star-rating {
    color: #ffc107;
    margin-bottom: 0.75rem;
    font-size: 0.9rem;
}

.review-content {
    color: #444;
    line-height: 1.6;
    margin: 0;
}

.reviews-list {
    max-height: 500px;
    overflow-y: auto;
    padding-right: 10px;
}

.reviews-list::-webkit-scrollbar {
    width: 6px;
}

.reviews-list::-webkit-scrollbar-track {
    background: #f1f1f1;
    border-radius: 10px;
}

.reviews-list::-webkit-scrollbar-thumb {
    background: #888;
    border-radius: 10px;
}

.reviews-list::-webkit-scrollbar-thumb:hover {
    background: #555;
}

.reviews-list {
    scrollbar-width: thin;
    scrollbar-color: #888 #f1f1f1;
}

.review-item {
    margin-right: 5px;
    break-inside: avoid;
}
</style>