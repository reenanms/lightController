import { createApp } from "vue";
import App from "./App.vue";
import "./registerServiceWorker";
import store from "./store";

store.dispatch("getPorts");
createApp(App).use(store).mount("#app");
