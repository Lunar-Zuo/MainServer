using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Forest.Controllers
{
    /// <summary>
    /// Api服务
    /// </summary>
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ForestApiController : Controller
    {
        [HttpGet]
        public async Task<string> Test()
        {

            return "访问成功";
        }

        [HttpGet]
        public async Task<object> test1(string parm)
        {
            
            return Json(new { code = 0, msg = "返回成功", count = "0", data = "zyc是" + parm }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<object> test2(string parm)
        {
            return Json(new { code = 0, msg = "返回成功", count = "0", data = "zyc是" + parm }, JsonRequestBehavior.AllowGet);
        }
    }
}