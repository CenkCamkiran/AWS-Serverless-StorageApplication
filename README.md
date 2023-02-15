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

`GET` [/api/main/bucket]

**Parameters**
No Body

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

`PUT` [/api/main/bucket/{bucketname}]

**Parameters**

|          Name | Required |  Type   | Description                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `bucketname` | required | QueryParam String  | bucket name to create bucket <br/><br/>                                                                     |

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

`DELETE` [/api/main/bucket/{bucketname}]

**Parameters**

|          Name | Required |  Type   | Description                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `bucketname` | required | QueryParam String  | bucket name to delete bucket <br/><br/>                                                                     |

**Response**

```
//204 No Content

//Bucket does not exist
{
    "ResponseCode": 500,
    "Message": "The specified bucket does not exist"
}
```

#### Object Controller

- It uses API Controller for S3 Object operations. It uses Dependency Injection to use IMediator interface.

`GET` [/bucket/{bucketname}/object]

**Parameters**

|          Name | Required |  Type   | Description                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `bucketname` | required | QueryParam String  | bucket name should be provided to get objects from defined bucket name <br/><br/>                                                                     |

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

`GET` [/api/main/object/bucket/{bucketname}/object/{objectname}]

**Parameters**

|          Name | Required |  Type   | Description                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `bucketname` | required | QueryParam String  | bucket name should be provided to get object from defined bucket name <br/><br/>                                                                     |
|     `objectname` | required | QueryParam String  | object name to get object from bucket <br/><br/>                                                                     |

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

`PUT` [/api/main/object/bucket/{bucketname}/object]

**Parameters**

|          Name | Required |  Type   | Description                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `bucketname` | required | QueryParam String  | bucket name to upload object into bucket <br/><br/>                                                                     |

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
> Object will be uploaded even the provided bucket does not exist in AWS S3. In this situation if bucket does not exist bucket will be created and after that object will be created in that bucket <br />

`DELETE` [/api/main/object/bucket/{bucketname}/object/{objectname}]

**Parameters**

|          Name | Required |  Type   | Description                                                                                                                                                           |
| -------------:|:--------:|:-------:| --------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|     `bucketname` | required | QueryParam String  | bucket name should be provided to delete object from defined bucket name <br/><br/>                                                                     |
|     `objectname` | required | QueryParam String  | object name to delete object from bucket <br/><br/>                                                                      |

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
> Object will be deleted even the provided object name does not exist in bucket. In this situation response will be 204 No Content <br />

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
