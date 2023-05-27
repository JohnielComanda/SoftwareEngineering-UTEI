import { React, useState } from 'react';
import '../css/InputSpace.css';

const IdentifyButton =()=>{
    const [unitTest, setUnitTest] = useState("");
    
    return(
        <button className='btn-identify'>Identify</button>
    );
}

export default IdentifyButton;