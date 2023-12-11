using Microsoft.AspNetCore.Mvc;
using P02_Dependency.Models;

namespace P02_Dependency.Controllers
{
    public class TestDependencyController1 : Controller
    {
        private readonly ITest test;
        private readonly ITest test1;

        public TestDependencyController1(ITest test, ITest test1)
        {
            this.test = test;
            this.test1 = test1;
        }
        public IActionResult Index()
        {
            return View(test.GenrateData());
        }

        public IActionResult Index1()
        {
            var group = new { data1 = test.GenrateData(), data2 = test1.GenrateData() };
            return View(group);
        }

        public IActionResult Index2()
        {
            return View(test.GenrateData());
        }
    }
}
