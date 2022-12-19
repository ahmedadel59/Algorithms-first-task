using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using System.Threading;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int[] arr = new int[1000];
        int count = 0;
        bool isNotZero(int n)
        {
            return n != 0;
        }
        
        void InsertionSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (inputArray[j - 1] > inputArray[j])
                    {
                        int temp = inputArray[j - 1];
                        inputArray[j - 1] = inputArray[j];
                        inputArray[j] = temp;
                    }
                }
            }
            
        }
        public void MergeArray(int[] array, int left, int middle, int right)
        {
            var leftArrayLength = middle - left + 1;
            var rightArrayLength = right - middle;
            var leftTempArray = new int[leftArrayLength];
            var rightTempArray = new int[rightArrayLength];
            int i, j;
            for (i = 0; i < leftArrayLength; ++i)
                leftTempArray[i] = array[left + i];
            for (j = 0; j < rightArrayLength; ++j)
                rightTempArray[j] = array[middle + 1 + j];
            i = 0;
            j = 0;
            int k = left;
            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (leftTempArray[i] <= rightTempArray[j])
                {
                    array[k++] = leftTempArray[i++];
                }
                else
                {
                    array[k++] = rightTempArray[j++];
                }
            }
            while (i < leftArrayLength)
            {
                array[k++] = leftTempArray[i++];
            }
            while (j < rightArrayLength)
            {
                array[k++] = rightTempArray[j++];
            }
        }
        public int[] SortArray(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                SortArray(array, left, middle);
                SortArray(array, middle + 1, right);
                MergeArray(array, left, middle, right);
            }
            return array;
        }
      

        

       
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bn2_Click(object sender, EventArgs e)
        {
          
            arr[count] = Convert.ToInt32(txt.Text);
            count++;
            txt.Clear();
        }
       
        private void txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void bn_Click(object sender, EventArgs e)
        {
            
            InsertionSort(arr);
            arr = Array.FindAll(arr, isNotZero).ToArray();
            string toDisplay = string.Join(Environment.NewLine, arr);
            MessageBox.Show(toDisplay);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SortArray(arr, 0, arr.Length - 1);
            arr = Array.FindAll(arr, isNotZero).ToArray();
            string toDisplay = string.Join(Environment.NewLine, arr);
            MessageBox.Show(toDisplay);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
