using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var values = _teamService.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            // Team nesnesinin doğrulama kurallarını tanımlayan TeamValidator sınıfı örneği oluşturulur.
            TeamValidator validationRules = new TeamValidator();

            // Oluşturulan TeamValidator sınıfı kullanılarak Team nesnesinin doğrulama işlemi yapılır.
            // ValidationResult, FluentValidation kütüphanesinin bir parçası olan ve doğrulama sonuçlarını içeren bir sınıftır.
            ValidationResult result = validationRules.Validate(team);

            // Eğer doğrulama başarılı ise (hiçbir kural ihlal edilmemişse) yeni takım eklenir ve Index sayfasına yönlendirme yapılır.
            if (result.IsValid)
            {
                _teamService.Insert(team);
                return RedirectToAction("Index");
            }

            // Eğer doğrulama başarısız ise (bir veya daha fazla kural ihlal edilmişse) hata mesajları ModelState'e eklenir.
            else
            {
                foreach (var error in result.Errors)
                {
                    // Hata mesajları, her bir özellik (PropertyName) için ve bu özellikteki hatanın açıklaması (ErrorMessage) ile birlikte ModelState'e eklenir.
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            // Hata mesajlarıyla birlikte, kullanıcının girdiği verilerle birlikte aynı sayfa tekrar gösterilir.
            return View();
        }
        public IActionResult DeleteTeam(int id)
        {
            var value = _teamService.GetById(id);
            _teamService.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateTeam(int id)
        {
            var value = _teamService.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateTeam(Team team)
        {
            TeamValidator validationRules = new TeamValidator();
            ValidationResult result = validationRules.Validate(team);

            if (result.IsValid)
            {
                _teamService.Update(team);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }
    }
}
