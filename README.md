# Storage Application API With AWS Serverless

## Abstract

I was curious about AWS Technologies like **AWS Serverless**. So I developed simple **AWS Serverless via .NET Core 6**.

## Philosophy

Build File Storage API via AWS Lambda Function.

## Contents

- [Storage Application API With AWS Serverless](#storage-application-api-with-aws-serverless)
  - [Abstract](#abstract)
  - [Philosophy](#philosophy)
  - [Contents](#contents)
  - [Features](#features)
  - [Requirements](#requirements)
- [AWS Lambda Storage Application API Project](#aws-lambda-storage-application-api-project)
  - [Here are some steps to follow from Visual Studio](#here-are-some-steps-to-follow-from-visual-studio)
  - [Here are some steps to follow to get started from the command line](#here-are-some-steps-to-follow-to-get-started-from-the-command-line)
  - [Business Logic](#business-logic)
    - [Controllers](#controllers)
      - [Bucket Controller](#bucket-controller)
      - [Object Controller](#object-controller)
    - [Environment Variables](#environment-variables)
    - [Commands](#commands)
    - [Handlers](#handlers)
    - [Helpers](#helpers)
    - [Middlewares](#middlewares)
    - [Models](#models)
    - [Queries](#queries)
    - [Repositories](#repositories)
  - [Structure](#structure)
  - [Contributing](#contributing)
  - [Bug Reports \& Feature Requests](#bug-reports--feature-requests)
  - [RoadMap](#roadmap)

## Features

- Developed via **.Net Core 6**
- Deploy on AWS Lambda!

## Requirements

> **Note** <br />
> AWS Developer Account <br />

___
<br />

# AWS Lambda Storage Application API Project

This starter project consists of:

- Function.cs - class file containing a class with a single function handler method
- aws-lambda-tools-defaults.json - default argument settings for use with Visual Studio and command line deployment tools for AWS

You may also have a test project depending on the options selected.

The generated function handler is a simple method accepting a string argument that returns the uppercase equivalent of the input string. Replace the body of this method, and parameters, to suit your needs.

## Here are some steps to follow from Visual Studio

To deploy your function to AWS Lambda, right click the project in Solution Explorer and select *Publish to AWS Lambda*.

To view your deployed function open its Function View window by double-clicking the function name shown beneath the AWS Lambda node in the AWS Explorer tree.

To perform testing against your deployed function use the Test Invoke tab in the opened Function View window.

To configure event sources for your deployed function, for example to have your function invoked when an object is created in an Amazon S3 bucket, use the Event Sources tab in the opened Function View window.

To update the runtime configuration of your deployed function use the Configuration tab in the opened Function View window.

To view execution logs of invocations of your function use the Logs tab in the opened Function View window.

## Here are some steps to follow to get started from the command line

Once you have edited your template and code you can deploy your application using the [Amazon.Lambda.Tools Global Tool](https://github.com/aws/aws-extensions-for-dotnet-cli#aws-lambda-amazonlambdatools) from the command line.

Install Amazon.Lambda.Tools Global Tools if not already installed.

```
    dotnet tool install -g Amazon.Lambda.Tools
```

If already installed check if new version is available.

```
    dotnet tool update -g Amazon.Lambda.Tools
```

Execute unit tests

```
    cd "AWS-Serverless-StorageApplication/test/AWS-Serverless-StorageApplication.Tests"
    dotnet test
```

Deploy function to AWS Lambda

```
    cd "AWS-Serverless-StorageApplication/src/AWS-Serverless-StorageApplication"
    dotnet lambda deploy-function
```

___

## Business Logic

- I developed this project using CQRS Design Pattern. I implemented CQRS Design Pattern via MediatR Nuget Package. All project developed using .NET Core 6. I shared some details below about project layers.

### Controllers

#### Bucket Controller

- It uses API Controller for S3 Bucket operations. It uses Dependency Injection to use IMediator interface.
- It sends GetBucketListQuery object to Repository Layer via _mediator object and gets list of S3Bucket type of objects. And returns that list as JSON format.

`GetBucketListAsync` [/api/main/bucket]

**Parameters**
No Body

**Response**

```
{
    "success": true
}

or any implemented error from https://buffer.com/developers/api/errors

{
    "code": 1000,
    "error": "An error message"
}
```

`CreateBucketAsync` [/api/main/bucket/{bucketname}]

**Parameters**

|          Name | Required |  Type   | Description                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `product` | required | string  | The product for which to perform the action. <br/><br/> Supported values: `publish` or `analyze`.                                                                     |
|        `plan` | required | string  | The plan for which to start the trial period. <br/><br/> Supported values for Publish: `pro`, `small`, `business`, `agency`.  <br/>Supported values for Analyze: `early-access-10`, `early-access-25`, `early-access-50`, `early-access-100`. |
| `trialLength` | optional | integer | Length of the trial in days. <br/><br/>Default is `null`. <br/><br/>If value is null, relies on the product hook logic to define the trial length for the given plan and product.                    |
|       `cycle` | optional | string  | Default is `null`. <br/><br/>If value is null, relies on the product hook logic to define the cycle. <br/><br/> Supported values: `null`, `month` or `year`          |
|    `quantity` | optional | integer  | Default is `1`. <br/><br/>This value (either default or passed) will always override the current subscription quantity value.          |
|    `cta` | optional | string  | Can be used for tracking purpose - [Read more](https://github.com/bufferapp/README/tree/master/runbooks/data-tracking)          |

**Response**

```
{
    "success": true
}

or any implemented error from https://buffer.com/developers/api/errors

{
    "code": 1000,
    "error": "An error message"
}
```

#### Object Controller

- Lorem ipsum

### Environment Variables

- Lorem ipsum

### Commands

- Lorem ipsum

### Handlers

- Lorem ipsum

### Helpers

- Lorem ipsum

### Middlewares

- Lorem ipsum

### Models

- Lorem ipsum

### Queries

- Lorem ipsum

### Repositories

- Lorem ipsum

___

## Structure

```bash
|   .gitignore
|   AWS-Serverless-StorageApplication.sln
|   README.md
|           
+---AWS-Serverless-StorageApplication
|   |   appsettings.Development.json
|   |   appsettings.json
|   |   aws-lambda-tools-defaults.json
|   |   AWS-Serverless-StorageApplication.csproj
|   |   Dockerfile
|   |   LambdaEntryPoint.cs
|   |   LocalEntryPoint.cs
|   |   serverless.template
|   |   Startup.cs
|   |                       
|   \---Properties
|           launchSettings.json
|           
+---AWS-Serverless-StorageApplication.Commands
|   |   AWS-Serverless-StorageApplication.Commands.csproj
|   |               
|   +---BucketCommands
|   |       CreateBucketCommand.cs
|   |       DeleteBucketCommand.cs
|   |                   
|   \---ObjectCommands
|           CreateObjectCommand.cs
|           DeleteObjectCommand.cs
|       
+---AWS-Serverless-StorageApplication.Controllers
|   |   AWS-Serverless-StorageApplication.Controllers.csproj
|   |   BucketController.cs
|   |   ObjectController.cs                
|   |   
|   \---Interfaces
|           IS3ObjectStorageContext.cs
|           
+---AWS-Serverless-StorageApplication.EnvConfiguration
|   |   AWS-Serverless-StorageApplication.EnvConfiguration.csproj
|   |   EnvVariablesConfiguration.cs
|                       
+---AWS-Serverless-StorageApplication.Handlers
|   |   AWS-Serverless-StorageApplication.Handlers.csproj
|   |               
|   +---BucketHandlers
|   |       CreateBucketHandler.cs
|   |       DeleteBucketHandler.cs
|   |       GetBucketListHandler.cs
|   |                   
|   \---ObjectHandlers
|           CreateObjectHandler.cs
|           DeleteObjectHandler.cs
|           GetObjectHandler.cs
|           GetObjectListHandler.cs
|           
+---AWS-Serverless-StorageApplication.Helpers
|   |   AWS-Serverless-StorageApplication.Helpers.csproj
|   |   StorageApplicationException.cs
|                       
+---AWS-Serverless-StorageApplication.Middleware
|   |   AWS-Serverless-StorageApplication.Middleware.csproj
|   |   ErrorHandlerMiddleware.cs
|   |   RequestValidationMiddleware.cs
|                       
+---AWS-Serverless-StorageApplication.Models
|   |   AWS-Serverless-StorageApplication.Models.csproj
|   |   AWSCredentials.cs
|   |   BaseResponse.cs
|   |   BucketResponse.cs
|   |   ObjectDetails.cs
|   |   ObjectResponse.cs
|   |   StorageApplicationError.cs   
|
+---AWS-Serverless-StorageApplication.Queries
|   |   AWS-Serverless-StorageApplication.Queries.csproj
|   |               
|   +---BucketQueries
|   |       GetBucketListQuery.cs
|   |                   
|   \---ObjectQueries
|           GetObjectListQuery.cs
|           GetObjectQuery.cs
|           
\---AWS-Serverless-StorageApplication.Repositories
    |   AWS-Serverless-StorageApplication.Repositories.csproj
    |               
    +---Interfaces
    |       IS3ObjectStorageRepository.cs
    |       
    \---Repositories
            S3ObjectStorageRepository.cs           
```

___

## Contributing

I am open every advice for my project. I am planning to improve myself on **.NET Core 6, AWS Lambda Functions**. So don't hesitate comment on my project. Every idea is plus for me.

## Bug Reports & Feature Requests

Please use the Github issues.

## RoadMap

- I am planning to improve myself on AWS Lambda Functions.
