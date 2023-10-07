import "../../../css/OutputSpace.css";
import { React } from "react";

const SuggestionOutput = ({ testResult }) => {
  return (
    <>
      <div className="output-space">
        <pre className="output-text">{testResult.testSuggestions}</pre>
      </div>
    </>
  );
};

export default SuggestionOutput;
