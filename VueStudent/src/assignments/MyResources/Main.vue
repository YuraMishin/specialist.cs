<template>
  <TheHeader title="RememberMe"></TheHeader>
  <TheResources></TheResources>
</template>

<script>
  import TheHeader
    from "@/assignments/MyResources/components/layouts/TheHeader.vue";
  import TheResources
    from
      "@/assignments/MyResources/components/learning-resources/TheResources.vue";

  export default {
    name: "Main",

    components: {
      TheResources,
      TheHeader
    },

    data() {
      return {

      }
    }
  }
</script>

<style>
  @import url('https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap');

  * {
    box-sizing: border-box;
  }

  html {
    font-family: 'Roboto', sans-serif;
  }

  body {
    margin: 0;
  }
</style>
