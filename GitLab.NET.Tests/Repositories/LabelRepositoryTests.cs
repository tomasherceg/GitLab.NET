using NSubstitute;
using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class LabelRepositoryTests
    {
        [Fact]
        public void Create_NameIsNull_ThrowsArgumentNullException()
        {
            var sut = new LabelRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, null, "color"));
        }

        [Fact]
        public async Task CreateAsync_NameIsNull_ThrowsArgumentNullException()
        {
            var sut = new LabelRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, null, "color"));
        }

        [Fact]
        public void Create_ColorIsNull_ThrowsArgumentNullException()
        {
            var sut = new LabelRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create(0, "name", null));
        }

        [Fact]
        public async Task CreateAsync_ColorIsNull_ThrowsArgumentNullException()
        {
            var sut = new LabelRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(0, "name", null));
        }

        [Fact]
        public void Delete_NameIsNull_ThrowsArgumentNullException()
        {
            var sut = new LabelRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Delete(0, null));
        }

        [Fact]
        public async Task DeleteAsync_NameIsNull_ThrowsArgumentNullException()
        {
            var sut = new LabelRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.DeleteAsync(0, null));
        }

        [Fact]
        public void Subscribe_NameIsNull_ThrowsArgumentNullException()
        {
            var sut = new LabelRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Subscribe(0, null));
        }

        [Fact]
        public async Task SubscribeAsync_NameIsNull_ThrowsArgumentNullException()
        {
            var sut = new LabelRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.SubscribeAsync(0, null));
        }

        [Fact]
        public void Unsubscribe_NameIsNull_ThrowsArgumentNullException()
        {
            var sut = new LabelRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Unsubscribe(0, null));
        }

        [Fact]
        public async Task UnsubscribeAsync_NameIsNull_ThrowsArgumentNullException()
        {
            var sut = new LabelRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UnsubscribeAsync(0, null));
        }

        [Fact]
        public void Update_NameIsNull_ThrowsArgumentNullException()
        {
            var sut = new LabelRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Update(0, null));
        }

        [Fact]
        public async Task UpdateAsync_NameIsNull_ThrowsArgumentNullException()
        {
            var sut = new LabelRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.UpdateAsync(0, null));
        }
    }
}
