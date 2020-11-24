<template>
  <div>
    <h1>Vue Student</h1>
    <SimpleRef/>
  </div>
</template>

<script lang="ts">
  import {Options, Vue} from "vue-class-component";
  import SimpleRef from "@/components/SimpleRef.vue"

  @Options({
    components: {SimpleRef}
  })
  export default class Home extends Vue {
  }
</script>
