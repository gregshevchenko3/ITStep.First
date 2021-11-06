using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITStep.First.Models;
using ITStep.First.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ITStep.First.Controllers
{
    [Route("/api/v1/profile")]
    [ApiController]
    public class ProfileController : Controller
    {
        AppDbContext _ctx;
        ILogger<ProfileController> _logger;

        public ProfileController(AppDbContext ctx)
        {
            _ctx = ctx;
            ILoggerFactory loggerFactory = LoggerFactory.Create(opts => opts.AddConsole());
            _logger = loggerFactory.CreateLogger<ProfileController>();
        }
        [HttpGet]
        public IActionResult Get()
        {
            Parameter DefaultProfileId = _ctx.Parameters.Where(p => p.Key == "DefaultProfileId").FirstOrDefault();
            Profile ProfileEntity = null;
            ProfileModel model = null;
            if (DefaultProfileId != null) 
                    ProfileEntity = _ctx.Profiles.Where(p => p.Id == int.Parse(DefaultProfileId.Value)).Include(p => p.Cover).Include(p => p.Socials).FirstOrDefault();
            if (DefaultProfileId == null || ProfileEntity == null)
                model = new();
            else if(ProfileEntity != null)
            {
                model = new()
                {
                    Title = ProfileEntity.Title,
                    Description = ProfileEntity.Description,
                    Cover = ProfileEntity.Cover,
                    Socials = ProfileEntity.Socials
                };
            }
            model.IsAdmin = User.IsInRole("Admins");
            model.IsAuthor = User.IsInRole("Authors");
            return View("Profile", model);
        }
    }
}
