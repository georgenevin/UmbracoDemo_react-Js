import React, { Fragment } from "react";

const InnerFooter = ({ footer }) => {


    return (


        <footer className="section--themed">
            <div className="container">
                <div className="row">
                    <div className="col-md-12 ta-center">
                        {footer.Address}
                    </div>
                </div>
            </div>
        </footer>
        
     )



}
export default InnerFooter;