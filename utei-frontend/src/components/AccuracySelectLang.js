import React, { useState } from 'react';

function AccuracySelectLang() {
    // State to manage the selected programming language
    const [selectedLanguage, setSelectedLanguage] = useState('');

    // Function to handle changes in the dropdown
    const handleLanguageChange = (event) => {
        setSelectedLanguage(event.target.value);
    };

    return (
        <div>
            <select value={selectedLanguage} onChange={handleLanguageChange} id="selectLanguage">
                <option defaultValue="Select a language">Select a language</option>
                <option value="javascript">JavaScript</option>
                <option value="python">Python</option>
                <option value="java">Java</option>
                <option value="csharp">C#</option>
                <option value="ruby">Ruby</option>
            </select>
        </div>
    );
}

export default AccuracySelectLang;
