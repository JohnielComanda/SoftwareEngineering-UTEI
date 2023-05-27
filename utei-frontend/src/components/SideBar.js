import React, {useState} from 'react';
import '../css/SideBar.css';

const SideBar = () => {
  const [activeTab, setActiveTab] = useState(0);

  const handleTabClick = (tabIndex) => {
    setActiveTab(tabIndex);
  };

  return (
    <div className="sidebar">
      <div className='buttons'>
        <button 
            a href="/" 
            className={activeTab === 0 ? 'active-efficiency' : 'efficiency'}
            onClick={() => handleTabClick(0)}
        > Identify Efficiency 
        </button>
        <button 
            a href="/accuracy" 
            className={activeTab === 1 ? 'active-accuracy' : 'accuracy'}
            onClick={() => handleTabClick(1)}
        > Identify Accuracy
        </button>
        <button 
            a href="#"  
            className={activeTab === 2 ? 'active-generate' : 'generate'}
            onClick={() => handleTabClick(2)}
        > Generate Unit Test
        </button>
      </div>

      <div className='saved-test'>
        <ul>
          <li>
            <button className='btn-test'> saved test</button>
          </li>
        </ul>
      </div>

      <button className='clear-history'> Clear History</button>
    </div>
  );
};

export default SideBar;