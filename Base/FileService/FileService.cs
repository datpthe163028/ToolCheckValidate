namespace CheckValidate.Base.FileService;

public interface IFileService
{
    Task<bool> WriteFileAsync(string filePath, string content);
    Task<string> ReadFileAsync(string filePath);
}

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _env;

    public FileService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public async Task<bool> WriteFileAsync(string filePath, string content)
    {
        string fullFilePath = Path.Combine(_env.ContentRootPath, filePath);

        try
        {
            await using StreamWriter writer = new StreamWriter(fullFilePath);
            await writer.WriteAsync(content);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi ghi file: {ex.Message}");
            return false;
        }
    }

    public async Task<string> ReadFileAsync(string filePath)
    {
        string fullFilePath = Path.Combine(_env.ContentRootPath, filePath);

        try
        {
            if (File.Exists(fullFilePath))
            {
                using StreamReader reader = new StreamReader(fullFilePath);
                return await reader.ReadToEndAsync();
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi đọc file: {ex.Message}");
            return null;
        }
    }
}