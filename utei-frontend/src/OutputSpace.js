import { React, useRef, useState, useEffect, useContext } from 'react';
import axios from 'axios';
import { useNavigate, useLocation } from 'react-router-dom';
import ResultContext from './ResultContext';
import './css/OutputSpace.css'
import { act } from 'react-dom/test-utils';
import StandardOutput from './outputs/StandardOutput';
import SuggestionOutput from './outputs/SuggestionOutput';
import EffiencyBar from './outputs/EfficiencyBar';

const OutputSpace = ({ testResult, setTestResult }) => {
    const [activeTab, setActiveTab] = useState(0);
    const navigate = useNavigate();
    const location = useLocation();
    const resultId = useContext(ResultContext);
    const isFirstRender = useRef(true);

    useEffect(() => {
        const fetchTestResult = async () => {
            try {
                const response = await axios.get(`https://localhost:7070/api/EfficiencyTest?id=${resultId}`);
                setTestResult(response.data);
            } catch (error) {
                console.log(error);
            }
        }
           fetchTestResult();
    }, [resultId]);

    useEffect(() => {
        handleTabClick(activeTab);
    }, []);

    useEffect(() => {
        if (!isFirstRender.current) {
            navigate('/summary', { state: testResult });
        } else {
            isFirstRender.current = false;
        }
    }, [testResult]);

    const handleTabClick = (tabIndex) => {  
        setActiveTab(tabIndex);
        { tabIndex === 0 && navigate('/summary', { state: testResult })}
        { tabIndex === 1 && navigate('/suggestion', { state: testResult })}
        { tabIndex === 2 && navigate('/enhancedVersion', { state: testResult })}
      };

    return (
        <div className='output'>
            <div className='output-header'>
                <button 
                    className={activeTab === 0 ? 'active-standard' : 'standard'}
                    onClick={() => handleTabClick(0)}
                > Summary 
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
            {testResult.efficiencyScore && <EffiencyBar score={testResult.efficiencyScore} />}
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