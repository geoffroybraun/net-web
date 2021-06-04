using Moq;

namespace GB.NetWeb.Application.Services.IntegrationTests.DataFixtures
{
    /// <summary>
    /// Represents an abstract dummy <see cref="TRepository"/> implementation
    /// </summary>
    /// <typeparam name="TRepository">The repository interface to mock</typeparam>
    public abstract class BaseDataFixture<TRepository> where TRepository : class
    {
        #region Fields

        private readonly Mock<TRepository> BrokenMock;
        private readonly Mock<TRepository> NullMock;

        #endregion

        #region Properties

        public TRepository Broken => BrokenMock.Object;

        public TRepository Null => NullMock.Object;

        #endregion

        protected BaseDataFixture()
        {
            BrokenMock = InitializeBrokenMock(new Mock<TRepository>());
            NullMock = InitializeNullMock(new Mock<TRepository>());
        }

        /// <summary>
        /// Delegate the method implementation to the deriving class
        /// </summary>
        /// <param name="mock">The <see cref="Mock{T}"/> implementation to set up</param>
        /// <returns>The initialized <see cref="Mock{T}"/> implementation</returns>
        protected abstract Mock<TRepository> InitializeBrokenMock(Mock<TRepository> mock);

        /// <summary>
        /// Delegate the method implementation to the deriving class
        /// </summary>
        /// <param name="mock">The <see cref="Mock{T}"/> implementation to set up</param>
        /// <returns>The initialized <see cref="Mock{T}"/> implementation</returns>
        protected abstract Mock<TRepository> InitializeNullMock(Mock<TRepository> mock);
    }
}
