import React, {Component} from 'react';
import UserInput from "./UserInput/UserInput";
import UserOutput from "./UserOutput/UserOutput";

class Task1 extends Component {
  state = {
    username: 'Super Yura'
  }

  usernameOnChangeHandler = (event: any) => {
    this.setState({
      username: event.target.value
    });
  }

  render() {
    return (
      <div>
        <UserInput
          value={this.state.username}
          changed={this.usernameOnChangeHandler}/>
        <UserOutput userName={this.state.username}/>
        <UserOutput userName="Yura2"/>
        <UserOutput userName="Yura3"/>
      </div>
    );
  }
}

export default Task1;
