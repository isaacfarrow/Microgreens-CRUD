using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microgreens.Services
{
    public interface ITextFileOperations
    {
        IEnumerable<string> LoadConditionsForAcceptanceText();


    }
}
