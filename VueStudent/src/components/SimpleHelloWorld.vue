<template>
  <hr/>
  <h3>SimpleHelloWorld Component</h3>
  <p>Hello, World!</p>
  <p>{{new Date().toString()}}</p>
  <hr/>
</template>

<script>
  const SimpleHelloWorld = {
    data() {
      return {
        name: 'Yura'
      };
    },
    methods: {}
  }

  export default SimpleHelloWorld;
</script>

<style lang="scss" scoped>

</style>
