import axios from 'axios'
import AuthService from './AuthService'

const API_URL = 'http://localhost:5000/api'

axios.interceptors.request.use(
    config => {
        const user = AuthService.getCurrentUser()
        if (user?.token) {
            config.headers['Authorization'] = `Bearer ${user.token}`
        }
        config.headers['Content-Type'] = 'application/json'
        return config
    },
    error => Promise.reject(error)
)

export default {
    async getUserProfile() {
        try {
            const response = await axios.get(`${API_URL}/user/profile`)
            return response.data
        } catch (error) {
            if (error.response?.status === 401) {
                throw { message: 'Vui lòng đăng nhập lại' }
            }
            throw error.response?.data || { message: 'Không thể tải thông tin người dùng' }
        }
    },

    async updateProfile(profileData) {
        try {
            const response = await axios.put(`${API_URL}/user/profile`, profileData)
            return response.data
        } catch (error) {
            console.error('Update profile error:', error.response?.data || error.message)
            if (error.response?.status === 401) {
                throw { message: 'Vui lòng đăng nhập lại' }
            }
            throw error.response?.data || { message: 'Cập nhật thông tin thất bại' }
        }
    }
}
