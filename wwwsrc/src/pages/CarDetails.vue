<template>
  <div class="car container-fluid">
    <div class="row">
      <div class="col-6">
        <h1>Make: {{car.make}}</h1>
        <h1>Model: {{car.model}}</h1>
        <img class="img-fluid" :src="car.imgUrl" alt />
      </div>
      <div class="col-6">
        <p>Price: {{car.price}}</p>
        <p>Year: {{car.year}}</p>
        <p>{{car.body}}</p>
        <div class="form-group form-inline">
          <label for="bid">Bid Amount:</label>
          <input
            type="number"
            class="form-control"
            name="bid"
            placeholder="300.00"
            v-model="bidAmount"
            min="1"
          />
          <button type="button" class="btn btn-success btn-block" @click="bid()">Bid</button>
          <button
            type="button"
            class="btn btn-danger btn-block"
            @click="deleteCar()"
            v-if="car.userId == $auth.user.sub"
          >Delete</button>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "car",
  data() {
    return {
      bidAmount: 1
    };
  },
  mounted() {
    this.$store.dispatch("getCar", this.$route.params.carId);
  },
  computed: {
    car() {
      return this.$store.state.activeCar;
    }
  },
  methods: {
    deleteCar() {
      this.$store.dispatch("deleteCar", this.car.id);
    },
    bid() {
      let tempCar = JSON.parse(JSON.stringify(this.car));
      tempCar.price = tempCar.price + +this.bidAmount;
      this.$store.dispatch("bidOnCar", tempCar);
    }
  },
  components: {}
};
</script>


<style lang="scss" scoped>
</style>