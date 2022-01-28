<template>
  <v-card>
    <v-card-title>Add Book</v-card-title>
    <v-card-text>
      <v-text-field v-model="book.title" label="Title"></v-text-field>
      <v-text-field v-model="book.description" label="Description"></v-text-field>
      <v-select
        v-model="book.author"
        :items="authors"
        :item-text="author => author.name"
        :item-value="author => author"
        label="Author"
      ></v-select>
      <v-select
        v-model="book.genre"
        :items="genres"
        :item-text="genre => genre.name"
        :item-value="genre => genre"
        label="Genre"
      ></v-select>
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
  name: 'AdminAddBook',
  setup() {
    const book = reactive({
      title: '',
      description: '',
      author: {},
      genre: {},
    })
    const authors = ref([])
    const genres = ref([])
    const id = ref(null)

    http.get(`/authors/`)
      .then((response) => {
        authors.value = response.data
      })

    http.get(`/genres/`)
      .then((response) => {
        genres.value = response.data
      })

    const onAdd = async () => {
      await http.post('/books', book)
        .then(response => {
          id.value = response.data.id
        })
      redirectToRoute(`/books/${id.value}`)
    }

    return {
      book,
      authors,
      genres,
      onAdd,
      redirectToRoute
    }
  }
}
</script>