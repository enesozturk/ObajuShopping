using System.ComponentModel.DataAnnotations;

namespace ObajuShopping.Admin.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        [UIHint("String")]
        public string CategoryName { get; set; }
        [UIHint("Integer")]
        public int? CategoryTopCat { get; set; }

        public bool CategoryIsActive { get; set; }
    }
}