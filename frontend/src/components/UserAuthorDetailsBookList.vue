<template>
  <v-container>
  <v-list>
    <v-list-item-group>
      <v-list-item v-for="book in books" :key="book.id">
        <v-list-item-content>
          <v-list-item-title>{{ book.title }}</v-list-item-title>
          <v-list-item-subtitle>{{ book.genre.name }}</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>
    </v-list-item-group>
  </v-list>
  </v-container>
</template>

<script>
export default {
  name: 'UserAuthorDetailsBookList',
  props: ['books']
}
</script>