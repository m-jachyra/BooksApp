<template>
<v-container>
  <AdminBookList v-if="isAdmin"></AdminBookList>
  <UserBookList v-else></UserBookList>
</v-container>
</template>

<script>
import UserBookList from "@/components/UserBookList.vue"
import { useUser } from "@/use/user";
import AdminBookList from "@/components/AdminBookList.vue";

export default {
    name: "ViewBookList",
    setup() {
        const { isAdmin } = useUser();
        return {
            isAdmin
        };
    },
    components: { UserBookList, AdminBookList }
}
</script>