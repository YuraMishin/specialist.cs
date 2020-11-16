<template>
  <hr/>
  <h3>Assignment 3</h3>
  <header>
    <h1>Reactivity in Action</h1>
  </header>
  <section id="assignment">
    <button @click="addNumber(5)">Add 5</button>
    <button @click="addNumber(1)">Add 1</button>
    <p>Result: {{result}} {{number}}</p>
    <!-- 2) Watch for changes in "result" and reset the value to 0 after 5 seconds -->
  </section>
  <hr/>
</template>

<script>
  const A3 = {
    data() {
      return {
        number: 0
      };
    },

    computed: {
      result() {
        if (this.number < 37) {
          return 'Not there yet';
        } else if (this.number === 37) {
          return this.number;
        } else {
          return 'Too much!';
        }
      }
    },

    watch: {
      result() {
        setTimeout(() => {
          this.number = 0;
        }, 5000)
      }
    },

    methods: {
      addNumber(num) {
        this.number = this.number + num;
      }
    }
  }

  export default A3;
</script>

<style lang="scss" scoped>
  * {
    box-sizing: border-box;
  }

  html {
    font-family: 'Jost', sans-serif;
  }

  body {
    margin: 0;
  }

  header {
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.26);
    margin: 3rem;
    border-radius: 10px;
    padding: 1rem;
    background-color: #1b995e;
    color: white;
    text-align: center;
  }

  #assignment {
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.26);
    margin: 3rem;
    border-radius: 10px;
    padding: 1rem;
    text-align: center;
  }

  #assignment h2 {
    font-size: 2rem;
    border-bottom: 4px solid #ccc;
    color: #1b995e;
    margin: 0 0 1rem 0;
  }

  #assignment p {
    font-size: 1.25rem;
    font-weight: bold;
    background-color: #8ddba4;
    padding: 0.5rem;
    color: #1f1f1f;
    border-radius: 25px;
  }

  #assignment input {
    font: inherit;
    border: 1px solid #ccc;
  }

  #assignment input:focus {
    outline: none;
    border-color: #1b995e;
    background-color: #d7fdeb;
  }

  #assignment button {
    font: inherit;
    cursor: pointer;
    border: 1px solid #ff0077;
    background-color: #ff0077;
    color: white;
    padding: 0.05rem 1rem;
    box-shadow: 1px 1px 2px rgba(0, 0, 0, 0.26);
  }

  #assignment button:hover,
  #assignment button:active {
    background-color: #ec3169;
    border-color: #ec3169;
    box-shadow: 1px 1px 4px rgba(0, 0, 0, 0.26);
  }
</style>
