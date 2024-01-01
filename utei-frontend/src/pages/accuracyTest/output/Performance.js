import React from "react";
import "../../../css/OutputSpace.css";

const Performance = ({ testResult }) => {
  return (
    <>
      <div className="output-space">
        <pre className="output-text">{testResult.resultSummary}</pre>
      </div>
    </>
  );
};
export default Performance;
