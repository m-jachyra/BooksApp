import Vue from 'vue'
import router from './router'
import vuetify from './plugins/vuetify'
import '@/plugins/composition-api';
import App from './App.vue'

Vue.config.productionTip = false

const app = new Vue({
  router,
  vuetify,
  render: h => h(App)
})

app.$mount('#app')
