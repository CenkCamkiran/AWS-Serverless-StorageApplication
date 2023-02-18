using AWS_Serverless_StorageApplication.Models;
using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using AWS_Serverless_StorageApplication.Helpers;
using System.Net;

namespace AWS_Serverless_StorageApplication.EnvConfiguration
{
    public static class EnvVariablesConfiguration
    {
        public static AWSCredentials AWSCredentials()
        {
            string secretName = "prodSecrets"; //secret name in AWS
            string region = "eu-central-1";

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT", // VersionStage defaults to AWSCURRENT if unspecified.
            };

            GetSecretValueResponse getSecretValueResponse;

            try
            {
                var asyncResult = client.GetSecretValueAsync(request);
                getSecretValueResponse = asyncResult.GetAwaiter().GetResult();
            }
            catch (Exception exception)
            {
                // For a list of the exceptions thrown, see
                // https://docs.aws.amazon.com/secretsmanager/latest/apireference/API_GetSecretValue.html

                StorageApplicationError error = new StorageApplicationError();
                error.Message = exception.Message.ToString();
                error.ResponseCode = (int)HttpStatusCode.InternalServerError;

                throw new StorageApplicationException(JsonConvert.SerializeObject(error));
            }

            string secret = getSecretValueResponse.SecretString;
            AWSCredentials credentialsModel = JsonConvert.DeserializeObject<AWSCredentials>(secret);

            return credentialsModel;
        }
    }
}
