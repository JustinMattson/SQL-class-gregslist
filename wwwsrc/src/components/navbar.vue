<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light">
    <router-link class="navbar-brand" :to="{ name: 'cars' }">Gregs List</router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav mr-auto">
        <li class="nav-item" :class="{ active: $route.name == 'cars' }">
          <router-link :to="{ name: 'cars' }" class="nav-link">Cars</router-link>
        </li>
        <li
          class="nav-item"
          v-if="$auth.isAuthenticated"
          :class="{ active: $route.name == 'dashboard' }"
        >
          <router-link class="nav-link" :to="{ name: 'dashboard' }">My-Dashboard</router-link>
        </li>
        <li
          class="nav-item"
          :class="{ active: $route.name == 'mycars'}"
          v-if="$auth.isAuthenticated"
        >
          <router-link :to="{name: 'mycars'}" class="nav-link">My Favorite Cars</router-link>
        </li>
      </ul>
      <span class="navbar-text">
        <button class="btn btn-success" @click="login" v-if="!$auth.isAuthenticated">Login</button>
        <button class="btn btn-danger" @click="logout" v-else>logout</button>
      </span>
    </div>
  </nav>
</template>

<script>
import axios from "axios";
import { setBearer, resetBearer } from '../store/AxiosService';

let _api = axios.create({
  baseURL: "https://localhost:5001",
  withCredentials: true
});
export default {
  name: "Navbar",
  methods: {
    async login() {
      await this.$auth.loginWithPopup();
      // this.$store.dispatch("setBearer", this.$auth.bearer);
      setBearer(this.$auth.bearer)
    },
    async logout() {
      // this.$store.dispatch("resetBearer");
      resetBearer()
      await this.$auth.logout({ returnTo: window.location.origin });
    }
  }
};
</script>

<style></style>
