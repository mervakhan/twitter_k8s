import axios from 'axios';

const API_URL = 'https://localhost:7100/api/Login';

export const login = async (username, password) => {
    const response = await axios.post(`${API_URL}/login`, {
        username,
        password,
    });
    return response.data;
};

// Implement register function if needed
export const register = async (username, password) => {
    const response = await axios.post(`${API_URL}/register`, {
        username,
        password,
    });
    return response.data;
};
