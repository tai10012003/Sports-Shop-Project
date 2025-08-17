import axios from 'axios'

const API_URL = 'http://localhost:5000/api'

export default {
    async login(credentials) {
        try {
            const response = await axios.post(`${API_URL}/auth/login`, credentials)
            if (response.data.token) {
                localStorage.setItem('user', JSON.stringify(response.data))
            }
            return response.data
        } catch (error) {
            throw error.response?.data || { message: 'Đăng nhập thất bại' }
        }
    },

    async register(registerData) {
      try {
          const response = await axios.post(`${API_URL}/auth/register`, {
              tenDangNhap: registerData.tenDangNhap,
              hoTen: registerData.hoTen,
              email: registerData.email,
              matKhau: registerData.matKhau,
              soDienThoai: registerData.soDienThoai || null,
              diaChi: registerData.diaChi || null
          })
          return response.data
        } catch (error) {
            throw error.response?.data || { message: 'Đăng ký thất bại' }
        }
    },

    logout() {
        localStorage.removeItem('user')
    },

    getCurrentUser() {
        const user = localStorage.getItem('user')
        return user ? JSON.parse(user) : null
    },

    checkAuth() {
        const user = this.getCurrentUser()
        if (!user || !user.token) return false
        try {
            const payload = JSON.parse(atob(user.token.split('.')[1]))
            const expirationTime = payload.exp * 1000
            if (Date.now() >= expirationTime) {
                localStorage.removeItem('user')
                return false
            }
            return true
        } catch (error) {
            console.error('Error checking JWT:', error)
            localStorage.removeItem('user')
            return false
        }
    },

    isLoggedIn() {
        return this.checkAuth()
    }
}