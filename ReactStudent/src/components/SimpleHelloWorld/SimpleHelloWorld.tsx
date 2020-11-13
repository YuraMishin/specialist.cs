import React from 'react';

const SimpleHelloWorld = () => {
  return (
    <div>
      <hr/>
      <h3>SimpleHelloWorld Component</h3>
      <p>Hello, World!</p>
      <p>{new Date().toString()}</p>
      <hr/>
    </div>
  );
}

export default SimpleHelloWorld;
