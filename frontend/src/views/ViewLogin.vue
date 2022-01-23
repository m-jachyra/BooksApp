<template>
  <v-main>
    <v-container fluid fill-height>
      <v-layout align-center justify-center>
        <v-flex xs12 sm8 md4>
          <v-card class="elevation-12">
            <v-toolbar dark color="primary">
              <v-toolbar-title>Login form</v-toolbar-title>
            </v-toolbar>
            <v-card-text>
              <form @submit.prevent="onSubmit">
                <v-text-field
                  v-model="form.username"
                  name="username"
                  label="Username"
                  type="text"
                ></v-text-field>
                <v-text-field
                  v-model="form.password"
                  id="password"
                  name="password"
                  label="Password"
                  type="password"
                ></v-text-field>
                <p v-if="isError" class="red--text">Wrong username or password.</p>
                <v-btn color="primary" type="submit">Login</v-btn>
              </form>
            </v-card-text>
          </v-card>
        </v-flex>
      </v-layout>
    </v-container>
  </v-main>
</template>

<script>
import { reactive, ref } from "@vue/composition-api"
import { redirectToRoute } from "@/use/router"
import { useUser } from '@/use/user'

export default {
  name: 'ViewLogin',
  setup() {
    const form = reactive({
      username: null,
      password: null
    })

    const { login } = useUser()
    const isError = ref(false)

    const onSubmit = () => {
      isError.value = false
      login(form).then(() => {
        redirectToRoute('/')
      })
      .catch(() => {
        isError.value = true
      });
    }

    return {
      form,
      onSubmit,
      isError
    }
  }
}
</script>