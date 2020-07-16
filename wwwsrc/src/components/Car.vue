<template>
  <div class="car">
    <div
      class="border rounded shadow"
      @click="$router.push({name: 'carDetails', params: {carId: carData.id}})"
    >
      <h1>{{carData.make}}</h1>
      <h2>{{carData.model}}</h2>
      <img :src="carData.imgUrl" class="img-fluid" />
      <h2>{{carData.price}}</h2>
      <h2>{{carData.year}}</h2>
      <h2>{{carData.body}}</h2>

      <button
        type="button"
        class="btn btn-outline-danger"
        @click="removeFav"
        v-if="isFavorite"
      >Remove Favorite</button>
      <button
        type="button"
        class="btn btn-outline-success"
        @click="addToFav"
        v-else
      >Add to Favorites</button>
      <slot></slot>
    </div>
  </div>
</template>

<script>
export default {
  name: "Car",
  props: ["carData"],
  data() {
    return {
      favId: ""
    }
  },
  computed: {
    isFavorite() {
      let car = this.$store.state.myFavoriteCars.find(c => c.id == this.carData.id)
      if (car == null) {
        return false;
      }
      this.favId = car.favoriteId
      return true;
    }
  },
  methods: {
    addToFav() {
      event.stopPropagation();
      this.$store.dispatch("addFav", { carId: this.carData.id })
    },
    removeFav() {
      event.stopPropagation();
      this.$store.dispatch("removeFav", this.favId)
    }
  }
}
</script>

<style>
</style>