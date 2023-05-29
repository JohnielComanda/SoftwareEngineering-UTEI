import {React, useState} from 'react';
import '../css/Dropdown.css'

function SelectProgLang({onSelectedLanguageChange}) {
    const [selectedItem, setSelectedItem] = useState("");
  
    const handleSelectChange = (event) => {
      const selectedValue = event.target.value;
      setSelectedItem(event.target.value);
      onSelectedLanguageChange(selectedValue);
    };
  
    return (
      <div>
        <select className='drop-down' id="items" value={selectedItem} onChange={handleSelectChange}>
          <option value="">Select Language</option>
          <option value="C++">C++</option>
          <option value="C#">C#</option>
          <option value="Java">Java</option>
          <option value="JavaScript">C++</option>
          <option value="Python">Python</option>
        </select>
      </div>
    );
  }

  export default SelectProgLang;