using System.Windows.Forms;

namespace Quiet_AtticFilms.Class
{
    public class ValidateCombo
    {
        public TextBox myInputTextBox {  get; set; }
        public Label myValidationText {get; set; }

        public ValidateCombo(TextBox _myInputBox, Label _myvalidationText) 
        {
            myInputTextBox = myInputTextBox;
            myValidationText = myValidationText;
        }

    }
}