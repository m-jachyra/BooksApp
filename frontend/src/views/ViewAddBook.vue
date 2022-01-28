<template>
<v-container>
  <AdminAddBook></AdminAddBook>
</v-container>
</template>


<script>
import AdminAddBook from "../components/AdminAddBook.vue";
export default{
    name: "ViewAddBook",
    components: { AdminAddBook }
}
</script>