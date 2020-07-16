<template>
  <div class="Cars container-fluid">
    <div class="row">
      <div class="col text-center">
        <h1 class="text-primary">Welcome To The Cars Page</h1>
      </div>
    </div>
    <div class="row">
      <car class="col-4" v-for="car in cars" :key="car.id" :carData="car" />
    </div>
  </div>
</template>

<script>
import Car from "@/components/Car"
export default {
  name: "Cars",
  mounted() {
    this.$store.dispatch("getCars")
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    cars() {
      return this.$store.state.cars
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    Car
  }
};
</script>
