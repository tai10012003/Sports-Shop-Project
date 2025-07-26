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

    isLoggedIn() {
        return !!this.getCurrentUser()
    }
}