import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'ViewHome',
    component: () => import(/* webpackChunkName: "about" */ '@/views/ViewHome')
  },
  {
    path: '/detail',
    name: 'ViewBookDetail',
    component: () => import(/* webpackChunkName: "about" */ '@/views/ViewBookDetail')
  },
  {
    path: '/login',
    name: 'ViewLogin',
    component: () => import(/* webpackChunkName: "about" */ '@/views/ViewLogin')
  },
  {
    path: '/register',
    name: 'ViewRegister',
    component: () => import(/* webpackChunkName: "about" */ '@/views/ViewRegister')
  },
  {
    path: '/books',
    name: 'ViewBookList',
    component: () => import(/* webpackChunkName: "about" */ '@/views/ViewBookList')
  },
  {
    path: '/authors',
    name: 'ViewAuthorList',
    component: () => import(/* webpackChunkName: "about" */ '@/views/ViewAuthorList')
  },
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  },
  {
    path: '/admin/books',
    name: 'ViewAdminBookList',
    component: () => import(/* webpackChunkName: "about" */ '@/views/admin/ViewAdminBookList')
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
