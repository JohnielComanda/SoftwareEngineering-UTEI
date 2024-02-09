import React from "react";
import "../../../css/OutputSpace.css";

const TestCase = ({ testResult }) => {
  if (!testResult || !testResult.testResult) {
    return <div className="output-space"></div>;
  }

  let resultArray = testResult.testResult.split("+");

  const result = resultArray[0];
  const expectedValue = resultArray[1];
  const actualValue = resultArray[2];

  return (
    <>
      <div className="output-space">
        <div className="containerTest">
          <p>Expected Value</p>
          <div className="resValue">{expectedValue}</div>
          <p>Actual Value</p>
          <div className="resValue">{actualValue}</div>
          <p>Result</p>
          <div className="resValue">{result}</div>
        </div>
      </div>
    </>
  );
};
export default TestCase;
