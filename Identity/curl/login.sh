clear

# Login
# curl --verbose --request 'post' 'http://localhost:18001/Login' --header 'Content-Type: application/json' --data '{ "username": "admin@company.com", "password": "P@ssw0rd", "rememberMe": true }'

# curl --request 'get' 'http://localhost:18001/Login/HashPassword' --header 'Content-Type: application/json' --data '{ "username": "admin@company.com", "password": "P@ssw0rd", "rememberMe": true }'

# curl --request 'get' 'http://localhost:18001/Login/VerifyPassword?hashPassword=AQAAAAIAAYagAAAAEOUTIH/hC5Mt1IbBxleSaD/A8pUPj/mlVJJ0dTYAu0I5SaWHMdPxyLFfPBwGpi3gDg==' --header 'Content-Type: application/json' --data '{ "username": "admin@company.com", "password": "P@ssw0rd", "rememberMe": true }'
curl --request 'get' 'http://localhost:18001/Login/EmailToken' --header 'Content-Type: application/json' --data '{ "username": "admin@company.com", "password": "P@ssw0rd", "rememberMe": true }'
echo ""
curl --request 'get' 'http://localhost:18001/Login/VerifyEmailToken' --header 'Content-Type: application/json' --data '{ "username": "admin@company.com", "password": "P@ssw0rd", "rememberMe": true }'
echo ""

curl --request 'get' 'http://localhost:18001/Login/TotpToken' --header 'Content-Type: application/json' --data '{ "username": "admin@company.com", "password": "P@ssw0rd", "rememberMe": true }'
echo ""

# AQAAAAIAAYagAAAAEOUTIH/hC5Mt1IbBxleSaD/A8pUPj/mlVJJ0dTYAu0I5SaWHMdPxyLFfPBwGpi3gDg==
