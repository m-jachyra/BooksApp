<template>
<v-container>
  <AdminBookDetails v-if="isAdmin" :id="$route.params.id"></AdminBookDetails>
  <UserBookDetails v-else :id="$route.params.id"></UserBookDetails>
</v-container>
</template>

<script>
import AdminBookDetails from "../components/AdminBookDetails.vue"
import UserBookDetails from "../components/UserBookDetails.vue";
import { useUser } from "../use/user";

export default {
  name: "ViewBookDetail",
  setup() {

    const { isAdmin } = useUser()
    return {
      isAdmin
    };
  },
  components: { AdminBookDetails, UserBookDetails }
}
</script>