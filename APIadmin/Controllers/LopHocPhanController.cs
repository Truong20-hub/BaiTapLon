using BLL_.InterFace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_;

namespace APIAdmin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class LopHocPhanController : ControllerBase
    {
        ILopHocPhanBLL _lopHocPhanBLL;
        public LopHocPhanController (ILopHocPhanBLL lopHocPhanBLL)
        {
            _lopHocPhanBLL = lopHocPhanBLL;
        }
        [HttpPost("createLHP")]
        public IActionResult createLHP(LopHocPhan lhp)
        {
            var result = _lopHocPhanBLL.ThemLHP(lhp);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("updateLHP")]
        public IActionResult updateLHP(LopHocPhan lhp)
        {
            var result = _lopHocPhanBLL.SuaLHP(lhp);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpGet("getAllLopHocPhan")]
        public IActionResult getAllHocPhan()
        {
            try
            {
                var result = _lopHocPhanBLL.GetAllLopHocPhan();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpDelete("deleteLHP")]
        public IActionResult deleteLHP([FromBody] string iDLopHP)
        {
            var result = _lopHocPhanBLL.XoaLHP(iDLopHP);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("getSVById")]
        public IActionResult Search([FromBody] LopHocPhan lhp)
        {
            var k = _lopHocPhanBLL.Search(lhp);
            return Ok(k);
        }
    }
}
