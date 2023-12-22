import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "../css/HeaderBar.css";

const HeaderBar = ({
  userName,
  setIsAuthenticated,
  setUserId,
  setUserName,
}) => {
  // const getInitials = (name) => {
  //   const initials = name
  //     .replace(/([A-Z])/g, " $1")
  //     .trim()
  //     .split(" ")
  //     .map((word) => word.charAt(0))
  //     .join("");
  //   return initials;
  // };

  // const initials = getInitials(userName);
  const navigate = useNavigate();
  // const [isHovered, setIsHovered] = useState(false);

  // const handleMouseEnter = () => {
  //   setIsHovered(true);
  // };

  // const handleMouseLeave = () => {
  //   setIsHovered(false);
  // };

  // const handleLogout = () => {
  //   setIsAuthenticated(false);
  //   setUserId("");
  //   setUserName("");
  //   setIsHovered(false);
  //   navigate("/login");
  // };

  return (
    <header className="header-bar">
      <div className="logo">
        <img src="UTEI_Logo_v1.png" alt="Logo" />
      </div>
      {/* {userName ? (
        <div
          className="profile"
          onMouseEnter={handleMouseEnter}
          onMouseLeave={handleMouseLeave}
        >
          {initials}
          <div
            className={`popup ${isHovered ? "show" : ""}`}
            onClick={handleLogout}
          >
            Logout
          </div>
        </div>
      ) : (
        ""
      )} */}
    </header>
  );
};

export default HeaderBar;
