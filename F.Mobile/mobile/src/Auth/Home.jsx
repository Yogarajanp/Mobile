import React from "react";
import { Link } from "react-router-dom";

const Home = () => {
  return (
    <div style={{ textAlign: "center", padding: "50px" }}>
      <h1>Welcome to Our Application</h1>
      <p>
        This is the home page of our app. You can log in to access your dashboard or explore other features.
      </p>
      <div style={{ marginTop: "20px" }}>
        <Link
          to="/login"
          style={{
            display: "inline-block",
            margin: "10px",
            padding: "10px 20px",
            backgroundColor: "#007BFF",
            color: "white",
            textDecoration: "none",
            borderRadius: "5px",
          }}
        >
          Login
        </Link>
        <Link
          to="/dashboard"
          style={{
            display: "inline-block",
            margin: "10px",
            padding: "10px 20px",
            backgroundColor: "#28a745",
            color: "white",
            textDecoration: "none",
            borderRadius: "5px",
          }}
        >
          Dashboard
        </Link>
      </div>
    </div>
  );
};

export default Home;
