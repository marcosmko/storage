using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TwentyTwenty.Storage.OpenStack.Test
{
    [CollectionDefinition("BlobTestBase")]
    public class BaseCollection : ICollectionFixture<StorageFixture>
    {
    }

    [Collection("BlobTestBase")]
    public abstract class BlobTestBase
    {        
        private Random _rand = new Random();
        protected OpenStackStorageProvider _provider;
        protected OpenStackStorageProvider _exceptionProvider;
        protected StorageFixture _fixture;

        public BlobTestBase(StorageFixture fixture)
        {
            _fixture = fixture;
            _provider = new OpenStackStorageProvider(new OpenStackProviderOptions
            {
                ConnectionString = fixture.Config["ConnectionString"],
            });
            _exceptionProvider = new OpenStackStorageProvider(new OpenStackProviderOptions
            {
                ConnectionString = "DefaultEndpointsProtocol=https;AccountName=aaa;AccountKey=bG9sd3V0",
            });
        }

        public byte[] GenerateRandomBlob(int length = 256)
        {
            var buffer = new Byte[length];
            _rand.NextBytes(buffer);
            return buffer;
        }

        public MemoryStream GenerateRandomBlobStream(int length = 256)
        {
            return new MemoryStream(GenerateRandomBlob(length));
        }

        public string GetRandomContainerName()
        {
            return StorageFixture.ContainerPrefix + Guid.NewGuid().ToString("N");
        }

        public string GenerateRandomName()
        {
            return Guid.NewGuid().ToString("N");
        }

        public void TestProviderAuth(Action<OpenStackStorageProvider> method)
        {
            var exception = Assert.Throws<StorageException>(() =>
            {
                method(_exceptionProvider);
            });
            Assert.Equal(exception.ErrorCode, (int)StorageErrorCode.InvalidCredentials);
        }

        public T TestProviderAuth<T>(Func<OpenStackStorageProvider, T> method)
        {
            var exception = Assert.Throws<StorageException>(() =>
            {
                method(_exceptionProvider);
            });
            Assert.Equal(exception.ErrorCode, (int)StorageErrorCode.InvalidCredentials);
            return method(_provider);
        }

        public async Task TestProviderAuthAsync(Func<OpenStackStorageProvider, Task> method)
        {
            var exception = await Assert.ThrowsAsync<StorageException>(() =>
            {
                return method(_exceptionProvider);
            });
            Assert.Equal(exception.ErrorCode, (int)StorageErrorCode.InvalidCredentials);
            await method(_provider);
        }

        protected bool StreamEquals(Stream stream1, Stream stream2)
        {
            if (stream1.CanSeek)
            {
                stream1.Seek(0, SeekOrigin.Begin);
            }
            if (stream2.CanSeek)
            {
                stream2.Seek(0, SeekOrigin.Begin);
            }

            const int bufferSize = 2048;
            byte[] buffer1 = new byte[bufferSize]; //buffer size
            byte[] buffer2 = new byte[bufferSize];
            while (true)
            {
                int count1 = stream1.Read(buffer1, 0, bufferSize);
                int count2 = stream2.Read(buffer2, 0, bufferSize);

                if (count1 != count2)
                    return false;

                if (count1 == 0)
                    return true;

                // You might replace the following with an efficient "memcmp"
                if (!buffer1.Take(count1).SequenceEqual(buffer2.Take(count2)))
                    return false;
            }
        }
    }
}