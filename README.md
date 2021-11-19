# AspnetMicroservices

To download a docker
docker pull [dockername]

To run a docker

docker run -d -p [localport]:[dockerport] --name [name_of_the_service] [dockername]

To see the log inside docker
docker logs -f [name_of_the_service]

To access to the docker instance
docker exec -it [name_of_the_service] /bin/bash

-it: interactive

type : Mongo to start mongo command

-> show dbs

-> use [db name] -> to create db
-> show collections -> show all collection in db
-> db.createCollection('[TableName]') -> create collection
-> db.[TableName].insertMany([json]) -> insert to collection
-> db.[TableName].find({}).pretty() -> list all items
-> db.[TableName].remove({})


Docker compose

docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d

-f: file
-d: detachment

stop docker-compose


docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down
