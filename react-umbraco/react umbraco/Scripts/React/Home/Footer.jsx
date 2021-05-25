import React from "react";
const Footer = ({ footer }) => {


    return (

        <section className="section section--themed">
            <div className="container">
                <div className="row">
                    <div className="ta-center">
                        <h2>{footer.Address}</h2>
                        <p className="section__description mw-640 ma-h-auto">{footer.Description}</p>
                        <a className="button button--border--light_solid" href={footer.CtaLink}>
                            {footer.CtaCaption}
                        </a>
                    </div>
                </div>
            </div>
        </section>



    )


}

export default Footer;