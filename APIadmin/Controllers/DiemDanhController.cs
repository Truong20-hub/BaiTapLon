using BLL;
using BLL.InterFace;
using BLL_;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace APIAdmin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class DiemDanhController : ControllerBase
    {
        IDiemDanhBLL _diemDanhBLL;
        public DiemDanhController(IDiemDanhBLL diemDanhBLL)
        {
            _diemDanhBLL = diemDanhBLL;
        }
        [HttpPost("createDD")]
        public IActionResult createDD(Model_.DiemDanh diemDanh)
        {
            var result = _diemDanhBLL.ThemDiemDanh(diemDanh);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("updateDD")]
        public IActionResult updateDD(Model_.DiemDanh diemDanh)
        {
            var result = _diemDanhBLL.SuaDiemDanh(diemDanh);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpGet("getAllDD")]
        public IActionResult getAllDD()
        {
            try
            {
                var result = _diemDanhBLL.GetAllDiemDanh();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpDelete("deleteDD")]
        public IActionResult deleteDD(string idDiemDanh)
        {
            var result = _diemDanhBLL.XoaDiemDanh(idDiemDanh);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("searchDD")]
        public IActionResult searchDD(Model_.DiemDanh diemDanh)
        {
            var result = _diemDanhBLL.SearchDiemDanh(diemDanh);
            return Ok(result);
        }
    }
}
