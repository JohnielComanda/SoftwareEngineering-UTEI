import React, { useEffect, useState } from "react";
import axios from "axios";
import "../css/Register.css";

const Register = () => {
  const initialUserDetails = {
    name: "",
    email: "",
    password: "",
    confirmPassword: "",
  };
  const [userDetails, setUserDetails] = useState(initialUserDetails);
  const [goResponse, setGoResponse] = useState("");

  const registerUser = async () => {
    let responseData = null;

    try {
      const response = await axios.post(
        `https://localhost:7070/api/authenticate/register`,
        userDetails
      );
      responseData = response.message;
      setGoResponse(responseData.message);
    } catch (error) {
      console.error("Error:", error.message);
    } finally {
      console.log("Response data:", responseData);
    }
  };

  const onClickSubmit = () => {
    const firstName = document.querySelector('input[name="firstName"]').value;
    const lastName = document.querySelector('input[name="lastName"]').value;
    const email = document.querySelector('input[name="email"]').value;
    const password = document.querySelector('input[name="password"]').value;
    const confirmPassword = document.querySelector(
      'input[name="confirmPassword"]'
    ).value;

    setUserDetails({
      email,
      name: `${firstName} ${lastName}`,
      password,
      confirmPassword,
    });

    console.log("User Details: ", firstName, lastName, email, password);
  };

  useEffect(() => {
    // This method is for the Post and uses axios to pass on the parameters to the backend side
    // Avoid unnecessary render on initial load
    if (userDetails.name) {
      registerUser();
    }
  }, [userDetails]);

  const [showPassword, setShowPassword] = useState(false);

  const togglePasswordVisibility = () => {
    setShowPassword(!showPassword);
  };

  return (
    <div className="register-container">
      <div className="rinput-container">
        <div className="reginput-field">
          <input name="firstName" type="text" placeholder="First Name" />
          <input name="lastName" type="text" placeholder="Last Name" />
          <input name="email" type="email" placeholder="Email" />
          <input
            name="password"
            type={showPassword ? "text" : "password"}
            placeholder="Password"
          />
          <input
            name="confirmPassword"
            type={showPassword ? "text" : "password"}
            placeholder="Confirm Password"
          />
          <button
            className="show-hide-btn"
            type="button"
            onClick={togglePasswordVisibility}
          >
            <img
              type="button"
              src={showPassword ? "hide.png" : "show.png"}
            ></img>
            {showPassword ? "Hide" : "Show"}
          </button>
        </div>
        <div className="signup-button">
          <button onClick={onClickSubmit}>Create Account</button>
          <text>
            Already have an account? <a href="/login"> Sign In</a>
          </text>
          <div
            className={
              goResponse ===
              "User registered successfully. Please verify your email."
                ? "regSuccess"
                : "regFail"
            }
          >
            {goResponse ? goResponse : ""}
          </div>
        </div>
      </div>
      <div className="reginfo-container">
        <h1>
          JOIN US WITH <span class="highlight">AI</span>
        </h1>
      </div>
    </div>
  );
};

export default Register;
