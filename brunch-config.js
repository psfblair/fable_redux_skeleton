exports.config = {

  paths: {
    public: 'public',

    watched: [
      'app/assets', 
      'app/styles', 
      'build/dist', 
      'fable-import-react',
      'test', 
      'vendor'
    ]
  },

  files: {
    javascripts: { joinTo: 'app.js' },
    stylesheets: { joinTo: 'app.css' }
  },

  plugins: {
    babel: { presets: ['es2015', 'react'] }
  },
};
