using Amazon;
using Amazon.S3;
using AWS_Serverless_StorageApplication.EnvConfiguration;
using AWS_Serverless_StorageApplication.Models;
using AWS_Serverless_StorageApplication.Repositories.Interfaces;
using AWS_Serverless_StorageApplication.Repositories.Repositories;
using AWS_Serverless_StorageApplication.Middleware;
using MediatR;

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
        //Assembly.GetAssembly(typeof(CreateObjectCommand));
        //Assembly.GetAssembly(typeof(DeleteObjectCommand));
        //Assembly.GetAssembly(typeof(CreateBucketCommand));
        //Assembly.GetAssembly(typeof(DeleteBucketCommand));

        //Assembly.GetAssembly(typeof(GetBucketListQuery));
        //Assembly.GetAssembly(typeof(GetObjectListQuery));
        //Assembly.GetAssembly(typeof(GetObjectQuery));

        //Assembly.GetAssembly(typeof(CreateBucketHandler));
        //Assembly.GetAssembly(typeof(DeleteBucketHandler));
        //Assembly.GetAssembly(typeof(GetBucketListHandler));

        //Assembly.GetAssembly(typeof(CreateObjectHandler));
        //Assembly.GetAssembly(typeof(DeleteObjectHandler));
        //Assembly.GetAssembly(typeof(GetObjectHandler));
        //Assembly.GetAssembly(typeof(GetObjectListHandler));

        var Commands = AppDomain.CurrentDomain.Load("AWS-Serverless-StorageApplication.Commands");
        var Queries = AppDomain.CurrentDomain.Load("AWS-Serverless-StorageApplication.Queries");
        var Handlers = AppDomain.CurrentDomain.Load("AWS-Serverless-StorageApplication.Handlers");
        services.AddMediatR(Commands);
        services.AddMediatR(Handlers);
        services.AddMediatR(Queries);

        services.AddScoped<IS3ObjectStorageRepository, S3ObjectStorageRepository>();

        EnvVariablesConfiguration envVariables = new EnvVariablesConfiguration();
        AWSCredentials awsCredentials = envVariables.AWSCredentials();

        IAmazonS3 client = new AmazonS3Client(awsCredentials.AccessKey, awsCredentials.SecretKey, RegionEndpoint.EUCentral1);
        services.AddSingleton<IAmazonS3>(client);

        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        //app.UseAuthorization();

        //app.UseWhen(context => context.Request.Path.StartsWithSegments("/api/main"), appBuilder =>  // The path must be started with '/'
        //{
        //    appBuilder.UseRequestValidationMiddleware();
        //});

        app.UseErrorHandlerMiddleware();

        app.UseWhen(context => context.Request.HasFormContentType, appBuilder =>  // The path must be started with '/'
        {
            appBuilder.UseRequestValidationMiddleware();
        });

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