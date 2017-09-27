using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.Demo.Models;
using OrchardCore.Demo.Services;
using OrchardCore.DisplayManagement.Views;

namespace OrchardCore.Demo.Drivers
{
    public class TestContentPartBDriver : ContentPartDisplayDriver<TestContentPartB>
    {
        private readonly ITestDependency _testDependency;

        public TestContentPartBDriver(ITestDependency testDependency)
        {
            _testDependency = testDependency;
        }

        //public override async Task<IDisplayResult> DisplayAsync(TestContentPartB part, BuildPartDisplayContext context)
        //{
        //    var model = new TestContentPartBViewModel
        //    {
        //        Message = await _testDependency.SayHiAsync("This message is coming from an async driver")
        //    };

        //    return Shape<TestContentPartBViewModel>("TestContentPartB", model).Location("Detail", "5");
        //}

        public override IDisplayResult Display(TestContentPartB part)
        {
            return Shape<TestContentPartBViewModel>("TestContentPartB", async model =>
            {
                model.Message = await _testDependency.SayHiAsync("This message is coming from an async driver");
            }).Location("Detail", "5");
        }
    }
}
