using Microsoft.AspNetCore.Mvc;

namespace AIContentCreatorApp.Components.Controllers;

[ApiController]
[Route("api/attachments")]
public sealed class AttachmentsController(IWebHostEnvironment environment) : ControllerBase
{
    private readonly IWebHostEnvironment environment = environment;
    [HttpPost("save")]
    public async Task<IActionResult> Save(
        [FromForm] IFormFile UploadFiles,
        CancellationToken cancellationToken)
    {
        if (UploadFiles is null || UploadFiles.Length == 0)
        {
            return BadRequest("No file was uploaded.");
        }
        string safeOriginalName = Path.GetFileName(UploadFiles.FileName);
        string uploadDirectory = GetUploadDirectory();
        string filePath = GetSafeFilePath(uploadDirectory, safeOriginalName);
        await using FileStream outputStream = new(
            filePath,
            FileMode.Create,
            FileAccess.Write,
            FileShare.None);
        await UploadFiles.CopyToAsync(outputStream, cancellationToken);
        return Ok(new
        {
            name = safeOriginalName,
            size = UploadFiles.Length,
            type = UploadFiles.ContentType
        });
    }
    [HttpPost("remove")]
    public IActionResult Remove([FromForm] string UploadFiles)
    {
        string safeFileName = Path.GetFileName(UploadFiles);
        if (string.IsNullOrWhiteSpace(safeFileName))
        {
            return BadRequest("No file name was provided.");
        }
        string uploadDirectory = GetUploadDirectory();
        string filePath = GetSafeFilePath(uploadDirectory, safeFileName);
        if (System.IO.File.Exists(filePath))
        {
            System.IO.File.Delete(filePath);
        }
        return Ok();
    }
    private string GetUploadDirectory()
    {
        string applicationRoot =
            environment.ContentRootPath
            ?? throw new InvalidOperationException("The application content root is unavailable.");
        string uploadDirectory = Path.Combine(applicationRoot, "App_Data", "Attachments");
        Directory.CreateDirectory(uploadDirectory);
        return uploadDirectory;
    }
    private static string GetSafeFilePath(
        string uploadDirectory,
        string fileName)
    {
        string safeFileName = Path.GetFileName(fileName);
        string fullUploadDirectory = Path.GetFullPath(uploadDirectory);
        string fullFilePath = Path.GetFullPath(Path.Combine(fullUploadDirectory, safeFileName));
        if (!fullFilePath.StartsWith(
                fullUploadDirectory + Path.DirectorySeparatorChar,
                StringComparison.Ordinal))
        {
            throw new InvalidOperationException("Invalid attachment path.");
        }
        return fullFilePath;
    }
}