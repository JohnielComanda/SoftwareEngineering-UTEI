import React, { useState } from 'react';
import SelectProgLang from './SelectProgLang';  
import '../css/InputSpace.css';

const InputSpace = () => {
    ///useEffect here for post
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
                <button className='btn-save'>Save</button>
                <button className='btn-identify'>Identify</button>   
            </div>
        </>
    );
}

export default InputSpace;