namespace MMS.AzureBlobStorage.Services;
using System.Threading.Tasks;

public interface IAzureBlobStorageService
{
    Task<string> UploadAsync(Stream fileStream, string fileName , string containerName);
    Task<string> UploadAsync(byte[] bytes,
                             string fileName,
                             string containerName);
    Task<Stream> DownloadAsync(string fileName, string containerName);
    Task DeleteAsync(string fileName, string containerName);
}
