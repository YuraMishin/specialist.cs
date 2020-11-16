<template>
  <div>
    <h1>Vue Student</h1>
    <A5/>

  </div>
</template>

<script lang="ts">
  import {Options, Vue} from "vue-class-component";
  import A5 from "@/assignments/A5.vue";

  @Options({
    components: {A5}
  })
  export default class Home extends Vue {
  }
</script>
