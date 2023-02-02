using Amazon;
using Amazon.S3;
using AWS_Serverless_StorageApplication.EnvConfiguration;
using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using AWS_Serverless_StorageApplication.Repositories.Repositories;
using MediatR;
using System.Reflection;

namespace AWS_Serverless_StorageApplication;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped<IS3ObjectStorageRepository, S3ObjectStorageRepository>();

        EnvVariablesConfiguration envVariables = new EnvVariablesConfiguration();
        AWSCredentials awsCredentials = envVariables.AWSCredentials();

        IAmazonS3 client = new AmazonS3Client(awsCredentials.AccessKey, awsCredentials.SecretKey, RegionEndpoint.EUCentral1);
        services.AddSingleton<IAmazonS3>(client);

        services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        //app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}