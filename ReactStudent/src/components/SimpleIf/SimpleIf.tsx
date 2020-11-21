import React, {useState} from 'react';

const SimpleIf = () => {
  const [isVisible, setIsVisible] = useState(true);

  const toggleHandler = () => {
    setIsVisible(!isVisible);
  };

  const helloHtml = (
    <div>Hello, If !</div>
  );

  return (
    <div>
      <hr/>
      <h3>SimpleIf Component</h3>
      <button onClick={toggleHandler}>Show/Hide</button>
      <p></p>

      {isVisible ? helloHtml : null}

      <hr/>
    </div>
  );
}

export default SimpleIf;
