import React, { useState } from "react";
import { Link } from "react-router-dom";
import "../css/SideBar.css";

const SideBar = () => {
  const [activeTab, setActiveTab] = useState(0);

  const handleTabClick = (tabIndex) => {
    setActiveTab(tabIndex);
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
        <ul>
          <li>
            <button className="btn-test"> saved test</button>
          </li>
        </ul>
      </div>

      <button className="clear-history"> Clear History</button>
    </div>
  );
};

export default SideBar;
