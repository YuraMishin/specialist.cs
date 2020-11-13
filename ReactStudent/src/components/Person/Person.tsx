import React from 'react'
import './Person.scss'

const Person = (props: any) => {
  return (
    <div className="Person">
      <p onClick={props.click}>
        I'm {props.name}. I'm {props.age} years old!<br/>
        {props.children}
      </p>
    </div>
  );
}

export default Person;
