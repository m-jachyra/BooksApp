<template>
<v-container v-if="isAdmin" class="text-center">
  <h1>Welcome to BooksApp admin panel</h1>
</v-container>
<v-container v-else>
  <v-row
    class="fill-height"
    align="center"
    justify="center"
  >
    <v-col 
      v-for="book in books" 
      :key="book.id"
      cols="12"
      md="4"
    >
      <v-hover v-slot="{ hover }">
        <v-card 
            :elevation="hover ? 12 : 2"
            @click="redirectToRoute(`/books/${book.id}`)"
        >
          <v-img 
            :src="`images/books/${book.id}.png`"
            height="350"
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
import { redirectToRoute } from "../use/router"
import { useUser } from "../use/user"

export default {
  name: 'ViewHome',
  setup() {
    const books = ref([])

    http.get('/books')
      .then((response) => {
        books.value = response.data
        books.value = books.value.slice(0, 9)
      })
      
    const { isAdmin } = useUser()

    return {
      books,
      isAdmin,
      redirectToRoute
    }
  }
}
</script>