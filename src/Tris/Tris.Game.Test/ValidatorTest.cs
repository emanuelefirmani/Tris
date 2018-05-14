using NUnit.Framework;

namespace Tris.Game.Test
{
    public class ValidatorTest
    {
        Validator _sut = new Validator();

        [Test]
        public void Pass()
        {
            Assert.True(true);            
        }
    }
}