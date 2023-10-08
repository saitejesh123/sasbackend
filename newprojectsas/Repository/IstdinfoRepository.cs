using Microsoft.AspNetCore.Mvc;
using newprojectsas.Controllers.Models;

namespace newprojectsas.Repository
{
    public interface IstdinfoRepository
    {

        Task<ActionResult<IEnumerable<stdinfo>>> Getstdinfo();
        Task<ActionResult<stdinfo>> Getstdinfo(int id);
        Task<ActionResult<stdinfo>> GetstdinfoByPwd(string email, string password);
        Task<ActionResult<stdinfo>> Poststdinfo(stdinfo stdinfo);
        Task<ActionResult<stdinfo>> Deletestdinfo(int id);
        bool stdinfoExists(int id);

    }
}
