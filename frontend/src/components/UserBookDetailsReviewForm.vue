<template>
  <v-container>
    <v-card>
      <v-card-title>Add Review</v-card-title>
      <v-card-text>
        <v-text-field
          v-model="review.title"
          label="Title"
        ></v-text-field>
        <v-textarea
          v-model="review.content"
          label="Content"
        >
        </v-textarea>
        <v-card-actions>
          <v-rating
          length="10"
          v-model="review.rate"
          ></v-rating>
          <v-spacer></v-spacer>
          <v-btn @click="addReview">
            Add
          </v-btn>
        </v-card-actions>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script>
import { reactive } from "@vue/composition-api"
import { http } from "../helpers/axios-instances"
import { useUser } from "../use/user"

export default {
  name: 'UserReviewForm',
  props: ['id'],
  emits: ['update'],
  setup(props, { emit }) {
    const { user } = useUser()
    const review = reactive({
      title: '',
      content: '',
      rate: 1,
      bookId: null,
      userId: null,
    })


    const addReview = async () => {
      review.userId = user.value.Id
      review.bookId = props.id
      await http.post('/reviews', review)
      emit('update')
    }

    return {
      review,
      addReview,
      user
    }
  }
}
</script>