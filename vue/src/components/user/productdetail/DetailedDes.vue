<template>
  <div class="tab-pane fade show active" id="description" role="tabpanel">
    <div class="detail-description">
      <div v-if="product.moTaChiTiet" v-html="product.moTaChiTiet"></div>
      <div v-else class="no-description">
        Hiện tại chưa có mô tả chi tiết cho sản phẩm này. Chúng tôi sẽ cập nhật sớm nhất !!
      </div>
    </div>
  </div>
</template>

<script setup>
defineProps({
  product: {
    type: Object,
    required: true
  }
})
</script>

<style scoped>
.detail-description {
    color: #444;
    line-height: 1.8;
    font-size: 1rem;
}
.no-description {
  padding: 1rem;
  background: #fff3cd;
  border-left: 5px solid #ffeeba;
  border-radius: 8px;
  color: #856404;
  font-weight: 500;
  text-align: center;
  font-size: 0.95rem;
}
</style>