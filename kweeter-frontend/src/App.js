
import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Login from './Login';
import SignUp from './Sign-Up';
import Tweet from './Tweet';
import GDPRNotice from './GDPRNotice';


const App = () => {
  return (
    <Router>
              <GDPRNotice />
              

      <Routes>
        <Route path="/login" element={<Login />} />
        <Route path="/signup" element={<SignUp />} />
        <Route path="/tweets" element={<Tweet />} /> {/* Add Tweet component route */}
        <Route path="/" element={<Login />} /> {/* Default to login page */}
      </Routes>
    </Router>
  );
};

export default App;
;

