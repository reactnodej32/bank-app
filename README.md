## DOTNET-REACT-NGINX-MYSQL template

If you are attempting to deploy this Please Contact me!
easyrun32@gmail.com!

I'll be glad to help! :)

Technolgies

nginx: Reverse Proxy version => latest </br>
Client: React version => 17.0.1</br>
users: .NetCore version => 5</br>

Endpoints:

- /api/users <- .NET

- localhost/api/users <- .NET

- localhost <- React

## Common deploy issues

Error: Error creating IAM Role terraform-20210613171749996800000001: AccessDenied: User: arn:aws:iam::642815940637:user/terraform is not authorized to perform: iam:CreateRole on resource: arn:aws:iam::642815940637:role/terraform-20210613171749996800000001 with an explicit deny
status code: 403, request id: 4390670f-576b-40fa-a209-7c85ac3c9648

Create a new aws user with admin and billing permission

add this role for safety!
retry

````
{
    "Version": "2012-10-17",
    "Statement": [
        {
            "Effect": "Allow",
            "Action": [
                "iam:CreateRole",
                "iam:DeleteRole",
                "iam:DeleteRolePolicy",
                "iam:ListRolePolicies",
                "iam:ListRoles",
                "iam:PutRolePolicy"
            ],
            "Resource": [
                "*"
            ]
        }
    ]
}```

````

Deploying:

make sure you build the images:

```
docker build \
  -f {FOLDER}/Dockerfile \
  -t {docker_username}/project-name-backend:prod \
  ./{FOLDER}

docker build \
  -f {FOLDER}/Dockerfile \
  -t {docker_username}/project-client:prod \
  --build-arg NODE_ENV=production \
  --build-arg REACT_APP_API_SERVICE_URL=${REACT_APP_API_SERVICE_URL} \
  ./{FOLDER}


```


If anything fails do terraform apply again or terrafrom destroy
