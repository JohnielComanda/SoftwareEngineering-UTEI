import React from "react";
import "../../../css/OutputSpace.css";

const Recommendation = ({ testResult }) => {
  return (
    <>
      <div className="output-space">
        <pre className="output-text">{testResult.testSuggestions}</pre>
      </div>
    </>
  );
};
export default Recommendation;
