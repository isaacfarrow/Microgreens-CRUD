using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Microgreens.Services
{
    public class TextFileOperations : ITextFileOperations
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public TextFileOperations(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        public IEnumerable<string> LoadConditionsForAcceptanceText()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            FileInfo filePath = new FileInfo(Path.Combine(webRootPath, "ConditionsForAdmittance.txt"));

            string[] lines = System.IO.File.ReadAllLines(filePath.ToString());
            return lines;

        }





    }
}
