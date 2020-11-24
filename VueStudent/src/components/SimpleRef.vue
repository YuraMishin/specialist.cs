<template>
  <hr/>
  <h3>SimpleRef Component</h3>
  <header>
    <h1>Vue Behind The Scenes</h1>
  </header>
  <section id="app">
    <h2>How Vue Works</h2>
    <input type="text" ref="userText">
    <button @click="setText">Set Text</button>
    <p>{{ message }}</p>
  </section>
  <hr/>
</template>

<script>
  const SimpleRef = {
    data() {
      return {
        currentUserInput: '',
        message: 'Vue is great!'
      };
    },
    methods: {
      saveInput(event) {
        this.currentUserInput = event.target.value;
      },
      setText() {
        // this.message = this.currentUserInput;
        this.message = this.$refs.userText.value;
      }
    }
  }

  export default SimpleRef;
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
    margin: 3rem auto;
    border-radius: 10px;
    padding: 1rem;
    background-color: #4fc08d;
    color: white;
    text-align: center;
    width: 90%;
    max-width: 40rem;
  }

  #app {
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.26);
    margin: 3rem auto;
    border-radius: 10px;
    padding: 1rem;
    text-align: center;
    width: 90%;
    max-width: 40rem;
  }

  #app h2 {
    font-size: 2rem;
    border-bottom: 4px solid #ccc;
    color: #4fc08d;
    margin: 0 0 1rem 0;
  }

  #app p {
    font-size: 1.25rem;
    font-weight: bold;
    border: 1px solid #4fc08d;
    background-color: #4fc08d;
    color: white;
    padding: 0.5rem;
    border-radius: 25px;
  }

  #app input {
    font: inherit;
    border: 1px solid #ccc;
  }

  #app input:focus {
    outline: none;
    border-color: #1b995e;
    background-color: #d7fdeb;
  }

  #app button {
    font: inherit;
    cursor: pointer;
    border: 1px solid #ff0077;
    background-color: #ff0077;
    color: white;
    padding: 0.05rem 1rem;
    box-shadow: 1px 1px 2px rgba(0, 0, 0, 0.26);
  }

  #app button:hover,
  #app button:active {
    background-color: #ec3169;
    border-color: #ec3169;
    box-shadow: 1px 1px 4px rgba(0, 0, 0, 0.26);
  }
</style>
