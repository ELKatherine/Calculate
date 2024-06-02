using System;
using System.Windows.Forms;

namespace Calculate
{
    public partial class Form1 : Form
    {
        private string input = string.Empty;
        private string operand1 = string.Empty;
        private string operand2 = string.Empty;
        private char operation;
        private double result = 0.0;

        public Form1()
        {
            InitializeComponent();
            CreateButtons();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBoxResult.Text += button.Text;
            input += button.Text;
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operand1 = input;
            operation = char.Parse(button.Text);
            input = string.Empty;
            textBoxResult.Text += button.Text;
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            operand2 = input;
            double num1, num2;
            double.TryParse(operand1, out num1);
            double.TryParse(operand2, out num2);

            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                        MessageBox.Show("Деление на ноль невозможно");
                    break;
                case '^':
                    result = Math.Pow(num1, num2);
                    break;
            }
            textBoxResult.Text = result.ToString();
            input = result.ToString();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxResult.Clear();
            input = string.Empty;
            operand1 = string.Empty;
            operand2 = string.Empty;
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            double num;
            double.TryParse(input, out num);
            result = Math.Sqrt(num);
            textBoxResult.Text = result.ToString();
            input = result.ToString();
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            double num;
            double.TryParse(input, out num);
            result = num / 100;
            textBoxResult.Text = result.ToString();
            input = result.ToString();
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (textBoxResult.Text.Length > 0)
            {
                textBoxResult.Text = textBoxResult.Text.Substring(0, textBoxResult.Text.Length - 1);
                input = textBoxResult.Text;
            }
        }

        private void CreateButtons()
        {
            int buttonWidth = 60;
            int buttonHeight = 60;
            int startX = 12;
            int startY = 60;
            int margin = 10;

            string[] buttonLabels = { "7", "8", "9", "/", "4", "5", "6", "*", "1", "2", "3", "-", "0", ".", "=", "+", "^", "√", "%", "⌫", "C" };
            EventHandler[] buttonHandlers = { button_Click, button_Click, button_Click, operator_Click, button_Click, button_Click, button_Click, operator_Click, button_Click, button_Click, button_Click, operator_Click, button_Click, button_Click, buttonEqual_Click, operator_Click, operator_Click, buttonSqrt_Click, buttonPercent_Click, buttonBackspace_Click, buttonClear_Click };

            for (int i = 0; i < buttonLabels.Length; i++)
            {
                Button button = new Button();
                button.Text = buttonLabels[i];
                button.Name = $"button{buttonLabels[i]}";
                button.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                button.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
                button.Location = new System.Drawing.Point(startX + (i % 4) * (buttonWidth + margin), startY + (i / 4) * (buttonHeight + margin));
                button.Click += buttonHandlers[i];
                this.Controls.Add(button);
            }
        }
    }
}
