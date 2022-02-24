import axios from 'axios';
import React, { useEffect, useState } from 'react';
import {Container,Row} from 'reactstrap';
import Review from './review';
export default function Reviews(reviews){
    
    return(
        <Container className='bg-light border mt-3'>
            <Row className='my-3'>
                <h3>Reviews:</h3>
            </Row>
            {reviews.reviews.map((review) => (
                <Review review={review}/>
            ))}
        </Container>
    );
}
