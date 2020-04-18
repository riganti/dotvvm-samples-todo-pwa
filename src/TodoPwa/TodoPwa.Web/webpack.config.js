const path = require("path");
const tsconfigPathsPlugin = require("tsconfig-paths-webpack-plugin");
const scriptsPath = "./Resources/Scripts";

module.exports = [
    {
        mode: "development",
        entry:
        {
            serviceWorker: [`${scriptsPath}/service-worker.ts`]
        },
        output: {
            path: path.resolve(__dirname, "wwwroot"),
            filename: "service-worker.js"
        },
        resolve: {
            extensions: [".js", ".ts"],
            plugins: [new tsconfigPathsPlugin({ configFile: `${scriptsPath}/tsconfig.json` })]
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