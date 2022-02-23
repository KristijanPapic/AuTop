import { Container,Row,Form,Input, Label, Button,Col} from "reactstrap";
import { useState,useEffect } from "react";
import axios from "axios";
function Filter(){
    const [transmissions,setTransmissions] = useState([])
    const [bodyShapes,setBodyShapes]= useState([])

    useEffect(() => {
        const Get = async () => {
            await fetchTransmission();
            await fetchBodyShapes();
            }
        Get()
    },[])

    const fetchTransmission = async () => {
        axios.get('https://localhost:44343/api/Transmission').then((response) => {
            setTransmissions(response.data)
        })
    }

    const fetchBodyShapes = async () => {
        axios.get('https://localhost:44343/api/BodyShape').then((response) => {
            setBodyShapes(response.data)
        })
    }


    const year = (new Date()).getFullYear();
    const years = Array.from(new Array(30),( val, index) => year - index);
    return(
        <Container className="bg-light border">
            <Form>
                <Row className="my-3">
                    <Label for="transmissions">Transmission</Label>
                    <Input type="select" id="transmissions">
                    <option value={null}></option>
                        {transmissions.length < 1 ? (null) : (
                            transmissions.map((transmission) => (
                                <option value={transmission.Id}>{transmission.Gears}-gear {transmission.Name}</option>
                            ))
                        )}
                    </Input>
                </Row>
                <Row className="my-3">
                <Label for="body_shapes">Body Shape</Label>
                    <Input type="select" id="body_shapes">
                        <option value={null}></option>
                    {bodyShapes.length < 1 ? (null) : (
                            bodyShapes.map((bodyShape) => (
                                <option value={bodyShape.Id}>{bodyShape.Name}</option>
                            ))
                        )}
                    </Input> 
                </Row>
                <Row className="my-3">
                    <Label for='power'>Engine power (hp)</Label>
                    <Row className="m-auto">
                        <Col md='5'>
                            <Input type="number" id="power"/>
                        </Col>
                        <Col md='2'>
                        <p>to</p>
                        </Col>
                        <Col md='5'>
                            <Input type="number" id="power"/>
                        </Col>
                    </Row>
                </Row>
                <Row className="my-3">
                    <Label for='year'>Year</Label>
                    <Row className="m-auto">
                        <Col md='5'>
                            <Input type="select" id="year">
                               {years.map((year, index) => {
                                    return <option key={index} value={year}>{year}</option>
                                })}
                            </Input>
                        </Col>
                        <Col md='2'>
                        <p>to</p>
                        </Col>
                        <Col md='5'>
                        <Input type="select" id="year">
                               {years.map((year, index) => {
                                    return <option key={index} value={year}>{year}</option>
                                })}
                            </Input>
                        </Col>
                    </Row>
                </Row>
                <Row className="my-4">
                    <Button type="button" color="info">Apply Filter</Button>
                </Row>
            </Form>
        </Container>
    );
}
export default Filter