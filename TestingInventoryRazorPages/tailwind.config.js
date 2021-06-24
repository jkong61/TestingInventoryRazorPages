module.exports = {
    mode: 'jit',
    important: true,
    prefix: 'tw-',
    purge: [
        './Pages/**/*.{cshtml,cshtml.cs}',
        './Areas/**/*.cshtml'
    ],
    darkMode: 'media', // or 'media' or 'class;
    theme: {
        extend: {}
    },
    variants: {
        extend: {},
    },
    plugins: []
}