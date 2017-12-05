using System.IO;
using Xunit;

namespace TwentyTwenty.Storage.OpenStack.Test
{
    [Trait("Category", "Azure")]
    public sealed class GetTestsAsync : BlobTestBase
    {
        public GetTestsAsync(StorageFixture fixture)
            : base(fixture)
        { }

    }
}