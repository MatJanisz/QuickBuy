using QuickBuy.DA.Interfaces;
using QuickBuy.DA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.DA.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly ApplicationDbContext _context;

        public TestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int TestGet()
        {
            return 4;
        }
    }
}
