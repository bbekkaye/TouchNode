using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchNode
{
    public class MyFirstNode
    {
        // This hides the overall class as a node
        private MyFirstNode() { }
        public static string HelloWorld()
        {
            // returns one node
            return "Hello world " + DateTime.Now;
        }
    }
}
