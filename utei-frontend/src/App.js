import React from 'react';
import HeaderBar from './components/HeaderBar';
import SideBar from './components/SideBar';
import InputSpace from './components/InputSpace';
import './css/App.css';
import OutputSpace from './OutputSpace';
import { Routes, Route } from 'react-router-dom';

function App() {

  return (
    <div className='background'>
      <HeaderBar/>
      <SideBar/>
      <InputSpace/>
      <Routes>
        <Route path='/' element={<OutputSpace/>}>
          {/* <Route path='/standard' element={<OutputSpace/>}></Route>
          <Route path='/suggestion' element={<OutputSpace/>}></Route>
          <Route path='/enhancedVersion' element={<OutputSpace/>}></Route> */}
        </Route>
      </Routes>
    </div>
  );
}

export default App;
