const path = require("path");

module.exports = {
    mode: 'development',
    entry: {
        app: path.resolve(__dirname, "Scripts/React/app.jsx")
     
    },
    output: {
        filename: "[name].bundle.js",
        path: path.resolve(__dirname, "Scripts/Dist")
    },

    stats: {
        errorDetails: true,
    },
   
    resolve: {
        extensions: [".js", ".jsx"]
    },
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                use: {
                    loader: "babel-loader"
                }
            }
        ]
    }
};