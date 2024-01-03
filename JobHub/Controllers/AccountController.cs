using ASPProject.EntityFramework;
using JobHub.ViewModel;
using JobHub.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<JobHubUser> _signInManager;
        private readonly UserManager<JobHubUser> _userManager;

        public AccountController(SignInManager<JobHubUser> signInManager, UserManager<JobHubUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        //register
        public IActionResult Register() //this will give us the Registration form ...
        {
            return View();
        }

        public IActionResult RegisterJobSeeker()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> RegisterJobSeeker(RegisterJobSeekerViewModel registerModel) // this will give us the Registration form
        {
            if (ModelState.IsValid)
            {
                //attempt to register to a new user account
                JobHubUser newUser = new()
                {
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    Email = registerModel.OfficeEmail,
                    PhoneNumber = registerModel.OfficePhone,
                    UserName = registerModel.UserName
                };
                var result = await _userManager.CreateAsync(newUser, registerModel.Password);

               // check result
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "JobSeeker");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(registerModel);
        }

        [HttpPost] //use the values from the Registration form to register new user
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                //attempt to register a new user account 
                JobHubUser newUser = new()
                {
                    CompanyName = registerModel.CompanyName,
                    Email = registerModel.OfficeEmail,
                    PhoneNumber = registerModel.OfficePhone,
                    UserName = registerModel.UserName
                };
                var result = await _userManager.CreateAsync(newUser, registerModel.Password);

                //check the result
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Company");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            //something went wrong, go back to the register form
            return View(registerModel);
        }

        [HttpGet]
        public IActionResult LoginJobSeeker(string? returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "JobSeeker");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginJobSeeker(LoginJobSeekerViewModel loginModel, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.Remember, false);

                if (result.Succeeded)
                {
                    var redirectUrl = TempData["ReturnUrl"] as string;
                    if (!string.IsNullOrEmpty(redirectUrl) && Url.IsLocalUrl(redirectUrl))
                    {
                        return Redirect(redirectUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "JobSeeker");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Failed to log in");
                }
            }

            return View(loginModel);
        }



        public IActionResult Login(string? ReturnUrl)
        {
            TempData["ReturnUrl"] = ReturnUrl;
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated == true)
                return RedirectToAction("Index", "JobSeeker");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.Remember, false);

                if (result.Succeeded)
                {
                    var redirectUrl = TempData["ReturnUrl"] as string;
                    if (!string.IsNullOrEmpty(redirectUrl) && Url.IsLocalUrl(redirectUrl))
                    {
                        return Redirect(redirectUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Company");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Failed to log in");
                }
            }

            return View(loginModel);
        }

        //logout
        public async Task<IActionResult> Logout()
        {
            // Sign out the current user
            await _signInManager.SignOutAsync();

            // Redirect to the homepage or login page after logging out
            return RedirectToAction("Index", "Company");
        }



    }

}
