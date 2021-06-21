<template>
  <img class="mainIcon" alt="Light Controller logo" src="./assets/logo.svg" />
  <LightController />
</template>

<script lang="ts">
import "bootstrap/dist/css/bootstrap.css";
import { Options, Vue } from "vue-class-component";
import LightController from "./components/LightController.vue";

@Options({
  components: {
    LightController,
  },
})
export default class App extends Vue {}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

.mainIcon {
  padding: 5px;
  width: 200px;
}
</style>
