using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ejercicios_razor_pages.Pages
{
    public class IMCModel : PageModel
    {
        [BindProperty]
        public double peso { get; set; } = 0;
        [BindProperty]
        public double altura { get; set; } = 0;

        public double imc = 0;
        public void OnPost()
        {
			peso = double.Parse(Request.Form["peso"]);
            altura = double.Parse(Request.Form["altura"]);
            imc = peso / (altura * altura);
            ModelState.Clear();
        }
    }
}
