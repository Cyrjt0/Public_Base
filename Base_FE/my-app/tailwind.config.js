
/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./index.html",
        "./src/**/*.{js,ts,jsx,tsx}",
    ],
    theme: {
        extend: {
            fontFamily: {
                sans: ['Inter', 'sans-serif'],
            },
            colors: {
                primary: {
                    DEFAULT: '#008658',
                },
                green:{
                    50: '#f0fdf4',
                    100: '#dcfce7',
                    200: '#bbf7d0',
                    300: '#86efac',
                    400: '#4ade80',
                    500: '#22c55e',
                    600: '#16a34a',
                    700: '#15803d',
                    800: '#166534',
                    900: '#14532d',
                    950: '#052e16',
                },
                secondary: '#3F51B5', 
                success: '#4CAF50',   
                warning: '#FFC107',   
                error: '#F44336',     
                info: '#2196F3',      
                gray: {
                    light: '#F5F5F5',
                    DEFAULT: '#9E9E9E',
                    dark: '#212121',
                },
                background: '#F8F8F8',
                text: {
                    primary: '#0A0A0C',  
                    secondary: '#757575' 
                }
            },
            borderRadius: {
                'none': '0',
                'sm': '0.125rem',     
                'DEFAULT': '0.25rem', 
                'md': '0.375rem',     
                'lg': '0.5rem',       
                'xl': '0.75rem',      
                '2xl': '1rem',        
                '3xl': '1.5rem',      
                'full': '9999px',
            },
        },
    },
    plugins: [],
}