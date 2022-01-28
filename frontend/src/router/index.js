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
    path: '/books/:id',
    name: 'ViewBookDetail',
    component: () => import(/* webpackChunkName: "about" */ '@/views/ViewBookDetail')
  },
  {
    path: '/authors/:id',
    name: 'ViewAuthorDetail',
    component: () => import(/* webpackChunkName: "about" */ '@/views/ViewAuthorDetail')
  },
  {
    path: '/reviews/:id',
    name: 'ViewReviewDetail',
    component: () => import(/* webpackChunkName: "about" */ '@/views/ViewReviewDetail')
  },
  {
    path: '/genres/:id',
    name: 'ViewGenreDetail',
    component: () => import(/* webpackChunkName: "about" */ '@/views/ViewGenreDetail')
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
    path: '/reviews',
    name: 'ViewReviewList',
    component: () => import(/* webpackChunkName: "about" */ '@/views/ViewReviewList')
  },
  {
    path: '/genres',
    name: 'ViewGenreList',
    component: () => import(/* webpackChunkName: "about" */ '@/views/ViewGenreList')
  },
  {
    path: '/add-book',
    name: 'ViewAddBook',
    component: () => import(/* webpackChunkName: "about" */ '@/views/ViewAddBook')
  },
  {
    path: '/add-author',
    name: 'ViewAddAuthor',
    component: () => import(/* webpackChunkName: "about" */ '@/views/ViewAddAuthor')
  },
  {
    path: '/add-genre',
    name: 'ViewAddGenre',
    component: () => import(/* webpackChunkName: "about" */ '@/views/ViewAddGenre')
  },
  {
    path: '/settings',
    name: 'ViewSettings',
    component: () => import(/* webpackChunkName: "about" */ '@/views/ViewSettings')
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
