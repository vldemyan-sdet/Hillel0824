using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoQA
{
    public static class MyAssert
    {
        public static void NotEqual(string s1, string s2)
        {
            if (s1 == s2) 
            { 
                throw new Exception($"Expected that {s1} is not equal to {s2} but was equal");
            }
        }        
        
        public static void Equal(string s1, string s2)
        {
            if (s1 != s2) 
            { 
                throw new Exception($"Expected that {s1} is equal to {s2} but was not equal");
            }
        }
    }
}
