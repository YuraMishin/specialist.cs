import React, {useState} from 'react';

const SimpleFor = () => {
  const [dates, setDate] = useState<Date[]>([]);

  const onToggleAddDate = () => {
    setDate([...dates, new Date()]);
  }

  const listItems = dates.map((date, index) =>
    <li key={index}>{date.toString()}</li>)

  return (
    <div>
      <hr/>
      <h3>SimpleFor Component</h3>
      <button onClick={onToggleAddDate}
      >Add Date
      </button>
      <ul>{listItems}</ul>
      <hr/>
    </div>
  );
}

export default SimpleFor;
