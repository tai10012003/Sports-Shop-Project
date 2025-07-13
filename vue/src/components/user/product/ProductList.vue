<template>
  <div>
    <!-- Hero Mini -->
    <div class="hero-mini">
      <div class="container">
        <h1 class="display-6 text-center mb-4">SẢN PHẨM THỂ THAO</h1>
        <div class="search-box mb-5 position-relative">
          <form @submit.prevent="onSearch">
            <div class="input-group">
              <input
                v-model="filters.search"
                @input="onInputSearch"
                type="text"
                class="form-control"
                placeholder="Tìm kiếm sản phẩm..."
                autocomplete="off"
              >
              <button type="submit" class="btn btn-primary"><i class="bi bi-search"></i></button>
            </div>
            <ul v-if="suggestions.length" class="suggest-list position-absolute w-100 bg-white shadow">
            <li
              v-for="s in suggestions"
              :key="s.id"
              @click="selectSuggestion(s.tenSanPham)"
              class="p-2 suggest-item d-flex align-items-center"
            >
              <img
                v-if="s.hinhAnh && s.hinhAnh.length"
                :src="getMainImage(s)"
                alt="Ảnh"
                class="suggest-thumb me-2"
              />
              <div class="flex-grow-1">
                <div class="fw-bold suggest-title">{{ s.tenSanPham }}</div>
                <div>
                  <span v-if="s.giaKhuyenMai && s.giaKhuyenMai < s.gia" class="text-danger fw-bold">
                    {{ formatPrice(s.giaKhuyenMai) }}
                  </span>
                  <span v-if="s.giaKhuyenMai && s.giaKhuyenMai < s.gia" class="text-muted ms-2" style="text-decoration: line-through;">
                    {{ formatPrice(s.gia) }}
                  </span>
                  <span v-else class="text-dark">{{ formatPrice(s.gia) }}</span>
                </div>
              </div>
            </li>
          </ul>
          </form>
        </div>
      </div>
    </div>

    <div class="container py-5">
      <div class="row">
        <!-- Sidebar lọc sản phẩm -->
        <div class="col-lg-3">
          <ProductSidebar
            :categories="categories"
            :brands="brands"
            :totalProducts="totalProducts"
            :filters="filters"
            :priceRanges="priceRanges"
            @set-filter="setFilter"
          />
        </div>

        <!-- Danh sách sản phẩm -->
        <div class="col-lg-9">
          <div class="product-controls mb-4">
            <div class="row align-items-center">
              <div class="col">
                <span>Hiển thị {{ products.length }} trong {{ totalProducts }} sản phẩm</span>
              </div>
              <div class="col-auto">
                <button class="btn btn-outline-dark btn-sm" style="font-size: 16px;" @click="resetFilters">
                  Tất cả sản phẩm
                </button>
              </div>
              <div class="col-auto">
                <select class="form-select" v-model="filters.sort" @change="fetchProducts">
                  <option value="">Tất cả</option>
                  <option value="promotion">Khuyến mãi</option>
                  <option value="price_asc">Giá tăng dần</option>
                  <option value="price_desc">Giá giảm dần</option>
                </select>
              </div>
            </div>
          </div>

          <transition-group name="fade-in-up" tag="div" class="row g-4">
            <div v-for="product in products" :key="product.id" class="col-md-4">
              <ProductCard :product="product" @add-to-cart="addToCart" />
            </div>
          </transition-group>
          <div v-if="!products.length" class="col-12">
            <p class="text-center">Không tìm thấy sản phẩm nào</p>
          </div>

          <ProductPagination
            :totalPages="totalPages"
            :currentPage="currentPage"
            @go-to-page="goToPage"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, reactive, onMounted } from 'vue'
import ProductService from '@/services/ProductService'
import ProductSidebar from './ProductSidebar.vue'
import ProductCard from './ProductCard.vue'
import ProductPagination from './ProductPagination.vue'

const products = ref([])
const categories = ref([])
const brands = ref([])
const totalProducts = ref(0)
const totalPages = ref(1)
const currentPage = ref(1)
const filters = reactive({
  search: '',
  category: '',
  brand: '',
  price: '',
  sort: ''
})

const suggestions = ref([])
let suggestTimeout = null

const VUE_BASE_URL = 'http://localhost:5173'

const priceRanges = [
  { value: '', label: 'Tất cả' },
  { value: '0-500000', label: 'Dưới 500.000₫' },
  { value: '500000-1000000', label: '500.000₫ - 1.000.000₫' },
  { value: '1000000-2000000', label: '1.000.000₫ - 2.000.000₫' },
  { value: '2000000-5000000', label: '2.000.000₫ - 5.000.000₫' },
  { value: '5000000-up', label: 'Trên 5.000.000₫' }
]

function setFilter(key, value) {
  filters[key] = value
  currentPage.value = 1
  fetchProducts()
}

function resetFilters() {
  filters.search = ''
  filters.category = ''
  filters.brand = ''
  filters.price = ''
  filters.sort = ''
  currentPage.value = 1
  fetchProducts()
}

function goToPage(page) {
  if (page !== currentPage.value) {
    currentPage.value = page
    fetchProducts()
  }
}

function formatPrice(price) {
  return price ? price.toLocaleString('vi-VN') + '₫' : ''
}
function getMainImage(product) {
  if (!product.hinhAnh || !product.hinhAnh.length) return ''
  const mainImage = product.hinhAnh.find(img => img.anhChinh) || product.hinhAnh[0]
  if (!mainImage) return ''
  return mainImage.duongDan.startsWith('http')
    ? mainImage.duongDan
    : `${VUE_BASE_URL}${mainImage.duongDan.replace('/assets', '/src/assets')}`
}
function onSearch() {
  currentPage.value = 1
  suggestions.value = []
  fetchProducts()
}
function onInputSearch(e) {
  clearTimeout(suggestTimeout)
  const query = e.target.value
  if (!query) {
    suggestions.value = []
    return
  }
  suggestTimeout = setTimeout(async () => {
    try {
      const res = await ProductService.getSuggestions(query)
      suggestions.value = res || []
    } catch {
      suggestions.value = []
    }
  }, 300)
}

function selectSuggestion(name) {
  filters.search = name
  suggestions.value = []
  onSearch()
}

async function fetchProducts() {
  try {
    const params = {
      search: filters.search,
      category: filters.category,
      brand: filters.brand,
      price: filters.price,
      page: currentPage.value,
      sort: (filters.sort === 'price_asc' || filters.sort === 'price_desc') ? filters.sort : ''
    }
    // Chỉ hiện khuyến mãi
    if (filters.sort === 'promotion') {
      params.promotion = true
    }
    const res = await ProductService.getProducts(params)
    products.value = res.products || []
    categories.value = res.categories || []
    brands.value = res.brands || []
    totalProducts.value = res.totalProducts || 0
    totalPages.value = res.totalPages || 1
  } catch (error) {
    products.value = []
    categories.value = []
    brands.value = []
    totalProducts.value = 0
    totalPages.value = 1
  }
}

async function fetchInitialData() {
  try {
    const [brandsData, categoriesData] = await Promise.all([
      ProductService.getBrands(),
      ProductService.getCategories()
    ])
    brands.value = brandsData || []
    categories.value = categoriesData || []
  } catch (error) {
    brands.value = []
    categories.value = []
  }
}

function addToCart(product) {
  alert('Đã thêm vào giỏ hàng: ' + (product.tenSanPham || product.ten_sp))
}

onMounted(async () => {
  await fetchInitialData()
  await fetchProducts()
})
</script>

<style scoped>
.hero-mini {
  background: var(--gradient);
  padding: 70px 0;
  color: white;
  margin-bottom: 30px;
}

.search-box .form-control {
  border-radius:0;
  padding: 10px 20px;
  font-size: 1.1rem;
}

.search-box .input-group {
  max-width: 800px;
  margin: 0 auto;
}

.search-box .btn {
  max-width: 850px;
  border-radius: 0;
  padding: 12px 25px;
}

.suggest-list {
  max-width: 800px;
  left: 0;
  right: 0;
  margin: 0 auto;
  z-index: 20;
  list-style: none;
  padding: 0;
  border-radius: 0 0 8px 8px;
  border: 1px solid #eee;
  border-top: none;
  max-height: 400px;
  overflow-y: auto;
  scrollbar-width: thin;
}

.suggest-list::-webkit-scrollbar {
  width: 6px;
}
.suggest-list::-webkit-scrollbar-thumb {
  background: #e0e0e0;
  border-radius: 4px;
}

.suggest-item {
  cursor: pointer;
  display: flex;
  align-items: center;
  gap: 12px;
  transition: background 0.2s;
  border-bottom: 1px solid #f3f3f3;
}
.suggest-title {
  color: #222;
}
.suggest-item:last-child {
  border-bottom: none;
}
.suggest-item:hover {
  background: #f5f7fa;
}
.suggest-thumb {
  width: 48px;
  height: 48px;
  object-fit: cover;
  border-radius: 6px;
  border: 1px solid #eee;
  margin-right: 10px;
  background: #fafafa;
}

.fade-in-up-enter-active {
  animation: fadeInUp 0.7s;
}
.fade-in-up-leave-active {
  animation: fadeOutDown 0.5s;
}
@keyframes fadeInUp {
  from { opacity: 0; transform: translateY(30px);}
  to { opacity: 1; transform: translateY(0);}
}
@keyframes fadeOutDown {
  from { opacity: 1; transform: translateY(0);}
  to { opacity: 0; transform: translateY(30px);}
}
</style>