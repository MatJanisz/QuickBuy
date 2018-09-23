using QuickBuy.BL.Interfaces;
using QuickBuy.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.BL.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public int TestGet()
        {
            return _testRepository.TestGet();
        }
    }
}
