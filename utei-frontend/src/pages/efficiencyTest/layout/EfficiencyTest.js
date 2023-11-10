import { React, useState } from "react";
import ResultContext from "../../../ResultContext";
import EfficiencyInputSpace from "./EfficiencyInputSpace";
import EfficiencyOutputSpace from "./EfficiencyOutputSpace";
import HeaderBar from "../../../components/HeaderBar";
import SideBar from "../../../components/SideBar";
import Login from "../../../components/Login";

const EfficiencyTest = ({
  selectedResult,
  setSelectedResult,
  efficiencyInput,
  setEfficiencyInput,
  unitTest,
  setUnitTest,
  efficiencySelectedLanguage,
  setEfficiencySelectedLanguage,
  efficiencyResult,
  setEfficiencyResult,
  isAuthenticated,
  setIsAuthenticated,
  newDataAction,
  setNewDataAction,
}) => {
  const [resultId, setResultId] = useState("");
  const [testResult, setTestResult] = useState({});
  const [activeTab, setActiveTab] = useState(0);

  return (
    <>
      <ResultContext.Provider value={resultId}>
        <>
          <HeaderBar />
          <SideBar
            testType={"efficiencyTest"}
            setSelectedResult={setSelectedResult}
            setTestResult={setEfficiencyResult}
            activeTab={activeTab}
            setActiveTab={setActiveTab}
            newDataAction={newDataAction}
          />
          <EfficiencyInputSpace
            efficiencyInput={efficiencyInput}
            setEfficiencyInput={setEfficiencyInput}
            unitTest={unitTest}
            setUnitTest={setUnitTest}
            efficiencySelectedLanguage={efficiencySelectedLanguage}
            setEfficiencySelectedLanguage={setEfficiencySelectedLanguage}
            setNewDataAction={setNewDataAction}
            //result
            setResultId={setResultId}
            setEfficiencyResult={setEfficiencyResult}
            selectedResult={selectedResult}
            setSelectedResult={setSelectedResult}
          />
          <EfficiencyOutputSpace
            //output
            efficiencyResult={efficiencyResult}
            setEfficiencyResult={setEfficiencyResult}
            //result
            resultId={resultId}
            testResult={
              Object.keys(selectedResult).length === 0
                ? efficiencyResult
                : selectedResult
            }
          />
        </>
      </ResultContext.Provider>
    </>
  );
};

export default EfficiencyTest;
