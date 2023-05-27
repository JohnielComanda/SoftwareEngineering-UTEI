import React, { useState } from 'react';
import SelectProgLang from './SelectProgLang';  
import SaveButton from './SaveButton';
import IdentifyButton from './IdentifyButton';
import '../css/InputSpace.css';

const InputSpace = () => {

    return (
        <>
            <div className='input'>
                <div className='input-header'>
                    <SelectProgLang></SelectProgLang>
                </div>
                <textarea 
                    name = 'unitTest'
                    className='input-space'
                    defaultValue={'Paste your unit test method here!'}  
                ></textarea>      
            </div>
            <div>
                <SaveButton></SaveButton>
                <IdentifyButton></IdentifyButton>     
            </div>
        </>
    );
}

export default InputSpace;