// src/services/tweetService.js

const API_URL = 'http://localhost:5185/api'; // Adjust API URL as per your setup

const getTweets = async () => {
    const response = await fetch(`${API_URL}/tweets`);
    if (!response.ok) {
        throw new Error('Failed to fetch tweets');
    }
    const tweetsData = await response.json();
    return tweetsData;
};

const postTweet = async (content) => {
    const response = await fetch(`${API_URL}/tweets`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ content }),
    });
    if (!response.ok) {
        throw new Error('Failed to post tweet');
    }
    // Optionally handle response if needed
};

export { getTweets, postTweet };
