import React, { useState, useEffect } from "react";
import axios from "axios";
import SelectProgLang from "../../../components/SelectProgLang";
import CodeMirror from "@uiw/react-codemirror";
import { javascript } from "@codemirror/lang-javascript";
import { java } from "@codemirror/lang-java";
import { python } from "@codemirror/lang-python";
import { cpp } from "@codemirror/lang-cpp";
import "../../../css/InputSpace.css";

const GenerateInputSpace = ({
  userId,
  setResultId,
  selectedResult,
  setSelectedResult,
  setGenerateResult,
  genereateBaseInput,
  setGenerateBaseInput,
  generateBaseMethod,
  setGenerateBaseMethod,
  generateSelectedLanguage,
  setGenerateSelectedLanguage,
  setNewDataAction,
}) => {
  const [action, setAction] = useState(0);
  const [isLoading, setIsLoading] = useState(true);

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
      console.log("Temp", genereateBaseInput);
      try {
        const response = await axios.post(
          `https://localhost:7070/api/generate`,
          genereateBaseInput
        );
        setResultId(response.data);
        setNewDataAction((prev) => prev + 1);
        alert("Successfully created a test.");
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
    setGenerateBaseInput((prevData) => ({
      userId,
      baseMethod: `${generateBaseMethod}`,
      programmingLanguage: `${generateSelectedLanguage}`,
    }));
    setSelectedResult({});
    setGenerateResult({});
    setAction((prev) => prev + 1);
  };

  // For selected prog languange onChange

  // For text editor onChange
  const onChange = React.useCallback((value, viewUpdate) => {
    console.log("value:", value);
    setGenerateBaseMethod(value);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  let extensions;
  let options;

  if (generateSelectedLanguage === "Java") {
    extensions = [java()];
    options = {
      mode: "text/x-java",
      // other options for Java...
    };
  } else if (generateSelectedLanguage === "C++") {
    extensions = [cpp()];
    options = {
      mode: "text/x-c++src",
      // other options for C++...
    };
  } else if (generateSelectedLanguage === "Python") {
    extensions = [python()];
    options = {
      mode: "text/x-python",
      // other options for Python...
    };
  } else if (generateSelectedLanguage === "JavaScript") {
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
            setSelectedLanguage={setGenerateSelectedLanguage}
            selectedResult={selectedResult}
            selectedLanguage={generateSelectedLanguage}
          />
        </div>
        <CodeMirror
          name="unitTest"
          className="input-space"
          placeholder={"Paste your unit test method here!"}
          value={
            Object.keys(selectedResult).length === 0
              ? genereateBaseInput.baseMethod
              : selectedResult.baseMethod
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

export default GenerateInputSpace;
