<template>
  <v-data-table
    :headers="headers"
    :items="authors"
    sort-by="id"
    class="elevation-1"
    @click:row="handleClick"
  >
    <template v-slot:top>
      <v-toolbar flat>
        <v-toolbar-title>Author list</v-toolbar-title>
        <v-divider class="mx-4" inset vertical></v-divider>
        <v-spacer></v-spacer>
        <v-btn color="primary" dark class="mb-2" @click="redirectToRoute('add-author')">New Author</v-btn>
      </v-toolbar>
    </template>
  </v-data-table>
</template>

<script>
import { http } from "@/helpers/axios-instances"
import { ref } from "@vue/composition-api"
import { redirectToRoute } from "@/use/router"

export default {
  name: "AdminAuthorList",
  setup() {
    const headers = [
      { text: 'Id', value: 'id' },
      { text: 'Name', value: 'name' },
    ]
    const authors = ref([])

    http.get('/authors')
      .then((response) => authors.value = response.data)

    const handleClick = (row) => {
      redirectToRoute(`/authors/${row.id}`)
    }

    return {
      headers,
      authors,
      handleClick,
      redirectToRoute
    }
  }
}
</script>