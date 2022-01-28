<template>
  <v-container>
    <v-card>
      <v-card-title>
        {{ author.authorName }}
      </v-card-title>
      <v-card-subtitle>
        {{ author.birthDate.substring(0, 10) }} | {{ author.deathDate ? author.deathDate.substring(0, 10) : '' }}
      </v-card-subtitle>
      <v-card-text>
        {{ author.biography }}
      </v-card-text>
    </v-card>
    <UserAuthorDetailsBookList :books="books"></UserAuthorDetailsBookList>
  </v-container>
</template>

<script>import { ref } from "@vue/composition-api"
import { http } from "../helpers/axios-instances"
import UserAuthorDetailsBookList from "./UserAuthorDetailsBookList.vue";

export default {
    name: "UserBookDetails",
    props: ["id"],
    setup(props) {
        const author = ref({});
        const books = ref([]);
        
        http.get(`/authors/${props.id}`)
            .then(response => {
            console.log(author.value);
            author.value = response.data;
        });

        http.get(`/authors/${props.id}/books`)
          .then(response => {
            books.value = response.data;
          });

        return {
            author,
            books
        };
    },
    components: { UserAuthorDetailsBookList }
}
</script>
