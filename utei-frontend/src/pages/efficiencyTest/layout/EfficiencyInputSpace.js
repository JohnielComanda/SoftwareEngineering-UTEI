import React, { useState, useEffect } from "react";
import axios from "axios";
import SelectProgLang from "../../../components/SelectProgLang";
import "../../../css/InputSpace.css";
import CodeMirror from "@uiw/react-codemirror";
import { javascript } from "@codemirror/lang-javascript";
import { java } from "@codemirror/lang-java";
import { python } from "@codemirror/lang-python";
import { cpp } from "@codemirror/lang-cpp";

const EfficiencyInputSpace = ({
  userId,
  setResultId,
  selectedResult,
  setSelectedResult,
  setEfficiencyResult,
  efficiencyInput,
  setEfficiencyInput,
  unitTest,
  setUnitTest,
  efficiencySelectedLanguage,
  setEfficiencySelectedLanguage,
  setNewDataAction,
}) => {
  const [action, setAction] = useState(0);
  const [isLoading, setIsLoading] = useState(true);
  console.log("EfficiencyInput1: ", efficiencyInput);

  // This is for passing the parameters to the backend to generate unit test
  // This useEffect will trigger when submit button will click as the action trigger is being updated
  useEffect(() => {
    if (action === 0) {
      setTimeout(() => {
        setIsLoading(false);
      }, 1000);
      return;
    }

    //This method is for the Post and uses axios to pass on the parameters to the backend side
    const createTest = async () => {
      setIsLoading(true);
      try {
        const response = await axios.post(
          `https://utei20240206153836.azurewebsites.net/api/efficiency`,
          efficiencyInput
        );
        setResultId(response.data);
        setNewDataAction((prev) => prev + 1);
      } catch (error) {
        console.error(error);
        alert("Failed to create a test.");
      } finally {
        setIsLoading(false);
      }
    };

    createTest();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [action]);

  // For submiting test, setAction will be updated and will trigger the useEffect for POST
  const onClickSubmit = () => {
    setEfficiencyInput((prevData) => ({
      userId,
      unitTest: `${unitTest}`,
      programmingLanguage: `${efficiencySelectedLanguage}`,
    }));
    console.log("EfficiencyInput2: ", efficiencyInput);
    setSelectedResult({});
    setEfficiencyResult({});
    setAction((prev) => prev + 1);
  };

  // For text editor onChange
  const onChange = React.useCallback((value, viewUpdate) => {
    console.log("value:", value);
    setUnitTest(value);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  let extensions;
  let options;

  if (efficiencySelectedLanguage === "Java") {
    extensions = [java()];
    options = {
      mode: "text/x-java",
      // other options for Java...
    };
  } else if (efficiencySelectedLanguage === "C++") {
    extensions = [cpp()];
    options = {
      mode: "text/x-c++src",
      // other options for C++...
    };
  } else if (efficiencySelectedLanguage === "Python") {
    extensions = [python()];
    options = {
      mode: "text/x-python",
      // other options for Python...
    };
  } else if (efficiencySelectedLanguage === "JavaScript") {
    extensions = [javascript()];
    options = {
      mode: "text/javascript",
      // other options for JavaScript...
    };
  } else {
    // Default to JavaScript if the language is not recognized
    extensions = [javascript()];
    options = {
      mode: "text/javascript",
      // other default options...
    };
  }

  return (
    <>
      <div className="input">
        <div className="input-header">
          <SelectProgLang
            setSelectedLanguage={setEfficiencySelectedLanguage}
            selectedResult={selectedResult}
            selectedLanguage={efficiencySelectedLanguage}
          />
        </div>
        <CodeMirror
          name="unitTest"
          className="input-space"
          placeholder={"Paste your unit test method here"}
          value={
            Object.keys(selectedResult).length === 0
              ? unitTest
              : selectedResult.unitTest
          }
          height="555px"
          extensions={extensions}
          options={options}
          onChange={onChange}
          theme="dark"
        ></CodeMirror>
      </div>
      <div>
        <button className="btn-identify" onClick={onClickSubmit}>
          Submit
        </button>
      </div>
      {isLoading && (
        <div className="loading-indicator">
          <div className="spinner" />
          <h1 className="loading-msg">Processing...</h1>
        </div>
      )}
    </>
  );
};

export default EfficiencyInputSpace;
