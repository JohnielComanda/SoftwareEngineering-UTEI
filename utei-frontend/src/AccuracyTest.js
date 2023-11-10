import React, { Component } from 'react';
import axios from "axios";
import CodeMirror from "@uiw/react-codemirror";
import { javascript } from "@codemirror/lang-javascript";
import "./css/OutputSpace.css";
import HeaderBar from "./components/HeaderBar.js";
import SideBar from "./components/SideBar.js";
import './css/accuracy.css';

class AccuracyTest extends Component {
    constructor() {
        super();
        this.state = {
            responseData: {
                ResultSummary: "",
                TestResult: "",
                TestSuggestions: "",
                EnhancedVersion: "",
            },
            basedMethod: '',
            programmingLanguage: '',
            unitTest: '',
            unitTestType: '',
            description: '',
            dependency1: '',
            dependency2: '',
            outputText: '',
        };
    }

    onClickSubmit = async () => {
        const finalData = {
            BaseMethod: this.state.basedMethod,
            ProgrammingLanguage: this.state.programmingLanguage,
            UnitTest: this.state.unitTest,
            UnitTestType: this.state.unitTestType,
            Description: this.state.description,
            Dependency1: this.state.dependency1,
            Dependency2: this.state.dependency2,
        };
        try {
            const response = await axios.post(
                'https://localhost:7070/api/AccuracyTest',
                finalData
            );
            console.log(response.data);
            const res = response.data;
            this.setState({
                responseData: {
                    TestResult: res.testResult,
                    ResultSummary: res.resultSummary,
                    TestSuggestions: res.testSuggestions,
                    EnhancedVersion: res.enhancedVersion,
                },
            });
            alert('Successfully created a test.');
        } catch (error) {
            console.error(error);
            alert('Failed to create a test.');
        }
    };

    testCasesBtn = () => {
        this.setState({ outputText: this.state.responseData.TestResult });
        console.log(this.state.outputText);
    };

    summaryBtn = () => {
        this.setState({ outputText: this.state.responseData.ResultSummary });
        console.log(this.state.outputText);
    };

    recommendationsBtn = () => {
        this.setState({ outputText: this.state.responseData.TestSuggestions });
        console.log(this.state.outputText);
    };

    enhanceVersionBtn = () => {
        this.setState({ outputText: this.state.responseData.EnhancedVersion });
        console.log(this.state.outputText);
    };

    handleLanguageChange = (event) => {
        this.setState({ programmingLanguage: event.target.value });
    };

    handleUnitTestTypeSelectionChange = (event) => {
        this.setState({ unitTestType: event.target.value });
    };

    onChangeBasedMethod = (value) => {
        this.setState({ basedMethod: value });
    };

    onChangeUnitTest = (value) => {
        this.setState({ unitTest: value });
    };

    onChangeDescription = (value) => {
        this.setState({ description: value });
    };

    onChangeDependency1 = (value) => {
        this.setState({ dependency1: value });
    };

    onChangeDependency2 = (value) => {
        this.setState({ dependency2: value });
    };

    render() {
        // Access the prop value using props.result
        var resultArray = this.state.outputText.split('+');

        // Assuming you want to display the individual parts separately
        var result = resultArray[0];
        var expectedValue = resultArray[1];
        var actualValue = resultArray[2];
        return (
            <div>
                <HeaderBar />
                <SideBar
                />
                <div id="container">
                    <div id="inputSpace">
                        <div id="inputSelectionSpace">
                            <div className='selections'>
                                <select value={this.state.programmingLanguage} onChange={this.handleLanguageChange} id="selectLanguage">
                                    <option defaultValue="Select a language">Select a language</option>
                                    <option value="javascript">JavaScript</option>
                                    <option value="python">Python</option>
                                    <option value="java">Java</option>
                                    <option value="csharp">C#</option>
                                    <option value="ruby">Ruby</option>
                                </select>
                            </div>
                            <div className='selections'>
                                <select value={this.state.unitTestType} onChange={this.handleUnitTestTypeSelectionChange} id="selectedUnitTestType">
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
                                value={this.state.unitTest}
                                extensions={[javascript({ jsx: true })]}
                                onChange={this.onChangeUnitTest}
                                theme="dark"
                            ></CodeMirror>
                            <CodeMirror
                                name="basedMethod"
                                placeholder={"Paste Based method here!!!"}
                                height='170px'
                                value={this.state.basedMethod}
                                extensions={[javascript({ jsx: true })]}
                                onChange={this.onChangeBasedMethod}
                                theme="dark"
                            ></CodeMirror>
                            <CodeMirror
                                name="description"
                                placeholder={"Input description (Optional)"}
                                height='70px'
                                value={this.state.description}
                                extensions={[javascript({ jsx: true })]}
                                onChange={this.onChangeDescription}
                                theme="dark"
                            ></CodeMirror>
                            <div id="dependencyText">
                                <CodeMirror
                                    name="dependency1"
                                    placeholder="Dependency 1 (Optional)"
                                    height='74px'
                                    value={this.state.dependency1}
                                    extensions={[javascript({ jsx: true })]}
                                    onChange={this.onChangeDependency1}
                                    theme="dark"
                                ></CodeMirror>
                                <CodeMirror
                                    name="dependency2"
                                    placeholder="Dependency 2 (Optional)"
                                    height='74px'
                                    value={this.state.dependency2}
                                    extensions={[javascript({ jsx: true })]}
                                    onChange={this.onChangeDependency2}
                                    theme="dark"
                                ></CodeMirror>
                            </div>
                        </div>
                        <button className='btn' id="savebtn">Save</button>
                        <button className='btn' onClick={this.onClickSubmit}>Submit</button>
                    </div>
                    <div id="outputSpace">
                        <div id="outputMenu">
                            <button className="outputBtn" onClick={this.testCasesBtn}>Test Cases</button>
                            <button className="outputBtn" onClick={this.summaryBtn}>Performance</button>
                            <button className="outputBtn" onClick={this.recommendationsBtn}>Recommendations</button>
                        </div>
                        <div className="output-space" id='output-space-accuracy'>
                            <pre className="output-text">
                                {this.state.outputText}
                            </pre>
                            <div className="output-space" id='output-space-accuracy'>
                                <pre className="output-text">{this.state.outputText}</pre>
                                <div id="containerTest">
                                    <p>Expected Value</p>
                                    <div class="resValue">
                                        {expectedValue}
                                    </div>
                                    <p>Actual Value</p>
                                    <div class="resValue">
                                        {actualValue}
                                    </div>
                                    <p>Result</p>
                                    <div class="resValue">
                                        {result}
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

export default AccuracyTest;