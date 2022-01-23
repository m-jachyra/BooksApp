import { reactive, computed } from "@vue/composition-api"
import { loginRequest } from "@/api/auth"
import { decodeToken } from "@/helpers/jwt"

const LOCALSTORAGE_TOKEN_KEY = 'accessToken'

const state = reactive({
    user: decodeToken(localStorage.getItem(LOCALSTORAGE_TOKEN_KEY)) || null,
    accessToken: localStorage.getItem(LOCALSTORAGE_TOKEN_KEY),
    requestedRoute: null,
})

export const setToken = ({token}) => {
  const decodedToken = decodeToken(token)

  state.user = decodedToken
  state.accessToken = token
  localStorage.setItem(LOCALSTORAGE_TOKEN_KEY, token)
}

export const login = ({ username, password }) => {
  return loginRequest({ username, password })
    .then(setToken)
}

export const logout = () => {
  state.accessToken = null
  localStorage.removeItem(LOCALSTORAGE_TOKEN_KEY)
}

export const getAccessToken = () => 
  state.accessToken || 
  localStorage.getItem(LOCALSTORAGE_TOKEN_KEY)

export const useUser = () => {
  const user = computed(() => state.user)
  const isUserLogged = computed(() => state.accessToken != null) 
  const isAdmin = computed(() => state.user.role === 'Admin')

  return {
    login,
    logout,
    user,
    isUserLogged,
    isAdmin
  }
}