# Storage Application With AWS Serverless

## Abstract

I was curious about AWS Technologies like **AWS Serverless**. So I developed simple **AWS Serverless via .NET Core 6**.

## Philosophy

Build GUID generator via AWS Lambda Function.

## Contents

- [Simple Guid Generator With AWS Lambda Function](#simple-guid-generator-with-aws-lambda-function)
  - [Abstract](#abstract)
  - [Philosophy](#philosophy)
  - [Contents](#contents)
  - [Features](#features)
  - [Requirements](#requirements)
- [AWS Lambda Guid Generator Function Project](#aws-lambda-guid-generator-function-project)
  - [Structure](#structure)
  - [Here are some steps to follow from Visual Studio](#here-are-some-steps-to-follow-from-visual-studio)
  - [Here are some steps to follow to get started from the command line](#here-are-some-steps-to-follow-to-get-started-from-the-command-line)
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

## Contributing

I am open every advice for my project. I am planning to improve myself on **.NET Core 6, AWS Lambda Functions**. So don't hesitate comment on my project. Every idea is plus for me.

## Bug Reports & Feature Requests

Please use the Github issues.

## RoadMap

- I am planning to improve myself on AWS Lambda Functions.