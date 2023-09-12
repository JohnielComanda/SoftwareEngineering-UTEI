import '../css/OutputSpace.css';
import { React } from 'react';
import { useLocation } from "react-router-dom";
import CodeMirror from '@uiw/react-codemirror';
import { javascript } from '@codemirror/lang-javascript';

const EnhancedOutput = () => {
    const location = useLocation();
    const testResult = location.state || {};

    // const options = {
    //     lineNumbers: true,
    //     mode: 'javascript',
    //     readOnly: true,
    //   };
      
    return(
        <>
            <div className='output-space'>
                <pre className='output-text'>{testResult.enhancedVersion}</pre>
            </div>
            {/* {console.log(testResult.EnhancedVersion)}
            <div className='output-space'>
                <CodeMirror
                    className='output-text'
                    value={testResult.EnhancedVersion}
                    options={options}   
                    theme='dark'
                    onChange={onChange()}
                />
            </div> */}
        </>
    );
}

export default EnhancedOutput;