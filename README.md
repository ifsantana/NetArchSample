# NetArchSample

Event Driven Sample Archtecture using:

###DDD
###CQRS - With Debezium to Sync Command Data Model Store DB (Sql Server) and Query Data Model Store DB (MongoDb)
###Hexagonal / Ports and Adapters Pattern http://wiki.c2.com/?PortsAndAdaptersArchitecture

## Build Command Store (SQL Server) Container

docker build -t flaubert165/italo-db-demo .

## Run Command Store (SQL Server) Container

docker run -it -e ACCEPT_EULA=Y -e SA_PASSWORD=Your_password123 -e MSSQL_PID=Developer -p 1439:1433 -e MSSQL_AGENT_ENABLED=true -d flaubert165/italo-db-demo

## Run MongoDb, Kafka, Zookeper and Kafka Connect

cd ./docker
docker-compose up -d

# To list kafka connector plugins

HTTP GET (Browser) - http://{host}:8083/connector-plugins

## To configure CDC for dbo.Person

HTTP POST (Using HTTP Client - Postman) - http://{host}:8083/connectors

Request Body:

{
    "name": "sqlserver-person-connector1",
    "config": 
    {
        "connector.class": "io.debezium.connector.sqlserver.SqlServerConnector",
        "database.hostname": "192.168.0.131",
        "database.port": "1439",
        "database.user": "sa",
        "database.password": "Your_password123",
        "database.dbname": "CDC_COMMAND_DB",
        "database.server.name": "dbserver1",
        "table.whitelist": "dbo.Person",
        "database.history.kafka.bootstrap.servers": "192.168.0.131:9092",
        "database.history.kafka.topic": "dbhistory.person"
    }
}

## Connecting with Query/Event Store (MongoDb) with MongoDb Compass

mongodb://root:rootpassword@localhost:27017

## Create Mongo Infra

On MongoDb Compass:

Create Database called: CDC_QUERY_DB

On CDC_QUERY_DB database, we will create a collection called: Person

## Serilog (Seq)

docker pull datalust/seq  
docker run --name seq -d --restart unless-stopped -e ACCEPT_EULA=Y -p 5341:80 datalust/seq:latest  



