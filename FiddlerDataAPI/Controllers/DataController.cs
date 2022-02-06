using Microsoft.AspNetCore.Mvc;
using PublicLib;
using PublicLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FiddlerDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        // GET: api/<DataController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DataController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DataController>
        [HttpPost]
        public async void Post()
        {
            try
            {
                var value = Request.Form["value"].FirstOrDefault();
                if (value != null)
                {
                    var oldDataArray = value.Trim().Split(',').ToList();
                    var newDataArray = new List<byte>();
                    oldDataArray.ForEach(x =>
                    {
                        if (Convert.ToChar(int.Parse(x)) > 32 && Convert.ToChar(int.Parse(x)) < 127)
                        {
                            newDataArray.Add(Convert.ToByte(x));
                        }
                    });

                    var returnResult = "";

                    var result = Encoding.UTF8.GetString(newDataArray.ToArray());
                    var regexRule = new Regex(RegexString.StartPattern);
                    var regexResult = regexRule.Match(result);
                    if (regexResult.Success)
                    {
                        regexRule = new Regex(RegexString.GameNumberPattern);
                        regexResult = regexRule.Match(result);
                        if (regexResult.Success)
                        {
                            returnResult = $"游戏编号：{regexResult.Value} \r\n";
                            var hasGameNumberData = DapperHelper<t_gameData>.QueryFirstOrDefault("select top 1 * from t_gamedata where gamenumber = @gamenumber order by createtime desc", new
                            {
                                gamenumber = regexResult.Value
                            });

                            if (hasGameNumberData == null)
                            {
                                await DapperHelper<t_gameData>.InsertAsync(new t_gameData()
                                {
                                    GameNumber = regexResult.Value,
                                });
                            }
                        }
                    }

                    regexRule = new Regex(RegexString.GetJsonStringPattern);
                    regexResult = regexRule.Match(result);
                    if (regexResult.Success)
                    {
                        returnResult += $"Json字符串：{regexResult.Value} \r\n";
                        var hasGameNumberData = DapperHelper<t_gameData>.QueryFirstOrDefault("select top 1 * from t_gamedata order by createtime desc", new
                        {
                            gamenumber = regexResult.Value
                        });

                        if (hasGameNumberData != null)
                        {
                            hasGameNumberData.GameJson += regexResult.Value + " ";
                            await DapperHelper<t_gameData>.UpdateAsync(hasGameNumberData);
                        }
                    }

                    regexRule = new Regex(RegexString.GetOpenResultPattern);
                    regexResult = regexRule.Match(result);
                    if (regexResult.Success)
                    {
                        returnResult += $"开奖结果：{regexResult.Value} \r\n";

                        var gameRegexRule = new Regex(RegexString.GameNumberPattern);
                        var gameRegexResult = gameRegexRule.Match(result);
                        var gameNumber = "";
                        if (gameRegexResult.Success)
                        {
                            gameNumber = gameRegexResult.Value;
                        }

                        var hasGameNumberData = DapperHelper<t_gameData>.QueryFirstOrDefault("select top 1 * from t_gamedata where gamenumber = @gamenumber order by createtime desc", new
                        {
                            gamenumber = gameNumber
                        });

                        if (hasGameNumberData == null)
                        {
                            await DapperHelper<t_gameData>.InsertAsync(new t_gameData()
                            {
                                GameResult = regexResult.Value,
                                GameNumber = gameNumber,
                            });
                        }
                        else
                        {
                            hasGameNumberData.GameResult = regexResult.Value;
                            await DapperHelper<t_gameData>.UpdateAsync(hasGameNumberData);
                        }
                    }
                    if (!string.IsNullOrEmpty(returnResult))
                    {
                        var finalResult = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]{returnResult}\r\n";
                        System.IO.File.AppendAllText("d:\\newLogs.txt", finalResult);
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        // PUT api/<DataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
