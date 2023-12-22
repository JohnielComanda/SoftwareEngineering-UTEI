import React from "react";
import "../../../css/OutputSpace.css";

const TestCase = ({ testResult }) => {
  return (
    <>
      <div className="output-space">
        <pre className="output-text">{testResult.testResult}</pre>
      </div>
    </>
  );
};
export default TestCase;
