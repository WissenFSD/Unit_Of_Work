using Microsoft.AspNetCore.Mvc;

namespace Unit_Of_Work.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UnitController : ControllerBase
	{
		UnitOfWork.UnitOfWork _unitOfWork;
        public UnitController(UnitOfWork.UnitOfWork unitOfWorks)
        {
            _unitOfWork = unitOfWorks;
        }

		[HttpGet]
		public IActionResult Save()
		{

			_unitOfWork._authRepository.Add(new DMO.Authentication()
			{
				Username = "Derya",
				Password = "2020"
			});


			// unit of work üzerinden repository'e erişip, modelimizi verdikç
			// yine unit of work üzerinden save metodunu çağırarak verinin kaydedilmesini sağlayalım


			_unitOfWork.Save();
			return Ok();
		}

	}
}
