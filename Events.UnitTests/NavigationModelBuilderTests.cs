using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TAC.Utils.TestModels;

using events.tac.local.Business.Navigation;

namespace Events.UnitTests
{
    [TestClass]
    public class NavigationModelBuilderTests
    {
        [TestMethod]
        public void ReturnsAModel()
        {
            var item = new TestItem("test");
            var modelBuilder = new NavigationModelBuilder();
            //var model = modelBuilder.CreateNavigationMenu(item, item);

            //Assert.IsNotNull(model);
        }
    }
}
