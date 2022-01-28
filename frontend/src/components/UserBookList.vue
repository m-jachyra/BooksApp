<template>
<v-container>
    <v-list three-line>
      <v-list-item-group>
        <v-list-item v-for="book in books" :key="book.id" @click="redirectToRoute(`/books/${book.id}`)">
          <v-list-item-avatar
            tile
            height="150"
            width="100"
          >
            <v-img 
            :src="`/images/books/${book.id}.png`" 
            @error="imageLoadError" 
            max-height="200px"
            max-width="120px"
          ></v-img>
          </v-list-item-avatar>
          <v-list-item-content>
            <v-list-item-title class="text-uppercase">{{ book.title }}</v-list-item-title>
            <v-list-item-subtitle>{{ book.author.name }}</v-list-item-subtitle>
            <v-list-item-subtitle>{{ book.genre.name }}</v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>
      </v-list-item-group>
    </v-list>
</v-container>
</template>

<script>
import { ref } from "@vue/composition-api"
import { http } from "../helpers/axios-instances"
import { redirectToRoute } from "@/use/router"

export default {
  name: 'UserBookList',
  setup() {
    const books = ref([])

    http.get('/books')
      .then((response) => {
        books.value = response.data
      })
    
    const imageLoadError = e => {
      e.target.src = 'images/books/default.png'
    }

    return {
      books,
      imageLoadError,
      redirectToRoute
    }
  }
}
</script>