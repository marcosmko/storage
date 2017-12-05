using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace TwentyTwenty.Storage.OpenStack.Test
{
    public class StorageFixture : IDisposable
    {
        public const string ContainerPrefix = "storagetest-";
        
        public StorageFixture()
        {
            Config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."))
                .AddEnvironmentVariables()
                .AddUserSecrets()
                .Build();
        }

        public IConfiguration Config { get; private set; }

        public void Dispose()
        {
            
        }
    }
}