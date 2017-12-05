using Xunit;

namespace TwentyTwenty.Storage.OpenStack.Test
{
    [Trait("Category", "Azure")]
    public sealed class DeletionTestsAsync : BlobTestBase
    {
        public DeletionTestsAsync(StorageFixture fixture)
            :base(fixture) { }
        
    }
}