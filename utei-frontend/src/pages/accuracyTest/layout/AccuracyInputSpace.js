import React, { useState, useEffect } from "react";
import axios from "axios";
import "../../../css/InputSpace.css";
import CodeMirror from "@uiw/react-codemirror";
import { javascript } from "@codemirror/lang-javascript";
import { java } from "@codemirror/lang-java";
import { python } from "@codemirror/lang-python";
import { cpp } from "@codemirror/lang-cpp";

const AccuracyInputSpace = ({
  userId,
  setResultId,
  accuracyInput,
  setAccuracyInput,
  accuracyUnitTest,
  setAccuracyUnitTest,
  accuracyBaseMethod,
  setAccuracyBaseMethod,
  accuracyDescription,
  setAccuracyDescription,
  accuracyDependency1,
  setAccuracyDependency1,
  accuracyDependency2,
  setAccuracyDependency2,
  accuracySelectedLanguage,
  setAccuracySelectedLanguage,
  accuracyTestType,
  setAccuracyTestType,
  setSelectedResult,
  setAccuracyResult,
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
      try {
        const response = await axios.post(
          `https://utei20240206153836.azurewebsites.net/api/accuracy`,
          accuracyInput
        );
        setResultId(response.data);
        console.log("Result ID: ", response.data);
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
    setAccuracyInput(() => ({
      userId: userId,
      baseMethod: accuracyBaseMethod,
      programmingLanguage: accuracySelectedLanguage,
      unitTest: accuracyUnitTest,
      unitTestType: accuracyTestType,
      description: accuracyDescription,
      dependency1: accuracyDependency1,
      dependency2: accuracyDependency2,
    }));
    setSelectedResult({});
    setAccuracyResult({});
    setAction((prev) => prev + 1);
  };

  // For text editor onChange
  const onChangeUnitTest = React.useCallback((value) => {
    setAccuracyUnitTest(value);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const onChangeBaseMethod = React.useCallback((value) => {
    setAccuracyBaseMethod(value);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const onChangeDescription = React.useCallback((value) => {
    setAccuracyDescription(value);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const onChangeDependency1 = React.useCallback((value) => {
    setAccuracyDependency1(value);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const onChangeDependency2 = React.useCallback((value) => {
    setAccuracyDependency2(value);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const handleSelectChange = (event) => {
    const selectedValue = event.target.value;
    setAccuracySelectedLanguage(selectedValue);
  };

  const handleTestTypeChange = (event) => {
    const selectedValue = event.target.value;
    setAccuracyTestType(selectedValue);
  };

  let extensions;
  let options;

  if (accuracySelectedLanguage === "Java") {
    extensions = [java()];
    options = {
      mode: "text/x-java",
      // other options for Java...
    };
  } else if (accuracySelectedLanguage === "C++") {
    extensions = [cpp()];
    options = {
      mode: "text/x-c++src",
      // other options for C++...
    };
  } else if (accuracySelectedLanguage === "Python") {
    extensions = [python()];
    options = {
      mode: "text/x-python",
      // other options for Python...
    };
  } else if (accuracySelectedLanguage === "JavaScript") {
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
        <div className="accuracy-input-header">
          <div>
            <select
              value={accuracySelectedLanguage}
              onChange={handleSelectChange}
              className="proglang-drop-down"
            >
              <option defaultValue="Select a language">Select Language</option>
              <option value="javascript">JavaScript</option>
              <option value="python">Python</option>
              <option value="java">Java</option>
              <option value="csharp">C#</option>
              <option value="ruby">Ruby</option>
            </select>
          </div>
          <div>
            <select
              value={accuracyTestType}
              onChange={handleTestTypeChange}
              className="testtype-drop-down"
            >
              <option defaultValue="Select what type of unit test">
                Select what type of unit test
              </option>
              <option value="Simple">Simple</option>
              <option value="Parameterized">Parameterized</option>
              <option value="Multi Dependency">Multi Dependency</option>
            </select>
          </div>
        </div>
        <div>
          <CodeMirror
            name="unitTest"
            placeholder={"Paste Unit test here!!!"}
            height="170px"
            extensions={extensions}
            options={options}
            theme="dark"
            value={accuracyUnitTest}
            onChange={onChangeUnitTest}
          ></CodeMirror>
          <CodeMirror
            name="basedMethod"
            placeholder={"Paste Based method here!!!"}
            height="170px"
            extensions={extensions}
            options={options}
            theme="dark"
            value={accuracyBaseMethod}
            onChange={onChangeBaseMethod}
          ></CodeMirror>
          <CodeMirror
            name="description"
            placeholder={"Input description (Optional)"}
            height="70px"
            extensions={extensions}
            options={options}
            theme="dark"
            value={accuracyDescription}
            onChange={onChangeDescription}
          ></CodeMirror>
          <div id="dependencyText">
            <CodeMirror
              name="dependency1"
              placeholder="Dependency 1 (Optional)"
              height="74px"
              extensions={extensions}
              options={options}
              theme="dark"
              value={accuracyDependency1}
              onChange={onChangeDependency1}
            ></CodeMirror>
            <CodeMirror
              name="dependency2"
              placeholder="Dependency 2 (Optional)"
              height="74px"
              extensions={extensions}
              options={options}
              theme="dark"
              value={accuracyDependency2}
              onChange={onChangeDependency2}
            ></CodeMirror>
          </div>
        </div>
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

export default AccuracyInputSpace;
