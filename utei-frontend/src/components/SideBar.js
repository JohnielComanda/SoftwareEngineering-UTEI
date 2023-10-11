import React, { useState, useEffect, useContext } from "react";
import ResultContext from "../ResultContext";
import { Link } from "react-router-dom";
import axios from "axios";
import "../css/SideBar.css";

const SideBar = ({ setSelectedResult, setTestResult }) => {
  const [activeTab, setActiveTab] = useState(0);
  const [tests, setTests] = useState([]);

  const handleTabClick = (tabIndex) => {
    setActiveTab(tabIndex);
  };

  useEffect(() => {
    // This method is for the fetching
    const fetchTestResult = async () => {
      try {
        const response = await axios.get(
          `https://localhost:7070/api/GenerateTest/all`
        );
        const reversedData = [...response.data].reverse();

        setTests(reversedData);
      } catch (error) {
        console.log(error);
      }
    };
    fetchTestResult();
  }, []);

  const handleViewHistory = (test) => {
    setTestResult({});
    setSelectedResult(test);
  };

  return (
    <div className="sidebar">
      <div className="buttons">
        <Link
          to="/efficiency_test"
          className={activeTab === 0 ? "active-efficiency" : "efficiency"}
          onClick={() => handleTabClick(0)}
        >
          {" "}
          Identify Efficiency
        </Link>
        <Link
          to="/accuracy"
          className={activeTab === 1 ? "active-accuracy" : "accuracy"}
          onClick={() => handleTabClick(1)}
        >
          {" "}
          Identify Accuracy
        </Link>
        <Link
          to="/generate_test"
          className={activeTab === 2 ? "active-generate" : "generate"}
          onClick={() => handleTabClick(2)}
        >
          {" "}
          Generate Unit Test
        </Link>
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
