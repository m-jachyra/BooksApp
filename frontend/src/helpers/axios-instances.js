import axios from "axios"
import { logout, getAccessToken, setToken } from "@/use/user"
import { isTokenValid } from "./jwt";
import { refreshTokenRequest } from "@/api/auth";
import { redirectToRoute } from "@/use/router";

export const http = axios.create({
    baseURL: `${process.env.VUE_APP_API_PREFIX}/api`
})

// Response interceptor
http.interceptors.response.use(
    response => response,
    error => {
      if (error.response?.status === 401) {
        logout()
        redirectToRoute('/login')
      }
      console.error(error.response);
  
      return Promise.reject(error);
    },
  );

// Request interceptor
http.interceptors.request.use(config => {
    if (Object.hasOwnProperty.call(config.headers, 'Authorization')) {
      console.log('jest już Authorization')
      return config;
    }

    console.log('pobieramy access token')
  
    const accessToken = getAccessToken();
    console.log('token jest')
    if (isTokenValid(accessToken)) {
      console.log('token jest valid')
      config.headers.Authorization = `Bearer ${accessToken}`;
  
      return config;
    }

    console.log('token nie jest valid, ale może refresh')
  
    refreshTokenRequest().then(setToken)
  
    return config;
});

export const auth = axios.create({
    baseURL: `${process.env.VUE_APP_API_PREFIX}/api/auth`
})