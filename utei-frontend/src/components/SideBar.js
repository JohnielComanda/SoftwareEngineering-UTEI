import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import "../css/SideBar.css";

const SideBar = ({
  userId,
  testType,
  activeTab,
  setSelectedResult,
  setTestResult,
  setActiveTab,
  newDataAction,
}) => {
  const [tests, setTests] = useState([]);
  const navigate = useNavigate(); // Use useNavigate from re-navigate
  const handleTabClick = (tabIndex) => {
    setActiveTab(tabIndex);
    console.log("Active Tab: ", activeTab);
  };

  useEffect(() => {
    // This method is for the fetching
    const fetchTestResult = async () => {
      try {
        const response = await axios.get(
          testType === "efficiencyTest"
            ? `https://utei20240206153836.azurewebsites.net/api/efficiency/all/${userId}`
            : testType === "generateTest"
            ? `https://utei20240206153836.azurewebsites.net/api/generate/all/${userId}`
            : testType === "accuracyTest"
            ? `https://utei20240206153836.azurewebsites.net/api/accuracy/all/${userId}`
            : ""
        );
        const reversedData = [...response.data].reverse();

        setTests(reversedData);
        console.log("Tests: ", tests);
      } catch (error) {
        console.log(error);
      }
    };
    fetchTestResult();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [newDataAction]);

  const handleViewHistory = (test) => {
    setTestResult({});
    setSelectedResult(test);
  };

  const tabs = [
    {
      to: "/efficiency-test",
      text: "Identify Efficiency",
      className: "efficiency",
    },
    { to: "/accuracy-test", text: "Identify Accuracy", className: "accuracy" },
    { to: "/generate-test", text: "Generate Unit Test", className: "generate" },
  ];

  return (
    <div className="sidebar">
      <div className="buttons">
        {tabs.map((tab, index) => (
          <button
            key={index}
            onClick={() => {
              handleTabClick(index);
              navigate(tab.to); // Use navigate to switch routes
            }}
            className={
              activeTab === index ? `active-${tab.className}` : tab.className
            }
          >
            {tab.text}
          </button>
        ))}
      </div>

      <div className="saved-test">
        {tests.map((test, index) => {
          return (
            <ul>
              <li>
                <button
                  onClick={() => handleViewHistory(test)}
                  className="btn-test"
                >
                  {test.programmingLanguage + "   " + test.date}
                </button>
              </li>
            </ul>
          );
        })}
      </div>

      {/* <button className="clear-history"> Clear History</button> */}
    </div>
  );
};

export default SideBar;
