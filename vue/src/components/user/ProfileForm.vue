<template>
  <div class="container py-5 profile-wrapper">
    <div class="row justify-content-center">
      <div class="col-lg-8">
        <!-- Alert -->
        <div
          v-if="message.show"
          :class="`alert alert-${message.type} alert-dismissible fade show`"
          role="alert"
        >
          {{ message.text }}
          <button type="button" class="btn-close" @click="message.show = false"></button>
        </div>

        <div class="account-wrapper">
          <div class="account-content">
            <div class="account-section">
              <h5 class="section-titles">
                <i class="bi bi-person-circle me-2"></i>
                THÔNG TIN CÁ NHÂN
              </h5>

              <form class="account-form" @submit.prevent="handleSubmit">
                <div class="row">
                  <!-- Họ tên -->
                  <div class="col-md-6">
                    <div class="form-group">
                      <label class="form-label" for="ho_ten">Họ và tên</label>
                      <div class="input-group">
                        <span class="input-group-text">
                          <i class="bi bi-person"></i>
                        </span>
                        <input
                          type="text"
                          id="ho_ten"
                          class="form-control"
                          v-model.trim="form.hoTen"
                          :class="{ 'is-invalid': v$.hoTen.$error }"
                          placeholder="Nhập họ tên"
                        />
                        <div class="invalid-feedback" v-if="v$.hoTen.$error">
                          <span v-if="!v$.hoTen.required">Họ tên là bắt buộc</span>
                          <span v-else-if="!v$.hoTen.minLength">Họ tên phải ít nhất 3 ký tự</span>
                          <span v-else-if="!v$.hoTen.maxLength">Họ tên tối đa 40 ký tự</span>
                        </div>
                      </div>
                    </div>
                  </div>

                  <!-- Email -->
                  <div class="col-md-6">
                    <div class="form-group">
                      <label class="form-label" for="email">Email</label>
                      <div class="input-group">
                        <span class="input-group-text">
                          <i class="bi bi-envelope"></i>
                        </span>
                        <input
                          type="email"
                          id="email"
                          class="form-control"
                          v-model.trim="form.email"
                          :class="{ 'is-invalid': v$.email.$error }"
                          placeholder="Nhập email"
                        />
                        <div class="invalid-feedback" v-if="v$.email.$error">
                          <span v-if="!v$.email.required">Email là bắt buộc</span>
                          <span v-else-if="!v$.email.email">Email không hợp lệ</span>
                          <span v-else-if="!v$.email.maxLength">Email tối đa 100 ký tự</span>
                        </div>
                      </div>
                    </div>
                  </div>

                  <!-- Số điện thoại -->
                  <div class="col-md-6">
                    <div class="form-group">
                      <label class="form-label" for="so_dien_thoai">Số điện thoại</label>
                      <div class="input-group">
                        <span class="input-group-text">
                          <i class="bi bi-phone"></i>
                        </span>
                        <input
                          type="tel"
                          id="so_dien_thoai"
                          class="form-control"
                          v-model.trim="form.soDienThoai"
                          :class="{ 'is-invalid': v$.soDienThoai.$error }"
                          placeholder="Nhập số điện thoại"
                        />
                        <div class="invalid-feedback" v-if="v$.soDienThoai.$error">
                          <span v-if="!v$.soDienThoai.maxLength">Số điện thoại tối đa 20 ký tự</span>
                          <span v-else>Định dạng số điện thoại không hợp lệ</span>
                        </div>
                      </div>
                    </div>
                  </div>

                  <!-- Địa chỉ -->
                  <div class="col-12">
                    <div class="form-group">
                      <label class="form-label" for="dia_chi">Địa chỉ</label>
                      <div class="input-group">
                        <span class="input-group-text">
                          <i class="bi bi-geo-alt"></i>
                        </span>
                        <textarea
                          id="dia_chi"
                          rows="3"
                          class="form-control"
                          v-model.trim="form.diaChi"
                          :class="{ 'is-invalid': v$.diaChi.$error }"
                          placeholder="Nhập địa chỉ"
                        ></textarea>
                        <div class="invalid-feedback" v-if="v$.diaChi.$error">
                          <span v-if="!v$.diaChi.maxLength">Địa chỉ tối đa 200 ký tự</span>
                        </div>
                      </div>
                    </div>
                  </div>

                  <!-- Submit -->
                  <div class="col-12">
                    <button type="submit" class="btn btn-primary btn-update" :disabled="loading">
                      <span v-if="loading" class="spinner-border spinner-border-sm me-2"></span>
                      <i v-else class="bi bi-check-circle me-2"></i>
                      Cập nhật thông tin
                    </button>
                  </div>
                </div>
              </form>

            </div>
          </div>
        </div>

      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, reactive, onMounted } from 'vue'
import { useVuelidate } from '@vuelidate/core'
import { required, email, maxLength, minLength } from '@vuelidate/validators'
import UserService from '@/services/UserService'

const loading = ref(false)
const message = reactive({
  show: false,
  type: 'success',
  text: ''
})

const form = reactive({
  hoTen: '',
  email: '',
  soDienThoai: '',
  diaChi: ''
})

const rules = {
  hoTen: { required, minLength: minLength(3), maxLength: maxLength(40) },
  email: { required, email, maxLength: maxLength(100) },
  soDienThoai: { maxLength: maxLength(20) },
  diaChi: { maxLength: maxLength(200) }
}

const v$ = useVuelidate(rules, form)

async function loadProfile() {
  try {
    const data = await UserService.getUserProfile()
    Object.assign(form, {
      hoTen: data.hoTen ?? '',
      email: data.email ?? '',
      soDienThoai: data.soDienThoai ?? '',
      diaChi: data.diaChi ?? ''
    })
  } catch (err) {
    message.type = 'danger'
    message.text = err.message || 'Không thể tải thông tin người dùng'
    message.show = true
  }
}

async function handleSubmit() {
  const isValid = await v$.value.$validate()
  if (!isValid) return

  try {
    loading.value = true
    await UserService.updateProfile({
        HoTen: form.hoTen,
        Email: form.email,
        SoDienThoai: form.soDienThoai,
        DiaChi: form.diaChi
    })
    message.type = 'success'
    message.text = 'Cập nhật thông tin thành công'
    message.show = true

    setTimeout(() => {
      if (message.type === 'success') {
        message.show = false
      }
    }, 2500)
  } catch (err) {
    message.type = 'danger'
    message.text = err.message || 'Cập nhật thông tin thất bại'
    message.show = true
  } finally {
    loading.value = false
  }
}

onMounted(loadProfile)
</script>

<style scoped>
/* Dùng lại style bạn đã gửi (rút gọn giữ nguyên class cũ để không vỡ layout) */

.profile-wrapper {
  min-height: 60vh;
}

.account-wrapper {
  background: white;
  border-radius: 20px;
  box-shadow: 0 5px 30px rgba(0,0,0,0.08);
  overflow: hidden;
}

.account-content {
  padding: 2rem 2rem 1rem 2rem;
}

.account-section {
  margin-bottom: 2rem;
}

.section-titles {
  font-size: 1.25rem;
  font-weight: 600;
  color: var(--primary-color);
  margin-bottom: 1.5rem;
  padding-bottom: 1rem;
  border-bottom: 2px solid var(--light-color);
  display: flex;
  align-items: center;
}

.section-titles i {
  font-size: 1.4rem;
  margin-right: 0.5rem;
}

.account-form .form-group {
  margin-bottom: 1.5rem;
}

.account-form .form-label {
  font-weight: 500;
  color: var(--dark-color);
  margin-bottom: 0.5rem;
}

.account-form .input-group-text {
  background: var(--light-color);
  border: none;
  color: var(--primary-color);
}

.account-form .form-control {
  border: 2px solid var(--light-color);
  padding: 0.75rem 1rem;
  font-size: 0.95rem;
  transition: all 0.3s ease;
}

.account-form .form-control:focus {
  border-color: var(--primary-color);
  box-shadow: 0 0 0 0.2rem rgba(0,55,128,0.1);
}

.btn-update {
  padding: 0.75rem 2rem;
  font-weight: 600;
  text-transform: uppercase;
  letter-spacing: 0.5px;
  background: var(--gradient);
  border: none;
  transition: all 0.3s ease;
}

.btn-update:hover {
  transform: translateY(-2px);
  box-shadow: 0 5px 15px rgba(0,55,128,0.2);
}
</style>
