import { Container,Row,Col } from "reactstrap";
import '../App.css'
import ReactStars from "react-rating-stars-component";
function Review(review){
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
        </Container>
    );
}
export default Review