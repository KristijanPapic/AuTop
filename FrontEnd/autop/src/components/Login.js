import React, { useState } from 'react';
import PropTypes from 'prop-types';
import {
  Form,
  FormFeedback,
  FormGroup,
  Label,
  Input,
  Button,
} from 'reactstrap';
import axios from 'axios';


async function getUserId(credentials){

  return axios.get('https://localhost:44343/username/' + credentials.username)
    .then(data => data.data)
    .catch(error => {
      alert(error)
    });
        
}

async function loginUser(credentials) {
    var formBody = [];
    for (var property in credentials) {
      var encodedKey = encodeURIComponent(property);
      var encodedValue = encodeURIComponent(credentials[property]);
      formBody.push(encodedKey + "=" + encodedValue);
    }
    formBody = formBody.join("&");
        
    return fetch('https://localhost:44343/token', {
    method: 'POST',
    headers: {
        'Content-Type': 'application/x-www-form-urlencoded'
    },
    body: formBody
    })
    .then(data => data.json())
    .then(data => data.access_token)
    .catch(error => {
      alert(error)
    });
}

export default function Login({ setToken, setId }) {
  const [username, setUserName] = useState();
  const [password, setPassword] = useState(); 
  const [grant_type, setGrantType] = useState("password");  

  const handleSubmit = async e => {
    e.preventDefault();
    const token = await loginUser({
      username,
      password,
      grant_type
    });    
    setToken(token);

    const id = await getUserId({
      username
    });
    setId(id);
  }
  return(
    <div className="Registration">
      <h2>Please Log In</h2>
      <Form className="form" onSubmit={handleSubmit}>
        <FormGroup>
          <Label>Username</Label>
            <Input type="text" onChange={e => setUserName(e.target.value)} />          
        </FormGroup>
        <FormGroup>
          <Label>Password</Label>
            <Input type="password" onChange={e => setPassword(e.target.value)} />
        </FormGroup>
        <div>
          <Button>Submit</Button>
        </div>
      </Form>
    </div>
  )
}

Login.propTypes = {
  setToken: PropTypes.func.isRequired
};