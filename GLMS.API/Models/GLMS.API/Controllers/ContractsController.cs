using Microsoft.AspNetCore.Mvc;
using GLMS.API.Models;

[ApiController]
[Route("api/[controller]")]
public class ContractsController : ControllerBase
{
    static List<Contract> contracts = new();

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(contracts);
    }

    [HttpPost]
    public IActionResult Create(Contract contract)
    {
        contracts.Add(contract);
        return Ok(contract);
    }

    [HttpPatch("{id}/status")]
    public IActionResult Update(int id, [FromBody] string status)
    {
        var contract = contracts.FirstOrDefault(x => x.Id == id);
        if (contract == null) return NotFound();

        contract.Status = status;
        return Ok(contract);
    }
}
