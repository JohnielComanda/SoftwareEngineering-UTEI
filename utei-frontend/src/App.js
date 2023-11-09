import { React, useState } from "react";
import { Routes, Route } from "react-router-dom";
import ResultContext from "./ResultContext";
import EfficiencyTest from "./pages/efficiencyTest/layout/EfficiencyTest";
import GenerateTest from "./pages/generateTest/layout/GenerateTest";
import Login from "./components/Login";
import Register from "./components/Register";
import "./css/App.css";

function App() {
  // For login authentication
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [newDataAction, setNewDataAction] = useState(0);

  // Effeciency inputs
  const initialEfficiencyInputs = {
    unitTest: "",
    programmingLanguage: "",
  };
  const [efficiencyInput, setEfficiencyInput] = useState(
    initialEfficiencyInputs
  );
  const [unitTest, setUnitTest] = useState("");
  const [efficiencySelectedLanguage, setEfficiencySelectedLanguage] =
    useState("");
  const [efficiencyResult, setEfficiencyResult] = useState({});
  const [efficiencySelectedResult, setEfficiencySelectedResult] = useState({});

  // Generate inputs
  const initialGenerateInputs = {
    baseMethod: "",
    programmingLanguage: "",
  };
  const [genereateBaseInput, setGenerateBaseInput] = useState(
    initialGenerateInputs
  );
  const [generateBaseMethod, setGenerateBaseMethod] = useState("");
  const [generateSelectedLanguage, setGenerateSelectedLanguage] = useState("");
  const [generateResult, setGenerateResult] = useState({});
  const [generateSelectedResult, setGenerateSelectedResult] = useState({});
  return (
    <div className="background">
      <ResultContext.Provider>
        <Routes>
          <Route
            path="/login"
            element={
              <Login
                isAuthenticated={isAuthenticated}
                setIsAuthenticated={setIsAuthenticated}
              />
            }
          />
          <Route path="/signup" element={<Register />} />
          <Route
            path="/"
            element={
              <Login
                isAuthenticated={isAuthenticated}
                setIsAuthenticated={setIsAuthenticated}
              />
            }
          />
          <Route
            path="efficiency_test"
            element={
              <EfficiencyTest
                testType={""}
                selectedResult={efficiencySelectedResult}
                setSelectedResult={setEfficiencySelectedResult}
                efficiencyInput={efficiencyInput}
                setEfficiencyInput={setEfficiencyInput}
                unitTest={unitTest}
                setUnitTest={setUnitTest}
                efficiencySelectedLanguage={efficiencySelectedLanguage}
                setEfficiencySelectedLanguage={setEfficiencySelectedLanguage}
                efficiencyResult={efficiencyResult}
                setEfficiencyResult={setEfficiencyResult}
                isAuthenticated={isAuthenticated}
                setIsAuthenticated={setIsAuthenticated}
                newDataAction={newDataAction}
                setNewDataAction={setNewDataAction}
              />
            }
          />
          <Route
            path="generate_test"
            element={
              <GenerateTest
                testType={""}
                selectedResult={generateSelectedResult}
                setSelectedResult={setGenerateSelectedResult}
                genereateBaseInput={genereateBaseInput}
                setGenerateBaseInput={setGenerateBaseInput}
                generateBaseMethod={generateBaseMethod}
                setGenerateBaseMethod={setGenerateBaseMethod}
                generateSelectedLanguage={generateSelectedLanguage}
                setGenerateSelectedLanguage={setGenerateSelectedLanguage}
                generateResult={generateResult}
                setGenerateResult={setGenerateResult}
                newDataAction={newDataAction}
                setNewDataAction={setNewDataAction}
              />
            }
          />
        </Routes>
      </ResultContext.Provider>
    </div>
  );
}

export default App;
