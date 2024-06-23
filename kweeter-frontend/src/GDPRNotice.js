import React, { useState, useEffect } from 'react';

const GDPRNotice = () => {
  const [isAccepted, setIsAccepted] = useState(false);
  const [showPreferences, setShowPreferences] = useState(false);
  const [preferences, setPreferences] = useState({
    functional: true,
    analytical: false,
    marketing: false,
  });

  useEffect(() => {
    const consent = localStorage.getItem('gdprConsent');
    if (consent) {
      setIsAccepted(true);
      setPreferences(JSON.parse(consent));
    }
  }, []);

  const handleAccept = () => {
    localStorage.setItem('gdprConsent', JSON.stringify(preferences));
    setIsAccepted(true);
    setShowPreferences(false);
  };

  const handleDecline = () => {
    localStorage.setItem('gdprConsent', JSON.stringify({ functional: true, analytical: false, marketing: false }));
    setIsAccepted(true);
    setShowPreferences(false);
  };

  const handlePreferencesChange = (type) => {
    setPreferences({ ...preferences, [type]: !preferences[type] });
  };

  if (isAccepted) return null;

  return (
    <div style={{
      position: 'fixed',
      bottom: '0',
      left: '0',
      width: '100%',
      backgroundColor: '#f8f9fa',
      padding: '15px',
      boxShadow: '0 -2px 5px rgba(0,0,0,0.1)',
      textAlign: 'center',
      zIndex: '1000',
    }}>
      {showPreferences ? (
        <div>
          <h3>Cookie Preferences</h3>
          <div>
            <label>
              <input type="checkbox" checked={preferences.functional} onChange={() => handlePreferencesChange('functional')} />
              Functional Cookies (required)
            </label>
          </div>
          <div>
            <label>
              <input type="checkbox" checked={preferences.analytical} onChange={() => handlePreferencesChange('analytical')} />
              Analytical Cookies
            </label>
          </div>
          <div>
            <label>
              <input type="checkbox" checked={preferences.marketing} onChange={() => handlePreferencesChange('marketing')} />
              Marketing Cookies
            </label>
          </div>
          <button onClick={handleAccept} style={buttonStyle}>Save Preferences</button>
        </div>
      ) : (
        <div>
          <p style={{ margin: '0 0 10px 0' }}>
            We use cookies to improve your experience on our site. By using our site, you consent to cookies.
            Read our <a href="/privacy-policy" style={{ color: '#1DA1F2' }}>privacy policy</a>.
          </p>
          <button onClick={handleAccept} style={buttonStyle}>Accept</button>
          <button onClick={handleDecline} style={declineButtonStyle}>Decline</button>
          <button onClick={() => setShowPreferences(true)} style={preferencesButtonStyle}>Manage Preferences</button>
        </div>
      )}
    </div>
  );
};

const buttonStyle = {
  background: '#1DA1F2',
  color: '#fff',
  padding: '10px 20px',
  border: 'none',
  borderRadius: '5px',
  cursor: 'pointer',
  fontSize: '16px',
  marginRight: '10px',
};

const declineButtonStyle = {
  background: '#ccc',
  color: '#000',
  padding: '10px 20px',
  border: 'none',
  borderRadius: '5px',
  cursor: 'pointer',
  fontSize: '16px',
};

const preferencesButtonStyle = {
  background: '#fff',
  color: '#1DA1F2',
  padding: '10px 20px',
  border: '1px solid #1DA1F2',
  borderRadius: '5px',
  cursor: 'pointer',
  fontSize: '16px',
  marginLeft: '10px',
};

export default GDPRNotice;
