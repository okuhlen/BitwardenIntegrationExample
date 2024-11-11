namespace ApplicationUtilities.Configuration;

public sealed class BitwardenSecretsConfiguration
{
    public string AccessToken { get; set; }
    
    public string OrganizationName { get; set; }
    
    public string ProjectName { get; set; }
    
    public string MachineAccountName { get; set; }
    
    public string ApiUrl { get; set; }
    
    public string IdentityUrl { get; set; }
    
    public string OrganizationId { get; set; }
    
    public string ProjectId { get; set; }
}