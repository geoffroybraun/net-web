using Moq;

namespace GB.NetWeb.Application.Services.UnitTests.DataFixtures
{
    /// <summary>
    /// Represents a dummy <see cref="TRepository"/> implementation
    /// </summary>
    /// <typeparam name="TRepository">The repository interface to mock</typeparam>
    public abstract class BaseDataFixture<TRepository> where TRepository : class
    {
        #region Fields

        private readonly Mock<TRepository> DummyMock;

        #endregion

        #region Properties

        public TRepository Dummy => DummyMock.Object;

        #endregion

        protected BaseDataFixture() => DummyMock = InitializeDummyMock(new Mock<TRepository>());

        /// <summary>
        /// Delegate the method implementation to the deriving class
        /// </summary>
        /// <param name="mock">The <see cref="Mock{T}"/> implementation to set up</param>
        /// <returns>THe initialized <see cref="Mock{T}"/> implementation</returns>
        protected abstract Mock<TRepository> InitializeDummyMock(Mock<TRepository> mock);
    }
}
