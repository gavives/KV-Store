using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVstore
{
    struct KeyValue
    {
        public readonly string key;
        public readonly object value;

        public KeyValue(string key, object value)
        {
            this.key = key;
            this.value = value;
        }
    }

    class MyDictionary
    {
        KeyValue[] kvs = new KeyValue[16];
        int storedValues = 0;

        public object this[string searchkey]
        {
            set
            {
                bool found = false;

                for (int i = 0; i < storedValues && !found; ++i)
                {
                    if (kvs[i].key == searchkey)
                    {
                        found = true;
                        //update
                        kvs[i] = new KeyValue(searchkey, value);
                    }
                        
                }

                if (!found)
                {
                    kvs[storedValues++] = new KeyValue(searchkey, value);
                   
                }
            }


            get
            {
                bool found = false;

                for (int i = 0; i < storedValues; ++i)
                {
                    if (kvs[i].key == searchkey)
                        return kvs[i].value;
                }

                throw new KeyNotFoundException($"Didn't find \"{searchkey}\" in MyDictionary");
            }
        }
    }

    public class Program
    {
        static void Main()
        {
            var d = new MyDictionary();
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

