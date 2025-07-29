//Create a React frontend that calls a .NET Web API endpoint using Axios and displays the result.

// ✅ Backend (C#/.NET API)
// Endpoint: GET https://localhost:5001/api/hello

// [ApiController]
// [Route("api/[controller]")]
// public class HelloController : ControllerBase
// {
//     [HttpGet]
//     public IActionResult Get()
//     {
//         return Ok("Hello from .NET!");
//     }
// }


// ✅ Frontend (React.js + Axios)
// In your React app:

// 1. Create a component called HelloApi.js
// 2. Use Axios to call the API and display the response on the page.

// 📌 Requirements:
// - Use useEffect() to call the API when the component loads.
// - Use useState() to store the response.
// - Display the message in an <h1> tag.
// - Use Axios (not fetch).

import React, {useState, useEffect} from 'react';
import axios from 'axios';

const HelloApi = () => {
    const [mesage, setMessage] = useuseState('');

    useEffect(() => {
        axios.get('https://localhost:5001/api/hello')
            .then(response => {
                setMessage(response.data);
            })
            .catch(error => {
                console.error('Error fetching data:', error);
                setMessage('Error loading message');
            });
    }, []);

    return (
        <div>
            <h1>{message}</h1>
        </div>
    );
};

export default HelloApi;