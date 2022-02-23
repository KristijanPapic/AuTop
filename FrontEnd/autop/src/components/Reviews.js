import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Dropdown, DropdownToggle, DropdownItem, DropdownMenu,Table, Button, CardHeader, Container, Modal, ModalBody, ModalFooter, FormGroup, ModalHeader, Label, Input } from 'reactstrap';

export default function Reviews(){
    
    const [reviews, setReviews] = useState([]);
    const [comment, setComment] = useState("");
    const [rating, setRating] = useState(0);    
    const [newReviewModal, setNewReviewModal] = useState(false);
    const [editUserModal, setEditUserModal] = useState(false);
    const [editId, setEditId] = useState("");
    const [editUsername, setEditUsername] = useState("");
    const [editEmail, setEditEmail] = useState("");

    useEffect(() => {
        axios.get('https://localhost:44343/reviews')
            .then((response) => {
                console.log(response.data)
                setReviews(response.data);
            })
    }, []);

    const setData = (data) => {
        let { id, username, email } = data;
        localStorage.setItem('Id', id);
        localStorage.setItem('Username', username);
        localStorage.setItem('Email', email)
    }
    const AddReview = () => {
        const newReviewData = {Comment : comment,
                             Rating : rating};
        axios.post('https://localhost:44343/reviews', newReviewData).then((response) => {
          setData(response.data);
          setComment('');
          setRating(0);
          console.log(response.data);
          console.log(newReviewData);
          
    
          reviews.push(response.data);
          //getData(); 
        });
      }

    const getData = () => {
        axios.get('https://localhost:44343/reviews')
            .then((getData) => {
                setReviews(getData.data);
            })
    }

    const getDataById = (id) => {
        axios.get('https://localhost:44343/reviews/' + id)
            .then((getData) => {
                setReviews(getData.data);
            })
    }

    const getReviews = () => {
        axios.get('https://localhost:44343/reviews')
            .then((getData) => {
                setReviews(getData.data);
            })
    }

    const onDelete = (id) => {
        axios.delete('https://localhost:44343/reviews/' + id)
        .then(() => {
            getData();
        })
    }

    let reviewsList = reviews.map((review) => {
        return (
          <tr key={review.Id}>
            <td>{review.Id}</td>
            <td>{review.Comment}</td>
            <td>{review.Rating}</td>
            <td>{review.User.Username}</td>
            <td>{review.LikePercentage}</td>
            <td>{review.DateCreated}</td>
            <td>                
                <Button color="danger" size="sm" onClick={() => onDelete(review.Id)}>Delete</Button>
            </td>            
          </tr>
        )
      });

    return (
        
        <Container>
            <h1>Reviews table</h1>

            <Button className="my-3" color="primary" onClick={() => setNewReviewModal(!newReviewModal)}>Add Review</Button>

            <Modal isOpen={newReviewModal} toggle={() => setNewReviewModal(!newReviewModal)}>
                <ModalHeader toggle={() => setNewReviewModal(!newReviewModal)}>Add new review</ModalHeader>
                <ModalBody>
                <FormGroup>
                    <Label for="Username">Comment:</Label>
                    <Input id="Username" value={comment} onChange={(e) => setComment(e.target.value)} />
                </FormGroup>
                <FormGroup>
                    <Label for="Email">Rating:</Label>
                    <Input id="Email" value={rating} onChange={(e) => setRating(e.target.value)} />
                </FormGroup>
                <ModalFooter>
                    <Button color="primary" onClick={() => AddReview()}>Add Review</Button>{' '}                    
                    <Button color="secondary" onClick={() => setNewReviewModal(!newReviewModal)} >Cancel</Button>
                </ModalFooter>

                </ModalBody>
                
            </Modal>

            <Table>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Comment</th>
                        <th>Rating</th>
                        <th>User</th>
                        <th>LikePercentage</th>
                        <th>DateCreated</th>
                        <th>Actions</th>
                    </tr>
                </thead>

                <tbody>
                    {reviewsList}
                </tbody>
            </Table>
        </Container>
    )
}