<template>
<v-container>
    <v-list three-line>
      <v-list-item-group>
        <v-list-item v-for="author in authors" :key="author.id" @click="redirectToRoute(`/authors/${author.id}`)">
          <v-list-item-avatar
            tile
            height="150"
            width="100"
          >
            <v-img 
            :src="`/images/authors/${author.id}.png`" 
            @error="imageLoadError" 
            max-height="200px"
            max-width="120px"
          ></v-img>
          </v-list-item-avatar>
          <v-list-item-avatar
            tile
            height="150"
            width="100"
          >
            <v-img 
            :src="`/images/authors/${authors.id}.png`" 
            @error="imageLoadError" 
            max-height="200px"
            max-width="120px"
          ></v-img>
          </v-list-item-avatar>
          <v-list-item-content>
            <v-list-item-title>{{ author.name }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list-item-group>
    </v-list>
</v-container>
</template>

<script>
import { ref } from "@vue/composition-api"
import { http } from "../helpers/axios-instances"
import { redirectToRoute } from "@/use/router"

export default {
  name: 'UserAuthorList',
  setup() {
    const authors = ref([])

    http.get('/authors')
      .then((response) => {
        authors.value = response.data
      })
    
    const imageLoadError = e => {
      e.target.src = 'images/authors/default.png'
    }

    return {
      authors,
      imageLoadError,
      redirectToRoute
    }
  }
}
</script>