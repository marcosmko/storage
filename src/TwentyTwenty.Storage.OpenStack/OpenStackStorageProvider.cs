using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TwentyTwenty.Storage.OpenStack
{
    public sealed class OpenStackStorageProvider : IStorageProvider
    {
        
        public OpenStackStorageProvider(OpenStackProviderOptions options)
        {
            
        }

        public Task DeleteBlobAsync(string containerName, string blobName)
        {
            throw new NotImplementedException();
        }

        public Task DeleteContainerAsync(string containerName)
        {
            throw new NotImplementedException();
        }

        public Task CopyBlobAsync(string sourceContainerName, string sourceBlobName, string destinationContainerName,
            string destinationBlobName = null)
        {
            throw new NotImplementedException();
        }

        public Task MoveBlobAsync(string sourceContainerName, string sourceBlobName, string destinationContainerName,
            string destinationBlobName = null)
        {
            throw new NotImplementedException();
        }

        public Task<BlobDescriptor> GetBlobDescriptorAsync(string containerName, string blobName)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetBlobStreamAsync(string containerName, string blobName)
        {
            throw new NotImplementedException();
        }

        public string GetBlobUrl(string containerName, string blobName)
        {
            throw new NotImplementedException();
        }

        public string GetBlobSasUrl(string containerName, string blobName, DateTimeOffset expiry, bool isDownload = false, 
            string filename = null, string contentType = null, BlobUrlAccess access = BlobUrlAccess.Read)
        {
            throw new NotImplementedException();
        }

        public Task<IList<BlobDescriptor>> ListBlobsAsync(string containerName)
        {
            throw new NotImplementedException();
        }

        public Task SaveBlobStreamAsync(string containerName, string blobName, Stream source, BlobProperties properties = null, bool closeStream = true)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBlobPropertiesAsync(string containerName, string blobName, BlobProperties properties)
        {
            throw new NotImplementedException();
        }
    }
}