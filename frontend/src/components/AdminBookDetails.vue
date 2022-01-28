<template>
  <v-card>
    <v-alert v-if="success" color="green">Successfully updated</v-alert>
    <v-card-title>Book Details</v-card-title>
    <v-card-text>
    <v-text-field 
      v-model="book.id"
      readonly
    ></v-text-field>
    <v-text-field
      v-model="book.title"
    ></v-text-field>
    <v-text-field
      v-model="book.description"
    ></v-text-field>
    <v-select
      v-model="book.author"
      :items="authors"
      :item-text="author => author.name"
      :item-value="author => author"
    ></v-select>
    <v-select
      v-model="book.genre"
      :items="genres"
      :item-text="genre => genre.name"
      :item-value="genre => genre"
    ></v-select>
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
  name: 'AdminBookDetails',
  props: ['id'],
  setup(props) {
    const book = ref({})
    const authors = ref([])
    const genres = ref([])
    const success = ref(false)

    http.get(`/books/${props.id}`)
      .then((response) => {
        book.value = response.data
      })
    
    http.get(`/authors/`)
      .then((response) => {
        authors.value = response.data
      })
    
    http.get(`/genres/`)
      .then((response) => {
        genres.value = response.data
      })

    const onUpdate = async () => {
      await http.put(`/books/${props.id}`, book.value)
      success.value = true
    }

    const onDelete = async () => {
      await http.delete(`/books/${props.id}`)
      redirectToRoute('/books')
    }
    

    return {
      book,
      authors,
      genres,
      onUpdate,
      onDelete,
      success
    }
  }
}
</script>