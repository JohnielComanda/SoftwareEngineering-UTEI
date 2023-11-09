import { React, useState } from "react";
import ResultContext from "../../../ResultContext";
import GenerateInputSpace from "./GenerateInputSpace";
import GenerateOutputSpace from "./GenerateOutputSpace";
import HeaderBar from "../../../components/HeaderBar";
import SideBar from "../../../components/SideBar";

const GenerateTest = ({
  genereateBaseInput,
  setGenerateBaseInput,
  generateBaseMethod,
  setGenerateBaseMethod,
  generateSelectedLanguage,
  setGenerateSelectedLanguage,
  generateResult,
  setGenerateResult,
  selectedResult,
  setSelectedResult,
  newDataAction,
  setNewDataAction,
}) => {
  const [resultId, setResultId] = useState("");
  const [activeTab, setActiveTab] = useState(2);
  console.log("GenerateTest selectedResult:", selectedResult);
  return (
    <div>
      <ResultContext.Provider value={resultId}>
        <HeaderBar />
        <SideBar
          testType={"generateTest"}
          setSelectedResult={setSelectedResult}
          setTestResult={setGenerateResult}
          activeTab={activeTab}
          setActiveTab={setActiveTab}
          newDataAction={newDataAction}
        />
        <GenerateInputSpace
          //inputs
          genereateBaseInput={genereateBaseInput}
          setGenerateBaseInput={setGenerateBaseInput}
          generateBaseMethod={generateBaseMethod}
          setGenerateBaseMethod={setGenerateBaseMethod}
          generateSelectedLanguage={generateSelectedLanguage}
          setGenerateSelectedLanguage={setGenerateSelectedLanguage}
          setNewDataAction={setNewDataAction}
          //result
          setResultId={setResultId}
          setGenerateResult={setGenerateResult}
          selectedResult={selectedResult}
          setSelectedResult={setSelectedResult}
        />
        <GenerateOutputSpace
          //output
          generateResult={generateResult}
          setGenerateResult={setGenerateResult}
          //result
          resultId={resultId}
          testResult={
            Object.keys(selectedResult).length === 0
              ? generateResult
              : selectedResult
          }
        />
      </ResultContext.Provider>
    </div>
  );
};

export default GenerateTest;
