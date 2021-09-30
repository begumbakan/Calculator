using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double prev = 0;
        bool changed = false;
        Operation prevOperation = Operation.None;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click_General(object sender, EventArgs e)
        {
            if (changed) 
            {
                textBox1.Text = ((Button)sender).Text;
            }
            else
            {
                if (textBox1.Text == "0")
                {
                    textBox1.Text = "";
                }
                textBox1.Text += ((Button)sender).Text;
            }
            changed = false;
        }

        private void CE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void posneg_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.StartsWith("-"))
            {
                textBox1.Text = textBox1.Text.TrimStart('-');
            }
            else
            {
                textBox1.Text = "-" + textBox1.Text;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(","))
            {
                textBox1.Text += ",";
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            if (textBox1.Text == "") 
            {
                textBox1.Text = "0";
            }
                
        }

        private void plus_Click(object sender, EventArgs e)
        {
            equal_Click(null, null);
            label1.Text = textBox1.Text + " + ";
            prev = double.Parse(textBox1.Text);
            changed = true;
            prevOperation = Operation.Addition;
        }

        private void C_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            label1.Text = "";
            prev = 0;
        }

        private void minus_Click(object sender, EventArgs e)
        {
            if (label1.Text == "")
            {
                label1.Text = textBox1.Text + " - ";
            }
            else
            {
                equal_Click(null, null);
                label1.Text = textBox1.Text + " - ";
            }
            prev = double.Parse(textBox1.Text);
            changed = true;
            prevOperation = Operation.Subtraction;
        }

        private void x_Click(object sender, EventArgs e)
        {
            if (label1.Text == "")
            {
                label1.Text = textBox1.Text + " x ";
            }
            else
            {
                equal_Click(null, null);
                label1.Text = textBox1.Text + " x ";
            }
            prev = double.Parse(textBox1.Text);
            changed = true;
            prevOperation = Operation.Multiplication;
        }

        private void division_Click(object sender, EventArgs e)
        {
            if (label1.Text == "")
            {
                label1.Text = textBox1.Text + " /";
            }
            else
            {
                equal_Click(null, null);
                label1.Text = textBox1.Text + " /";
            }
            prev = double.Parse(textBox1.Text);
            changed = true;
            prevOperation = Operation.Division;
        }

        private void equal_Click(object sender, EventArgs e)
        {
            switch (prevOperation)
            {
                case Operation.Addition:
                    label1.Text = prev + " + " + textBox1.Text + " =";
                    textBox1.Text = (prev + double.Parse(textBox1.Text)).ToString();
                    break;
                case Operation.Subtraction:
                    label1.Text = prev + " - " + textBox1.Text + " =";
                    textBox1.Text = (prev - double.Parse(textBox1.Text)).ToString();
                    break;
                case Operation.Multiplication:
                    label1.Text = prev + " x " + textBox1.Text + " =";
                    textBox1.Text = (prev * double.Parse(textBox1.Text)).ToString();
                    break;
                case Operation.Division:
                    label1.Text = prev + " / " + textBox1.Text + " =";
                    textBox1.Text = (prev / double.Parse(textBox1.Text)).ToString();
                    break;
                default:
                    break;
            }
        }
    }

    enum Operation
    {
        None, Addition, Subtraction, Multiplication, Division
    }
}