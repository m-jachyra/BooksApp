import { reactive, computed } from "@vue/composition-api"
import { loginRequest } from "@/api/auth"

const LOCALSTORAGE_TOKEN_KEY = 'accessToken'

const state = reactive({
    user: null,
    accessToken: localStorage.getItem(LOCALSTORAGE_TOKEN_KEY),
    requestedRoute: null,
})

export const setToken = ({token}) => {
  state.accessToken = token
  localStorage.setItem(LOCALSTORAGE_TOKEN_KEY, token)
}

export const login = ({ username, password }) => {
  loginRequest({ username, password })
    .then(setToken)
    .catch(err => {
      console.error('Kurwa nie działa', err)
    })
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

  return {
    login,
    logout,
    user,
    isUserLogged
  }
}