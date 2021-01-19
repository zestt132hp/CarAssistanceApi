using Microsoft.AspNetCore.Mvc;

namespace CarAssistance.Controllers
{
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
