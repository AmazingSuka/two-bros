const smartGrid = require('smart-grid')

const settings = {
    filename: 'smartgrid',
    outputStyle: 'scss',
    columns: 12,
    offset: '30px',
    container: {
        maxWidth: '1140px',
        fields: '30px',
    },
    breakPoints: {
        lg: {
            width: '1024px',
            fields: '30px'
        },
        md: {
            width: '768px',
            fields: '20px'
        },
        sm: {
            width: '480px',
            fields: '15px'
        }
    }
}

smartGrid('./wwwroot/css', settings)