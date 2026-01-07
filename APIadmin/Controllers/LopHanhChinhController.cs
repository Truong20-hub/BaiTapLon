using BLL.InterFace;
using BLL_;
using BLL_.InterFace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_;

namespace APIAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopHanhChinhController : ControllerBase
    {
        ILopHanhChinhBLL LopHanhChinh;
        public LopHanhChinhController(ILopHanhChinhBLL lopHanhChinh)
        {
            LopHanhChinh = lopHanhChinh;
        }
        [HttpPost("createLopHC")]
        public IActionResult createLopHC(LopHanhChinh lhc)
        {
            var result = LopHanhChinh.ThemLopHC(lhc);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("updateLopHc")]
        public IActionResult updateLopHC(LopHanhChinh lhc)
        {
            var result = LopHanhChinh.SuaLopHC(lhc);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpGet("getAllLopHC")]
        public IActionResult getAllLopHC()
        {
            try
            {
                var result = LopHanhChinh.GetAllLopHC();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpDelete("deleteLopHC")]
        public IActionResult deleteLopHC([FromBody] string iDLopHC)
        {
            var result = LopHanhChinh.XoaLopHC(iDLopHC);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("getSVById")]
        public IActionResult Search([FromBody] LopHanhChinh lhc)
        {
            var k = LopHanhChinh.Search(lhc);
            return Ok(k);
        }
    }
}
