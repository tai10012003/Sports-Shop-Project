<template>
  <div class="about-page">
    <AboutHero />
    <AboutStory />
    <AboutMission :missions="missions" />
    <AboutValues :values="values" />
    <Statistics :stats="stats" />
    <AboutServices :services="services" />
    <AboutCta />
  </div>
</template>

<script setup>
import AboutHero from '@/components/user/about/Hero.vue'
import AboutStory from '@/components/user/about/Story.vue'
import AboutMission from '@/components/user/about/Mission.vue'
import AboutValues from '@/components/user/about/Values.vue'
import AboutServices from '@/components/user/about/Services.vue'
import Statistics from '@/components/user/Statistics.vue'
import AboutCta from '@/components/user/about/Cta.vue'

const missions = [
  {
    icon: 'bi bi-bullseye',
    title: 'Tầm Nhìn',
    description: 'Trở thành thương hiệu số 1 về thiết bị thể thao cao cấp tại Việt Nam.'
  },
  {
    icon: 'bi bi-flag',
    title: 'Sứ Mệnh',
    description: 'Nâng cao chất lượng cuộc sống của cộng đồng thông qua thể thao.'
  },
  {
    icon: 'bi bi-heart',
    title: 'Giá Trị Cốt Lõi',
    description: 'Chất lượng - Uy tín - Tận tâm - Sáng tạo.'
  }
]

const values = [
  {
    icon: 'bi bi-heart-fill',
    title: 'Tận Tâm',
    description: 'Luôn đặt khách hàng làm trọng tâm trong mọi hoạt động'
  },
  {
    icon: 'bi bi-shield-check',
    title: 'Uy Tín',
    description: 'Cam kết chất lượng và độ tin cậy trong từng sản phẩm'
  },
  {
    icon: 'bi bi-lightning-charge',
    title: 'Năng Động',
    description: 'Không ngừng đổi mới để mang lại trải nghiệm tốt nhất'
  }
]

const services = [
  {
    image: 'images/about/service1.jpg',
    alt: 'Tư vấn thiết kế phòng gym',
    title: 'Tư Vấn Thiết Kế Phòng Gym',
    description: 'Đội ngũ chuyên gia giàu kinh nghiệm sẽ giúp bạn thiết kế phòng gym theo không gian và ngân sách.'
  },
  {
    image: 'images/about/service2.jpg',
    alt: 'Bảo trì thiết bị',
    title: 'Bảo Trì Thiết Bị',
    description: 'Dịch vụ bảo trì, sửa chữa thiết bị thể thao chuyên nghiệp với đội ngũ kỹ thuật viên tay nghề cao.'
  },
  {
    image: 'images/about/service3.jpg',
    alt: 'Cho thuê thiết bị',
    title: 'Cho Thuê Thiết Bị',
    description: 'Dịch vụ cho thuê thiết bị thể thao ngắn và dài hạn với đa dạng lựa chọn phù hợp nhu cầu.'
  }
]

const stats = [
  { number: '5000+', label: 'Khách hàng hài lòng' },
  { number: '1000+', label: 'Sản phẩm đa dạng' },
  { number: '15+', label: 'Năm kinh nghiệm' },
  { number: '50+', label: 'Thương hiệu hợp tác' }
]
</script>

<style scoped>
.about-page {
  background: var(--light-color);
}
</style>