using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GitLab.NET.Tests
{
    public class BuildVariableRepositoryTests
    {
        [Fact]
        public void Create_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, null, "value"));
        }

        [Fact]
        public async Task CreateAsync_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, null, "value"));
        }

        [Fact]
        public void Create_ValueIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, "key", null));
        }

        [Fact]
        public async Task CreateAsync_ValueIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, "key", null));
        }

        [Fact]
        public void Delete_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Delete(0, null));
        }

        [Fact]
        public async Task DeleteAsync_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.DeleteAsync(0, null));
        }

        [Fact]
        public void GetByKey_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.GetByKey(0, null));
        }

        [Fact]
        public async Task GetByKeyAsync_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetByKeyAsync(0, null));
        }

        [Fact]
        public void Update_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Update(0, null, "value"));
        }

        [Fact]
        public async Task UpdateAsync_KeyIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateAsync(0, null, "value"));
        }

        [Fact]
        public void Update_ValueIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Update(0, "key", null));
        }

        [Fact]
        public async Task UpdateAsync_ValueIsNull_ThrowsArgumentNullException()
        {
            var sut = new BuildVariableRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateAsync(0, "key", null));
        }
    }
}
