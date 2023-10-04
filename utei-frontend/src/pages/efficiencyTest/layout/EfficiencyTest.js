import { React, useState } from "react";
import ResultContext from "../../../ResultContext";
import EfficiencyInputSpace from "./EfficiencyInputSpace";
import EfficiencyOutputSpace from "./EfficiencyOutputSpace";

const EfficiencyTest = () => {
  const [resultId, setResultId] = useState("");
  const [testResult, setTestResult] = useState({});
  return (
    <div>
      <ResultContext.Provider value={resultId}>
        <EfficiencyInputSpace
          setResultId={setResultId}
          setTestResult={setTestResult}
        />
        <EfficiencyOutputSpace
          resultId={resultId}
          testResult={testResult}
          setTestResult={setTestResult}
        />
      </ResultContext.Provider>
    </div>
  );
};

export default EfficiencyTest;
