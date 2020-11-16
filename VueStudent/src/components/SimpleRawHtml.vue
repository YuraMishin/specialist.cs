<template>
  <hr/>
  <h3>SimpleRawHtml Component</h3>
  <p v-html="word"></p>
  <hr/>
</template>

<script>
  const SimpleRawHtml = {
    data() {
      return {
        word: '<strong>Strong</strong>'
      };
    },
    methods: {}
  }

  export default SimpleRawHtml;
</script>

<style lang="scss" scoped>

</style>
