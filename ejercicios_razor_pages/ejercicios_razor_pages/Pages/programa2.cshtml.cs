using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ejercicios_razor_pages.Pages
{
    public class programa2Model : PageModel
    {
        public string message { get; set; }
        public int shift { get; set; }
        public string result { get; set; }

        public void OnPost()
        {
            var message = Request.Form["message"];
            var shift = int.Parse(Request.Form["shift"]);
            var action = Request.Form["action"];

            if (action == "encode")
            {
                result = Encode(message, shift);
            }
            else if (action == "decode")
            {
                result = Decode(message, shift);
            }
        }

        private string Encode(string message, int shift)
        {
            return ProcessMessage(message, shift);
        }

        private string Decode(string message, int shift)
        {
            return ProcessMessage(message, -shift);
        }

        private string ProcessMessage(string message, int shift)
        {
            char[] buffer = message.ToUpper().ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];

                if (char.IsLetter(letter))
                {
                    letter = (char)(letter + shift);

                    if (letter > 'Z') letter = (char)(letter - 26);
                    else if (letter < 'A') letter = (char)(letter + 26);
                }

                buffer[i] = letter;
            }
            return new string(buffer);
        }
    }
}
