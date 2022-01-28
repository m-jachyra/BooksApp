<template>
  <v-container>
    <AdminGenreDetails :id="$route.params.id"></AdminGenreDetails>
  </v-container>
</template>

<script>
import { useUser } from "../use/user";
import AdminGenreDetails from "../components/AdminGenreDetails.vue";
export default {
    name: "ViewGenreDetail",
    setup() {
      const { isAdmin } = useUser()
      return {
        isAdmin
      }
    },
    components: { AdminGenreDetails }
}
</script>