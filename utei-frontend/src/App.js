import React, { useEffect, useState } from "react";
import { HashRouter as Router, Routes, Route } from "react-router-dom";
import ResultContext from "./ResultContext";
import EfficiencyTest from "./pages/efficiencyTest/layout/EfficiencyTest";
import GenerateTest from "./pages/generateTest/layout/GenerateTest";
import AccuracyTest from "./pages/accuracyTest/layout/TempTest";
// import AccuracyTest from "./";
import Login from "./components/Login";
import Register from "./components/Register";
import HeaderBar from "./components/HeaderBar";
import { jwtDecode } from "jwt-decode";
import { Navigate } from "react-router-dom";
import axios from "axios";
import "./css/App.css";

function App() {
  // navigation

  // For login authentication
  const [isAuthenticated, setIsAuthenticated] = useState(() => {
    const token = localStorage.getItem("authToken");
    console.log(!!token);
    return !!token;
  });
  const [newDataAction, setNewDataAction] = useState(0);
  const [, setDecodeToken] = useState({});

  useEffect(() => {
    const token = localStorage.getItem("authToken");

    async function checkAuthentication() {
      if (!token) {
        setIsAuthenticated(false); // No token found, user not authenticated
        return false;
      }

      try {
        const response = await axios.post(
          "https://localhost:7070/api/authenticate/verifyToken",
          null,
          {
            headers: {
              "Content-Type": "application/json",
              Authorization: `Bearer ${token}`,
            },
          }
        );

        const isAuthenticated = response.status === 200; // Check if response status is OK (200)
        setIsAuthenticated(isAuthenticated);

        if (isAuthenticated) {
          const decodedToken = jwtDecode(token);
          setDecodeToken(decodedToken);
          setUserId(
            decodedToken[
              "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
            ]
          ); // Accessing the 'sub' claim for user ID
          setUserName(
            decodedToken[
              "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
            ]
          );
          setNewDataAction((prev) => prev + 1);
        }

        return isAuthenticated;
      } catch (error) {
        console.error("Verification error:", error);
        setIsAuthenticated(false);
        return false;
      }
    }

    checkAuthentication();
  }, []);

  // For currently logged in User (UserId)
  const [userId, setUserId] = useState("");
  const [userName, setUserName] = useState("");

  // Efficiency inputs
  const initialEfficiencyInputs = {
    userId: "",
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

  // Accuracy inputs
  const initialAccuracyInputs = {
    userId: "",
    baseMethod: "string",
    programmingLanguage: "string",
    unitTest: "string",
    unitTestType: "string",
    description: "string",
    dependency1: "string",
    dependency2: "string",
  };

  const [accuracyInput, setAccuracyInput] = useState(initialAccuracyInputs);
  const [accuracyUnitTest, setAccuracyUnitTest] = useState("");
  const [accuracyBaseMethod, setAccuracyBaseMethod] = useState("");
  const [accuracyDescription, setAccuracyDescription] = useState("");
  const [accuracyDependency1, setAccuracyDependency1] = useState("");
  const [accuracyDependency2, setAccuracyDependency2] = useState("");
  const [accuracySelectedLanguage, setAccuracySelectedLanguage] = useState("");
  const [accuracyTestType, setAccuracyTestType] = useState("");

  const [accuracyResult, setAccuracyResult] = useState({});
  const [accuracySelectedResult, setAccuracySelectedResult] = useState({});

  // Generate inputs
  const initialGenerateInputs = {
    userId: userId,
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
      <HeaderBar
        userName={userName}
        setIsAuthenticated={setIsAuthenticated}
        setUserId={setUserId}
        setUserName={setUserName}
      />
      <ResultContext.Provider>
        <Router>
          <Routes>
            <Route
              path="/login"
              element={
                <Login
                  setUserName={setUserName}
                  setUserId={setUserId}
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
                  setUserName={setUserName}
                  setUserId={setUserId}
                  isAuthenticated={isAuthenticated}
                  setIsAuthenticated={setIsAuthenticated}
                />
              }
            />
            <Route
              path="/accuracy"
              element={
                isAuthenticated ? (
                  <AccuracyTest
                    userId={userId}
                    testType={""}
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
                    accuracyResult={accuracyResult}
                    setAccuracyResult={setAccuracyResult}
                    selectedResult={accuracySelectedResult}
                    setSelectedResult={setAccuracySelectedResult}
                    newDataAction={newDataAction}
                    setNewDataAction={setNewDataAction}
                  />
                ) : (
                  <Navigate to="/login" replace />
                )
              }
            />
            <Route
              path="/efficiency_test"
              element={
                isAuthenticated ? (
                  <EfficiencyTest
                    userId={userId}
                    testType={""}
                    selectedResult={efficiencySelectedResult}
                    setSelectedResult={setEfficiencySelectedResult}
                    efficiencyInput={efficiencyInput}
                    setEfficiencyInput={setEfficiencyInput}
                    unitTest={unitTest}
                    setUnitTest={setUnitTest}
                    efficiencySelectedLanguage={efficiencySelectedLanguage}
                    setEfficiencySelectedLanguage={
                      setEfficiencySelectedLanguage
                    }
                    efficiencyResult={efficiencyResult}
                    setEfficiencyResult={setEfficiencyResult}
                    isAuthenticated={isAuthenticated}
                    setIsAuthenticated={setIsAuthenticated}
                    newDataAction={newDataAction}
                    setNewDataAction={setNewDataAction}
                  />
                ) : (
                  <Navigate to="/login" replace />
                )
              }
            />
            <Route
              path="/generate_test"
              element={
                isAuthenticated ? (
                  <GenerateTest
                    userId={userId}
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
                ) : (
                  <Navigate to="/login" replace />
                )
              }
            />
          </Routes>
        </Router>
      </ResultContext.Provider>
    </div>
  );
}

export default App;
