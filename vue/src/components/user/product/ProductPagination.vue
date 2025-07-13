<template>
  <nav v-if="totalPages > 1" class="mt-5">
    <ul class="pagination justify-content-center">
      <li v-for="i in totalPages" :key="i" :class="['page-item', currentPage === i ? 'active' : '']">
        <a class="page-link" href="#" @click.prevent="$emit('go-to-page', i)">{{ i }}</a>
      </li>
    </ul>
  </nav>
</template>

<script setup>
defineProps(['totalPages', 'currentPage'])
defineEmits(['go-to-page'])
</script>

<style scoped>
.pagination .page-item.active .page-link {
  background-color: #007BFF;
  border-color: #007BFF;
  color: #FFFFFF;
}
</style>