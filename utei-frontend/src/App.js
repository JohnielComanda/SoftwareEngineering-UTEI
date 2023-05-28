import React from 'react';
import HeaderBar from './components/HeaderBar';
import SideBar from './components/SideBar';
import InputSpace from './components/InputSpace';
import './css/App.css';
import OutputSpace from './OutputSpace';
import { Routes, Route } from 'react-router-dom';
import StandardOutput from './outputs/StandardOutput';
import SuggestionOutput from './outputs/SuggestionOutput';
import EnhancedOutput from './outputs/EnhancedOutput';

function App() {

  return (
    <div className='background'>
      <HeaderBar/>
      <SideBar/>
      <InputSpace/>
      <OutputSpace/>
      <Routes>
          <Route path='/standard' element={<StandardOutput/>}></Route>
          <Route path='/suggestion' element={<SuggestionOutput/>}></Route>
          <Route path='/enhancedVersion' element={<EnhancedOutput/>}></Route>
      </Routes>
    </div>
  );
}

export default App;
