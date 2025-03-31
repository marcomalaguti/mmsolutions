namespace MMS.AzureBlobStorage;

using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMS.AzureBlobStorage.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddMMSAzureBlobStorage(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IAzureBlobStorageService>(provider =>
        {
            var blobServiceClient = new BlobServiceClient(configuration.GetConnectionString("saweerpprod"));
            return new AzureBlobStorageService(blobServiceClient);
        });

        return services;
    }
}
