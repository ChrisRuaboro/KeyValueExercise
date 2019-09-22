using System;
using System.Collections.Generic;

namespace KeyValueStore
{
    struct KeyValue<T>
    {
        public string Key { get; }
        public T Value;

        public KeyValue(string key, T value)
        {
            this.Key = key;
            this.Value = value;

        }
    }
    public class MyDictionary<T>
    {
        public int storedValues;
        KeyValue<T>[] arr = new KeyValue<T>[7];
        public T this[string key]
        {
            get
            {
                //iterate through arr and returning value if found
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Key == key)
                        return arr[i].Value;
                }
                // throws exception if no key matches in arr
                throw new KeyNotFoundException(key);
            }
            set
            {
                //searches thru array, overwrites key if found
                for (int i = 0; i < arr.Length; i++)
                {
                    //
                    if (arr[i].Key == key)
                    {
                        arr[i] = new KeyValue<T>(key, value);

                    }
                }
                //searched thru array, finds first empty spot, sets new KeyValue, 
                //adds to counter, and breaks out of loop the new value is set.
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Key == null)
                    {
                        arr[i] = new KeyValue<T>(key, value);
                        storedValues++;
                        return;
                    }
                }
            }
        }


    }
    public class Program
    {
        static void Main()
        {
            var d = new MyDictionary<object>();
            try
            {
                Console.WriteLine(d["Cats"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            d["Cats"] = 42;
            d["Dogs"] = 17;
            Console.WriteLine($"{(int)d["Cats"]}, {(int)d["Dogs"]}");
        }
    }
}
