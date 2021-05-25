import React, { Fragment, useState, useEffect } from "react";
import axios from 'axios';
import ProductTitle from '../Product/ProductTitle';


const Blog = () => {


    const [blogs, setBlog] = useState("");
    const [blogpost, setblogpost] = useState("");

    useEffect(() => {

        axios.get("/umbraco/api/Home/GetJson?page=blog").then(response => {

            if (response.status == 200) {
         
                var data = response.data;
                setBlog(data);
            }
        }).catch((error) => console.log(error));




    }, []);

    if (blogs !== "") {

        return (


            <Fragment>
                <ProductTitle title={blogs.Blog.PageTitle} />
            </Fragment>



        )


    }
    else {
        return (
            <p>Loading</p>
            )
     
    }
   





}

export default Blog;