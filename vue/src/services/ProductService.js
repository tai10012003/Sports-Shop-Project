import axios from 'axios'

const API_URL = 'http://localhost:5000/api'
const VUE_BASE_URL = 'http://localhost:5173'

export default {
    async getFeaturedProducts() {
        try {
            // console.log('Calling featured products API...')
            const response = await axios.get(`${API_URL}/product/featured`)
            // console.log('API Response:', response.data)

            const products = response.data.map(product => {
                // console.log('Processing product:', product.maSanPham)
                // console.log('Product images:', product.hinhAnh)
                const mainImage = this.getMainImage(product)
                // console.log('Main image URL:', mainImage)
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

    getMainImage(product) {
        if (!product.hinhAnh?.length) return null
        
        const mainImage = product.hinhAnh.find(img => img.anhChinh)
        if (!mainImage) return null

        // Chuyển đường dẫn về thư mục assets của Vue
        const imagePath = mainImage.duongDan.replace('/assets', '/src/assets')
        return `${VUE_BASE_URL}${imagePath}`
    }
}
