import { React } from "react";
import CodeMirror from "@uiw/react-codemirror";
import { javascript } from "@codemirror/lang-javascript";
import "../../../css/OutputSpace.css";

const GenerateStandardOutput = ({ testResult }) => {
  return (
    <>
      <div className="output-space">
        <CodeMirror
          className="output-code"
          value={
            testResult.unitTest === "-1" || testResult === ""
              ? "Input code is not testable."
              : testResult.unitTest
          }
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

export default GenerateStandardOutput;
