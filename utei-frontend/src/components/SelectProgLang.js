import { React, useState } from "react";
import "../css/Dropdown.css";

function SelectProgLang({ onSelectedLanguageChange, selectedResult }) {
  const [selectedItem, setSelectedItem] = useState("");

  const handleSelectChange = (event) => {
    const selectedValue = event.target.value;
    setSelectedItem(selectedValue);
    onSelectedLanguageChange(selectedValue);
  };

  return (
    <div>
      <select
        className="drop-down"
        id="items"
        value={
          selectedResult && selectedResult.programmingLanguage
            ? selectedResult.programmingLanguage
            : selectedItem
        }
        onChange={handleSelectChange}
      >
        <option value="">Select Language</option>
        <option value="C++">C++</option>
        <option value="C#">C#</option>
        <option value="Java">Java</option>
        <option value="JavaScript">JavaScript</option>
        <option value="Python">Python</option>
      </select>
    </div>
  );
}

export default SelectProgLang;
