import React, {useState} from 'react';

const SimpleButton = (props: any) => {
  const [personsState, setPersonsState] = useState({
    persons: [
      {name: 'Max', age: 28},
      {name: 'Yura', age: 29}
    ],
    otherState: 'foo'
  });

  // eslint-disable-next-line
  const [getFooString, setFooString] = useState('foo string');

  const switchNameHandler = () => {
    setPersonsState({
      persons: [
        {name: 'Maximus', age: 30},
        {name: 'Yury', age: 29}
      ],
      otherState: personsState.otherState
    });
  }

  return (
    <div>
      <hr/>
      <h3>SimpleButton component</h3>
      <button onClick={switchNameHandler}>Click me!</button>
      <p>
        I'm {personsState.persons[0].name}.
        I'm {personsState.persons[0].age} years old!<br/>
      </p>
      <hr/>
    </div>
  );
}

export default SimpleButton;
