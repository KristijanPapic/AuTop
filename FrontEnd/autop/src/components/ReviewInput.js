import React, {useState} from 'react';
import axios from 'axios';
import ReactStars from 'react-rating-stars-component';
import { Container,Form,FormGroup,Label,Input, Button } from 'reactstrap';
import './App.css';

export default function ReviewInput(){
    
    const [comment, setComment] = useState("");
    const [rating, setRating] = useState(0);   
    
    const AddReview = () => {
        const newReviewData = {Comment : comment,
                             Rating : rating,
                             UserId : '1E3B4F5B-2CED-448C-82BA-B4D977E34571',
                             ModelVersionId: '679DA10D-530D-4FE8-B28B-5FDB95415BCB'};
        
        axios.post('https://localhost:44343/reviews', newReviewData).then((response) => {
          setComment('');
          setRating(0);
          console.log(response.data);
          console.log(newReviewData);    
    
    })};


    const ratingChanged = (newRating) => {
        setRating(newRating)
      };

    return(
        <Container className='Registration'>                        
            <FormGroup>
                <Label>Comment</Label>
                <Input
                    id="exampleText"
                    name="text"
                    type="textarea"
                    value={comment} onChange={(e) => setComment(e.target.value)}
                    />
                <br></br>
                <Label>Rating</Label>
                <ReactStars
                    count={5} 
                    size={24}
                    value={rating} 
                    onChange={ratingChanged}
                />
                <br></br>             
                <Button onClick={AddReview}>Submit</Button>
            </FormGroup>
        </Container>
    )
}