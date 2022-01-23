<template>
<v-app-bar app>
  <span class="hidden-sm-and-up">
    <v-app-bar-nav-icon @click="sidebar = !sidebar">
      </v-app-bar-nav-icon>
    </span>
    <v-toolbar-title>
      <v-btn text to="/">
        BooksApp
      </v-btn>
    </v-toolbar-title>
    <v-spacer></v-spacer>
    <v-toolbar-items class="hidden-xs-only">
      <v-btn
        text
        to="/books">
        <v-icon left dark>mdi-book</v-icon>
        Books
      </v-btn>
      <v-btn
        text
        to="/authors">
        <v-icon left dark>mdi-account-tie</v-icon>
        Authors
      </v-btn>
      <v-btn
        text
        to="/reviews">
        <v-icon left dark>mdi-star</v-icon>
        Reviews
      </v-btn>
      <v-btn
        text
        to="/users">
        <v-icon left dark>mdi-account</v-icon>
        Users
      </v-btn>
      <v-btn
        text
        to="/settings">
        <v-icon left dark>mdi-cog</v-icon>
        Settings
      </v-btn>
      <v-btn
        text
        to="/login"
        @click="logout">
        <v-icon left dark>mdi-door</v-icon>
        Logout
      </v-btn>
    </v-toolbar-items>
  </v-app-bar>
</template>

<script>
import { useUser } from "../use/user"

export default {
  name: 'AdminNav',
  setup() {
    const {isUserLogged, logout} = useUser();

    return {
      isUserLogged,
      logout
    }
  }
}
</script>