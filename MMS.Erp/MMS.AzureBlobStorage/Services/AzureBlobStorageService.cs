namespace MMS.AzureBlobStorage.Services;

using Azure.Storage.Blobs;
using System.Threading.Tasks;

public class AzureBlobStorageService(BlobServiceClient blobServiceClient)
    : IAzureBlobStorageService
{
    public async Task<string> UploadAsync(byte[] bytes,
                                          string fileName,
                                          string containerName)
    {
        return await UploadAsync(new MemoryStream(bytes), fileName, containerName);
    }

    public async Task<string> UploadAsync(Stream fileStream,
                                          string fileName,
                                          string containerName)
    {
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(fileName);

        await blobClient.UploadAsync(fileStream, overwrite: true);
        return blobClient.Uri.ToString();
    }

    public async Task<Stream> DownloadAsync(string fileName, string containerName)
    {
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(fileName);

        var response = await blobClient.DownloadAsync();
        return response.Value.Content;
    }

    public async Task DeleteAsync(string fileName, string containerName)
    {
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(fileName);

        await blobClient.DeleteIfExistsAsync();
    }
}
