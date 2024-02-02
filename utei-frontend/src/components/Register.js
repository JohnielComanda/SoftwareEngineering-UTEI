import React, { useEffect, useState, useRef } from "react";
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
  const signupButtonRef = useRef(null);
  const [isLoading, setIsLoading] = useState(false);

  const registerUser = () => {
    setIsLoading(true);
    axios
      .post(`https://localhost:7070/api/authenticate/register`, userDetails)
      .then((response) => {
        // Handle success
        console.log("Registration successful:", response.data);
        setGoResponse(response.data.message);
      })
      .catch((error) => {
        if (
          document.querySelector('input[name="password"]').value !==
          document.querySelector('input[name="confirmPassword"]').value
        ) {
          setGoResponse(error.response.data.errors.ConfirmPassword[0]);
        } else if (error.response && error.response.data) {
          // Handle error
          console.error("Registration failed:", error.response.data);
          setGoResponse(error.response.data);
        }
      })
      .finally(() => {
        setIsLoading(false);
      });
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

  const handleEnterKeyPress = (event) => {
    if (event.key === "Enter") {
      event.preventDefault(); // Prevent default form submission behavior
      signupButtonRef.current.click(); // Simulate click on the signup button
    }
  };

  useEffect(() => {
    // This method is for the Post and uses axios to pass on the parameters to the backend side
    // Avoid unnecessary render on initial load
    if (userDetails.name) {
      registerUser();
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [userDetails]);

  const [showPassword, setShowPassword] = useState(false);

  const togglePasswordVisibility = () => {
    setShowPassword(!showPassword);
  };

  return (
    <>
      <div className="register-container">
        <div className="rinput-container">
          <div className="reginput-field">
            <input
              name="firstName"
              type="text"
              placeholder="First Name"
              onKeyPress={handleEnterKeyPress}
            />
            <input
              name="lastName"
              type="text"
              placeholder="Last Name"
              onKeyPress={handleEnterKeyPress}
            />
            <input
              name="email"
              type="email"
              placeholder="Email"
              onKeyPress={handleEnterKeyPress}
            />
            <input
              name="password"
              type={showPassword ? "text" : "password"}
              placeholder="Password"
              onKeyPress={handleEnterKeyPress}
            />
            <input
              name="confirmPassword"
              type={showPassword ? "text" : "password"}
              placeholder="Confirm Password"
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
          <div className="signup-button">
            <button ref={signupButtonRef} onClick={onClickSubmit}>
              Create Account
            </button>
            <text>
              Already have an account? <a href="/login"> Sign In</a>
            </text>
            <div
              className={
                goResponse ===
                "User registered successfully. Please verify your email."
                  ? "regFail"
                  : "regSuccess"
              }
            >
              {isLoading ? (
                <p>Processing your request...</p>
              ) : (
                <p>{goResponse ? goResponse : ""}</p>
              )}
            </div>
          </div>
        </div>
        <div className="reginfo-container">
          <h1>
            JOIN US WITH <span class="highlight">AI</span>
          </h1>
        </div>
      </div>
    </>
  );
};

export default Register;
