<template>
  <div class="my-cars row justify-content-center">
    <car class="col-4 border rounded" v-for="car in cars" :key="car.id" :carData="car" />
  </div>
</template>


<script>
import Car from "@/components/Car"
export default {
  name: "my-cars",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getMyFavoriteCars");
  },
  computed: {
    cars() {
      //   return this.$store.state.myCars;
      return this.$store.state.myFavoriteCars;
    }
  },
  methods: {},
  components: { Car }
};
</script>


<style lang="scss" scoped>
</style>