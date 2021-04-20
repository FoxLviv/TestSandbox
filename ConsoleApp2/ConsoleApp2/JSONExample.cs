using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp2
{
    class JSONExample
    {
        public void Example()
        {
            var array = new JArray();
            var text = new JValue("Manual text");
            var date = new JValue(new DateTime(2000, 5, 23));

            array.Add(text);
            array.Add(date);

            string json = array.ToString();
            Console.WriteLine(json);
            // [
            //   "Manual text",
            //   "2000-05-23T00:00:00"
            // ]

            var product = new Product();

            product.Name = "Apple";
            product.ExpiryDate = new DateTime(2008, 12, 28);
            product.Price = 3.99;
            product.Sizes = new string[] { "Small", "Medium", "Large" };

            string output = JsonConvert.SerializeObject(product);
            Console.WriteLine(output);
            //{
            //  "Name": "Apple",
            //  "ExpiryDate": "2008-12-28T00:00:00",
            //  "Price": 3.99,
            //  "Sizes": [
            //    "Small",
            //    "Medium",
            //    "Large"
            //  ]
            //}

            var deserializedProduct = JsonConvert.DeserializeObject<Product>(output);

            var serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (var sw = new StreamWriter("json.txt"))
            using (var writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, deserializedProduct);
                // {"ExpiryDate":new Date(1230375600000),"Price":0}
            }

            using (var reader = File.OpenText("json.txt"))
            {
                var o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                var readedProduct = o.ToString();
                Console.WriteLine(readedProduct);
            }
        }
        public class Product
        {
            public string Name { get; set; }
            public DateTime ExpiryDate { get; set; }
            public double Price { get; set; }
            public string[] Sizes { get; set; }
        }
    }
}
