import { React, useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import './css/OutputSpace.css'

const OutputSpace = () => {
    const [activeTab, setActiveTab] = useState(0);
    const [testResult, setTestResult] = useState({});
    const navigate = useNavigate();

    useEffect(() => {
        const fetchTestResult = async () => {
            await axios.get(`https://localhost:7070/api/EfficiencyTest?id=${'64723ce6f0219e3b4bac9645'}`)
            .then(response => {
                setTestResult(response.data);
            })
            .catch(error => console.log(error));
           }
           fetchTestResult();
    }, [testResult]);

    const handleTabClick = (tabIndex) => {
      setActiveTab(tabIndex);
      { tabIndex === 0 && navigate('/standard', { state: testResult }) }
      { tabIndex === 1 && navigate('/suggestion', { state: testResult }) }
      { tabIndex === 2 && navigate('/enhancedVersion', { state: testResult }) }
    };

    return (
        <div className='output'>
            <div className='output-header'>
                <button 
                    className={activeTab === 0 ? 'active-standard' : 'standard'}
                    onClick={() => handleTabClick(0)}
                > Standard 
                </button>
                <button 
                    className={activeTab === 1 ? 'active-suggestion' : 'suggestion'}
                    onClick={() => handleTabClick(1)}
                > Suggestions
                </button>
                <button 
                    className={activeTab === 2 ? 'active-enhance' : 'enhance'}
                    onClick={() => handleTabClick(2)}
                > Enhanced Version 
                </button>
            </div>
        </div>
    );
}

export default OutputSpace;








{/* <div className='output'>
<div className='output-header'>
    <button 
        className={activeTab === 0 ? 'active-standard' : 'standard'}
        onClick={() => handleTabClick(0)}
    > Standard 
    </button>
    <button 
        className={activeTab === 1 ? 'active-suggestion' : 'suggestion'}
        onClick={() => handleTabClick(1)}
    > Suggestions
    </button>
    <button 
        className={activeTab === 2 ? 'active-enhance' : 'enhance'}
        onClick={() => handleTabClick(2)}
    > Enhanced Version 
    </button>
</div>
<div className='output-space-bg'>
    <text className='output-space'/>
</div>
</div> */}