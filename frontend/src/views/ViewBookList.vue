<template>
<v-container fluid fill-height>
  <v-layout align-center justify-center>
    <v-list three-line>
      <v-list-item v-for="book in books" :key="book.id">
        <v-img 
          :src="`/images/books/${book.id}.png`" 
          @error="replaceByDefault" 
          max-height="200px"
          max-width="120px"
        ></v-img>
        <v-list-item-content>
          <v-list-item-title>{{ book.title }}</v-list-item-title>
          <v-list-item-subtitle>{{ book.authorName }}</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>
    </v-list>
  </v-layout>
</v-container>
</template>

<script>
import { ref } from "@vue/composition-api"
import { http } from "../helpers/axios-instances"

export default {
  name: 'ViewBookList',
  setup() {
    const books = ref([])

    http.get('/books')
      .then((response) => response.data)
      .then((data) => books.value = data)

    const replaceByDefault = event => {
      event.target.src = '/images/books/default.png'
    }

    return {
      books,
      replaceByDefault
    }
  }
}
</script>