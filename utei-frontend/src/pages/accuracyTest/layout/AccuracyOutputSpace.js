import { React, useRef, useState, useEffect } from "react";
import axios from "axios";
import "../../../css/OutputSpace.css";
import TestCase from "../output/TestCase";
import Performance from "../output/Performance";
import Recommendation from "../output/Recommendation";

const AccuracyOutputSpace = ({
  resultId,
  testResult,
  setAccuracyResult,
  setSelectedResult,
}) => {
  const [activeTab, setActiveTab] = useState(0);
  const isFirstRender = useRef(true);

  // This is for getting the result from the database by fetching using axios
  // This will trigger everytime resultId is being updated

  useEffect(() => {
    // This method is for the fetching
    const fetchTestResult = async () => {
      try {
        const response = await axios.get(
          `https://localhost:7070/api/AccuracyTest/${resultId}`
        );
        setAccuracyResult(response.data);
        console.log("TEST RESULT ACCURACY: ", testResult);
        setSelectedResult({});
      } catch (error) {
        console.log(error);
      }
    };
    fetchTestResult();
  }, [resultId]);

  // This useEffect is for the tabs to dynamically change every re-render
  useEffect(() => {
    handleTabClick(activeTab);
  }, []);

  const handleTabClick = (tabIndex) => {
    setActiveTab(tabIndex);
  };

  return (
    <div className="output">
      <div className="output-header">
        <button
          className={activeTab === 0 ? "active-standard" : "standard"}
          onClick={() => handleTabClick(0)}
        >
          {" "}
          Test Cases
        </button>
        <button
          className={activeTab === 1 ? "active-suggestion" : "suggestion"}
          onClick={() => handleTabClick(1)}
        >
          {" "}
          Performance
        </button>
      </div>
      {activeTab === 0 && <TestCase testResult={testResult} />}
      {activeTab === 1 && <Performance testResult={testResult} />}
    </div>
  );
};

export default AccuracyOutputSpace;
