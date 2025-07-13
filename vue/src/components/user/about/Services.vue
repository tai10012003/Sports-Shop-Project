<template>
     <section class="about-services">
       <div class="container">
         <h2 class="section-title mb-5">DỊCH VỤ CỦA CHÚNG TÔI</h2>
         <div class="row g-4">
           <div class="col-lg-4 col-md-6" v-for="(service, index) in services" :key="index">
             <div class="service-card">
               <img :src="service.image" :alt="service.alt" class="img-fluid">
               <div class="service-content">
                 <h4>{{ service.title }}</h4>
                 <p>{{ service.description }}</p>
                 <a href="#" class="btn btn-outline-primary">Tìm hiểu thêm</a>
               </div>
             </div>
           </div>
         </div>
       </div>
     </section>
   </template>

   <script setup>
   defineProps({
     services: {
       type: Array,
       required: true
     }
   })
   </script>

   <style scoped>
   .about-services {
      padding: 100px 0;
      background: var(--light-color);
  }
  
  .service-card {
      border-radius: 20px;
      overflow: hidden;
      box-shadow: 0 10px 30px rgba(0,0,0,0.1);
      transition: all 0.3s ease;
      height: 100%;
  }
  
  .service-card:hover {
      transform: translateY(-10px);
      box-shadow: 0 20px 40px rgba(0,0,0,0.15);
  }
  
  .service-card img {
      width: 100%;
      height: 250px;
      object-fit: cover;
  }
  
  .service-content {
    margin: 10px 0;
    line-height: 1.8;
      padding: 30px;
  }
   </style>