<template>
  <div class="filter-sidebar">
    <!-- Danh mục -->
    <div class="filter-box mb-4">
      <h5 class="filter-title border-bottom pb-2 mb-3">Danh Mục</h5>
      <div class="list-group list-group-flush">
        <a href="#" @click.prevent="setFilter('category', '')"
           :class="['list-group-item', 'list-group-item-action', 'd-flex', 'justify-content-between', 'align-items-center', !filters.category ? 'active fw-bold' : '']">
          <span>Tất cả</span>
          <span class="badge bg-primary rounded-pill">{{ totalProducts }}</span>
        </a>
        <a v-for="cat in categories" :key="cat.id" href="#" @click.prevent="setFilter('category', cat.maDanhMuc)"
           :class="['list-group-item', 'list-group-item-action', 'd-flex', 'justify-content-between', 'align-items-center', filters.category === cat.maDanhMuc ? 'active fw-bold' : '']">
          <span>{{ cat.tenDanhMuc }}</span> <!-- Sửa ten_danh_muc thành tenDanhMuc -->
          <i class="bi bi-chevron-right"></i>
        </a>
      </div>
    </div>
    <!-- Thương hiệu -->
    <div class="filter-box mb-4">
      <h5 class="filter-title border-bottom pb-2 mb-3 mt-4">Thương Hiệu</h5>
      <div class="list-group list-group-flush">
        <a href="#" @click.prevent="setFilter('brand', '')"
           :class="['list-group-item', 'list-group-item-action', 'd-flex', 'justify-content-between', 'align-items-center', !filters.brand ? 'active fw-bold' : '']">
          <span>Tất cả</span>
          <span class="badge bg-primary rounded-pill">{{ totalProducts }}</span>
        </a>
        <a v-for="brand in brands" :key="brand.id" href="#" @click.prevent="setFilter('brand', brand.maThuongHieu)" 
           :class="['list-group-item', 'list-group-item-action', 'd-flex', 'justify-content-between', 'align-items-center', filters.brand === brand.maThuongHieu ? 'active fw-bold' : '']">
          <span>{{ brand.tenThuongHieu }}</span> <!-- Sửa ten_thuong_hieu thành tenThuongHieu -->
          <i class="bi bi-chevron-right"></i>
        </a>
      </div>
    </div>
    <!-- Khoảng giá -->
    <div class="filter-box mb-4">
      <h5 class="filter-title border-bottom pb-2 mb-3 mt-4">Khoảng Giá</h5>
      <div class="d-grid gap-2">
        <button v-for="range in priceRanges" :key="range.value"
                @click="setFilter('price', range.value)"
                :class="['btn', filters.price === range.value ? 'btn-success' : 'btn-outline-success', 'btn-sm']">
          {{ range.label }}
        </button>
      </div>
    </div>
  </div>
</template>

<script setup>
const emit = defineEmits(['set-filter'])
defineProps(['categories', 'brands', 'totalProducts', 'filters', 'priceRanges'])
const setFilter = (key, value) => {
  emit('set-filter', key, value)
}
</script>

<style scoped>
.filter-sidebar {
  background: white;
  padding: 1.5rem;
  border-radius: 15px;
  box-shadow: 0 2px 15px rgba(0,0,0,0.08);
}

.filter-title {
  font-size: 1.1rem;
  font-weight: 600;
  margin-bottom: 1rem;
}

.btn-sm {
  padding: 6px 15px;
  font-size: 0.85rem;
}
</style>