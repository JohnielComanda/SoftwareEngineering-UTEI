import { React, useState } from "react";
import ResultContext from "../../../ResultContext";
import GenerateInputSpace from "./GenerateInputSpace";
import GenerateOutputSpace from "./GenerateOutputSpace";

const GenerateTest = ({ selectedResult, setSelectedResult }) => {
  const [resultId, setResultId] = useState("");
  const [testResult, setTestResult] = useState({});
  console.log("GenerateTest selectedResult:", selectedResult);
  return (
    <div>
      <ResultContext.Provider value={resultId}>
        <GenerateInputSpace
          setResultId={setResultId}
          setTestResult={setTestResult}
          selectedResult={selectedResult}
          setSelectedResult={setSelectedResult}
        />
        <GenerateOutputSpace
          setTestResult={setTestResult}
          resultId={resultId}
          testResult={
            Object.keys(selectedResult).length === 0
              ? testResult
              : selectedResult
          }
        />
      </ResultContext.Provider>
    </div>
  );
};

export default GenerateTest;
