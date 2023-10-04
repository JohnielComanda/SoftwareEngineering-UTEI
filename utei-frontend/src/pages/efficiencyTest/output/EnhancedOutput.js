import "../../../css/OutputSpace.css";
import { React } from "react";

const EnhancedOutput = ({ testResult }) => {
  return (
    <>
      <div className="output-space">
        <pre className="output-text">{testResult.enhancedVersion}</pre>
      </div>
    </>
  );
};

export default EnhancedOutput;
