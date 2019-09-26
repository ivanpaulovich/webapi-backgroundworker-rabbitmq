# .NET Core 3.0 WebApi, BackgroundWorker and RabbitMQ

Sample implementation of a WebApi that publishes messages to RabbitMQ and consume them using a BackgroundWorker.

> This is a working in progress. PR are welcome!

## Install

```
$ git clone https://github.com/ivanpaulovich/webapi-backgroundworker-rabbitmq.git
```

## Setup

```
$ ./src/scripts/setup-rabbitmq.sh
$ dotnet run
$ curl https://localhost:5001/Orders
```

### Development Environment

* MacOS Mojave :apple:
* Visual Studio Code :heart:
* [.NET Core SDK 3.0](https://dotnet.microsoft.com/download/dotnet-core/3.0)
* Docker :whale:
* RabbitMQ

### Support and Issues

Please `star` it then open an issue.
