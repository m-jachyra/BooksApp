<template>
<v-container class="pa-4 text-center">
  
</v-container>
</template>

<script>
import { ref } from "@vue/composition-api"
import { http } from "../helpers/axios-instances"

export default {
  name: 'ViewAuthorList',
  setup() {
    const authors = ref([])

    http.get('/books')
      .then((response) => response.data)
      .then((data) => {
        authors.value = data
        console.log(authors.value)
      })

    const replaceByDefault = event => {
      event.target.src = '/images/authors/default.png'
    }

    return {
      authors,
      replaceByDefault
    }
  }
}
</script>