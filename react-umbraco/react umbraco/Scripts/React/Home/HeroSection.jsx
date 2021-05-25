import React from "react";



const HeroSection=(props)=> {


    return (

        <div>
            <section className="section section--full-height background-image-full overlay overlay--dark section--content-center section--thick-border"
                style={{ backgroundImage: `url(${props.hero.backgroundImage})` }}>
                <div className="section__hero-content">
                    <h1>{props.hero.header}</h1>
                    <p className="section__description">{props.hero.description }</p>
                    <a className="button button--border--solid" href={props.hero.ctaLink}>
                        {props.hero.ctaCaption}
                 </a>
                </div>
            </section>
         </div>

    )

}

export default HeroSection;

