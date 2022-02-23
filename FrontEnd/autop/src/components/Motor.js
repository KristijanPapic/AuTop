import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Row, Button, CardHeader, Container, ListGroup, ListGroupItem } from 'reactstrap';


export default function Motor({Motor}) {
    const [modelVersions, setModelVersion] = useState({});  
   
        return (
            modelVersions == null ? <p>Loading...</p>:
          <Container key={modelVersions.Id} className="bg-light mt-2">   
             <h5>Motor</h5>
                <Row className='bg-light mt-2 '>Type: {Motor?.Name}</Row>   
                <Row className='bg-light'>Year: {Motor?.Year}</Row>  
                <Row className='bg-light'>Type: {Motor?.Type}</Row>  
                <Row className='bg-light'>MaxHP: {Motor?.MaxHP}</Row>                     
            
          </Container>
        )
        
}