import { createStore } from "vuex";
import Axios from "axios";

const apiUrlBase = "https://localhost:44399";

export default createStore({
  state: {
    ports: [],
  },
  mutations: {
    setPorts(state, payload) {
      const { ports } = payload;
      state.ports = ports;
    },
  },
  actions: {
    async getPorts(context) {
      await Axios.get(`${apiUrlBase}/light`).then((response) => {
        const query = response.data;
        context.commit("setPorts", { ports: query });
      });
    },
    async setPortState(_, payload) {
      const port = payload;
      if (port.isOn) await Axios.post(`${apiUrlBase}/light/${port.port}/on`);
      else await Axios.post(`${apiUrlBase}/light/${port.port}/off`);
    },
  },
  modules: {},
});
