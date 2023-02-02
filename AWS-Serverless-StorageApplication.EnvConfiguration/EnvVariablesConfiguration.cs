using AWS_Serverless_StorageApplication.Models;

namespace AWS_Serverless_StorageApplication.EnvConfiguration
{
    public class EnvVariablesConfiguration
    {
        public AWSCredentials AWSCredentials()
        {
            AWSCredentials awsCredentials = new AWSCredentials()
            {
                AccessKey = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY"),
                SecretKey = Environment.GetEnvironmentVariable("AWS_SECRET_KEY")
            };

            return awsCredentials;
        }
    }
}
