using NUnit.Framework;
using Character_Generator;

namespace RollerTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            
            AutoRoller roller = new AutoRoller("4d6d1");
          
            roller.Roll();
            ClassRoller classRoller = new ClassRoller("Human", roller.getStats());
            classRoller.RollClass();
          
        }
    }
}