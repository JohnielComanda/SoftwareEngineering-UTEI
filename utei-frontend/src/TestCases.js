import React from 'react';
import './css/TestCases.css'

const TestCases = (props) => {
  // Access the prop value using props.result
  var resultArray = props.result.split('+');

  // Assuming you want to display the individual parts separately
  var result = resultArray[0];
  var expectedValue = resultArray[1];
  var actualValue = resultArray[2];

  return (
    <div id="container">
      <p>Expected Value</p>
      <div id="expectedDiv">
        {expectedValue}
      </div>
      <p>Actual Value</p>
        <div id="actualDiv">
          {actualValue}
      </div>
        <p>Result</p>
        <div id="resultDiv">
          {result}
        </div>
    </div>
  );
}

export default TestCases;
