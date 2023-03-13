clear

# curl --verbose --request 'post' 'http://localhost:18001/Login/AddUser' --header 'Content-Type: application/json' --data '{ "username": "Qadmin@company.com", "password": "P@ssw0rd", "rememberMe": true }'

# Login
# curl --verbose --request 'post' 'http://localhost:18001/Login' --header 'Content-Type: application/json' --data '{ "username": "admin@company.com", "password": "P@ssw0rd", "rememberMe": true }'

# curl --request 'get' 'http://localhost:18001/Login/HashPassword' --header 'Content-Type: application/json' --data '{ "username": "admin@company.com", "password": "P@ssw0rd", "rememberMe": true }'

# curl --request 'get' 'http://localhost:18001/Login/VerifyPassword?hashPassword=AQAAAAIAAYagAAAAEOUTIH/hC5Mt1IbBxleSaD/A8pUPj/mlVJJ0dTYAu0I5SaWHMdPxyLFfPBwGpi3gDg==' --header 'Content-Type: application/json' --data '{ "username": "admin@company.com", "password": "P@ssw0rd", "rememberMe": true }'

# curl --request 'get' 'http://localhost:18001/Login/EmailToken' --header 'Content-Type: application/json' --data '{ "username": "admin@company.com", "password": "P@ssw0rd", "rememberMe": true }'

# curl --request 'get' 'http:///localhost:18001/Login/VerifyEmailToken' --header 'Content-Type: application/json' --data '{ "username": "admin@company.com", "password": "P@ssw0rd", "rememberMe": true }'

# curl --request 'get' 'http://localhost:18001/Login/PhoneToken' --header 'Content-Type: application/json' --data '{ "username": "admin@company.com", "password": "P@ssw0rd", "rememberMe": true }'

# curl --request 'get' 'http://localhost:18001/Login/VerifyPhoneToken' --header 'Content-Type: application/json' --data '{ "username": "admin@company.com", "password": "P@ssw0rd", "rememberMe": true }'

# curl --request 'get' 'http://localhost:18001/Login/VerifyTfaToken' --header 'Content-Type: application/json' --data '{ "username": "admin@company.com", "password": "P@ssw0rd", "rememberMe": true }'

curl --request 'get' 'http://localhost:18001/Login/TfaUrlToken' --header 'Content-Type: application/json' --data '{ "username": "admin@company.com", "password": "P@ssw0rd", "rememberMe": true }'

echo ""
