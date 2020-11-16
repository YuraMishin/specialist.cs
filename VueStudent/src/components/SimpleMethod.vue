<template>
  <hr/>
  <h3>SimpleMethod Component</h3>
  <p>{{print()}}</p>
  <hr/>
</template>

<script>
  const SimpleMethod = {
    data() {
      return {
        message: `I'm method`
      };
    },
    methods: {
      print() {
        return this.message;
      }
    }
  }

  export default SimpleMethod;
</script>

<style lang="scss" scoped>

</style>
