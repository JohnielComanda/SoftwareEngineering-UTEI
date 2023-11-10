import { React, useRef, useState, useEffect, useContext } from "react";
import EffiencyBar from "../output/EfficiencyBar";
import axios from "axios";
import "../../../css/OutputSpace.css";
import StandardOutput from "../output/StandardOutput";
import SuggestionOutput from "../output/SuggestionOutput";
import EnhancedOutput from "../output/EnhancedOutput";

const EfficiencyOutputSpace = ({
  resultId,
  testResult,
  setEfficiencyResult,
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
          `https://localhost:7070/api/EfficiencyTest?id=${resultId}`
        );
        setEfficiencyResult(response.data);
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
          Summary
        </button>
        <button
          className={activeTab === 1 ? "active-suggestion" : "suggestion"}
          onClick={() => handleTabClick(1)}
        >
          {" "}
          Suggestions
        </button>
        <button
          className={activeTab === 2 ? "active-enhance" : "enhance"}
          onClick={() => handleTabClick(2)}
        >
          {" "}
          Enhanced Version
        </button>
      </div>
      {activeTab === 0 && <StandardOutput testResult={testResult} />}
      {activeTab === 1 && <SuggestionOutput testResult={testResult} />}
      {activeTab === 2 && <EnhancedOutput testResult={testResult} />}

      {testResult.efficiencyScore && (
        <EffiencyBar score={testResult.efficiencyScore} />
      )}
    </div>
  );
};

export default EfficiencyOutputSpace;
