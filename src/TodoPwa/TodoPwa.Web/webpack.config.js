const path = require("path");
const tsconfigPathsPlugin = require("tsconfig-paths-webpack-plugin");
const scriptsPath = "./Resources/Scripts";

module.exports = [
    {
        mode: "development",
        entry:
        {
            app: [`${scriptsPath}/App/App.ts`]
        },
        output: {
            path: path.resolve(__dirname, "wwwroot"),
            filename: "app.js"
        },
        resolve: {
            extensions: [".js", ".ts"],
            plugins: [new tsconfigPathsPlugin({ configFile: `${scriptsPath}/App/tsconfig.json` })]
        },
        module: {
            rules: [
                {
                    test: /\.ts$/,
                    loader: "ts-loader"
                }
            ]
        },
        externals: ["tls", "net", "fs"]
    },
    {
        mode: "development",
        entry:
        {
            serviceWorker: [`${scriptsPath}/ServiceWorker/ServiceWorker.ts`]
        },
        output: {
            path: path.resolve(__dirname, "wwwroot"),
            filename: "service-worker.js"
        },
        resolve: {
            extensions: [".js", ".ts"],
            plugins: [new tsconfigPathsPlugin({ configFile: `${scriptsPath}/ServiceWorker/tsconfig.json` })]
        },
        module: {
            rules: [
                {
                    test: /\.ts$/,
                    loader: "ts-loader"
                }
            ]
        },
        externals: ["tls", "net", "fs"]
    }
];