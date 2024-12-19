using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchNode
{
    /// <summary>
    /// Wrapper class for the node
    /// </summary>
    public class MyFirstNode
    {
        // This hides the overall class as a node
        private MyFirstNode() { }

        /// <summary>
        /// Returns a string that says hello world
        /// </summary>
        /// <returns name="helloWorldString">Our hello world node.</returns>
        public static string HelloWorld(string username)
        {
            // returns one node
            return $"Hello {username}";
        }
    }
}
