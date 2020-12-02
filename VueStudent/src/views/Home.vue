<template>
  <div>
    <h1>Vue Student</h1>
    <Main/>

  </div>
</template>

<script lang="ts">
  import {Options, Vue} from "vue-class-component";
  import Main from "@/assignments/MyResources/Main.vue";

  @Options({
    components: {Main}
  })
  export default class Home extends Vue {
  }
</script>
