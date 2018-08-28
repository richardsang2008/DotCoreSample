
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using DataModels.Entities;
using Moq;
using Xunit;

namespace UnitTests.ApplicationCore.Services.EfRepositoryTests
{
    public class RepositoryWorks
    {
        private readonly IService _repository;

        public RepositoryWorks()
        {
            
        }

        public RepositoryWorks(IService mockedRepository)
        {
            _repository = mockedRepository;
        }

        [Fact]
        public void ReturnTrueGiven1Order()
        {
            //init the moq
            var mockedRepository = new Mock<IService>();
            mockedRepository.Setup(o => o.GetOrderAsync(1)).Returns(Task.FromResult(new Order()));
            Task.Run(async () =>
            {
                
                var result = _repository.GetOrderAsync(1);
                Assert.NotNull(result);
            }).GetAwaiter().GetResult();
            
            
        }
    }
}