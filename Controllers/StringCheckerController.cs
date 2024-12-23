using Microsoft.AspNetCore.Mvc;
using StringCheck.Models;
using System.IO;

namespace StringCheck.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StringCheckerController : Controller
    {
       
     
        [HttpGet("scanFiles")]

        public List<string> ScanFiles(string folderPath, string searchString)
        {
            List<string> result = new List<string>();

            if (!Directory.Exists(folderPath))
            {
                throw new DirectoryNotFoundException($"The directory '{folderPath}' does not exist.");
            }

            // Include files in all subdirectories
            var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                try
                {
                    string content = System.IO.File.ReadAllText(file);
                    if (content.Contains(searchString))
                    {
                        result.Add($"Present: {Path.GetFileName(file)}");
                    }
                    else
                    {
                        result.Add($"Absent: {Path.GetFileName(file)}");
                    }
                }
                catch (Exception ex)
                {
                    result.Add($"Error: Could not read {Path.GetFileName(file)} - {ex.Message}");
                }
            }

            return result;
        }


    }

}

