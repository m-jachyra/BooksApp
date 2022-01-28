<template>
  <v-container>
    <v-card>
      <v-card-title>
        {{ book.title }}
      </v-card-title>
      <v-card-subtitle>
        {{ book.author.name }}
      </v-card-subtitle>
      <v-card-text>
        {{ book.description }}
      </v-card-text>
    </v-card>
    <UserBookDetailsReviewForm :id="book.id" @update="fetchReviews"></UserBookDetailsReviewForm>
    <UserBookDetailsReviewList :reviews="reviews"></UserBookDetailsReviewList>
  </v-container>
</template>

<script>import { ref } from "@vue/composition-api"
import { http } from "../helpers/axios-instances"
import UserBookDetailsReviewList from "./UserBookDetailsReviewList.vue"
import UserBookDetailsReviewForm from "./UserBookDetailsReviewForm.vue";

export default {
  name: "UserBookDetails",
  props: ["id"],
  setup(props) {
    const book = ref({});
    const reviews = ref([]);
    http.get(`/books/${props.id}`)
      .then(response => {
        book.value = response.data;
      });


    const fetchReviews = () => {
      http.get(`/books/${props.id}/reviews`)
        .then(response => {
          reviews.value = response.data;
        });
    }

    fetchReviews()

    return {
      book,
      reviews,
      fetchReviews
    };
  },
  components: { UserBookDetailsReviewList, UserBookDetailsReviewForm }
}
</script>
