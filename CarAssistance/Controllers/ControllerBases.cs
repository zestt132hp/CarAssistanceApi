using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarAssistance.Controllers
{
    [Authorize]
    public class ControllerBases:ControllerBase
    {
        public ControllerBases()
        {

        }

        public bool ValidateInputModel(string inputModelDto) 
        {
            return string.IsNullOrWhiteSpace(inputModelDto);
        }
    }
}
