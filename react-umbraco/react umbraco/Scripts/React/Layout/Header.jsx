import React, { Fragment } from "react";
import axios from 'axios';
import Home from "../Home/Home";
import Product from "../Product/Product";
import InnerFooter from "./InnerFooter";
import People from "../People/People";
import Blog from "../Blog/Blog";
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";


class Header extends React.Component {


    constructor(props) {
        super(props);

        this.state = {
            header: "",
            footer:""

        };

    }

    componentDidMount() {

        axios.get("/umbraco/api/Home/GetJson?page=Home").then(response => {
            debugger;
            if (response.status == 200) {
                debugger;
                var data = response.data.HomePage.HeroSection;
                var footerData = response.data.HomePage.Footer;
                this.setState(
                    {
                        header: data,
                        footer: footerData

                    });

            }


        });

    }


    render() {

        if (this.state.header == "") {

            return <div>Loading</div>
        }
        else {

            return (
                <>
                    <Router>
                        <header className="header">
                            <div className="logo">
                                <a className="nav-link nav-link--home nav-link--home__text logo-text" href="/">{this.state.header.siteName}</a>
                            </div>
                            <nav className="nav-bar top-nav">
                                <Link to="/" className="nav-link">Home</Link>
                                <Link to="/products" className="nav-link">Products</Link>
                                <Link to="/people" className="nav-link">People</Link>
                                <Link to="/blog" className="nav-link">Blog</Link>
                            </nav>
                            <div className="mobile-nav-handler">
                                <div className="hamburger lines" id="toggle-nav">
                                    <span></span>
                                </div>
                            </div>
                        </header>

                        <Switch>
                            <Route exact path="/">
                                <Home />
                            </Route>
                            <Route exact path="/products">
                                <Product />
                                <InnerFooter footer={this.state.footer} />
                            </Route>
                            <Route exact path="/people">
                                <People />
                                <InnerFooter footer={this.state.footer} />
                            </Route>
                            <Route exact path="/blog">
                                <Blog />
                                <InnerFooter footer={this.state.footer} />
                            </Route>
                        </Switch>
                    </Router >
                </>


            )


        }





    }






};

export default Header;