function getAuthHeader() {
    const token = localStorage.getItem('token');
    return token ? { Authorization: `Bearer ${token}` } : {};
}

async function apiGet(endpoint) {
    const response = await fetch(window.baseApiUrl + endpoint, {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            ...getAuthHeader()
        }
    });
    if (!response.ok) throw new Error('GET API failed');
    return await response.json();
}

async function apiPost(endpoint, data) {
    const response = await fetch(window.baseApiUrl + endpoint, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            ...getAuthHeader()
        },
        body: JSON.stringify(data)
    });
    if (!response.ok) throw new Error('POST API failed');
    return await response.json();
}

async function apiPut(endpoint, data) {
    const response = await fetch(window.baseApiUrl + endpoint, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            ...getAuthHeader()
        },
        body: JSON.stringify(data)
    });
    if (!response.ok) throw new Error('PUT API failed');
    return await response.json();
}

async function apiDelete(endpoint) {
    const response = await fetch(window.baseApiUrl + endpoint, {
        method: 'DELETE',
        headers: {
            'Accept': 'application/json',
            ...getAuthHeader()
        }
    });
    if (!response.ok) throw new Error('DELETE API failed');
    return await response.json();
}