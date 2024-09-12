using RadiatorSprings.Application.Categories.AddCategory;
using RadiatorSprings.Application.Categories.GetCategories;
using RadiatorSprings.Application.Categories.GetCategoryById;
using RadiatorSprings.Application.Categories.UpdateCategory;

namespace RadiatorSprings.Api.Controllers;

[Authorize]
[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ISender _mediator;

    public CategoriesController(ISender mediator)
    {
        _mediator = mediator;
    }

    [PermissionRequired("view_categories")]
    [HttpGet]
    public async Task<IActionResult> GetCategories() =>
        Ok((await _mediator.Send(new GetCategoriesQuery())));

    [PermissionRequired("view_single_category")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategory(int id) =>
       Ok((await _mediator.Send(new GetCategoryByIdQuery(id))));

    [PermissionRequired("add_category")]
    [HttpPost]
    public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommand command) =>
        Created("", (await _mediator.Send(command)));

    [PermissionRequired("update_category")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }
}
