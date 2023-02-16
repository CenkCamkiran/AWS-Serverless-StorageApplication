# Storage Application API With AWS Serverless

## Abstract

I was curious about AWS Technologies like **AWS Serverless**. So I developed simple **AWS Storage Application API via .NET Core 6**.

## Philosophy

Build File Storage API via AWS Serverless technology.

## Contents

- [Storage Application API With AWS Serverless](#storage-application-api-with-aws-serverless)
  - [Abstract](#abstract)
  - [Philosophy](#philosophy)
  - [Contents](#contents)
  - [Features](#features)
  - [Requirements](#requirements)
- [.NET Core Web API Serverless Application](#net-core-web-api-serverless-application)
    - [Configuring for API Gateway HTTP API](#configuring-for-api-gateway-http-api)
    - [Configuring for Application Load Balancer](#configuring-for-application-load-balancer)
    - [Project Files](#project-files)
  - [Here are some steps to follow from Visual Studio](#here-are-some-steps-to-follow-from-visual-studio)
  - [Here are some steps to follow to get started from the command line](#here-are-some-steps-to-follow-to-get-started-from-the-command-line)
  - [Business Logic](#business-logic)
- [Controllers (API Endpoints)](#controllers-api-endpoints)
  - [`GET` /api/main/bucket](#get-apimainbucket)
  - [`PUT` /api/main/bucket/{bucketname}](#put-apimainbucketbucketname)
  - [`DELETE` /api/main/bucket/{bucketname}](#delete-apimainbucketbucketname)
  - [`GET` /bucket/{bucketname}/object](#get-bucketbucketnameobject)
  - [`GET` /api/main/object/bucket/{bucketname}/object/{objectname}](#get-apimainobjectbucketbucketnameobjectobjectname)
  - [`PUT` /api/main/object/bucket/{bucketname}/object](#put-apimainobjectbucketbucketnameobject)
  - [`DELETE` /api/main/object/bucket/{bucketname}/object/{objectname}](#delete-apimainobjectbucketbucketnameobjectobjectname)
- [Business Logic](#business-logic-1)
  - [Environment Variables](#environment-variables)
  - [Commands](#commands)
    - [Bucket Commands](#bucket-commands)
    - [Object Commands](#object-commands)
  - [Handlers](#handlers)
    - [Bucket Handlers](#bucket-handlers)
    - [Object Handlers](#object-handlers)
  - [Helpers](#helpers)
  - [Middlewares](#middlewares)
    - [Error Handler Middleware](#error-handler-middleware)
    - [Request Validation Middleware](#request-validation-middleware)
  - [Models](#models)
  - [Queries](#queries)
    - [Bucket Queries](#bucket-queries)
    - [Object Queries](#object-queries)
  - [Repositories](#repositories)
- [Structure](#structure)
- [Contributing](#contributing)
- [Bug Reports \& Feature Requests](#bug-reports--feature-requests)
- [RoadMap](#roadmap)

## Features

- Developed via **.Net Core 6**

## Requirements

> **Note** <br />
> AWS Developer Account <br />

___

# .NET Core Web API Serverless Application

This project shows how to run an ASP.NET Core Web API project as an AWS Lambda exposed through Amazon API Gateway. The NuGet package [Amazon.Lambda.AspNetCoreServer](https://www.nuget.org/packages/Amazon.Lambda.AspNetCoreServer) contains a Lambda function that is used to translate requests from API Gateway into the ASP.NET Core framework and then the responses from ASP.NET Core back to API Gateway.

For more information about how the Amazon.Lambda.AspNetCoreServer package works and how to extend its behavior view its [README](https://github.com/aws/aws-lambda-dotnet/blob/master/Libraries/src/Amazon.Lambda.AspNetCoreServer/README.md) file in GitHub.

### Configuring for API Gateway HTTP API ###

API Gateway supports the original REST API and the new HTTP API. In addition HTTP API supports 2 different
payload formats. When using the 2.0 format the base class of `LambdaEntryPoint` must be `Amazon.Lambda.AspNetCoreServer.APIGatewayHttpApiV2ProxyFunction`.
For the 1.0 payload format the base class is the same as REST API which is `Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction`.
**Note:** when using the `AWS::Serverless::Function` CloudFormation resource with an event type of `HttpApi` the default payload
format is 2.0 so the base class of `LambdaEntryPoint` must be `Amazon.Lambda.AspNetCoreServer.APIGatewayHttpApiV2ProxyFunction`.

### Configuring for Application Load Balancer ###

To configure this project to handle requests from an Application Load Balancer instead of API Gateway change
the base class of `LambdaEntryPoint` from `Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction` to
`Amazon.Lambda.AspNetCoreServer.ApplicationLoadBalancerFunction`.

### Project Files ###

- serverless.template - an AWS CloudFormation Serverless Application Model template file for declaring your Serverless functions and other AWS resources
- aws-lambda-tools-defaults.json - default argument settings for use with Visual Studio and command line deployment tools for AWS
- LambdaEntryPoint.cs - class that derives from **Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction**. The code in
this file bootstraps the ASP.NET Core hosting framework. The Lambda function is defined in the base class.
Change the base class to **Amazon.Lambda.AspNetCoreServer.ApplicationLoadBalancerFunction** when using an
Application Load Balancer.
- LocalEntryPoint.cs - for local development this contains the executable Main function which bootstraps the ASP.NET Core hosting framework with Kestrel, as for typical ASP.NET Core applications.
- Startup.cs - usual ASP.NET Core Startup class used to configure the services ASP.NET Core will use.
- web.config - used for local development.

You may also have a test project depending on the options selected.

## Here are some steps to follow from Visual Studio

To deploy your Serverless application, right click the project in Solution Explorer and select *Publish to AWS Lambda*.

To view your deployed application open the Stack View window by double-clicking the stack name shown beneath the AWS CloudFormation node in the AWS Explorer tree. The Stack View also displays the root URL to your published application.

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

Deploy application

```
    cd "AWS-Serverless-StorageApplication/src/AWS-Serverless-StorageApplication"
    dotnet lambda deploy-serverless # or what you want a name
```

___

## Business Logic

- I developed this project using CQRS Design Pattern. I implemented CQRS Design Pattern via MediatR Nuget Package. All project developed using .NET Core 6. I shared some details below about project layers.

# Controllers (API Endpoints)

## `GET` /api/main/bucket

**Parameters**

|          Name | Required |  Type   | Description                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     n/a | n/a | n/a | <br/> n/a <br/><br/>                                                                     |

**Response**

```
//It has no bucket
[]

//It has one bucket
[
    {
        "creationDate": "2023-02-04T17:39:54+03:00",
        "bucketName": "cenktests3"
    }
]

//It has two bucket
[
    {
        "creationDate": "2023-02-04T17:39:54+03:00",
        "bucketName": "cenktests3"
    },
    {
        "creationDate": "2023-02-04T19:01:08+03:00",
        "bucketName": "cf-templates-bjkbm48mjq7o-eu-central-1"
    }
]

```

## `PUT` /api/main/bucket/{bucketname}

**Parameters**

|          Name | Required |  Type   | Description                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `bucketname` | required | QueryParam String  | <br/> bucket name to create bucket <br/><br/>                                                                     |

**Response**

```
//Bucket creation successfull
{
    "bucketName": "cengo123",
    "responseCode": 200,
    "responseDescription": "Bucket created successfully!"
}

//Bucket already created
{
    "ResponseCode": 500,
    "Message": "Your previous request to create the named bucket succeeded and you already own it."
}
```

## `DELETE` /api/main/bucket/{bucketname}

**Parameters**

|          Name | Required |  Type   | Description                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `bucketname` | required | QueryParam String  | <br/> bucket name to delete bucket <br/><br/>                                                                     |

**Response**

```
//204 No Content

//Bucket does not exist
{
    "ResponseCode": 500,
    "Message": "The specified bucket does not exist"
}
```

## `GET` /bucket/{bucketname}/object

**Parameters**

|          Name | Required |  Type   | Description                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `bucketname` | required | QueryParam String  | <br/> bucket name should be provided to get objects from defined bucket name <br/><br/>                                                                     |

**Response**

```
//No objects in bucket
[]

//One object in bucket
[
    {
        "checksumAlgorithm": [],
        "eTag": "\"4b5a6ee97a163c2628a2a00dbd27a522\"",
        "bucketName": "cengo123",
        "key": "ProfilePicture.png",
        "lastModified": "2023-02-15T22:56:05+03:00",
        "owner": null,
        "size": 16384,
        "storageClass": {
            "value": "STANDARD"
        }
    }
]

//Two or more objects in bucket
[
    {
        "checksumAlgorithm": [],
        "eTag": "\"4b5a6ee97a163c2628a2a00dbd27a522\"",
        "bucketName": "cengo123",
        "key": "ProfilePicture.png",
        "lastModified": "2023-02-15T22:56:05+03:00",
        "owner": null,
        "size": 16384,
        "storageClass": {
            "value": "STANDARD"
        }
    },
    {
        "checksumAlgorithm": [],
        "eTag": "\"6fd4c280a3f74db14edcb946e25ac395\"",
        "bucketName": "cengo123",
        "key": "Screenshot_1.png",
        "lastModified": "2023-02-15T22:57:08+03:00",
        "owner": null,
        "size": 28274,
        "storageClass": {
            "value": "STANDARD"
        }
    }
]
```

## `GET` /api/main/object/bucket/{bucketname}/object/{objectname}

**Parameters**

|          Name | Required |  Type   | Description                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `bucketname` | required | QueryParam String  | <br/> bucket name should be provided to get object from defined bucket name <br/><br/>                                                                     |
|     `objectname` | required | QueryParam String  | <br/> object name to get object from bucket <br/><br/>                                                                     |

**Response**

```
//Object will be downloaded into client
Response: Object as File

//Object or bucket does not exist in bucket
{
    "ResponseCode": 500,
    "Message": "The specified key does not exist."
}
```

## `PUT` /api/main/object/bucket/{bucketname}/object

**Parameters**

|          Name | Required |  Type   | Description                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `bucketname` | required | QueryParam String  | <br/> bucket name to upload object into bucket <br/><br/>                                                                     |

`Content-Type`: `multipart/form-data`
`Body`:

```
Key: file
Value: File location in client to upload file as object into bucket
```

**Response**

```
//Error occurs when file key does not exist in body
{
    "ResponseCode": 400,
    "Message": "Request should contain file data!"
}

//Error occurs when file size exceeds limit. Limit is 30000000 bytes (30 MB)
{
    "ResponseCode": 500,
    "Message": "Request body too large. The max request body size is 30000000 bytes."
}

//Object uploaded successfully into bucket
{
    "objectName": "3759866e-698d-4472-85bf-07ce1ea60d69.txt",
    "bucketName": "cenktests3",
    "responseCode": 200,
    "responseDescription": "Object created successfully!"
}
```

> **Note** <br />
> :exclamation: :exclamation: :exclamation:Object will be uploaded even the provided bucket does not exist in AWS S3. In this situation if bucket does not exist bucket will be created and after that object will be created in that bucket.  :exclamation: :exclamation: :exclamation: <br />

## `DELETE` /api/main/object/bucket/{bucketname}/object/{objectname}

**Parameters**

|          Name | Required |  Type   | Description                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `bucketname` | required | QueryParam String  | <br/> bucket name should be provided to delete object from defined bucket name <br/><br/>                                                                     |
|     `objectname` | required | QueryParam String  | <br/> object name to delete object from bucket <br/><br/>                                                                      |

**Response**

```
//Error occurs when object (file) key does not exist in bucket
{
    "ResponseCode": 500,
    "Message": "The bucket you are attempting to access must be addressed using the specified endpoint. Please send all future requests to this endpoint."
}

//Object (file) deleted successfully
//Response: 204 No Content
```

> **Note** <br />
> :exclamation: :exclamation: :exclamation:Object will be deleted even the provided object name does not exist in bucket. In this situation response will be 204 No Content. :exclamation: :exclamation: :exclamation: <br />

# Business Logic

## Environment Variables

- AWS Access Key and AWS Secret Key must be provided as Environment Variables to use API properly. This layer gets Environment Variables and injects them into AWS S3 Connection.

___

## Commands

- Write-Delete Commands written in this layer. Here are some details about Commands below.

### Bucket Commands

- Command: `CreateBucketCommand` => Base: `IRequest<BucketResponse>`
- Command: `DeleteBucketCommand` => Base: `IRequest<BucketResponse>`

### Object Commands

- Command: `CreateObjectCommand` => Base: `IRequest<ObjectResponse>`
- Command: `DeleteObjectCommand` => Base: `IRequest<int>`

___

## Handlers

- Query and Command Handlers written in this layer. Here are some details about Handlers below.

### Bucket Handlers

- This handlers have three tasks. Create, Delete and GetBucketList in AWS S3.

- Handler: `CreateBucketHandler` => Base: `IRequestHandler<CreateBucketCommand, BucketResponse>`
- Handler: `DeleteBucketHandler` => Base: `IRequestHandler<DeleteBucketCommand, BucketResponse>`
- Handler: `GetBucketListHandler` => Base: `IRequestHandler<GetBucketListQuery, List<S3Bucket>>`

### Object Handlers

- This handlers have three tasks. Create, Delete, GetObject and GetObjectList in AWS S3.

- Handler: `CreateObjectHandler` => Base: `IRequestHandler<CreateObjectCommand, ObjectResponse>`
- Handler: `DeleteObjectHandler` => Base: `IRequestHandler<DeleteObjectCommand, int>`
- Handler: `GetObjectHandler` => Base: `IRequestHandler<GetObjectQuery, GetObjectResponse>`
- Handler: `GetObjectListHandler` => Base: `IRequestHandler<GetObjectListQuery, List<S3Object>>`

___

## Helpers

- Exception classes written in this layer. **StorageApplicationException** exception class is used for throwing exception when errors occurred.

## Middlewares

- Middlewares written in this layer. Here are some details about Middlewares below.

### Error Handler Middleware

- It is responsible for handling exceptions.
- It catches exceptions and builds Response Body and Response Status code according to exception.

### Request Validation Middleware

- It is responsible for checking fields on Form-Data field. It basically checks incoming to **CreateObjectAsync** action on **ObjectController**. It has four steps:
  1. It checks Request Content Type. If Content Type does not have Form-Data it throws exception.
  2. It checks any file injected in Form Data. If Form Data does not have file it throws exception.
  3. It checks file size. If file size is zero or less bytes it throws exception.
  4. It checks file size limit. If file size exceeds limit it throws exception.

___

## Models

- Response and Request models defined in this layer.

___

## Queries

- Queries written in this layer. Here are some details about Queries below.

### Bucket Queries

Handler: `GetBucketListQuery` => Base: `IRequest<List<S3Bucket>>`

### Object Queries

Handler: `GetObjectListQuery` => Base: `IRequest<List<S3Object>>`
Handler: `GetObjectQuery` => Base: `IRequest<GetObjectResponse>`

___

## Repositories

- It handles S3 Object Storage methods in this layer. It has Repository class and interface.

# Structure

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

# Contributing

I am open every advice for my project. I am planning to improve myself on **.NET Core 6, AWS Lambda Functions**. So don't hesitate comment on my project. Every idea is plus for me.

# Bug Reports & Feature Requests

Please use the Github issues.

# RoadMap

- I am planning to improve myself on AWS Lambda Functions.
