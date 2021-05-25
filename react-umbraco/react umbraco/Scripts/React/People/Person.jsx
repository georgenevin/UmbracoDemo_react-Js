import React, { Fragment, useState, useEffect } from "react";

const Person = ({ personalDetails }) => {
   

    return (

        <div className="employee-grid__item">
            <div className="employee-grid__item__image" style={{ backgroundImage: `url(${personalDetails.Photo})` }}></div>
            <div className="employee-grid__item__details">
                <h3 className="employee-grid__item__name">{personalDetails.Name }</h3>

                <a href={personalDetails.Email } className="employee-grid__item__email">{personalDetails.Email}</a>

                <div className="employee-grid__item__contact">

                </div>
            </div>
        </div>









    )




}

export default Person;