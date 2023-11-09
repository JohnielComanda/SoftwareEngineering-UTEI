import React, { useState, useEffect, useContext } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import "../css/SideBar.css";

const SideBar = ({
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
  };

  useEffect(() => {
    // This method is for the fetching
    const fetchTestResult = async () => {
      try {
        const response = await axios.get(
          testType === "efficiencyTest"
            ? `https://localhost:7070/api/EfficiencyTest/all`
            : `https://localhost:7070/api/GenerateTest/all`
        );
        const reversedData = [...response.data].reverse();

        setTests(reversedData);
      } catch (error) {
        console.log(error);
      }
    };
    fetchTestResult();
  }, [newDataAction]);

  const handleViewHistory = (test) => {
    setTestResult({});
    setSelectedResult(test);
  };

  const tabs = [
    {
      to: "/efficiency_test",
      text: "Identify Efficiency",
      className: "efficiency",
    },
    { to: "/accuracy", text: "Identify Accuracy", className: "accuracy" },
    { to: "/generate_test", text: "Generate Unit Test", className: "generate" },
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
