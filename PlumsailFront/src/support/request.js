import axios from 'axios';

export async function request(url, type, data){
    const response = await axios({
        url,
        method: type,
        data: JSON.stringify(data),
        headers: {
            'Content-Type': 'application/json',
        }
    })
    
    return {response, data: response.data};
}