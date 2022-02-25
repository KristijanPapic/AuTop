import { Container,Row,Col,Button } from "reactstrap";
import '../App.css'
import ReactStars from "react-rating-stars-component";
import axios from "axios";
function Review(review){
const handleLike = () => {
   if(review.review.CurrentUserReaction == null){
    const data = {UserId : localStorage.getItem('id'),
        ReviewId : review.review.Id,
        IsLiked : true
    };
    axios.post('https://localhost:44343/api/Reaction', data).then((response) => {
        console.log(response)
          window.location.reload()  
    })
   } 
}
const handleRemoveLike = () => {}
const handleDislike = () => {}
const handleRemoveDislike = () => {}

    return(
        <Container className="border my-3" id="review">
            <Row>
                <Col md='8' className="text-start">
                <h6>{review.review.User.Username}</h6>
                </Col>
                <Col md='4'>
                <ReactStars
                    edit={false}
                    count={5}
                    size={24}
                    value={review.review.Rating}
                    />
                </Col>
                
            </Row>
            <Row>
                <Container className="bg-light border mb-3 text-start">
                    <p>{review.review.Comment}</p>
                </Container>
            </Row>
            <Row>
                <Col md='3'>
                    {review.review.CurrentUserReaction !== null ? (<>
                    {review.review.CurrentUserReaction.IsLiked === true ? (<Button color="info" type="button" onClick={handleRemoveLike}>Like</Button>) : (<Button onClick={handleLike} color="light" type="button">Like</Button>)}
                    </>) : 
                    (<Button onClick={handleLike} type="button">Like</Button>
                    )
                    }
                
                </Col>
                <Col md='3'>
                {review.review.CurrentUserReaction !== null ? (<>
                    {review.review.CurrentUserReaction.IsLiked === false ? (<Button color="danger" type="button" onClick={handleRemoveDislike}>Dislike</Button>) : (<Button onClick={handleDislike} color="light" type="button">Dislike</Button>)}
                    </>) : 
                    (<Button onClick={handleDislike} type="button">Dislike</Button>
                    )
                    }
                
                </Col>
                <Col md='6'>
                <p>{review.review.LikePercentage}% of users liked this</p>
                </Col>
            </Row>
        </Container>
    );
}
export default Review