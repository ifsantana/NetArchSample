# NetArchSample

## Build DB Container

docker build -t flaubert165/italo-db-demo .

## Run DB Container

docker run -it -e ACCEPT_EULA=Y -e SA_PASSWORD=Your_password123 -e MSSQL_PID=Developer -p 1433:1433 -e MSSQL_AGENT_ENABLED=true -d flaubert165/italo-db-demo

## Run Kafka, Zookeper and Kafka Connect

cd ./docker
docker-compose up -d
