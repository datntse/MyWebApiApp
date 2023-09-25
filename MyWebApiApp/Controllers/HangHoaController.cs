using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HangHoaController : ControllerBase
	{
		public static List<HangHoa> hangHoas = new List<HangHoa>();

		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok(hangHoas);
		}

		[HttpGet("{id}")]
		public IActionResult GetHangHoaById(string id)
		{
			var hanghoa = hangHoas.SingleOrDefault(x => x.MaHangHoa.Equals(id));
			if(hanghoa == null)
			{
				return NotFound();
			}
			return Ok(hanghoa);
		}

		[HttpPost]
		public IActionResult Create(HangHoaVM hangHoaVM) {
			var hangHoa = new HangHoa
			{
				MaHangHoa = Guid.NewGuid().ToString(),
				TenHangHoa = hangHoaVM.TenHangHoa,
				DonGia = hangHoaVM.DonGia
			};
			hangHoas.Add(hangHoa);
			return Ok(new
			{
				Success = true,
				Data = hangHoas
			});
		}

		[HttpPut("{id}")]
		public IActionResult Update(string id, HangHoa hangHoaVM)
		{
			var hanghoa = hangHoas.SingleOrDefault(x => x.MaHangHoa.Equals(id));
			if (hanghoa == null)
			{
				return NotFound();
			}
			if(id != hanghoa.MaHangHoa)
			{
				return BadRequest();
			}
			hanghoa.TenHangHoa = hangHoaVM.TenHangHoa;
			hanghoa.DonGia = hangHoaVM.DonGia;
			return Ok(hanghoa);
		}

		[HttpDelete("{id}")]
		public IActionResult Remove(string id)
		{
			var hanghoa = hangHoas.SingleOrDefault(x => x.MaHangHoa.Equals(id));
			if (hanghoa == null)
			{
				return NotFound();
			}
			hangHoas.Remove(hanghoa);
			return Ok(hanghoa);
		}


	}
}
