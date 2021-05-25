import React, { Fragment } from "react";

const ProductItem = ({ product}) => {

   
    return (

        <Fragment>
            <a href={product.ProductLink} className="product-grid__item" style={{ backgroundImage: `url(${product.Photos})` }}>
                <div className="product-grid__item__overlay">
                    <div className="product-grid__item__name">{product.ProductName}</div>
                    <div className="product-grid__item__price">{product.Price}</div>
                </div>
                </a>
          
        </Fragment>


    )



}

export default ProductItem;