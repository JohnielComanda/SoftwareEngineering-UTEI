import React, {useState} from 'react';
import './css/OutputSpace.css'

const OutputSpace = () => {
    const [activeTab, setActiveTab] = useState(0);

    const handleTabClick = (tabIndex) => {
      setActiveTab(tabIndex);
    };

    return (
        <div className='output'>
            <div className='output-header'>
                <button 
                    a href="#" 
                    className={activeTab === 0 ? 'active-standard' : 'standard'}
                    onClick={() => handleTabClick(0)}
                > Standard 
                </button>
                <button 
                    a href="#" 
                    className={activeTab === 1 ? 'active-suggestion' : 'suggestion'}
                    onClick={() => handleTabClick(1)}
                > Suggestions
                </button>
                <button 
                    a href="#" 
                    className={activeTab === 2 ? 'active-enhance' : 'enhance'}
                    onClick={() => handleTabClick(2)}
                > Enhanced Version 
                </button>
            </div>
            <div className='output-space-bg'>
                <text className='output-space'/>
            </div>     
        </div>

    );
}

export default OutputSpace;