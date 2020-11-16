<template>
  <hr/>
  <h3>SimpleLink Component</h3>
  <p>Link: <a v-bind:href="vueLink">Google</a></p>
  <p>Link: <a :href="vueLink">Google</a></p>
  <hr/>
</template>

<script>
  const SimpleLink = {
    data() {
      return {
        vueLink: 'https://www.google.com/'
      };
    },
    methods: {}
  }

  export default SimpleLink;
</script>

<style lang="scss" scoped>

</style>
