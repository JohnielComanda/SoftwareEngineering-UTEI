import { React, useState, useRef } from 'react';
import HeaderBar from './components/HeaderBar';
import SideBar from './components/SideBar';
import InputSpace from './components/InputSpace';
import './css/App.css';
import OutputSpace from './OutputSpace';
import { Routes, Route } from 'react-router-dom';
import StandardOutput from './outputs/StandardOutput';
import SuggestionOutput from './outputs/SuggestionOutput';
import EnhancedOutput from './outputs/EnhancedOutput';
import ResultContext from './ResultContext';

function App() {
  const [resultId, setResultId] = useState("");
  const isFirstRender = useRef(true);

  return (
    <div className='background'>
      <HeaderBar/>
      <SideBar/>
      <ResultContext.Provider value={resultId}>
        <InputSpace setResultId={setResultId} />
        <OutputSpace resultId={resultId} />
      </ResultContext.Provider>
      <Routes>
        <Route path='/summary' element={<StandardOutput/>}></Route>
        <Route path='/suggestion' element={<SuggestionOutput/>}></Route>
        <Route path='/enhancedVersion' element={<EnhancedOutput/>}></Route>
      </Routes>
    </div>
  );
}

export default App;
