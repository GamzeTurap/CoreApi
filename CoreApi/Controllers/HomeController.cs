using BusinessLayer.ImplementationsOfManagers;
using EntityLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("h")]
    public class HomeController : Controller
    {
        private readonly StudentManager _manager;

        public HomeController(StudentManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult AllStudents()
        {

            try
            {
                var data = _manager.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddStudent(StudentVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Problem("Bilgilerinizi eksiksiz girdiginize emin olun! Tekrar deneyiniz.");
                }
                var result = _manager.Add(model);
                return Created("", result.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult FindStudentsByYear(int? year)
        {
            try
            {
                if (year == null)
                {
                    //Yıl değeri verilmemişse bütün öğrencileri göndersin
                    return Problem("Yıl değeri vermediniz!");
                }

                var result = _manager.GetAll(x =>
                x.BirthDate != null && x.BirthDate.Value.Year == year).Data;
                if (result.Count > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return Problem("Uygun veri bulunamadı!");
                }

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}
