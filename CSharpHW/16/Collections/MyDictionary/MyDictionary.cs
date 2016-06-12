using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    public class MyKeyValuePair<Tkey, Tvalue>
    {
        public readonly List<Tkey> keys;
        public readonly List<Tvalue> values;

        public MyKeyValuePair()
        {
            keys = new List<Tkey>();
            values = new List<Tvalue>();
        }

        public void Add(Tkey key, Tvalue value)
        {
            if (!keys.Any(k => k.Equals(key)))
            {
                keys.Add(key);
                values.Add(value);
            }
            else
                throw new InvalidOperationException();
        }

        public void Remove(Tkey key)
        {
            if (keys.Any(k => k.Equals(key)))
            {
                keys.RemoveAt(keys.IndexOf(key));
                values.RemoveAt(keys.IndexOf(key));
            }
        }

        public Tvalue GetValueByKey(Tkey key)
        {
            return values[keys.IndexOf(key)];
        }
    }


    //public class MyDictionary<Tkey, Tvalue>
    //{
    //    readonly MyKeyValuePair<Tkey, Tvalue> myKeyValuePair;
    //    public List<Tkey> Keys { get; set; }
    //    public List<Tvalue> Values { get; set; }

    //    public MyDictionary()
    //    {
    //        myKeyValuePair = new MyKeyValuePair<Tkey, Tvalue>();

    //    }

    //    public void Add(Tkey key, Tvalue value)
    //    {
    //        myKeyValuePair.Add(key, value);
    //        //Key = key;
    //        //Value = value;
    //    }

    //    public void Remove(Tkey key, Tvalue value)
    //    {
    //        myKeyValuePair.Remove(key);
    //    }

    //    public Tvalue GetValue(Tkey key)
    //    {
    //        return myKeyValuePair.GetValueByKey(key);
    //    }

    //}
}
