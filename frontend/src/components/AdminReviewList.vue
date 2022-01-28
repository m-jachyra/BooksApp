<template>
  <v-data-table
    :headers="headers"
    :items="reviews"
    sort-by="id"
    class="elevation-1"
  >
  <template v-slot:top>
      <v-toolbar flat>
        <v-toolbar-title>Review list</v-toolbar-title>
        <v-divider
          class="mx-4"
          inset
          vertical
        ></v-divider>
        <v-spacer></v-spacer>
      </v-toolbar>
    </template>
    <template v-slot:item.actions="{ item }">
        <v-icon
          small
          @click="deleteItem(item)"
        >
          mdi-delete
        </v-icon>
      </template>
  </v-data-table>
</template>

<script>
import { http } from "@/helpers/axios-instances"
import { ref } from "@vue/composition-api"

export default {
  name: "AdminReviewList",
  setup() {
    const headers = [
      { text: 'Id', value: 'id' },
      { text: 'Title', value: 'title' },
      { text: 'Content', value: 'content' },
      { text: 'Rate', value: 'rate' },
      { text: 'Username', value: 'user.username' },
      { text: 'Actions', value: 'actions', sortable: false}
    ]
    const reviews = ref([])

    const loadReviews = () => {
      http.get('/reviews')
        .then((response) => reviews.value = response.data)
    }

    loadReviews()

    const deleteItem = async item => {
      await http.delete(`/reviews/${item.id}`)
      loadReviews()
    }

    return {
      headers,
      reviews,
      deleteItem
    }
  }
}
</script>