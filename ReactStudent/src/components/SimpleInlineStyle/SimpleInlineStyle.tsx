import React, {Component} from 'react';

class SimpleInlineStyle extends Component {
  state = {}

  render() {
    const bntStyle = {
      border: '1px solid blue'
    };

    return (
      <div>
        <hr/>
        <h3>SimpleInlineStyle Component</h3>
        <button style={bntStyle}> Click me!</button>
      </div>
    );
  }
}

export default SimpleInlineStyle;
