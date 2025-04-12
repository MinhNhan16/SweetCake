/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
      './Components/**/*.{razor,html,cs}',
      './Pages/**/*.{razor,html,cs}',
      './Layout/**/*.{razor,html,cs}',
      './wwwroot/index.html',
      './App.razor'
    ],
    theme: {
      extend: {},
    },
    plugins: [],
  }