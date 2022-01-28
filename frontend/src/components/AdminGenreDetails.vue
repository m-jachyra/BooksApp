<template>
  <v-card>
    <v-alert v-if="success" color="green">Successfully updated</v-alert>
    <v-card-title>Genre Details</v-card-title>
    <v-card-text>
      <v-text-field v-model="genre.id" readonly label="Id"></v-text-field>
      <v-text-field v-model="genre.name" label="Name"></v-text-field>
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
  name: 'AdminGenreDetails',
  props: ['id'],
  setup(props) {
    const genre = ref({})
    const success = ref(false)

    http.get(`/genres/${props.id}`)
      .then((response) => {
        genre.value = response.data
      })

    const onUpdate = async () => {
      await http.put(`/genres/${props.id}`, genre.value)
      success.value = true
    }

    const onDelete = async () => {
      await http.delete(`/genres/${props.id}`)
      redirectToRoute('/genres')
    }

    return {
      genre,
      onUpdate,
      onDelete,
      success
    }
  }
}
</script>