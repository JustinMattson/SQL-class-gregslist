<template>
  <div class="dashboard">
    <h1>WELCOME TO THE DASHBOARD</h1>
    <car-form />
    <car v-for="car in cars" :key="car.id" :carData="car">
      <small>*this is your car</small>
    </car>
  </div>
</template>

<script>
import CarForm from "../components/CarForm.vue";
import Car from "../components/Car"
export default {
  mounted() {
    this.$store.dispatch("getMyCars")
  },
  computed: {
    cars() {
      return this.$store.state.myCars
    }
  },
  components: { CarForm, Car }
};
</script>

<style></style>
