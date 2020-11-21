import React, {Component} from 'react';
import Person from "../Person/Person";

class SimpleSendParamToComp extends Component {
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
        <button
          style={bntStyle}
          onClick={this.switchNameHandler.bind(this, 'Maximus')}>
          Click me!
        </button>
        <Person
          name={this.state.persons[0].name}
          age={this.state.persons[0].age}
          click={this.switchNameHandler.bind(this, 'Maximus')}
        >
          My interests: sports
        </Person>
      </div>
    );
  }
}

export default SimpleSendParamToComp;
