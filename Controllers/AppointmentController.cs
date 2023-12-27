using Appointment_form.Models;
using Appointment_form.Models.Repo_s;
using Appointment_form.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace Appointment_form.Controllers
{
    public class AppointmentController : Controller
    {
        private IAppointmentRepo<Appointment> db;

        public AppointmentController(IAppointmentRepo<Appointment> _db)
        {
            db = _db;
        }
        // GET: AppointmentController
        public ActionResult Index()
        {
            var AppointmentList = db.List();
            var nationalities = NationalityHelper.GetNationalities();
            ViewBag.Nationalities = new SelectList(nationalities, "CountryName", "CountryName");
            return View(AppointmentList);
        }

        // POST: AppointmentController/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment appointment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.create(appointment);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ValidationStatus = 0;
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: AppointmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var appointment= db.Find(id);
            return View(appointment);
        }

        // POST: AppointmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Appointment appointment)
        {
            try
            {
                db.Delete(appointment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
    // A helper class to generate a list of all nationalities
    public static class NationalityHelper
    {
        public static List<NationalityViewModel> GetNationalities()
        {
            var nationalities = new List<NationalityViewModel>();

            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo region = new RegionInfo(ci.Name);
                var nationality = new NationalityViewModel
                {
                    CountryCode = region.TwoLetterISORegionName,
                    CountryName = region.DisplayName
                };

                nationalities.Add(nationality);
            }

            return nationalities;
        }
    }
}
