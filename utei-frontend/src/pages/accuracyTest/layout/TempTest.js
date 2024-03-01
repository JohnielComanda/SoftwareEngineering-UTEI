import React, { useState } from "react";
import ResultContext from "../../../ResultContext";
import AccuracyOutputSpace from "./AccuracyOutputSpace";
import SideBar from "../../../components/SideBar";
import AccuracyInputSpace from "./AccuracyInputSpace";

const TempTest = ({
  userId,
  testType,
  accuracyInput,
  setAccuracyInput,
  accuracyUnitTest,
  setAccuracyUnitTest,
  accuracyBaseMethod,
  setAccuracyBaseMethod,
  accuracyDescription,
  setAccuracyDescription,
  accuracyDependency1,
  setAccuracyDependency1,
  accuracyDependency2,
  setAccuracyDependency2,
  accuracySelectedLanguage,
  setAccuracySelectedLanguage,
  accuracyTestType,
  setAccuracyTestType,
  accuracyResult,
  setAccuracyResult,
  selectedResult,
  setSelectedResult,
  newDataAction,
  setNewDataAction,
}) => {
  const [resultId, setResultId] = useState("");
  const [activeTab, setActiveTab] = useState(2);
  console.log("TempTest TO VIEW: ", accuracyInput);
  return (
    <>
      <ResultContext.Provider value={resultId}>
        <SideBar
          userId={userId}
          testType={"accuracyTest"}
          setSelectedResult={setSelectedResult}
          setTestResult={setAccuracyResult}
          activeTab={activeTab}
          setActiveTab={setActiveTab}
          newDataAction={newDataAction}
        />
        <AccuracyInputSpace
          setResultId={setResultId}
          userId={userId}
          accuracyInput={accuracyInput}
          setAccuracyInput={setAccuracyInput}
          accuracyUnitTest={accuracyUnitTest}
          setAccuracyUnitTest={setAccuracyUnitTest}
          accuracyBaseMethod={accuracyBaseMethod}
          setAccuracyBaseMethod={setAccuracyBaseMethod}
          accuracyDescription={accuracyDescription}
          setAccuracyDescription={setAccuracyDescription}
          accuracyDependency1={accuracyDependency1}
          setAccuracyDependency1={setAccuracyDependency1}
          accuracyDependency2={accuracyDependency2}
          setAccuracyDependency2={setAccuracyDependency2}
          accuracySelectedLanguage={accuracySelectedLanguage}
          setAccuracySelectedLanguage={setAccuracySelectedLanguage}
          accuracyTestType={accuracyTestType}
          setAccuracyTestType={setAccuracyTestType}
          setSelectedResult={setSelectedResult}
          setAccuracyResult={setAccuracyResult}
          setNewDataAction={setNewDataAction}
        />
        <AccuracyOutputSpace
          //output props
          resultId={resultId}
          testResult={
            Object.keys(selectedResult).length === 0
              ? accuracyResult
              : selectedResult
          }
          setAccuracyResult={setAccuracyResult}
          setSelectedResult={setSelectedResult}
        />
      </ResultContext.Provider>
    </>
  );
};

export default TempTest;
