## Development

If you wish to work only with dotnet only and mysql!<br/>
In the docker-compose.yml file comment out

```# # Nginx container
  # reverseproxy:
  #   build:
  #     context: ./nginx
  #     dockerfile: Dockerfile
  #   ports:
  #     - "80:80"
  #     - "443:443"

  #   depends_on:
  #     - client
  #   restart: always

  #   # React container
  # client:
  #   stdin_open: true
  #   container_name: client
  #   build:
  #     context: "./client"
  #     dockerfile: Dockerfile
  #   volumes:
  #     - "./client:/usr/src/app"
  #     - "/usr/src/app/node_modules"
  #   environment:
  #     - NODE_ENV=production
  #   links:
  #     - api
  #   ports:
  #     - 3000:3000

  # # .NET CONTAINER
  # api:
  #   container_name: api
  #   ports:
  #     - 5000:5000
  #   build:
  #     context: ./api
  #     dockerfile: Dockerfile.prod
  #   environment:
  #     DATABASE_HOST: database
  #     MYSQL_ROOT_PASSWORD: dbuserpassword
  #     MYSQL_USER: dbuser
  #     # for development http://
  #     # for production  http://+:5000
  #     ASPNETCORE_URLS: "http://+;http://+:5000"
  #   restart: always
```

<br/>

then do `docker-compose up --remove-orphans` to turn on the MySql database

By commenting out the other container you will only work with the database instead<br/>

Now you can cd into api and do <br/>

`dotnet run `
<br/>
Then you can head on over to

`http://localhost:5000/api/users`
