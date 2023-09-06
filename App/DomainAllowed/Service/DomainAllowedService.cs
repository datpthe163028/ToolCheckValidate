using System.Text.RegularExpressions;
using CheckValidate.Base.FileService;
namespace CheckValidate.App.DomainAllowed.Service;

public interface IDomainAllowedService
{
    public Task<bool> AddDomain(string domain);
    public Task<string[]> GetList();
    public Task<int> DeleteDomain(string domain);
}

public class DomainAllowedService : IDomainAllowedService
{
    private readonly IFileService _fileService;
    private readonly IConfiguration _configuration;
    
    public DomainAllowedService( IFileService fileService, IConfiguration configuration )
    {
        _fileService = fileService;
        _configuration = configuration;
    }
    
    public async Task<bool> AddDomain(string domain)
    {   
        string pathFileDomain = _configuration["pathFileDomain"];
        string content = (await _fileService.ReadFileAsync(pathFileDomain)) + domain + ","; 
        
        if (await _fileService.WriteFileAsync(pathFileDomain, content))
            return true;
        return false;
    }
    
    public async Task<int> DeleteDomain(string domain)
    {
        string[] result = await GetList();
        if (result == null)
            return 4;  
        
        List<string> resultList = new List<string>(result);

        var d = resultList.FirstOrDefault(t => t.Equals(domain));
        if (d == null)
            return 2;

        resultList.Remove(domain);
        var resultContent = "";
        foreach (var v in resultList)
        {
            resultContent += (v + ",");
        }

        string pathFileDomain = _configuration["pathFileDomain"];
        
        if (!(await _fileService.WriteFileAsync(pathFileDomain, resultContent)))
            return 3;
        return 1;
    }
    
    public async Task<string[]> GetList()
    {
        string pathFileDomain = _configuration["pathFileDomain"];
        string content =  await _fileService.ReadFileAsync(pathFileDomain);

        if (content == null)
            return null;
        
        char[] separators = { ' ', ',' };

        string[] result = content.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        return result;
    }
    
}