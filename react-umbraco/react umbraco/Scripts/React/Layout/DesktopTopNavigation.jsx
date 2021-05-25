import React from "react";
import Home from "../Home/Home";
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";

function DesktopTopNavigation() {


    return (

        <Router>
                <nav className="nav-bar top-nav">
                    <Link to="/" className="nav-link">Home</Link>
                </nav>
                <Switch>
                    <Route exact path="/">
                        <Home />
                    </Route>
                </Switch>
          
        </Router >




    )



}

export default DesktopTopNavigation;