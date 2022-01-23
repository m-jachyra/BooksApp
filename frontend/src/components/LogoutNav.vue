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
        to="/login">
        <v-icon left dark>mdi-lock-open</v-icon>
        Login
      </v-btn>
      <v-btn
        text
        to="/register">
        <v-icon left dark>mdi-account-circle</v-icon>
        Register
      </v-btn>
    </v-toolbar-items>
  </v-app-bar>
</template>

<script>
export default {
  name: 'UserNav',
}
</script>