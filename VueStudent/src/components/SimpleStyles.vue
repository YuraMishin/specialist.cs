<template>
  <hr/>
  <h3>SimpleStyles Component</h3>
  <header>
    <h1>Vue Dynamic Styling</h1>
  </header>
  <section id="styling">
    <div
      class="demo"
      :style="{borderColor: boxASelected? 'red':'#ccc'}"
      @click="boxSelectedHandler('A')">1
    </div>
    <div
      :class="boxASelected ? 'demo active' : 'demo'"
      @click="boxSelectedHandler('A')">2
    </div>
    <div
      :class="{demo: true, active: boxASelected}"
      @click="boxSelectedHandler('A')">3
    </div>
    <div
      class="demo"
      :class="{active: boxASelected}"
      @click="boxSelectedHandler('A')">4
    </div>
    <div
      class="demo"
      :class="boxAClasses"
      @click="boxSelectedHandler('A')">5
    </div>
    <div
      :class="['demo', {active: boxASelected}]"
      @click="boxSelectedHandler('A')">6
    </div>
  </section>
  <hr/>
</template>

<script>
  const SimpleStyles = {
    data() {
      return {
        boxASelected: false,
        boxBSelected: false,
        boxCSelected: false
      };
    },

    computed: {
      boxAClasses() {
        return {active: this.boxASelected};
      }
    },

    methods: {
      boxSelectedHandler(box) {
        if (box === 'A') {
          this.boxASelected = !this.boxASelected;
        } else if (box === 'B') {
          this.boxBSelected = !this.boxBSelected;
        } else if (box === 'C') {
          this.boxCSelected = !this.boxBSelected;
        }
      }
    }
  }

  export default SimpleStyles;
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
    background-color: #4fc08d;
    color: white;
    text-align: center;
  }

  #styling {
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.26);
    margin: 3rem;
    border-radius: 10px;
    padding: 1rem;
    text-align: center;
  }

  .demo {
    width: calc(100% - 32px);
    height: 100px;
    margin: 16px;
    border: 2px dashed #ccc;
  }

  .active {
    border-color: red;
    background-color: salmon;
  }
</style>
