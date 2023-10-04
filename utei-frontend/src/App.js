import { React } from "react";
import { Routes, Route } from "react-router-dom";
import HeaderBar from "./components/HeaderBar";
import SideBar from "./components/SideBar";
import EfficiencyTest from "./pages/efficiencyTest/layout/EfficiencyTest";
import GenerateTest from "./pages/generateTest/layout/GenerateTest";
import "./css/App.css";

function App() {
  return (
    <div className="background">
      <HeaderBar />
      <SideBar />
      <Routes>
        <Route index path="/" element={<EfficiencyTest />} />
        <Route path="efficiency_test" element={<EfficiencyTest />} />
        <Route path="generate_test" element={<GenerateTest />} />
      </Routes>
    </div>
  );
}

export default App;
