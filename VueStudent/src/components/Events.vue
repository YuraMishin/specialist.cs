<template>
  <hr/>
  <h3>Events Component</h3>
  <header>
    <h1>Vue Events</h1>
  </header>
  <section id="events">
    <h2>Events in Action</h2>
    <button @click="add(5)">Add</button>
    <button v-on:click="reduce(10)">Reduce</button>
    <p v-once>Starting Counter: {{counter}}</p>
    <p>Result: {{ counter }}</p>
    <!--    <input-->
    <!--      type="text"-->
    <!--      v-on:input="setName($event, 'Mishin')"-->
    <!--      v-on:keyup.enter="confirmInput"-->
    <!--    >-->
    <input
      type="text"
      v-model="name"
    >
    <button v-on:click="resetInputHandler">Reset Input</button>
    <!--    <p>Your name: {{name}}</p>-->
    <p>Your name: {{fullname}}</p>
    <!--    <form v-on:submit.prevent="submitForm">-->
    <!--      <input type="text">-->
    <!--      <button>Sign Up</button>-->
    <!--    </form>-->
  </section>
  <hr/>
</template>

<script>
  const Events = {
    data() {
      return {
        counter: 0,
        name: '',
        confirmedName: ''
      };
    },

    computed: {
      fullname() {
        if (this.name === '') {
          return ''
        }
        return this.name + ' ' + 'Mishin';
      }
    },

    watch: {
      name(newValue, oldValue) {
        console.log(`Name is changed. New: ${newValue}. Old: ${oldValue}`);
      },

      counter(value){
        if (value > 50) {
          setTimeout(() => {
            this.counter = 0;
          },1000);
        }
      }
    },

    methods: {
      resetInputHandler() {
        this.name = '';
      },

      confirmInput() {
        this.confirmedName = this.name;
      },

      submitForm(event) {
        // event.preventDefault();
        alert('!');
      },

      setName(event, lastName) {
        this.name = event.target.value + ' ' + lastName;
      },
      add(num) {
        this.counter = this.counter + num;
      },
      reduce(num) {
        this.counter = this.counter - num;
      }
    }
  }

  export default Events;
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

  #events {
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.26);
    margin: 3rem auto;
    border-radius: 10px;
    padding: 1rem;
    text-align: center;
    width: 90%;
    max-width: 40rem;
  }

  #events h2 {
    font-size: 2rem;
    border-bottom: 4px solid #ccc;
    color: #4fc08d;
    margin: 0 0 1rem 0;
  }

  #events p {
    font-size: 1.25rem;
    font-weight: bold;
    border: 1px solid #4fc08d;
    background-color: #4fc08d;
    color: white;
    padding: 0.5rem;
    border-radius: 25px;
  }

  #events input {
    font: inherit;
    border: 1px solid #ccc;
  }

  #events input:focus {
    outline: none;
    border-color: #1b995e;
    background-color: #d7fdeb;
  }

  #events button {
    font: inherit;
    cursor: pointer;
    border: 1px solid #ff0077;
    background-color: #ff0077;
    color: white;
    padding: 0.05rem 1rem;
    box-shadow: 1px 1px 2px rgba(0, 0, 0, 0.26);
    border-radius: 20px;
    margin: 0 1rem;
  }

  #events button:hover,
  #events button:active {
    background-color: #ec3169;
    border-color: #ec3169;
    box-shadow: 1px 1px 4px rgba(0, 0, 0, 0.26);
  }
</style>
