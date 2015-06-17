var webpack          = require('webpack');
var path             = require('path');
var ngAnnotatePlugin = require('ng-annotate-webpack-plugin');
var node_modules     = path.resolve(__dirname, 'node_modules');

var config = {
    entry: {
        app: './src/js/app.ts'//,
        // breweryModule: './src/js/breweryModule/module.ts',
        // module2: './src/js/module2/module.ts',
        // module3: './src/js/module3/module.ts',
        // module4: './src/js/module4/module.ts'
    },
    output: {
        filename: './js/[name].js',
        chunkFilename: "./js/[name].js"
    },
    resolve: {
        extensions: ['', '.webpack.js', '.web.js', '.js', '.ts'],
        alias: {
            'ui.router': 'angular-ui-router'
        }
    },
    module: {
        noParse: [],
        loaders: [
            { test: /\.html$/, loader: 'raw' },
            {
              test: /\.ts$/,
              loader: 'typescript-loader?module=commonjs'
            }
        ]
    },
    devtool: 'source-map',
    plugins: [
       //new webpack.optimize.CommonsChunkPlugin('vendor', 'vendor.js'),
       new ngAnnotatePlugin({
           add: true,
           // other ng-annotate options here 
       })
    ]
};

module.exports = config;