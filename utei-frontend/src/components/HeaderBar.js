import React from 'react';
import '../css/HeaderBar.css';

const HeaderBar = () => {

    return (
        <header className="header-bar">
            <div className="logo">
                <img src="UTEI_Logo_v1.png" alt="Logo" />
            </div>
            <div class="profile">
                <img src="user.png" alt="Profile Picture"/>
                <p>John Doe</p>
                <button class="logout">Logout</button>
            </div>
        </header>
    )
}

export default HeaderBar;