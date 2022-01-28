<template>
  <v-card>
    <v-card-title>Add Genre</v-card-title>
    <v-card-text>
      <v-text-field v-model="genre.genreName" label="Name"></v-text-field>
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
  name: 'AdminAddGenre',
  setup() {
    const genre = reactive({
      genreName: '',
    })
    const id = ref(null)


    const onAdd = async () => {
      await http.post('/genres', genre)
        .then(response => {
          id.value = response.data.id
        })
      redirectToRoute(`/genres/${id.value}`)
    }

    return {
      genre,
      onAdd,
      redirectToRoute
    }
  }
}
</script>