using System.Collections.Generic;
using Xunit;

namespace TwentyTwenty.Storage.OpenStack.Test
{
    [Trait("Category", "Azure")]
    public sealed class UpdateTestsAsync : BlobTestBase
    {
        public UpdateTestsAsync(StorageFixture fixture)
            :base(fixture) { }
        
    }
}