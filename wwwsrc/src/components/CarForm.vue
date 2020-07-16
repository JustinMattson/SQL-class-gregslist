<template>
  <div class="car-form">
    <form @submit.prevent="createCar">
      <div class="form-group">
        <label for="make">Make</label>
        <input
          type="text"
          name="make"
          class="form-control"
          placeholder="Enter make...."
          v-model="newCar.make"
        />
      </div>
      <div class="form-group">
        <label for="model">Model</label>
        <input
          type="text"
          name="model"
          class="form-control"
          placeholder="Enter model...."
          v-model="newCar.model"
        />
      </div>
      <div class="form-group">
        <label for="year">year</label>
        <input
          type="number"
          name="year"
          class="form-control"
          placeholder="Enter year...."
          v-model.number="newCar.year"
        />
      </div>
      <div class="form-group">
        <label for="price">price</label>
        <input
          type="number"
          name="price"
          class="form-control"
          placeholder="Enter price...."
          v-model.number="newCar.price"
        />
      </div>
      <div class="form-group">
        <label for="imgUrl">imgUrl</label>
        <input
          type="text"
          name="imgUrl"
          class="form-control"
          placeholder="Enter imgUrl...."
          v-model="newCar.imgUrl"
        />
      </div>
      <div class="form-group">
        <label for="body">body</label>
        <input
          type="text"
          name="body"
          class="form-control"
          placeholder="Enter body...."
          v-model="newCar.body"
        />
      </div>
      <button type="submit" class="btn btn-primary">Add Car</button>
    </form>
  </div>
</template>


<script>
export default {
  name: "CarForm",
  data() {
    return {
      newCar: {}
    };
  },
  mounted() {
    this.$store.dispatch("getCars");
  },
  computed: {
    cars() {
      return this.$store.state.cars;
    }
  },
  methods: {
    createCar() {
      this.$store.dispatch("createCar", this.newCar);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>