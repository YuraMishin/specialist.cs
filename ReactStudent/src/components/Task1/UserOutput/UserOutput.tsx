import React from 'react';
import './UserOutput.scss';

const UserOutput = (props:any) => {
  return (
    <div className="UserOutput">
      <h3>UserOutput</h3>
      <p>Username: {props.userName}</p>
      <p>Lorem ipsum dolor.</p>
    </div>
  );
}

export default UserOutput;
