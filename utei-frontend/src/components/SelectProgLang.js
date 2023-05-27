import {React, useState} from 'react';
import '../css/Dropdown.css'

function SelectProgLang() {
    const [selectedItem, setSelectedItem] = useState("");
  
    const handleSelectChange = (event) => {
      setSelectedItem(event.target.value);
    };
  
    return (
      <div>
        <select className='drop-down' id="items" value={selectedItem} onChange={handleSelectChange}>
          <option value="">Select Language</option>
          <option value="C#">C#</option>
          <option value="Java">Java</option>
          <option value="Python">Python</option>
          <option value="C++">C++</option>
        </select>
      </div>
    );
  }

  export default SelectProgLang;