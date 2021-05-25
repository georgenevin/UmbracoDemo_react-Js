import React, { Fragment, useState, useEffect } from "react";
import axios from 'axios';
import ProductTitle from '../Product/ProductTitle';
import PeopleList from '../People/PeopleList'

const People = () => {


    const [people, setPeople] = useState("");

    useEffect(() => {
        axios.get("/umbraco/api/Home/GetJson?page=people").then(response => {

            if (response.status == 200) {
           
                var data = response.data.PeopleListing;
              
                setPeople(data);
            

            }
          

        }).catch((error) => console.log(error));

      
    },[]);

    if (people !== "") {

        return (
            <Fragment>
                <ProductTitle title={people.pageTitle} />
                <PeopleList people={people.People} />
            </Fragment>
        );
          
    }
    else {

        return <p>Loading</p>
    }
    


}
export default People;