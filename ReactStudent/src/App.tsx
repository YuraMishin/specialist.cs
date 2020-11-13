import React, {Component} from 'react';
import './App.css';
import Person from "./components/Person/Person";
import Task1 from "./components/Task1/Task1";


class App extends Component {
  state = {
    persons: [
      {name: 'Max', age: 28},
      {name: 'Yura', age: 29}
    ]
  }

  switchNameHandler = (newName: string) => {
    this.setState({
      persons: [
        {name: newName, age: 28},
        {name: 'Yury', age: 29}
      ]
    });
  }

  render() {
    const bntStyle = {
      border: '1px solid blue'
    };

    return (
      <div>
        <h1>React Student</h1>
        <button
          style={bntStyle}
          onClick={this.switchNameHandler.bind(this, 'Maximus')}>
          Click me!
        </button>
        <Person
          name={this.state.persons[0].name}
          age={this.state.persons[0].age}
          click={this.switchNameHandler}
        >
          My interests: sports
        </Person>
        <Task1/>
      </div>
    );
  }
}

export default App;
