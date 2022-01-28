<template>
  <v-card>
    <v-alert v-if="success" color="green">Successfully updated</v-alert>
    <v-card-title>Author Details</v-card-title>
    <v-card-text>
    <v-text-field 
      v-model="author.id"
      readonly
    ></v-text-field>
    <v-text-field
      v-model="author.authorName"
    ></v-text-field>
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
    <v-textarea
      v-model="author.biography"
    ></v-textarea>
    <v-card-actions>
      <v-btn color="primary" @click="onUpdate">Update</v-btn>
      <v-btn color="error" @click="onDelete">Delete</v-btn>
    </v-card-actions>
    </v-card-text>
  </v-card>
</template>

<script>
import { ref } from "@vue/composition-api"
import { http } from "../helpers/axios-instances"
import { redirectToRoute } from "../use/router"

export default {
  name: 'AdminAuthorDetails',
  props: ['id'],
  setup(props) {
    const author = ref({})
    const menu1 = ref(false)
    const menu2 = ref(false)
    const success = ref(false)

    http.get(`/authors/${props.id}`)
      .then((response) => {
        author.value = response.data
        author.value.birthDate = author.value.birthDate.substring(0, 10)
        author.value.deathDate = author.value.deathDate.substring(0, 10)
      })

    const onUpdate = async () => {
      await http.put(`/authors/${props.id}`, author.value)
      success.value = true
    }

    const onDelete = async () => {
      await http.delete(`/authors/${props.id}`)
      redirectToRoute('/authors')
    }
    

    return {
      author,
      onUpdate,
      onDelete,
      success,
      menu1,
      menu2
    }
  }
}
</script>