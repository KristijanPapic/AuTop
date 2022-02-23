import { Link } from "react-router-dom";
import { Breadcrumb,BreadcrumbItem,bre } from "reactstrap";

function Breadcrumbs(crumbs) {
    return (
<div>
  <Breadcrumb listTag="div">
  {crumbs.crumbs.map((crumb,index) => (
    index + 1 == crumbs.crumbs.length ? (
    <BreadcrumbItem active
        href={Link}
        tag="a"
      >
          {crumb.Name}
      </BreadcrumbItem>
      ) : (
        <BreadcrumbItem
        href="#"
        tag="a"
      >
          {crumb.Name}
          {console.log(index)}
          {console.log(crumbs.crumbs.length)}
          {console.log(crumbs.crumbs)}
      </BreadcrumbItem>
      )
  ))}  
  </Breadcrumb>
</div>
    );
}
export default Breadcrumbs