import React from "react";
import "../../../css/OutputSpace.css";

const TestCase = ({ testResult }) => {
  return (
    <>
      <div className="output-space">
        <div className="containerTest">
          <p>Expected Value</p>
          <div className="resValue">{1}</div>
          <p>Actual Value</p>
          <div className="resValue">{1}</div>
          <p>Result</p>
          <div className="resValue">{1}</div>
        </div>
      </div>
    </>
  );
};
export default TestCase;
