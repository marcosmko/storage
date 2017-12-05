using System.IO;
using Xunit;

namespace TwentyTwenty.Storage.OpenStack.Test
{
    [Trait("Category", "Azure")]
    public class ExceptionTestsAsync : BlobTestBase
    {
        public ExceptionTestsAsync(StorageFixture fixture)
            : base(fixture)
        { }

    }
}