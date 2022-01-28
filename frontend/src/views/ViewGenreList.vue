<template>
<v-container>
  <AdminGenreList></AdminGenreList>
</v-container>
</template>

<script>
import AdminGenreList from "../components/AdminGenreList.vue";
export default {
    name: "ViewGenreList",
    components: { AdminGenreList }
}
</script>