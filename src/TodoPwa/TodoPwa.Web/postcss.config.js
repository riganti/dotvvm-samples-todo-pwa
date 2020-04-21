module.exports = (context) => ({
    map: context.options.map,
    parser: context.options.parser,
    plugins: [
        require('autoprefixer')({ browsers: "last 3 versions", grid: true })
    ]
})
