using System;
using System.Collections.Generic;

namespace EventTesting {
    internal class Program {
        
        public static void Main(string[] args) {
            Test t = new Test();
            t.main();

        }

       
    }


    public class ECombineStringEvent {
        public delegate string Combine(string s1, string s2);

        public ECombineStringEvent() {
            delegates = new List<Combine>();
        }
        private List<Combine> delegates;

        public void AddListner(Combine c) {
            delegates.Add(c);
        }

        public void Invoke() {
            foreach (var d in delegates) {
                d("1", "2");
            }
        }
    }
    public class Test{ 

        string AddStrings(string string1, string string2) {
            string retVal = string1 + " " + string2;
            Console.WriteLine(retVal);
            return retVal;
        }
        string AddStringsReverse(string string1, string string2) {
            string retVal = string2 + " " + string1;
            Console.WriteLine(retVal);
            return retVal;
        }
        string AddStringsWithInstert(string string1, string string2) {
            string retVal = string1 + " INSERT " + string2;
            Console.WriteLine(retVal);
            return retVal;
        }

        private ECombineStringEvent CombineStringEvent = new ECombineStringEvent(); 
        
        public void main() {
            CombineStringEvent.AddListner(AddStrings);
            CombineStringEvent.AddListner(AddStringsReverse);
            CombineStringEvent.AddListner(AddStringsWithInstert);
            
            CombineStringEvent.Invoke();
        }
        
        
        
    }
}