## React,Nginx,MySQL,.Net development

run<br/>
`docker-compose up `
<br/>
Then you can head on over to

`http://localhost/`

## .Net only development

If you wish to work only with dotnet and mysql only!<br/>

do

`docker-compose -f docker-compose.mysql.yml up --remove-orphans`

Now you can cd into api and do <br/>

`dotnet run `
<br/>
Then you can head on over to

`http://localhost:5000/api/users`
