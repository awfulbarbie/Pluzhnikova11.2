namespace lab11_graph_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Matrix
        {
            //���� ������
            double[][] DoubleArray;
            int n;
            int m;

            public Matrix(int rows, int cols)       //����������� �������
            {
                n = rows;
                m = cols;
                DoubleArray = new double[n][];
            }
            public void EnterElements(TextBox textBox1)     //���������� �������
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))       //��������, ���� ������ ������
                {
                    MessageBox.Show("������� �������� �������.", "������",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var sNums = new string[n, m];
                var arr1 = textBox1.Text.Split('\n');       //���������� ����� ��������� � textbox1
                if (arr1.Length != n)
                {
                    MessageBox.Show("����� ������� �� ������������� ����������!", "������",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                for (int i = 0; i < n; i++)
                {
                    var arr2 = arr1[i].Split(' ');
                    if (arr2.Length != m)
                    {
                        MessageBox.Show("����� ������� �� ������������� ����������!", "������",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    for (int j = 0; j < m; j++)
                    {
                        sNums[i, j] = arr2[j];
                    }
                }

                try
                {
                    for (int i = 0; i < n; i++)
                    {
                        DoubleArray[i] = new double[m];
                        for (int j = 0; j < m; j++)
                        {

                            DoubleArray[i][j] = double.Parse(sNums[i, j]);
                        }
                    }
                    MessageBox.Show("������ ��������", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (FormatException)
                {
                    MessageBox.Show("������������ ���� ������. ���������� �����", "������",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            public void PrintMatrix(TextBox textBox2)        //����� ������� �� �����
            {
                for (int i = 0; i < DoubleArray.Length; i++)
                {
                    for (int j = 0; j < DoubleArray[i].Length; j++)
                    {
                        textBox2.Text += DoubleArray[i][j] + "\t";
                    }
                    textBox2.Text += Environment.NewLine;
                }

            }
            public void Sort()      //���������� ������� (������������� �������� ������ ������ ������� � ������� ��������)
            {
                for (var i = 0; i < DoubleArray.Length; ++i)
                {
                    Array.Sort(DoubleArray[i]);
                    Array.Reverse(DoubleArray[i]);
                }
            }
            public int ElementCount        //������� ���������� ��������� � �������
            {
                get { return n * m; }       //�������� ��� ������ ���������� ���������� ������
            }

            public double ScalarMultiply        //���������� �� ������
            {
                set     //�������� ��� ������ �������� �� ���������� ���� ������
                {
                    double roundTo = Math.Pow(10, 1);
                    for (int i = 0; i < DoubleArray.Length; i++)
                    {
                        for (int j = 0; j < DoubleArray[i].Length; j++)
                        {
                            DoubleArray[i][j] = Math.Truncate((DoubleArray[i][j] += value) * roundTo) / roundTo;        //����������
                                 //value - ������� ��������, ���������� ��������, ������� ������������� ��������
                        }

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            int m = 0;

            try
            {

                if (numericUpDown1.Value <= 0)
                {
                    MessageBox.Show("���������� ����� �� ����� ����� ������������� ��� ������� ��������!", "������",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            catch
            {
                MessageBox.Show("�������� ������ ����� ������!", "������",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            n = (int)numericUpDown1.Value;

            try
            {

                if (numericUpDown2.Value <= 0)
                {
                    MessageBox.Show("���������� �������� �� ����� ����� ������������� ��� ������� ��������!", "������",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            catch
            {
                MessageBox.Show("�������� ������ ����� ������!", "������",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            m = (int)numericUpDown2.Value;

            Matrix newMatrix = new Matrix(n, m);        //�������� ����������
                                                        //����� ������� ������

            newMatrix.EnterElements(textBox1);
            newMatrix.PrintMatrix(textBox2);
            newMatrix.Sort();
            newMatrix.PrintMatrix(textBox3);

            textBox4.Text += $"���������� ��������� � �������: {newMatrix.ElementCount}";
            double scalar = 0;
            try
            {

                if (numericUpDown3.Value <= 0)
                {
                    MessageBox.Show("������ �� ����� ����� ������������� ��� ������� ��������!", "������", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            catch
            {
                MessageBox.Show("�������� ������ ����� ������!", "������", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            scalar = (double)numericUpDown3.Value;
            //str += $"{DoubleArray[i][j]:f2}";
            newMatrix.ScalarMultiply = scalar;
            newMatrix.PrintMatrix(textBox5);

            textBox5.Text += "��� �������� ��������� �� ������";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Clear();
            textBox2.Text = "";
            textBox2.Clear();
            textBox3.Text = "";
            textBox3.Clear();
            textBox4.Text = "";
            textBox4.Clear();
            textBox5.Text = "";
            textBox5.Clear();
        }
    }
}

