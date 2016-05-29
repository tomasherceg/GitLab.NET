﻿using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.Repositories;
using NSubstitute;
using Xunit;

namespace GitLab.NET.Tests.Repositories
{
    public class SystemHookRepositoryTests
    {
        [Fact]
        public void Create_UrlIsNull_ThrowsArgumentNullException()
        {
            var sut = new SystemHookRepository(Substitute.For<IRequestExecutor>());

            Assert.Throws<ArgumentNullException>(() => sut.Create(null));
        }

        [Fact]
        public async Task CreateAsync_UrlIsNull_ThrowsArgumentNullException()
        {
            var sut = new SystemHookRepository(Substitute.For<IRequestExecutor>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.CreateAsync(null));
        }
    }
}