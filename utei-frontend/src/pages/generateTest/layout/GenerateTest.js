import { React, useState } from "react";
import ResultContext from "../../../ResultContext";
import GenerateInputSpace from "./GenerateInputSpace";
import GenerateOutputSpace from "./GenerateOutputSpace";

const GenerateTest = () => {
  const [resultId, setResultId] = useState("");
  const [testResult, setTestResult] = useState({});
  return (
    <div>
      <ResultContext.Provider value={resultId}>
        <GenerateInputSpace
          setResultId={setResultId}
          setTestResult={setTestResult}
        />
        <GenerateOutputSpace
          setTestResult={setTestResult}
          resultId={resultId}
          testResult={testResult}
        />
      </ResultContext.Provider>
    </div>
  );
};

export default GenerateTest;
