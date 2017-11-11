using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AISD_lab8
{
    public partial class Form1 : Form
    {
        private int[] iArray = null;
        private uint uiSize = 0;

        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 6 || !(uint.TryParse(textBox1.Text, out uint _uiSize)))
            {
                MessageBox.Show("Incorrect count of elements");
                return;
            }

            uiSize = _uiSize;
            
            dataGridView1.Rows.Clear();
            richTextBox1.Clear();

            iArray = new int[uiSize];

            Random rnd = new Random();
            for (uint i = 0; i < uiSize; ++i)
            {
                iArray[i] = rnd.Next(0, 100000);
                dataGridView1.Rows.Add(Convert.ToString(iArray[i]));
            }
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (uiSize == 0 || iArray == null)
            {
                MessageBox.Show("First of all, generate random elements");
                return;
            }

            //Searching min element(iMin)
            int iMin = iArray[0];
            for (uint i = 0; i < uiSize; i++)
            {
                if (iMin > iArray[i])
                {
                    iMin = iArray[i];
                }
            }

            //Finding in an array larger or equal element for a doubled product of minimum element(iMin)
            int iMinDoubleProduct = 2 * iMin * iMin;
            bool isFounded = false;
            uint uiPos = 0;
            uint uiCountOfComparsions = 0;
            for (uint i = 0; i < uiSize; i++)
            {
                ++uiCountOfComparsions;
                if (iArray[i] >= iMinDoubleProduct)
                {
                    uiPos = i;
                    isFounded = true;
                    break;
                }
            }

            richTextBox1.Clear();

            // Output results
            if (isFounded)
            {
                richTextBox1.Text += "Position of founded element: " + (uiPos + 1).ToString() + "\nCount of comparsions: " + uiCountOfComparsions.ToString();
            }
            else
            {
                richTextBox1.Text += "Element hasn't been founded\nCount of comparsions: " + uiCountOfComparsions.ToString();
            }
            button2.Enabled = false;
        }
    }
}
