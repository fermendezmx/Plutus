using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plutus.Business.Services.Contracts;

namespace Plutus.Api.Controllers
{
    [Authorize]
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #region Endpoints

        [HttpGet]
        [Route("{typeId}")]
        public IActionResult Get(int typeId)
        {
            return Ok(_categoryService.ReadAllByType(typeId));
        }

        #endregion
    }
}
