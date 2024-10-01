using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace DealershipSoftware
{
    public class Utilities
    {
        public static string BoolToString(bool b)
        {
            return b ? "Да" : "Не";
        }
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            bool hasText = true;
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            if (value != string.Empty)
            {
                textBox.Text = value;
            }
            else
            {
                textBox.Text = "";
            }
            buttonOk.Text = "Потвърждаване";
            buttonCancel.Text = "Отказ";
            buttonOk.TextAlign = ContentAlignment.MiddleCenter;
            buttonCancel.TextAlign = ContentAlignment.MiddleCenter;

            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 10, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            //buttonYes.SetBounds(228, 72, 75, 30);
            buttonOk.SetBounds(7, 72, 130, 90);
            buttonCancel.SetBounds(255, 72, 130, 90);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            buttonOk.Click += new EventHandler((sender, e) => InputBox_buttonOk_Click(sender, e, textBox, ref hasText));                        

            form.ClientSize = new Size(396, 175);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(400, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            if (hasText)
            {
                value = textBox.Text;
                return dialogResult;
            }
            else
            {
                return DialogResult.TryAgain;
            }
        }
        public static DialogResult InputBox(string title, string promptText, ref string valueEN, ref string valueBG)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBoxEN = new TextBox();            
            TextBox textBoxBG = new TextBox();
            Label labelEN = new Label();
            Label labelBG = new Label();
            bool hasText = true;
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            labelEN.Text = "EN:";
            labelBG.Text = "BG:";
            if (valueEN != string.Empty)
            {
                textBoxEN.Text = valueEN;
            }
            else
            {
                textBoxEN.Text = "";
            }
            if (valueBG != string.Empty)
            {
                textBoxBG.Text = valueBG;
            }
            else
            {
                textBoxBG.Text = "";
            }
            buttonOk.Text = "Потвърждаване";
            buttonCancel.Text = "Отказ";
            buttonOk.TextAlign = ContentAlignment.MiddleCenter;
            buttonCancel.TextAlign = ContentAlignment.MiddleCenter;

            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 10, 372, 13);
            labelEN.SetBounds(9, 36, 372, 13);
            labelBG.SetBounds(9, 70, 372, 13);
            textBoxEN.SetBounds(42, 36, 340, 20);
            textBoxBG.SetBounds(42, 70, 340, 20);
            buttonOk.SetBounds(7, 110, 130, 90);
            buttonCancel.SetBounds(254, 110, 130, 90);

            label.AutoSize = true;
            labelEN.AutoSize = true;
            labelBG.AutoSize = true;
            textBoxEN.Anchor = textBoxEN.Anchor | AnchorStyles.Right;
            textBoxBG.Anchor = textBoxBG.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            buttonOk.Click += new EventHandler((sender, e) => InputBox_buttonOk_Click(sender, e, textBoxEN, textBoxBG, ref hasText));

            form.ClientSize = new Size(396, 214);
            form.Controls.AddRange(new Control[] { label, labelEN, labelBG, textBoxEN, textBoxBG, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(400, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            if (hasText)
            {
                valueEN = textBoxEN.Text;
                valueBG = textBoxBG.Text;
                return dialogResult;
            }
            else
            {
                return DialogResult.TryAgain;
            }
        }
        public static DialogResult MessageBoxCustomYesNo(string title, string promptText, string yesText, string noText)
        {
            Form form = new Form();
            Label label = new Label();            
            Button buttonYes = new Button();
            Button buttonNo = new Button();

            form.Text = title;
            label.Text = promptText;
            
            buttonYes.Text = yesText;
            buttonNo.Text = noText;
            buttonYes.TextAlign = ContentAlignment.MiddleCenter;
            buttonNo.TextAlign = ContentAlignment.MiddleCenter;

            buttonYes.DialogResult = DialogResult.Yes;
            buttonNo.DialogResult = DialogResult.No;

            label.SetBounds(9, 10, 390, 13);            
            buttonYes.SetBounds(105, 80, 100, 75);
            buttonNo.SetBounds(285, 80, 100, 75);

            label.AutoSize = true;
            label.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonYes.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonNo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;            



            form.ClientSize = new Size(396, 170);
            form.Controls.AddRange(new Control[] { label, buttonYes, buttonNo });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonYes;
            form.CancelButton = buttonNo;

            DialogResult dialogResult = form.ShowDialog();
            return dialogResult;
        }

        internal static void InputBox_buttonOk_Click(object sender, EventArgs e, TextBox textBox, ref bool hasText)
        {
            if (textBox.Text.Length == 0)
            {
                MessageBox.Show("Текстовата кутия няма текст!\nОпитай пак!");
                hasText = false;
            }
            else
            {
                hasText = true;
            }
        }
        internal static void InputBox_buttonOk_Click(object sender, EventArgs e, TextBox textBox1, TextBox textBox2, ref bool hasText)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                MessageBox.Show("Текстова кутия няма текст!\nОпитай пак!");
                hasText = false;
            }
            else
            {
                hasText = true;
            }
        }

        public static Bitmap GetImageFromByteArray(byte[] byteArray)
        {
            ImageConverter imageConverter = new ImageConverter();
            Bitmap bm = (Bitmap)imageConverter.ConvertFrom(byteArray);

            if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution ||
                               bm.VerticalResolution != (int)bm.VerticalResolution))
            {                
                bm.SetResolution((int)(bm.HorizontalResolution + 0.5f),
                                 (int)(bm.VerticalResolution + 0.5f));
            }

            return bm;
        }
        public static byte[] GetByteArrayFromImage(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        public static bool IsEmailValid(string email)
        {
            bool valid;

            try
            {
                var emailAddress = new MailAddress(email);
                valid = (email.LastIndexOf(".") > email.LastIndexOf("@") && email.LastIndexOf(".") < email.Length - 1);

            }
            catch
            {
                valid = false;
            }

            return valid;
        }
    }
}
