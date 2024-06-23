const { createProxyMiddleware } = require('http-proxy-middleware');

module.exports = function(app) {
  // Proxy for API server 1
  app.use(
    '/api',
    createProxyMiddleware({
      target: 'http://34.76.247.162', // API server URL 1
      changeOrigin: true,
    })
  );

  // Proxy for API server 2 (e.g., for creating tweets)
  app.use(
    '/tweets',
    createProxyMiddleware({
      target: 'http://35.233.9.34', // API server URL 2
      changeOrigin: true,
    })
  );
};
