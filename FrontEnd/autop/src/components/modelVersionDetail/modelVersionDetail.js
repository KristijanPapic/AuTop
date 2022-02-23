import { Container,Row,Col } from "reactstrap";
import axios from "axios";
import { useEffect,useState } from "react";
import ModelVersionImageView from "./modelVersionImageView";
import { useParams } from "react-router-dom";
import ReviewInput from "./ReviewInput";
function ModelVerionDetail(){

const [modelVersion,setModelVersion] = useState(undefined)
const {modelVersionId} = useParams()

useEffect(() => {
    const Get = async () => {
        await FetchModelVersion();
        }
    Get()
},[])

const FetchModelVersion = async () => {
    axios.get('https://localhost:44343/api/ModelVersion/' + modelVersionId).then((response) => {
        console.log(response)
        setModelVersion(response.data)
    })
}

    return(
        
        <Container>
            {modelVersion == undefined ? (<p>loading</p>) : (<>
            <Row>
                <Col md='7'>
                <ModelVersionImageView 
                manufac_name={modelVersion.Model.Manufacturer.Name}
                model_name={modelVersion.Model.Name}
                model_version_name={modelVersion.Name}
                imageURL={modelVersion.Model.ImageURL}
                />
                </Col>
                <Col md='5'>
                
                </Col>
            </Row>
            <Row>
                <Col md='7'>
                    <ReviewInput modelVersionId={modelVersion.Id}/>
                </Col>
                <Col md='5'>
                
                </Col>
                
            </Row>
            <Row>

            </Row>
            </>)}
            
        </Container>
    );
}
export default ModelVerionDetail