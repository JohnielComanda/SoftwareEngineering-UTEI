import '../css/OutputSpace.css';
import { React, useState } from 'react';
import { useLocation } from "react-router-dom";

const StandardOutput = () => {
    const location = useLocation();
    const testResult = location.state;
    return(
        <>
            <div className='output-space'>
                <pre className='output-text'>{ testResult.resultSummary }</pre>
            </div>
        </>
    );
}

export default StandardOutput;