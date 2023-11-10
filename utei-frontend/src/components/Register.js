import React, { useEffect, useState } from "react";
import axios from "axios";
import "../css/Register.css";

const Register = () => {
  const initialUserDetails = {
    name: "",
    email: "",
    password: "",
  };
  const [userDetails, setUserDetails] = useState(initialUserDetails);

  const registerUser = async () => {
    try {
      const response = await axios.post(
        `https://localhost:7070/api/UserRegistration`,
        userDetails
      );
      if (response.data) alert("Registered successfully.");
    } catch (error) {
      console.error(error);
      alert("Email is already used");
    }
  };

  const onClickSubmit = () => {
    const firstName = document.querySelector('input[name="firstName"]').value;
    const lastName = document.querySelector('input[name="lastName"]').value;
    const email = document.querySelector('input[name="email"]').value;
    const password = document.querySelector('input[name="password"]').value;

    setUserDetails({
      name: `${firstName} ${lastName}`,
      email,
      password,
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

  return (
    <div className="register-container">
      <div className="rinput-container">
        <div className="reginput-field">
          <input name="firstName" type="text" placeholder="First Name" />
          <input name="lastName" type="text" placeholder="Last Name" />
          <input name="email" type="email" placeholder="Email" />
          <input name="password" type="password" placeholder="Password" />
        </div>
        <div className="signup-button">
          <button onClick={onClickSubmit}>Create Account</button>
          <text>or</text>
          <button>
            <img src="google.png"></img>Continue with Google
          </button>
          <text>
            Already have an account? <a href="/login"> Sign In</a>
          </text>
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
