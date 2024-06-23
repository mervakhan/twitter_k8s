import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate, useLocation } from 'react-router-dom';

const Login = () => {
  const [username, setUsername] = useState('John');
  const [password, setPassword] = useState('Password');
  const [error, setError] = useState('');
  const navigate = useNavigate();
  const location = useLocation();

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('http://34.76.247.162/api/Login/login', {
        username,
        password
      }, {
        headers: {
          'Content-Type': 'application/json',
        }
      });
      localStorage.setItem('token', response.data.token); // Save token to localStorage
      setError('');
      navigate('/tweets');
    } catch (err) {
      setError('Login failed. Please check your username and password.');
    }
  };

  return (
    <div style={{ fontFamily: 'Arial, sans-serif', maxWidth: '400px', margin: 'auto', padding: '20px', backgroundColor: '#fff', borderRadius: '12px', boxShadow: '0 0 10px rgba(0,0,0,0.1)' }}>
      <h2 style={{ fontSize: '24px', fontWeight: 'bold', color: '#1DA1F2', textAlign: 'center', marginBottom: '20px' }}>Kweeter - Login</h2>
      {location.state?.message && <p style={{ color: 'green' }}>{location.state.message}</p>}
      <form onSubmit={handleLogin}>
        <div style={{ marginBottom: '20px' }}>
          <label style={{ display: 'block', marginBottom: '6px', fontSize: '16px' }}>Username:</label>
          <input
            type="text"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            style={{ width: '100%', padding: '10px', fontSize: '16px', borderRadius: '8px', border: '1px solid #ccc', boxSizing: 'border-box' }}
            required
          />
        </div>
        <div style={{ marginBottom: '20px' }}>
          <label style={{ display: 'block', marginBottom: '6px', fontSize: '16px' }}>Password:</label>
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            style={{ width: '100%', padding: '10px', fontSize: '16px', borderRadius: '8px', border: '1px solid #ccc', boxSizing: 'border-box' }}
            required
          />
        </div>
        <button type="submit" style={{ background: '#1DA1F2', color: '#fff', padding: '12px 24px', border: 'none', borderRadius: '9999px', cursor: 'pointer', fontSize: '16px', width: '100%' }}>Login</button>
      </form>
      {error && <p style={{ color: 'red', textAlign: 'center', marginTop: '10px' }}>{error}</p>}
      <p style={{ textAlign: 'center', marginTop: '10px', fontSize: '14px' }}>
        Don't have an account? <a href="/signup" style={{ color: '#1DA1F2', textDecoration: 'none' }}>Sign up here</a>
      </p>
    </div>
  );
};

export default Login;
