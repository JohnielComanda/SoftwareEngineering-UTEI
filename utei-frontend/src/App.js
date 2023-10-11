import { React, useState } from "react";
import { Routes, Route } from "react-router-dom";
import ResultContext from "./ResultContext";
import HeaderBar from "./components/HeaderBar";
import SideBar from "./components/SideBar";
import EfficiencyTest from "./pages/efficiencyTest/layout/EfficiencyTest";
import GenerateTest from "./pages/generateTest/layout/GenerateTest";
import "./css/App.css";

function App() {
  const [selectedResult, setSelectedResult] = useState({});
  const [testResult, setTestResult] = useState({});
  return (
    <div className="background">
      <HeaderBar />
      <ResultContext.Provider value={selectedResult}>
        <SideBar
          setSelectedResult={setSelectedResult}
          setTestResult={setTestResult}
        />
        {console.log("selectedResult at App: " + selectedResult)}
        <Routes>
          <Route index path="/" element={<EfficiencyTest />} />
          <Route path="efficiency_test" element={<EfficiencyTest />} />
          <Route
            path="generate_test"
            element={
              <GenerateTest
                selectedResult={selectedResult}
                setSelectedResult={setSelectedResult}
              />
            }
          />
        </Routes>
      </ResultContext.Provider>
    </div>
  );
}

export default App;
