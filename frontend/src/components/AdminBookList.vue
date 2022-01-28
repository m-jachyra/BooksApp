<template>
  <v-data-table
    :headers="headers"
    :items="books"
    sort-by="id"
    class="elevation-1"
    @click:row="handleClick"
  >
    <template v-slot:top>
      <v-toolbar flat>
        <v-toolbar-title>Book list</v-toolbar-title>
        <v-divider
          class="mx-4"
          inset
          vertical
        ></v-divider>
        <v-spacer></v-spacer>
        <v-btn
          color="primary"
          dark
          class="mb-2"
          @click="redirectToRoute('add-book')"
        >
          New book
        </v-btn>
      </v-toolbar>
    </template>
  </v-data-table>
</template>

<script>
import { http } from "@/helpers/axios-instances"
import { ref } from "@vue/composition-api"
import { redirectToRoute } from "@/use/router"


export default {
  name: "AdminBookList",
  setup() {
    const headers = [
      { text: 'Id', value: 'id' },
      { text: 'Title', value: 'title' },
      { text: 'Author Name', value: 'author.name' },
      { text: 'Genre Name', value: 'genre.name' },
    ]
    const books = ref([])

    http.get('/books')
      .then((response) => {
        books.value = response.data
    })

    const handleClick = (row) => {
      redirectToRoute(`/books/${row.id}`)
    }

    return {
      headers,
      books,
      handleClick,
      redirectToRoute
    }
  }
}
</script>