<template>
  <v-container>
    <v-card>
      <v-card-title>Settings</v-card-title>
      <v-card-text>Email: {{ user.email }}</v-card-text>
      <v-card-text>Username: {{ user.unique_name }}</v-card-text>
    </v-card>
  </v-container>
</template>

<script>import { useUser } from "../use/user"

export default {
  name: 'ViewSettings',
  setup() {
    const { user } = useUser()

    return {
      user
    }
  }
}
</script>