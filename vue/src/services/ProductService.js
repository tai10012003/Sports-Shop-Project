import axios from 'axios'

const API_URL = 'http://localhost:5000/api'
const VUE_BASE_URL = 'http://localhost:5173'

export default {
  async getFeaturedProducts() {
    try {
      const response = await axios.get(`${API_URL}/product/featured`)
      const products = response.data.map(product => {
        const mainImage = this.getMainImage(product)
        return {
          ...product,
          mainImage
        }
      })
      return products
    } catch (error) {
      console.error('Error fetching products:', error)
      return []
    }
  },

async getProducts(params = {}) {
    try {
      const res = await axios.get(`${API_URL}/product`, { params })
      const products = Array.isArray(res.data.products) ? res.data.products : []
      const processedProducts = products.map(product => {
        const mainImage = this.getMainImage(product)
        return {
          ...product,
          mainImage
        }
      })
      return {
        products: processedProducts,
        categories: res.data.categories || [],
        brands: res.data.brands || [],
        totalProducts: res.data.totalProducts || 0,
        totalPages: res.data.totalPages || 1
      }
    } catch (error) {
      console.error('Error fetching products:', error)
      return {
        products: [],
        categories: [],
        brands: [],
        totalProducts: 0,
        totalPages: 1
      }
    }
  },
  async getBrands() {
    const res = await axios.get('/api/Brand')
    return res.data
  },
  async getCategories() {
    const res = await axios.get('/api/Category')
    return res.data
  },

async getSuggestions(query) {
    const res = await axios.get(`${API_URL}/Product/suggest`, { params: { query } })
    console.log('Suggestions API result:', res.data)
    return res.data // res.data là mảng sản phẩm
},

  getMainImage(product) {
    if (!product.hinhAnh || !product.hinhAnh.length) return null
    const mainImage = product.hinhAnh.find(img => img.anhChinh) || product.hinhAnh[0]
    if (!mainImage) return null
    const imagePath = mainImage.duongDan.replace('/assets', '/src/assets')
    return `${VUE_BASE_URL}${imagePath}`
  }
}