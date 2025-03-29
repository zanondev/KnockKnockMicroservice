
# Docker Commands for Microservices

This document provides the necessary commands for building images, starting/stopping containers, and managing Docker images for the microservices.

## 1. Build Images

To build Docker images for the microservices, use the following commands:

```bash
docker build -f Dockerfile.txt -t hellomicroservice .
docker build -f Dockerfile.txt -t knockknockmicroservice .
```

These commands will build the `hellomicroservice` and `knockknockmicroservice` images using the `Dockerfile.txt`.

## 2. Start or Stop Containers

To start or stop the containers using `docker-compose`, use the following commands:

### Start the containers

```bash
docker-compose up --build
```

This command will build the images (if necessary) and start the containers defined in the `docker-compose.yml` file.

### Stop the containers

```bash
docker-compose down
```

This command will stop and remove the running containers.

## 3. Create Containers

To create and run containers directly from the images, use the following commands:

### Create the `hellomicroservice` container

```bash
docker run -d -p 5015:8080 -e ASPNETCORE_ENVIRONMENT=Development --name hellomicroservice-container hellomicroservice
```

### Create the `knockknockmicroservice` container

```bash
docker run -d -p 8081:8080 -e ASPNETCORE_ENVIRONMENT=Development --name knockknockmicroservice-container knockknockmicroservice
```

These commands will create and run the containers with the appropriate environment settings.

## 4. Stop Container

To stop a running container, use the following command:

```bash
docker stop <microservice-name>
```

Replace `<microservice-name>` with the name of the container, such as `hellomicroservice-container` or `knockknockmicroservice-container`.

## 5. Remove Container

To remove a container, use the command:

```bash
docker rm <microservice-name>
```

Replace `<microservice-name>` with the name of the container you want to remove.

## 6. Remove Images

To remove the Docker images, use the following command:

```bash
docker rmi <microservice-name>
```

Replace `<microservice-name>` with the name of the image you want to remove, such as `hellomicroservice` or `knockknockmicroservice`.
