using LeetCode.Data;
using LeetCode.Data.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Service.Test
{
    public class Method : IMethod
    {
        public HttpClientService httpClientService;
        /// <summary>
        /// 数据库上下文
        /// </summary>
        public MySqlDbContext  _context;
        public ILogger<Method> logger;
        public Method(HttpClientService _httpClientService, ILogger<Method> _logger, MySqlDbContext context)
        {
            httpClientService = _httpClientService;
            logger = _logger;
            _context = context;
        }
        public  void run()
        {
            DateTimeOffset time = DateTimeOffset.Now;
            for (int i = 0; i < 10000; i++)
            {
                Task.Run(()=>{
                    Random random = new Random();
                    var s=random.Next(1,10000);
                    var par = i.ToString();
                    var res = httpClientService.GetUserInfoAsync(s.ToString());
                    //JObject jo = JsonConvert.DeserializeObject<JObject>(res);
                    //string resid = jo["result"]["guid"].ToString();
                    //if (par != resid)
                    //{
                    //    logger.LogError("--------------------");
                    //    logger.LogError("-------错误---------");
                    //    logger.LogError("--------------------");
                    //}
                    logger.LogInformation($"{res}\n第{s}次请求{DateTime.Now}\n");

                });
            }

            DateTimeOffset _time = DateTimeOffset.Now;
            TimeSpan s = _time - time;
            logger.LogInformation($"花费{s.TotalSeconds}秒");
        }
        /// <summary>
        /// 随机向数据库添加数据EFCore
        /// </summary>
        public void AddData()
        {
            try
            {
                ClubseasonDrawboxreceive model = _context.ClubseasonDrawboxreceive.FirstOrDefault(i => i.Areaid == 100);
                model.Id = 0;
                for (int i = 0; i < 10000; i++)
                {
                    var info = model;
                    info.Id = 0;
                    info.endtime = DateTime.Now;
                    info.opentime = DateTime.Now;
                    Random random = new Random();
                    info.Gameno = DateTime.Now.ToString("yyyyMMddHHmmssfffff");
                    info.Uid = random.Next(1000,3000);
                    info.Clubid = random.Next(100000, 100020);
                    _context.Add(info);
                    info = null;
                    logger.LogInformation($"第{i}条");
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                logger.LogError($"{e.Message}");
            }
        }
    }
}
