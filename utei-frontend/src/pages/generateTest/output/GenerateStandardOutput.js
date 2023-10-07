import React from "react";
import "../../../css/OutputSpace.css";

const GenerateStandardOutput = ({ testResult }) => {
  return (
    <>
      <div className="output-space">
        <pre className="output-text">{testResult.unitTest}</pre>
      </div>
    </>
  );
};

export default GenerateStandardOutput;
