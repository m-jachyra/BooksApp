<template>
<v-container>
  <v-row>
    <v-col v-for="book in books" :key="book.id">
      <v-hover v-slot="{ hover }">
        <v-card 
            :elevation="hover ? 12 : 2"
            height="350"
            max-width="350"
        >
          <v-img 
            :src="`/images/books/${book.id}.png`" 
            @error="replaceByDefault" 
          >
          </v-img>
          <v-card-title class="text-h6">
              <v-row 
                class="fill-height ma-0"
                align="center"
                justify="center"
              >
                <p class="mt-4 subheading text-left">
                  {{ book.title }}
                </p>
              </v-row>
          </v-card-title>
        </v-card>
      </v-hover>
    </v-col>
  </v-row>
</v-container>
</template>

<script>
import { ref } from "@vue/composition-api"
import { http } from "../helpers/axios-instances"

export default {
  name: 'ViewHome',
  setup() {
    const books = ref([])

    http.get('/books')
      .then((response) => response.data)
      .then((data) => books.value = data)

    console.log(books.value)

    const replaceByDefault = event => {
      event.target.src = '/images/books/default.png'
    }

    console.log("TUTAJ")
    console.log(books.value)

    return {
      books,
      replaceByDefault
    }
  }
}
</script>