using ITStep.First.Models;
using ITStep.First.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITStep.First.ViewComponents
{
    public class ProfileViewComponent : ViewComponent
    {
        AppDbContext _ctx;
        public ProfileViewComponent(AppDbContext ctx) : base() {
            _ctx = ctx;
        }
        public IViewComponentResult Invoke(ProfileModel model = null)
        {
            ProfileModel p = model ?? new ProfileModel();
            return View("Profile", p);
        }
    }
}
