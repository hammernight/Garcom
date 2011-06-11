using Garcom.Models;
using NUnit.Framework;

namespace Garcom.Test.Unit.Models
{
    [TestFixture]
    public class MenuSpec
    {
        [Test]
        public void ShouldHaveItems()
        {
            var menu = new Menu();
            Assert.That(menu.Items, Is.Not.Null);
        }
    }
}