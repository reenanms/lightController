<template>
  <div>
    <h1>Light Controller</h1>
    <h2 v-for="portInfo in ports" v-bind:key="portInfo.port">
      <div class="custom-control custom-switch">
        <input
          type="checkbox"
          class="custom-control-input"
          :id="portInfo.port"
          v-model="portInfo.isOn"
          @change="setPortState(portInfo)"
        />
        <label class="custom-control-label" :for="portInfo.port"
          >Porta {{ portInfo.port }}</label
        >
      </div>
    </h2>
  </div>
</template>

<script lang="ts">
import { mapState, mapActions } from "vuex";
import { Options, Vue } from "vue-class-component";
import store from "@/store";

export interface Port {
  port: number;
  isOn: boolean;
}

@Options({
  methods: {
    ...mapActions(["getPorts", "setPortState"]),
  },
  computed: {
    ...mapState(["ports"]),
  },
})
export default class LightController extends Vue {
  private ports: Port[] = [];
  async created(): Promise<void> {
    await store.dispatch("getPorts");
    this.ports = store.state.ports;
  }
}
</script>

<style scoped>
h1 {
  color: #126900;
  font-weight: bold;
}
h2 {
  margin: 40px 0 0;
  color: #031685;
}
</style>
