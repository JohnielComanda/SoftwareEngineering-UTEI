import "../../../css/OutputSpace.css";
import { React } from "react";
import CodeMirror from "@uiw/react-codemirror";
import { javascript } from "@codemirror/lang-javascript";

const EnhancedOutput = ({ testResult }) => {
  return (
    <>
      <div className="output-space">
        <CodeMirror
          className="output-code"
          value={testResult.enhancedVersion}
          height="555px"
          extensions={[javascript()]}
          lineNumbers={false}
          readOnly={true}
          theme="dark"
        ></CodeMirror>
      </div>
    </>
  );
};

export default EnhancedOutput;
