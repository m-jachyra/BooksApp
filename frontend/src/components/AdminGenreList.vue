<template>
  <v-data-table
    :headers="headers"
    :items="genres"
    sort-by="id"
    class="elevation-1"
    @click:row="handleClick"
  >
    <template v-slot:top>
      <v-toolbar flat>
        <v-toolbar-title>Genre list</v-toolbar-title>
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
          @click="redirectToRoute('add-genre')"
        >
          New genre
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
  name: "AdminGenreList",
  setup() {
    const headers = [
      { text: 'Id', value: 'id' },
      { text: 'Name', value: 'name' }
    ]
    const genres = ref([])

    http.get('/genres')
      .then((response) => {
        genres.value = response.data
    })

    const handleClick = (row) => {
      redirectToRoute(`/genres/${row.id}`)
    }

    return {
      headers,
      genres,
      handleClick,
      redirectToRoute
    }
  }
}
</script>