import { Container,Row,Col } from "reactstrap";
import axios from "axios";
import { useEffect,useState } from "react";
import ModelVersionImageView from "./modelVersionImageView";
import { useParams } from "react-router-dom";
import ReviewInput from "./ReviewInput";
import Breadcrumbs from "../common/breadCrumbs";
import Reviews from "../Reviews";
import Motor from "./Motor";
import BodyShape from "./BodyShape";
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
        console.log(response.data.Reviews);
        setModelVersion(response.data);
    })
}
var crumbs = []
if(modelVersion != undefined){
   crumbs = [
    {"Name" : 'Manufacturers',"Link": '/'},
    {"Name": modelVersion.Model.Manufacturer.Name,"Link": '/'},
    {"Name" : modelVersion.Model.Name,"Link": '/'},
    {"Name" : modelVersion.Name,"Link": '/'}
] 
}
 
    return(
        
        <Container>
            <Row>
                {console.log(crumbs)}
                {console.log(modelVersion)}
                <Breadcrumbs crumbs = {crumbs}/>
            </Row>
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
                    <Row><Motor motor={modelVersion.Motor}/></Row>
                    <Row><BodyShape bodyShape={modelVersion.BodyShape}/></Row>
                </Col>
            </Row>
            <Row>
                <Col md='7'>
                {sessionStorage.getItem('id') == null ? (null) : (<ReviewInput modelVersionId={modelVersion.Id}/>)}
                    
                </Col>
                <Col md='5'>
                
                </Col>
                
            </Row>
            <Row>
                <Col md='7'>
                {modelVersion.Reviews.length < 1 ? (null) : (<Reviews reviews = {modelVersion.Reviews}/>)}
                </Col>
                <Col md='5'>
                </Col>
                
                
            </Row>
            </>)}
            
        </Container>
    );
}
export default ModelVerionDetail