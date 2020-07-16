import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";
import { api } from "./AxiosService";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    cars: [],
    myCars: [],
    myFavoriteCars: [],
    activeCar: {}
  },
  mutations: {
    setCars(state, cars) {
      state.cars = cars
    },
    setMyCars(state, cars) {
      state.myCars = cars
    },
    setMyFavoriteCars(state, cars) {
      state.myFavoriteCars = cars
    },
    setCar(state, car) {
      state.activeCar = car
    }
  },
  actions: {
    //#region CARS

    async getCars({ commit, dispatch }) {
      try {
        let res = await api.get("cars")
        commit("setCars", res.data)
      } catch (err) {
        alert(JSON.stringify(err));
      }
    },
    async getMyCars({ commit }) {
      let res = await api.get("/cars/user")
      commit("setMyCars", res.data)
    },
    async getMyFavoriteCars({ commit }) {
      let res = await api.get("/carFavorites")
      commit("setMyFavoriteCars", res.data)
    },
    async getCar({ commit }, carId) {
      try {
        let res = await api.get("/cars/" + carId)
        console.log("getCar:", res.data)
        commit("setCar", res.data)
      } catch (error) {

      }
    },
    async createCar({ commit, dispatch }, newCar) {
      let res = await api.post("cars", newCar)
      dispatch("getCars")
      dispatch("getMyCars")
    },
    async deleteCar({ dispatch }, carId) {
      try {
        await api.delete("cars/" + carId)
        router.push({ name: "dashboard" })
      } catch (error) {
        alert(JSON.stringify(error.response.data));
      }

    },
    async bidOnCar({ commit }, payload) {
      try {
        let res = await api.put("cars/" + payload.id, payload)
        commit("setCar", res.data)
      } catch (err) {
        console.error(err)
      }
    },
    //#endregion

    async addFav({ dispatch }, fav) {
      try {
        let res = await api.post("/carFavorites", fav)
        dispatch("getMyFavoriteCars")
      } catch (err) {
        console.error(err)
      }
    },
    async removeFav({ dispatch }, favId) {
      try {
        let res = await api.delete("/carFavorites/" + favId)
        dispatch("getMyFavoriteCars")
      } catch (err) {
        console.error(err)
      }
    }


  }
});
