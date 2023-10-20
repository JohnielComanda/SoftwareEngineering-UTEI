import React from "react";
import "../css/Login.css";

const Login = () => {
  return (
    <div className="login-container">
      <div className="info-container">
        <h1>
          Test your Unit Test in simple steps with the power of AI as tool
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
          <input type="email" placeholder="Email" />
          <input type="password" placeholder="Password" />
        </div>
        <div className="login-button">
          <button>Sign In</button>
          <text>or</text>
          <button>Sign in with Google</button>
        </div>
      </div>
    </div>
  );
};

export default Login;
