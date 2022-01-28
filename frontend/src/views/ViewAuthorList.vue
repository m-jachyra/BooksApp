<template>
<v-container>
  <AdminAuthorList v-if="isAdmin"></AdminAuthorList>
  <UserAuthorList v-else></UserAuthorList>
</v-container>
</template>

<script>
import { ref } from "@vue/composition-api"
import { http } from "../helpers/axios-instances"
import AdminAuthorList from "../components/AdminAuthorList.vue"
import { useUser } from "../use/user";
import UserAuthorList from "../components/UserAuthorList.vue";

export default {
  name: "ViewAuthorList",
  setup() {
    const authors = ref([]);
    http.get("/books")
      .then((response) => {
        authors.value = response.data
      })

    const replaceByDefault = event => {
      event.target.src = "/images/authors/default.png";
    };
    const { isAdmin } = useUser()
    return {
      authors,
      replaceByDefault,
      isAdmin
    };
  },
  components: { AdminAuthorList, UserAuthorList }
}
</script>