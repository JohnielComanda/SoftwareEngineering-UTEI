import React, { useEffect, useState, useRef } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import "../css/Login.css";

const Login = ({ setUserId, setIsAuthenticated, setUserName }) => {
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
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [userDetails]);

  const [isLoading, setIsLoading] = useState(false);
  const loginUser = async () => {
    setIsLoading(true);
    try {
      const response = await axios.post(
        `https://utei20240206153836.azurewebsites.net/api/authenticate/login`,
        userDetails
      );
      console.log("login response: ", response.data);
      setUserId(response.data.userId);
      setUserName(response.data.email);
      setIsAuthenticated(true);
      localStorage.setItem("authToken", response.data.accessToken);
      navigate("/efficiency-test");
    } catch (error) {
      if (error.response && error.response.data) {
        // Handle error
        console.error("login failed:", error.response.data);
        setGoResponse(error.response.data);
      }
    } finally {
      setIsLoading(false);
    }
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

  const [showPassword, setShowPassword] = useState(false);

  const togglePasswordVisibility = () => {
    setShowPassword(!showPassword);
  };

  return (
    <>
      <div className="login-container">
        <div className="info-container">
          <h1>
            Streamline your testing process{" "}
            <span class="highlight1">Generate</span>
            <span class="highlight0">{" > "}</span>
            <span class="highlight2">Enhance</span>
            <span class="highlight0">{" > "}</span>
            <span class="highlight3">Test</span>
          </h1>
        </div>
        <div className="input-container">
          <div className="input-field">
            <input name="email" type="email" placeholder="Email" />
            <input
              name="password"
              type={showPassword ? "text" : "password"}
              placeholder="Password"
              onKeyPress={handleEnterKeyPress}
            />
            <button
              className="show-hide-btn"
              type="button"
              onClick={togglePasswordVisibility}
            >
              <img
                type="button"
                alt="show password"
                src={showPassword ? "hide.png" : "show.png"}
              ></img>
              {showPassword ? "Hide" : "Show"}
            </button>
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
      {isLoading && (
        <div className="login-loading">
          <div className="login-spinner" />
        </div>
      )}
    </>
  );
};

export default Login;
