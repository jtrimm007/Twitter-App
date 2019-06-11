using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterApp
{
    class Check<T, UNBOXING>
    {
        public bool Compare(UNBOXING unboxing, T unboxingTest)
        {
            if(unboxing.Equals(unboxingTest))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }

    //public void Test()
    //{
    //    Check<string, int> newTest = new Check<string, int>();


    //}
}
