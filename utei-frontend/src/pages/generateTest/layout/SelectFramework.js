import { React, useState } from "react";
import "../../../css/SelectFramework.css";

function SelectFramework({
  onSelectedLanguageChange,
  selectedLanguage,
  selectedResult,
  selectedFramework,
  setSelectedFramework,
}) {
  const [selectedItem, setSelectedItem] = useState("");

  const handleSelectChange = (event) => {
    const selectedValue = event.target.value;
    setSelectedItem(selectedValue);
    setSelectedFramework(selectedValue);
  };

  return (
    <div>
      <select
        className="framework-dropdown"
        id="items"
        value={
          selectedResult && selectedResult.framework
            ? selectedResult.framework
              ? selectedResult.framework
              : selectedFramework
            : selectedItem
        }
        onChange={handleSelectChange}
      >
        <option value="">Select Framework</option>
        {selectedLanguage === "C#" ? (
          <>
            <option value="MSTest">MSTest</option>
            <option value="NUnit">NUnit</option>
            <option value="XUnit">XUnit</option>
            <option value="Moq">Moq</option>
            <option value="NSubstitute">NSubstitute</option>
            <option value="FluentAssertions">FluentAssertions</option>
          </>
        ) : selectedLanguage === "Java" ? (
          <>
            <option value="JUnit">JUnit</option>
            <option value="TestNG">TestNG</option>
            <option value="Mockito">Mockito</option>
            <option value="PowerMock">PowerMock</option>
            <option value="AssertJ">AssertJ</option>
            <option value="Hamcrest">Hamcrest</option>
            <option value="Jmockit">Jmockit</option>
          </>
        ) : selectedLanguage === "JavaScript" ? (
          <>
            <option value="Jest">Jest</option>
            <option value="Jasmine">Jasmine</option>
            <option value="QUnit">QUnit</option>
            <option value="Ava">Ava</option>
            <option value="ScriptTape">ScriptTape</option>
            <option value="Karma">Karma</option>
            <option value="Cypress">Cypress</option>
            <option value="Mocha">Mocha</option>
          </>
        ) : selectedLanguage === "Python" ? (
          <>
            <option value="Pytest">Pytest</option>
            <option value="Unittest">Unittest</option>
            <option value="Nose2">Nose2</option>
            <option value="Doctest">Doctest</option>
            <option value="PythonTox">PythonTox</option>
            <option value="Hypothesis">Hypothesis</option>
            <option value="Robotframework">Robotframework</option>
            <option value="Testify">Testify</option>
          </>
        ) : selectedLanguage === "C++" ? (
          <>
            {" "}
            <option value="GoogleTest">GoogleTest</option>
            <option value="Catch2">Catch2</option>
            <option value="BoostTest">BoostTest</option>
            <option value="CppUtest">CppUtest</option>
            <option value="Igloo">Igloo</option>
            <option value="CppUnit">CppUnit</option>
          </>
        ) : (
          ""
        )}
      </select>
    </div>
  );
}

export default SelectFramework;
