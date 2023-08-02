using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsConsole.Tests
{
    internal class WorldsDumbestFunctionTests
    {
        //Naming Convention - ClassName_Method_ExceptedResult
        public static void WorldsDumbestFunction_ReturnsPikachuIfZero_ReturnString()
        {
            try
            {
                //Arrange - Go get your variables, whatever you need, you classes, go get function
                int number = 0;
                WorldsDumbestFunction worldsDumbest = new WorldsDumbestFunction();

                //Act - Execute this function 
                string result = worldsDumbest.ReturnsPikachuIfZero(number);

                //Assert - Whatever ever is returned is it what you want.
                if (result == "Pikachu!")
                {
                    Console.WriteLine("PASSED: WorldsDumbestFunction.ReturnsPikachuIfZero_ReturnsString");
                }
                else
                {
                    Console.WriteLine("FAILED: WorldsDumbestFunction.ReturnsPikachuIfZero_ReturnsString");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
