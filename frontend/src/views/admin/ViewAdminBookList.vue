<template>
  <v-data-table
    :headers="headers"
    :items="books"
    sort-by="calories"
    class="elevation-1"
  >
  </v-data-table>
</template>

<script>
import { http } from "../../helpers/axios-instances"
import { ref } from "@vue/composition-api"

export default {
  name: "ViewAdminBookList",
  setup() {
    const headers = [
      { text: 'Id', value: 'id' },
      { text: 'Title', value: 'title' },
      { text: 'Author Name', value: 'authorName' },
      { text: 'Genre Name', value: 'genreName' },
    ]
    const books = ref([])

    http.get('/books')
      .then((response) => books.value = response.data)

    return {
      headers,
      books
    }
  }
}
</script>