using ApplicationUtilities.Services;
using Microsoft.AspNetCore.Mvc;
using SampleWebApi.Models;

namespace SampleWebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class SampleController(ISecretManager settingsManager) : Controller
{
    [HttpGet]
    public IActionResult Get()
    {
        var secrets = settingsManager.ListSecrets();
        return Ok(secrets);
    }

    [HttpPost]
    public IActionResult Create([FromBody] NewSetting model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        settingsManager.LoadSecret(model.Key, model.Value, model.Note);
        return Created();
    }
}