import React, {useState} from 'react';

const SimpleInput = () => {
  const [name, setName] = useState('');

  const onChangeHandler = (event: any) => {
    setName(event.target.value);
  }

  return (
    <div>
      <hr/>
      <h3>SimpleInput Component</h3>
      <p><input type="text" onChange={onChangeHandler} value={name}/></p>
      <p>Value: {name}</p>
      <hr/>
    </div>
  );
}

export default SimpleInput;
