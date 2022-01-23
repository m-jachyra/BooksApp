<template>
  <v-app>
    
    <LogoutNav v-if="!isUserLogged"></LogoutNav>
    <template v-else>
      <UserNav v-if="!isAdmin"></UserNav>
      <AdminNav v-else></AdminNav>
    </template>
    
    <v-main>
      <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script>
import { ref } from "@vue/composition-api";
import { useUser } from "./use/user";
import LogoutNav from "./components/LogoutNav.vue";
import AdminNav from "./components/AdminNav.vue";
import UserNav from "./components/UserNav.vue";

export default {
    name: "App",
    setup() {
        const sidebar = ref(false);
        const { isUserLogged, isAdmin } = useUser();

        return {
            sidebar,
            isUserLogged,
            isAdmin,
        };
    },
    components: { LogoutNav, AdminNav, UserNav }
};
</script>

<style></style>
