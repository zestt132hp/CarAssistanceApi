using System;

namespace Shared.Contracts.DtoModels
{
    public class ModelDto
    {
        public string ModelName { get; set; }
        public DateTime YearStart { get; set; }
        public DateTime YearEnd { get; set; }
    }
}