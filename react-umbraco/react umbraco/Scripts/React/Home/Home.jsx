import React, { Fragment } from "react";
import HeroSection from "./HeroSection";
import ContentSection from "./contentSection";
import Footer from "./Footer";

import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";

import axios from 'axios';

class Home extends React.Component {

    constructor(props) {

        super(props);
        this.state = {
            home: ""
        };

    }

    componentDidMount() {

        axios.get("/umbraco/api/Home/GetJson?page=Home").then(response => {

            if (response.status == 200) {
                var data = response.data.HomePage;
                this.setState({ home: data });

            }


        }).catch((error) => console.log(error));



        

    }

    render() {


        if (this.state.home === "") {
            return <div>Loading</div>;
        }
        else {

            return (
                <Fragment>
                    <HeroSection hero={this.state.home.HeroSection} />
                    <ContentSection fullwidth={this.state.home.ContentSection} />
                    <Footer footer={this.state.home.Footer} />
                </Fragment >


            )
        }

    }



};

export default Home;