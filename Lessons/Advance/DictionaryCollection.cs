using System.Collections.Generic;

namespace Advance
{
    public class DictionaryCollection
    {
        public DictionaryCollection()
        {
            //        key type, value type
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            
            dictionary.Add("Estonia", "Tallinn");
            dictionary.Add("Russia", "Moscow");
            
            if (dictionary.ContainsKey("Estonia"))
            {
                string capital = dictionary["Estonia"];
            }

            foreach (var item in dictionary)
            {
                string key = item.Key;
                string value = item.Value;
            }
            
            foreach (var key in dictionary.Keys)
            {
                string key1 = key;
                string value = dictionary[key];
            }
            
            foreach (var value in dictionary.Values)
            {
                string value1 = value;
            }

            dictionary.Remove("Estonia"); // remove value by key
        }
    }
}