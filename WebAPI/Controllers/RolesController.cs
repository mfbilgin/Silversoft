using Business.Abstracts;
using Dtos.Role;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController(IRoleService roleService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll(int index = 1, int size = 10)
    {
        var roles = roleService.GetAll(index, size);
        return Ok(roles);
    }

    [HttpGet("id/{id}")]
    public IActionResult GetById(Guid id)
    {
        var role = roleService.GetById(id);
        if (role == null)
        {
            return NotFound("The role is not found.");
        }

        return Ok(role);
    }

    [HttpGet("name/{name}")]
    public IActionResult GetByName(string name)
    {
        var role = roleService.GetByName(name);
        if (role == null)
        {
            return NotFound("The role is not found.");
        }

        return Ok(role);
    }

    [HttpPost]
    public IActionResult Add([FromBody] RoleAddDto roleAddDto)
    {
        roleService.Add(roleAddDto);
        return Created("", "The role has been added.");
    }

    [HttpPut]
    public IActionResult Update([FromBody] RoleUpdateDto roleUpdateDto)
    {
        roleService.Update(roleUpdateDto);
        return Ok("The role has been updated.");
    }

    [HttpDelete]
    public IActionResult Delete([FromBody] RoleDeleteDto roleDeleteDto)
    {
        roleService.Delete(roleDeleteDto);
        return Ok("The role has been deleted.");
    }
}