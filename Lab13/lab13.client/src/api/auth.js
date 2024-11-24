export const fetchAuthToken = async () => {
    const response = await fetch('http://localhost:5145/api/account/token', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            client_id: 'your-client-id',
            client_secret: 'your-client-secret',
            audience: 'your-api-audience',
            grant_type: 'client_credentials',
        }),
    });

    const tokenResponse = await response.json();

    if (response.ok) {
        console.log('Access token:', tokenResponse.access_token);
        return tokenResponse.access_token;
    } else {
        console.error('Failed to fetch token', tokenResponse);
    }
};
