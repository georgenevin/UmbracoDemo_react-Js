import React, { Fragment, useState, useEffect } from "react";
import Person from "../People/Person"


const PeopleList = ({ people }) => {

    console.log("PeopleList",people);
    return (
        
        <section className="section">
            <div className="container">
                <div className="employee-grid">
                    {
                        people.map((person, index) => (

                            <Person personalDetails={person.personalDetails} key={index} personalContact={person.personalContact} />
                           
                       
                            
                       ))


                    }
           
                </div>
            </div>
        </section>
        
        
   )






}

export default PeopleList;