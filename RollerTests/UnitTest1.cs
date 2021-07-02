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
        public void TestRollTwice()
        {
            AutoRoller roller = new AutoRoller("3d6r2");
            roller.Roll();
        }

        [Test]
        public void Test1()
        {
            AutoRoller roller = new AutoRoller("4d6d1");
            roller.Roll();
            ClassRoller classRoller = new ClassRoller("Human", roller.getStats());
            classRoller.RollClass();

            int[] cn = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };

            string CharClass;
            for (int i = 0; i < 1000000; i++)
            {
                roller.Roll();
                classRoller.UpdateStats(roller.getStats());
                classRoller.UpdateRace("Human");
                CharClass = classRoller.RollClass();

                switch (CharClass)
                {
                    case "Fighter":
                        {
                            cn[0]++;
                            break;
                        }
                    case "Ranger":
                        {
                            cn[1]++;
                            break;
                        }
                    case "Paladin":
                        {
                            cn[2]++;
                            break;
                        }
                    case "Wizard":
                        {
                            cn[3]++;
                            break;
                        }
                    case "Cleric":
                        {
                            cn[4]++;
                            break;
                        }
                    case "Thief":
                        {
                            cn[5]++;
                            break;
                        }
                    case "Bard":
                        {
                            cn[6]++;
                            break;
                        }
                    case "Log":
                        {
                            cn[7]++;
                            break;
                        }
                }
            }
        }
    }
}