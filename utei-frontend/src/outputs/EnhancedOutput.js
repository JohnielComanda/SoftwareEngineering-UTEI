import '../css/OutputSpace.css';
import { React } from 'react';
import { useLocation } from "react-router-dom";

const EnhancedOutput = () => {
    const location = useLocation();
    const testResult = location.state || {};
    
    return(
        <>
            <div className='output-space'>
                <pre className='output-text'>{testResult.enhancedVersion}</pre>
            </div>
        </>
    );
}

export default EnhancedOutput;