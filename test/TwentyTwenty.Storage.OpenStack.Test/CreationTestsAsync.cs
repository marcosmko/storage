using System.IO;
using Xunit;
using System.Collections.Generic;

namespace TwentyTwenty.Storage.OpenStack.Test
{
    [Trait("Category", "Azure")]
    public class CreationTestsAsync : BlobTestBase
    {
        public CreationTestsAsync(StorageFixture fixture)
            :base(fixture) { }
        
    }
}