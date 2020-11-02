using LeetCode.Service;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace LeetCode.ConsoleRunMethod
{
    class Program
    {

        private static string s = "{\"code\":\"1\"}";
        private static string s2 = "eyJjb2RlIjoiMSJ9";
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {


          
            Console.WriteLine("----输入信息----");
            var res = ToByte(s);
            byte[] bytes = Convert.FromBase64String(s2);

            Console.WriteLine(JsonConvert.SerializeObject(res));
            Console.ReadKey(true);
        }
        public static byte[] ToByte(string query)
        {
            byte[] byteArray = Encoding.Default.GetBytes(query);
            return byteArray;
        }

       
    }
}
