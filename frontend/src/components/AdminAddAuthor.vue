<template>
  <v-card>
    <v-card-title>Add Author</v-card-title>
    <v-card-text>
      <v-text-field v-model="author.authorName" label="Name"></v-text-field>
      <v-menu
        v-model="menu1"
        :close-on-content-click="false"
        :nudge-right="40"
        transition="scale-transition"
        offset-y
        min-width="auto"
      >
        <template v-slot:activator="{ on, attrs }">
          <v-text-field
            v-model="author.birthDate"
            label="Birth Date"
            prepend-icon="mdi-calendar"
            readonly
            v-bind="attrs"
            v-on="on"
          ></v-text-field>
        </template>
        <v-date-picker v-model="author.birthDate" @input="menu2 = false"></v-date-picker>
      </v-menu>
      <v-menu
        v-model="menu2"
        :close-on-content-click="false"
        :nudge-right="40"
        transition="scale-transition"
        offset-y
        min-width="auto"
      >
        <template v-slot:activator="{ on, attrs }">
          <v-text-field
            v-model="author.deathDate"
            label="Death Date"
            prepend-icon="mdi-calendar"
            readonly
            v-bind="attrs"
            v-on="on"
          ></v-text-field>
        </template>
        <v-date-picker v-model="author.deathDate" @input="menu2 = false"></v-date-picker>
      </v-menu>
      <v-textarea v-model="author.biography" label="Biography"></v-textarea>
      <v-card-actions>
        <v-btn color="primary" @click="onAdd">Add</v-btn>
      </v-card-actions>
    </v-card-text>
  </v-card>
</template>

<script>
import { reactive, ref } from "@vue/composition-api"
import { http } from "../helpers/axios-instances"
import { redirectToRoute } from "../use/router"

export default {
  name: 'AdminAddAuthor',
  setup() {
    const author = reactive({
      authorName: '',
      birthDate: null,
      deathDate: null,
      biography: ''
    })
    const menu1 = ref(false)
    const menu2 = ref(false)
    const id = ref(null)

    const onAdd = async () => {
      await http.post('/authors', author)
        .then(response => {
          id.value = response.data.id
        })
      redirectToRoute(`/authors/${id.value}`)
    }

    return {
      menu1,
      menu2,
      author,
      onAdd,
      redirectToRoute
    }
  }
}
</script>