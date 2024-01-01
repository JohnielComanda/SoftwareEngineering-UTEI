import React, { useEffect, useState, useRef } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import "../css/Login.css";

const Login = ({ setUserId, setIsAuthenticated, setUserName }) => {
  const isFirstRender = useRef(true);
  const navigate = useNavigate();
  const signupButtonRef = useRef(null);
  const [goResponse, setGoResponse] = useState("");
  const initialUserDetails = {
    email: "",
    password: "",
  };
  const [userDetails, setUserDetails] = useState(initialUserDetails);

  useEffect(() => {
    //This method is for the Post and uses axios to pass on the parameters to the backend side
    if (userDetails.email) {
      loginUser();
    }
  }, [userDetails]);

  const loginUser = async () => {
    await axios
      .post(`https://localhost:7070/api/authenticate/login`, userDetails)
      .then((response) => {
        console.log("login response: ", response);
        setUserId(response.data.userId);
        setUserName(response.data.email);
        setIsAuthenticated(true);
        localStorage.setItem("authToken", response.data.accessToken);
        navigate("/efficiency_test");
      })
      .catch((error) => {
        if (error.response && error.response.data) {
          // Handle error
          console.error("login failed:", error.response.data);
          setGoResponse(error.response.data);
        }
      });
  };

  const onClickSubmit = () => {
    setUserDetails(() => ({
      email: document.querySelector('input[name="email"]').value,
      password: document.querySelector('input[name="password"]').value,
    }));
  };

  const handleEnterKeyPress = (event) => {
    if (event.key === "Enter") {
      event.preventDefault(); // Prevent default form submission behavior
      signupButtonRef.current.click(); // Simulate click on the signup button
    }
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
            <input
              name="password"
              type="password"
              placeholder="Password"
              onKeyPress={handleEnterKeyPress}
            />
          </div>
          <div className="login-button">
            <button ref={signupButtonRef} onClick={onClickSubmit}>
              Sign In
            </button>
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
