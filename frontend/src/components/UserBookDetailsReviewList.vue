<template>
  <v-container>
  <v-list>
    <v-list-item-group>
      <v-list-item v-for="review in reviews" :key="review.id">
        <v-list-item-icon>
          <v-icon v-text="`mdi-numeric-${review.rate}-circle`"></v-icon>
        </v-list-item-icon>
        <v-list-item-content>
          <v-list-item-title>{{ review.title }}</v-list-item-title>
          <v-list-item-subtitle>{{ review. content }}</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>
    </v-list-item-group>
  </v-list>
</v-container>
</template>

<script>
export default {
  name: 'UserBookDetailsReviewList',
  props: ['reviews']
}
</script>