using Microsoft.AspNetCore.Mvc;
using StringCheck.Models;
using System.IO;

namespace StringCheck.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StringCheckerController : Controller
    {
       
        //[HttpGet("scan")]
        //public IActionResult ScanFolder([FromQuery] string folderPath, [FromQuery] string searchValue)
        //{
        //    if (string.IsNullOrWhiteSpace(folderPath) || string.IsNullOrWhiteSpace(searchValue))
        //    {
        //        return BadRequest(new { Message = "Both folderPath and searchValue are required." });
        //    }

        //    if (!Directory.Exists(folderPath))
        //    {
        //        return BadRequest(new { Message = "The specified folder does not exist." });
        //    }

        //    var results = new List<ResultModel>();

        //    try
        //    {
        //        var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

        //        foreach (var file in files)
        //        {
        //            try
        //            {
        //                var content = System.IO.File.ReadAllText(file);
        //                var status = content.ToLower().Contains(searchValue.ToLower(), StringComparison.OrdinalIgnoreCase)
        //                    ? "Present"
        //                    : "Absent";

        //                results.Add(new ResultModel
        //                {
        //                    FileName = Path.GetFileName(file),
        //                    Status = status
        //                });
        //            }
        //            catch (Exception ex)
        //            {
        //                results.Add(new ResultModel
        //                {
        //                    FileName = Path.GetFileName(file),
        //                    Status = $"Error: {ex.Message}"
        //                });
        //            }
        //        }

        //        return Ok(results);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { Message = $"An error occurred: {ex.Message}" });
        //    }
        //}

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

