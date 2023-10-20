import React, { useState } from 'react';
import './css/accuracy.css';
import axios from "axios";
import CodeMirror from "@uiw/react-codemirror";
import { javascript } from "@codemirror/lang-javascript";
import "./css/OutputSpace.css";

function AccuracyTest() {
    var responseData = {
        UnitTest: "",
        ProgrammingLanguage: "",
        Date: "",
        ResultSummary: "",
        TestResult: "",
        TestSuggestions: "",
        EnhancedVersion: "",
    };
    //Input
    const [basedMethod, setBasedMethod] = useState('');
    const [programmingLanguage, setProgrammingLanguage] = useState('');
    const [unitTest, setUnitTest] = useState('');
    const [unitTestType, setUnitTestType] = useState('');
    const [description, setDescription] = useState('');
    const [dependency1, setDependency1] = useState('');
    const [dependency2, setDependency2] = useState('');
    const [outputText, setOutputText] = useState('');
    //Output
    const [testResult, setTestResult] = useState('');
    const [summary, setSummary] = useState('');
    const [recommendations, setRecommendations] = useState('');
    const [enhanceVersion, setEnhanceVersiom] = useState('');

    // For submiting test, setAction will be updated and will trigger the useEffect for POST
    const onClickSubmit = async () => {
        const finalData = {
            BaseMethod: basedMethod,
            ProgrammingLanguage: programmingLanguage,
            UnitTest: unitTest,
            UnitTestType: unitTestType,
            Description: description,
            Dependency1: dependency1,
            Dependency2: dependency2,
        };
        try {
            const response = await axios.post(
                'https://localhost:7070/api/AccuracyTest',
                finalData
            );
            console.log(response.data);
            alert('Successfully created a test.');
        } catch (error) {
            console.error(error);
            alert('Failed to create a test.');
        }
    };

    const testCasesBtn = async () => {
        setOutputText(testResult);
    };

    const summaryBtn = async () => {
        setOutputText(summary);
        console.log(outputText);
    };

    const recommendationsBtn = async () => {
        setOutputText(recommendations);
    };

    const enhanceVersionBtn = async () => {
        setOutputText(enhanceVersion);
    };

    // Function to handle changes in the dropdown
    const handleLanguageChange = (event) => {
        setProgrammingLanguage(event.target.value)
    };

    // Function to handle changes in the dropdown
    const handleUnitTestTypeSelectionChange = (event) => {
        setUnitTestType(event.target.value);
    };

    const onChangeBasedMethod = React.useCallback((value) => {
        setBasedMethod(value);
    }, []);

    const onChangeUnitTest = React.useCallback((value) => {
        setUnitTest(value);
    }, []);

    const onChangeDescription = React.useCallback((value) => {
        setDescription(value);
    }, []);

    const onChangeDependency1 = React.useCallback((value) => {
        setDependency1(value);
    }, []);

    const onChangeDependency2 = React.useCallback((value) => {
        setDependency2(value);
    }, []);

    return (
        <div id="container">
            <div id="inputSpace">
                <div id="inputSelectionSpace">
                    <div class='selections'>
                        <select value={programmingLanguage} onChange={handleLanguageChange} id="selectLanguage">
                            <option defaultValue="Select a language">Select a language</option>
                            <option value="javascript">JavaScript</option>
                            <option value="python">Python</option>
                            <option value="java">Java</option>
                            <option value="csharp">C#</option>
                            <option value="ruby">Ruby</option>
                        </select>
                    </div>
                    <div class='selections'>
                        <select value={unitTestType} onChange={handleUnitTestTypeSelectionChange} id="selectedUnitTestType">
                            <option defaultValue="Select what type of unit test">Select what type of unit test</option>
                            <option value="Simple">Simple</option>
                            <option value="Parameterized">Parameterized</option>
                            <option value="Multi Dependency">Multi Dependency</option>
                        </select>
                    </div>
                </div>
                <div id="unitAndBasedSpace">
                    <CodeMirror
                        name="unitTest"
                        placeholder={"Paste Unit test here!!!"}
                        height='170px'
                        value={unitTest}
                        extensions={[javascript({ jsx: true })]}
                        onChange={onChangeUnitTest}
                        theme="dark"
                    ></CodeMirror>
                    <CodeMirror
                        name="basedMethod"
                        placeholder={"Paste Based method here!!!"}
                        height='170px'
                        value={basedMethod}
                        extensions={[javascript({ jsx: true })]}
                        onChange={onChangeBasedMethod}
                        theme="dark"
                    ></CodeMirror>
                    <CodeMirror
                        name="description"
                        placeholder={"Input desciption (Optional)"}
                        height='70px'
                        value={description}
                        extensions={[javascript({ jsx: true })]}
                        onChange={onChangeDescription}
                        theme="dark"
                    ></CodeMirror>
                    <div id="dependencyText">
                        <CodeMirror
                            name="dependency1"
                            placeholder="Dependency 1 (Optional)"
                            height='74px'
                            value={dependency1}
                            extensions={[javascript({ jsx: true })]}
                            onChange={onChangeDependency1}
                            theme="dark"
                        ></CodeMirror>
                        <CodeMirror
                            name="dependency2"
                            placeholder="Depenency 2 (Optional)"
                            height='74px'
                            value={dependency2}
                            extensions={[javascript({ jsx: true })]}
                            onChange={onChangeDependency2}
                            theme="dark"
                        ></CodeMirror>
                    </div>
                </div>
                <button class='btn' id="savebtn">Save</button>
                <button class='btn' onClick={onClickSubmit}>Submit</button>
            </div>
            <div id="outputSpace">
                <div id="outputMenu">
                    <button className="outputBtn" onClick={testCasesBtn}>Test Cases</button>
                    <button className="outputBtn" onClick={summaryBtn}>Summary</button>
                    <button className="outputBtn" onClick={recommendationsBtn}>Recommendations</button>
                    <button className="outputBtn" onClick={enhanceVersionBtn}>Enhance Version</button>
                </div>
                <div className="output-space" id='output-space-accuracy'>
                    <pre className="output-text">{outputText}</pre>
                </div>
            </div>
        </div>
    );
}

export default AccuracyTest;
