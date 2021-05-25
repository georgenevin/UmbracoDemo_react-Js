import React from "react";
import ProductItem from "./ProductItem";

const ProductList = ({ list }) => {

   
    return (
        
        <section className="section">
            <div className="container">
                <div className="product-grid">
                
                    {
                        list.map((item, index) => (
                            < ProductItem key = { index } product = { item.productDetails } />
                        )
                              
                             
                        )
                    }

                    </div>
            </div>
         
        </section>
        
        
    )





}

export default ProductList;