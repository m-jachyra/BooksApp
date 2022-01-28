<template>
<v-container>
  <AdminReviewList></AdminReviewList>
</v-container>
</template>

<script>
import AdminReviewList from "../components/AdminReviewList.vue";
export default {
    name: "ViewReviewList",
    components: { AdminReviewList }
}
</script>