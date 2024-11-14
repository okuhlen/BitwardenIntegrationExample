using ApplicationUtilities.Configuration;
using ApplicationUtilities.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SampleWebApi.Models;

namespace SampleWebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public sealed class SampleController(ISecretManager settingsManager, 
    IOptions<MyOtherConfiguration> myOtherConfiguration) : Controller
{
    
    /// <summary>
    /// This is a sample action that returns a list of secrets from the secret manager
    /// </summary>
    /// <returns>A list of secrets on the secret manager</returns>
    [HttpGet]
    public IActionResult Get()
    {
        var secrets = settingsManager.ListSecrets().Select(x => new NewSetting
        {
            Key = x.Key,
            Value = x.Value,
            Note = x.Note
        }).ToList();
        
        return Ok(secrets);
    }

    /// <summary>
    /// This is a sample action that creates a new secret in the secret manager
    /// </summary>
    /// <param name="model"></param>
    /// <returns>HTTP status 204 if successful</returns>
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

    /// <summary>
    /// This is a sample action that fetches a custom setting from the configuration source.
    /// This is our test setting which was added by the BitwardenSecretManagerProvider.cs
    /// </summary>
    /// <returns>An object representing the custom setting</returns>
    [HttpGet]
    public IActionResult FetchCustomSetting()
    {
        var value = myOtherConfiguration.Value;

        return Ok(value);
    }
}