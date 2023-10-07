import { React, useRef, useEffect } from "react";
import GenerateStandardOutput from "../output/GenerateStandardOutput";
import axios from "axios";
import "../../../css/OutputSpace.css";

const GenerateOutputSpace = ({ resultId, testResult, setTestResult }) => {
  const isFirstRender = useRef(true);

  // This is for getting the result from the database by fetching using axioss
  // This will trigger everytime resultId is being updated
  useEffect(() => {
    // This method is for the fetching
    const fetchTestResult = async () => {
      try {
        const response = await axios.get(
          `https://localhost:7070/api/GenerateTest?id=${resultId}`
        );
        setTestResult(response.data);
      } catch (error) {
        console.log(error);
      }
    };
    fetchTestResult();
  }, [resultId]);

  return (
    <div className="output">
      <div className="output-header">
        <button disabled={true} className="standard2">
          Standard Output
        </button>{" "}
      </div>
      <GenerateStandardOutput testResult={testResult} />
    </div>
  );
};

export default GenerateOutputSpace;
