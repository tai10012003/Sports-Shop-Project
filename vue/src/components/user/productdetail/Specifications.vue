<template>
  <table class="table .table-specifications">
    <tbody>
      <tr>
        <td><strong>Màu sắc:</strong></td>
        <td>{{ product.mauSac || 'Chưa cập nhật' }}</td>
      </tr>
      <tr>
        <td><strong>Kích thước:</strong></td>
        <td>{{ product.kichThuoc || 'Chưa cập nhật' }}</td>
      </tr>
      <tr>
        <td><strong>Chất liệu:</strong></td>
        <td>{{ product.chatLieu || 'Chưa cập nhật' }}</td>
      </tr>
      <tr>
        <td><strong>Xuất xứ:</strong></td>
        <td>{{ product.xuatXu || 'Chưa cập nhật' }}</td>
      </tr>
      <tr>
        <td><strong>Bảo hành:</strong></td>
        <td>{{ product.baoHanh || 'Chưa cập nhật' }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script setup>
defineProps({
  product: Object
})
</script>

<style scoped>
/* Specifications Table */
.table-specifications {
    width: 100%;
    margin-bottom: 0;
}

.table-specifications td {
    padding: 1rem;
    border-color: rgba(0,0,0,0.05);
}

.table-specifications tr:nth-child(odd) {
    background-color: var(--light-color);
}


</style>