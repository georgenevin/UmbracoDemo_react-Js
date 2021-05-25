import React, { Fragment} from "react";
import axios from 'axios';
import ProductTitle from './ProductTitle';
import ProductList from './ProductList';


class Product extends React.Component {


    constructor(props) {

        super(props);

        this.state = {
            products:""

        }


    }

    componentDidMount() {

        axios.get("/umbraco/api/Home/GetJson?page=products").then(response => {

            if (response.status == 200) {
                var data = response.data.ProductListing;
                this.setState({ products: data });

            }


        }).catch((error) => console.log(error));





    }


    render() {

        if (this.state.products == "") {

            return <p>Loading</p>


        }
        else {

            return (
                <Fragment>
                    <ProductTitle title={this.state.products.pageTitle} />
                    <ProductList list={this.state.products.FeaturedProducts.Products} />
                </Fragment>

            )

        }
      

           

        
      

    }



}

export default Product;