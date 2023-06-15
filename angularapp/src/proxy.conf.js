const PROXY_CONFIG = [
  {
    context: [
      "/order",
    ],
    target: "https://localhost:7144",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
