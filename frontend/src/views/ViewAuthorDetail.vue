<template>
  <v-container>
    <AdminAuthorDetails v-if="isAdmin" :id="$route.params.id"></AdminAuthorDetails>
    <UserAuthorDetails v-else :id="$route.params.id"></UserAuthorDetails>
  </v-container>
</template>

<script>
import UserAuthorDetails from "../components/UserAuthorDetails.vue";
import AdminAuthorDetails from "../components/AdminAuthorDetails.vue";
import { useUser } from "../use/user";
export default {
    name: "ViewAuthorDetail",
    setup() {
      const { isAdmin } = useUser()
      return {
        isAdmin
      }
    },
    components: { UserAuthorDetails, AdminAuthorDetails }
}
</script>