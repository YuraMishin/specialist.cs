<template>
  <h3>SimpleHelloWorld Component Class-based</h3>
  <p>Hello, World!</p>
</template>

<script lang="ts">
  import {Options, Vue} from "vue-class-component";

  @Options({
    props: {}
  })
  export default class HelloWorld extends Vue {

  }
</script>

<style scoped lang="scss">

</style>
