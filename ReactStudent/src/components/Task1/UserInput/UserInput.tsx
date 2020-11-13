import React from 'react';

const UserInput = (props: any) => {
  const inputStyle = {
    border: '2px solid red'
  };

  return (
    <div>
      <h3>UserInput</h3>
      <p><input
        type="text"
        style={inputStyle}
        value={props.value}
        onChange={props.changed}/></p>
    </div>
  );
}

export default UserInput;
