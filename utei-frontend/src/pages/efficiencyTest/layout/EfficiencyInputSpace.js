import React, { useState, useEffect, useRef, useContext } from "react";
import axios from "axios";
import SelectProgLang from "../../../components/SelectProgLang";
import ResultContext from "../../../ResultContext";
import "../../../css/InputSpace.css";
import CodeMirror from "@uiw/react-codemirror";
import { javascript } from "@codemirror/lang-javascript";

const EfficiencyInputSpace = ({ setResultId, setTestResult }) => {
  const temp = {
    unitTest: "",
    programmingLanguage: "",
  };
  const [testInput, setTestInput] = useState(temp);
  const [unitTest, setUnitTest] = useState("");
  const [selectedLanguage, setSelectedLanguage] = useState("");
  const isFirstRender = useRef(true);
  const [action, setAction] = useState(0);
  const resultId = useContext(ResultContext);
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
          `https://localhost:7070/api/EfficiencyTest`,
          testInput
        );
        setResultId(response.data);
        alert("Successfully created a test.");
      } catch (error) {
        console.error(error);
        alert("Failed to create a test.");
      } finally {
        setIsLoading(false);
      }
    };

    createTest();
  }, [action]);

  // For submiting test, setAction will be updated and will trigger the useEffect for POST
  const onClickSubmit = () => {
    setTestInput((prevData) => ({
      unitTest: `${unitTest}`,
      programmingLanguage: `${selectedLanguage}`,
    }));
    setTestResult({});
    setAction((prev) => prev + 1);
  };

  // For selected prog languange onChange
  const handleSelectedLanguageChange = (selectedValue) => {
    setSelectedLanguage(selectedValue);
  };

  // For text editor onChange
  const onChange = React.useCallback((value, viewUpdate) => {
    console.log("value:", value);
    setUnitTest(value);
  }, []);

  return (
    <>
      <div className="input">
        <div className="input-header">
          <SelectProgLang
            onSelectedLanguageChange={handleSelectedLanguageChange}
          />
        </div>
        <CodeMirror
          name="unitTest"
          className="input-space"
          placeholder={"Paste your unit test method here!"}
          value={testInput.unitTest}
          height="555px"
          extensions={[javascript({ jsx: true })]}
          onChange={onChange}
          theme="dark"
        ></CodeMirror>
      </div>
      <div>
        <button className="btn-save">Save</button>
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