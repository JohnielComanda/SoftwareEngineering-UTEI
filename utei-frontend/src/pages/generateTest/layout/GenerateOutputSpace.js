import { React, useEffect } from "react";
import GenerateStandardOutput from "../output/GenerateStandardOutput";
import axios from "axios";
import { CopyToClipboard } from "react-copy-to-clipboard";
import "../../../css/OutputSpace.css";

const GenerateOutputSpace = ({
  resultId,
  testResult,
  setGenerateResult,
  setSelectedResult,
}) => {
  console.log("GenerateOutputSpace testResult:", testResult);

  // This is for getting the result from the database by fetching using axios
  // This will trigger everytime resultId is being updated
  useEffect(() => {
    // This method is for the fetching
    const fetchTestResult = async () => {
      try {
        const response = await axios.get(
          `https://utei20240206153836.azurewebsites.net/api/generate/${resultId}`
        );
        setGenerateResult(response.data);
        setSelectedResult({});
        console.log("TestResult: ", testResult);
      } catch (error) {
        console.log(error);
      }
    };
    fetchTestResult();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [resultId]);

  return (
    <div className="output">
      <div className="output-header">
        <button disabled={true} className="standard2">
          Standard Output
        </button>{" "}
        {testResult.unitTest ? (
          <CopyToClipboard
            text={testResult.unitTest}
            onCopy={(text, result) => console.log(result)}
          >
            <button className="copy-btn"> Copy</button>
          </CopyToClipboard>
        ) : (
          ""
        )}
      </div>
      <GenerateStandardOutput testResult={testResult} />
    </div>
  );
};

export default GenerateOutputSpace;
