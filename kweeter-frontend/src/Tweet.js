import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Tweet = () => {
  const [tweets, setTweets] = useState([]);
  const [message, setMessage] = useState('');
  const [error, setError] = useState('');
  const token = localStorage.getItem('token');

  useEffect(() => {
    fetchTweets();
  }, []);

  const fetchTweets = async () => {
    try {
      const response = await axios.get('http://35.233.9.34/tweets/tweets', {
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${token}`
        }
      });
      setTweets(response.data);
      setError('');
    } catch (err) {
      setError('Failed to load tweets.');
      console.error('Error fetching tweets:', err);
    }
  };

  const handleCreateTweet = async (e) => {
    e.preventDefault();
    try {
      await axios.post('http://35.233.9.34/tweets/createtweets', message, {
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${localStorage.getItem('token')}`
        }
      });
      setTweets([{ tweetText: message }, ...tweets]); // Place new tweet at the beginning
      setMessage('');
      setError('');
    } catch (err) {
      setError('Failed to create tweet.');
    }
  };

  return (
    <div style={{ fontFamily: 'Arial, sans-serif', maxWidth: '600px', margin: 'auto', padding: '20px', backgroundColor: '#fff', borderRadius: '12px', boxShadow: '0 0 10px rgba(0,0,0,0.1)' }}>
      <div style={{ display: 'flex', alignItems: 'center', marginBottom: '20px' }}>
        <h2 style={{ fontSize: '24px', fontWeight: 'bold', color: '#1DA1F2' }}>Kweeter</h2>
      </div>
      <form onSubmit={handleCreateTweet} style={{ marginBottom: '20px' }}>
        <div style={{ marginBottom: '10px' }}>
          <textarea
            value={message}
            onChange={(e) => setMessage(e.target.value)}
            placeholder="What's happening?"
            style={{ width: '100%', padding: '10px', fontSize: '16px', borderRadius: '8px', border: '1px solid #ccc', boxSizing: 'border-box', minHeight: '100px' }}
            required
          />
        </div>
        <button type="submit" style={{ background: '#1DA1F2', color: '#fff', padding: '12px 24px', border: 'none', borderRadius: '9999px', cursor: 'pointer', fontSize: '16px' }}>Tweet</button>
      </form>
      {error && <p style={{ color: 'red', textAlign: 'center' }}>{error}</p>}
      <div>
        {tweets.length > 0 ? (
          tweets.map((tweet, index) => (
            <div key={index} style={{ backgroundColor: '#f0f0f0', marginBottom: '12px', padding: '12px', borderRadius: '12px', boxShadow: '0 2px 4px rgba(0,0,0,0.1)' }}>
              <p style={{ fontSize: '16px', marginBottom: '8px', lineHeight: '1.4' }}>{tweet.tweetText}</p>
            </div>
          ))
        ) : (
          <p style={{ textAlign: 'center', color: '#666' }}>No tweets available.</p>
        )}
      </div>
    </div>
  );
};

export default Tweet;
