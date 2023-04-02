using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConcreteMonitoring.Web.Entry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        // GET: api/<MenuController>
        [HttpGet]
        public IActionResult Get()
        {
            List<string> list = new List<string>
            {
                "btn_add",
                "btn_edit"
            };
            Meta meta = new Meta() { Title = "权限管理" ,Icon= "lollipop",Rank=10 };
            Meta meta1 = new Meta() { Title = "页面权限" };
            Meta meta2 = new Meta() { Title = "按钮权限" };
            meta2.Auths = list;

            Children children1 =new Children() { Path= "/permission/page/index", Name= "PermissionPage" };
            children1.meta = meta1;
            Children children2 = new Children() { Path = "/permission/button/index", Name = "PermissionButton" };
            children2.meta = meta2;

            Menu menu1 = new Menu() { Path= "/permission", };
            menu1.meta = meta;
            menu1.children.Add(children1);
            menu1.children.Add(children2);

            MResult mResult = new MResult() { Success=true};
            mResult.data.Add(menu1);
            return Ok(mResult);
        }
    }

    public class MResult
    {
        public MResult()
        {
            data = new List<Menu>();
        }

        public bool Success { get; set; }

        public List<Menu>? data { get; set; }
    }

    public class Menu
    {
        public Menu()
        {
            meta = new Meta();
            children = new List<Children>();
        }

        public string? Path { get; set; }
        public Meta? meta { get; set; }
        public List<Children>? children { get; set; }
    }

    public class Children
    {
        public Children()
        {
            meta = new Meta();
        }

        public string? Path { get; set; }
        public string? Name { get; set; }
        public Meta? meta { get; set; }
    }

    public class Meta
    {
        public Meta()
        {
            Auths = new List<string>();
        }
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public int Rank { get; set; }
        public List<string>? Auths { get; set; }
    }
}
