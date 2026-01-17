using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping_Hexora.Attributes;
using Shopping_Hexora.Sittings;
using System.ComponentModel.DataAnnotations;

namespace Shopping_Hexora.ViewModels
{
    public class CreateItemVM : BaseItemVM
    {
       
        [AllowedExtensions(FileSettings.AllowedExtensions)]
        [MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;
        Stock Stock { get; set; } = default!;


    }
}
