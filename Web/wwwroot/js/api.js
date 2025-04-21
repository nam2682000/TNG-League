function getAuthHeader() {
    const token = localStorage.getItem('token');
    return token ? { Authorization: `Bearer ${token}` } : {};
}

async function handleResponse(response) {
    if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`API Error: ${response.status} - ${errorText}`);
    }
    return await response.json();
}

async function get(endpoint) {
    const response = await fetch(window.baseApiUrl + endpoint, {
        method: 'GET',
        headers: {
            Accept: 'application/json',
            ...getAuthHeader()
        }
    });
    return handleResponse(response);
}

async function post(endpoint, data) {
    const response = await fetch(window.baseApiUrl + endpoint, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            ...getAuthHeader()
        },
        body: JSON.stringify(data)
    });
    return handleResponse(response);
}

async function put(endpoint, data) {
    const response = await fetch(window.baseApiUrl + endpoint, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            ...getAuthHeader()
        },
        body: JSON.stringify(data)
    });
    return handleResponse(response);
}

async function delelete(endpoint) {
    const response = await fetch(window.baseApiUrl + endpoint, {
        method: 'DELETE',
        headers: {
            Accept: 'application/json',
            ...getAuthHeader()
        }
    });
    return handleResponse(response);
}

async function postFormData(endpoint, formData) {
    const response = await fetch(window.baseApiUrl + endpoint, {
        method: 'POST',
        headers: {
            ...getAuthHeader()
        },
        body: toFormData(formData)
    });
    return handleResponse(response);
}

function toFormData(obj, formData = new FormData(), parentKey = '') {
    if (obj === null || obj === undefined) return formData;

    if (typeof obj !== 'object' || obj instanceof File) {
        formData.append(parentKey, obj);
    } else if (Array.isArray(obj)) {
        obj.forEach((item, index) => {
            const key = parentKey ? `${parentKey}[${index}]` : index;
            toFormData(item, formData, key);
        });
    } else {
        Object.keys(obj).forEach(key => {
            const value = obj[key];
            const fullKey = parentKey ? `${parentKey}.${key}` : key;
            toFormData(value, formData, fullKey);
        });
    }

    return formData;
}