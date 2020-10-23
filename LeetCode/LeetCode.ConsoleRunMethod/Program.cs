using LeetCode.Service;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace LeetCode.ConsoleRunMethod
{
    class Program
    {

        private static string s = "首　";
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {


          
            Console.WriteLine("----输入信息----");
            var query=Console.ReadLine();
            var res = ToByte(s);
            Console.WriteLine(JsonConvert.SerializeObject(res));
        }
        public static byte[] ToByte(string query)
        {
            byte[] byteArray = Encoding.Default.GetBytes(query);
            return byteArray;
        }

       
    }
}
