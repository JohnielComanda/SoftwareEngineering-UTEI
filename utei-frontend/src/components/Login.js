import React, { useEffect, useState, useRef } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import "../css/Login.css";

const Login = ({ setUserId, setIsAuthenticated, setUserName }) => {
  const initialUserDetails = {
    email: "",
    password: "",
  };
  const [userDetails, setUserDetails] = useState(initialUserDetails);
  const isFirstRender = useRef(true);
  const navigate = useNavigate();
  const [goResponse, setGoResponse] = useState("");

  useEffect(() => {
    //This method is for the Post and uses axios to pass on the parameters to the backend side
    if (userDetails.email) {
      loginUser();
    }
  }, [userDetails]);

  const loginUser = async () => {
    try {
      const response = await axios.post(
        `https://localhost:7070/api/authenticate/login`,
        userDetails
      );
      console.log("Loggedin user: ", response.data);
      if (response.data) setIsAuthenticated(true);
      setUserName(userDetails.name);
      console.log("LOG: ", response.data.name);
      setUserId(response.data.id);
      navigate("/efficiency_test");
    } catch (error) {
      console.error(error);
      setGoResponse("Incorrect email or password.");
    }
  };

  const onClickSubmit = () => {
    setUserDetails(() => ({
      email: document.querySelector('input[name="email"]').value,
      password: document.querySelector('input[name="password"]').value,
    }));
  };

  return (
    <>
      <div className="login-container">
        <div className="info-container">
          <h1>
            Test your <span class="highlight1">Unit Test</span> in simple steps
            with the power of <span class="highlight2">AI</span> as a tool
          </h1>
          <ul>
            <h6>Supports Multiple Languages</h6>
            <h6>Automated Test Cases</h6>
            <h6>Generates Recommendation</h6>
            <h6>Generates Enhanced Version</h6>
            <h6>Generates Unit Test</h6>
          </ul>
        </div>
        <div className="input-container">
          <div className="input-field">
            <input name="email" type="email" placeholder="Email" />
            <input name="password" type="password" placeholder="Password" />
          </div>
          <div className="login-button">
            <button onClick={onClickSubmit}>Sign In</button>
            <text>
              Don't have an account? <a href="/signup"> Sign Up</a>
            </text>
          </div>
          <div className="loginFail">{goResponse ? goResponse : ""}</div>
        </div>
      </div>
    </>
  );
};

export default Login;
