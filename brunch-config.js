exports.config = {

  paths: {
    public: 'public',

    watched: [
      'app/assets', 
      'app/styles', 
      'build/dist', 
      'test', 
      'vendor'
    ]
  },
  modules: {
    nameCleaner: (path) => path.replace('fable-import-react', 'build/dist/node_modules/fable-import-react')
  },
  files: {
    javascripts: { joinTo: 'app.js' },
    stylesheets: { joinTo: 'app.css' }
  },

  plugins: {
    babel: { presets: ['es2015', 'react'] }
  },
};
