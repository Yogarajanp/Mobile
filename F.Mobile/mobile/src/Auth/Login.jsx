import React from "react";
import { GoogleOAuthProvider, GoogleLogin } from "@react-oauth/google";
import axios from "axios";

const Login = () => {
  const handleSuccess = async (response) => {
    try {
      const res = await axios.post("https://localhost:7075/api/Auth/Callback", {
        token: response.credential,
      });
      console.log("Server Response:", res.data);
    } catch (err) {
      console.error("Error during authentication:", err);
    }
  };

  return (
    <GoogleOAuthProvider clientId="351229316983-3q0ieo9dk5o16cmefog20tlkvl80rqkn.apps.googleusercontent.com">
      <div className="App">
        <h1>Login with Google</h1>
        <GoogleLogin onSuccess={handleSuccess} onError={() => console.error("Login Failed")} />
      </div>
    </GoogleOAuthProvider>
  );
};

export default Login;
