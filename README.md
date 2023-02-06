# Storage Application With AWS Serverless

## Abstract

I was curious about AWS Technologies like **AWS Serverless**. So I developed simple **AWS Serverless via .NET Core 6**.

## Philosophy

Build GUID generator via AWS Lambda Function.

## Contents

- [Storage Application With AWS Serverless](#storage-application-with-aws-serverless)
  - [Abstract](#abstract)
  - [Philosophy](#philosophy)
  - [Contents](#contents)
  - [Features](#features)
  - [Requirements](#requirements)
- [AWS Lambda Guid Generator Function Project](#aws-lambda-guid-generator-function-project)
  - [Structure](#structure)
  - [Here are some steps to follow from Visual Studio](#here-are-some-steps-to-follow-from-visual-studio)
  - [Here are some steps to follow to get started from the command line](#here-are-some-steps-to-follow-to-get-started-from-the-command-line)
  - [Business Logic](#business-logic)
    - [S3 Storage API with .NET 6 Serverless](#s3-storage-api-with-net-6-serverless)
    - [AWS API Gateway](#aws-api-gateway)
  - [Structure](#structure-1)
  - [Contributing](#contributing)
  - [Bug Reports \& Feature Requests](#bug-reports--feature-requests)
  - [RoadMap](#roadmap)

## Features

- Developed via **.Net Core 6**
- Can run on any platform (Mac, Linux and Windows wherever you want!)

## Requirements

> **Note** <br />
> AWS Developer Account <br />

# AWS Lambda Guid Generator Function Project

This starter project consists of:

- Function.cs - class file containing a class with a single function handler method
- aws-lambda-tools-defaults.json - default argument settings for use with Visual Studio and command line deployment tools for AWS

You may also have a test project depending on the options selected.

The generated function handler is a simple method accepting a string argument that returns the uppercase equivalent of the input string. Replace the body of this method, and parameters, to suit your needs.

## Structure

```bash
+---AWSLambdaGuidGenerator
|   |   .gitignore //gitignore file
|   |   aws-lambda-tools-defaults.json //AWS lambda default configs
|   |   AWSLambdaGuidGenerator.csproj //Dotnet project file
|   |   AWSLambdaGuidGenerator.sln //Dotnet solution file
|   |   Function.cs //Main Function File
|   |   README.MD
|   |   
    |                  
|   \---Properties
|           launchSettings.json
|           
\---Models
    |   BaseModel.cs
    |   Models.csproj
    |   RequestModel.cs
    |   ResponseModel.cs  
```

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
    cd "AWSLambdaGuidGenerator/test/AWSLambdaGuidGenerator.Tests"
    dotnet test
```

Deploy function to AWS Lambda

```
    cd "AWSLambdaGuidGenerator/src/AWSLambdaGuidGenerator"
    dotnet lambda deploy-function
```

## Business Logic

### S3 Storage API with .NET 6 Serverless

- Lorem ipsum

### AWS API Gateway

- Lorem ipsum

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

## Contributing

I am open every advice for my project. I am planning to improve myself on **.NET Core 6, AWS Lambda Functions**. So don't hesitate comment on my project. Every idea is plus for me.

## Bug Reports & Feature Requests

Please use the Github issues.

## RoadMap

- I am planning to improve myself on AWS Lambda Functions.
- Event Sourcing Design Pattern will be implemented <https://www.gencayyildiz.com/blog/asp-net-core-event-store-ile-event-sourcing-uygulamasiorneklendirme/>
- I wanna learn API Gateway on AWS.
