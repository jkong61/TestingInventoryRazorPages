const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const { resolve } = require("path");
const path = require('path');
const devMode = process.env.NODE_ENV === "production" ? 'production' : 'development';

module.exports = {
    entry : path.resolve(__dirname,'Styles','app.js'),
    output: {
        path: path.resolve(__dirname, 'wwwroot'),
        filename: 'js/site.js',
    },
    mode: devMode,
    watchOptions: {
        ignored: '**/node_modules/'
    },
    plugins: [
        new MiniCssExtractPlugin({
            filename: 'css/site.css'
        })
    ],
    module: {
        rules: [
        {
            test: /\.css$/i,
            use: [MiniCssExtractPlugin.loader,
                {
                    loader: "css-loader",
                    options: {
                        importLoaders: 1
                    }
                }, 
                "postcss-loader"
            ],
        },
        ],
    },
};
