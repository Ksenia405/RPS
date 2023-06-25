using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using LaB3C.Properties;

namespace LaB3C
{
    public partial class Form1 : Form
    {
        double a = 0;
        double step = 0;
        public Form1()
        {
            InitializeComponent();
            checkBox1.Checked = Convert.ToBoolean(Settings.Default["saveChoice"]);
            checkBox3.Checked =Convert.ToBoolean(Settings.Default["menuStart"]);
            if (checkBox3.Checked) MessageBox.Show("Работу выполнил студент группы № 405\nЕмельянова Ксения\nВариант 7.\n\n" +
                "Работа №3. Методология программирования.\n" +
                "Построение трактрисы"
            );
            StartProg();
        }

        private void StartProg() {
            textBox1.Text = "20";
            textBox2.Text = "0,2";
            double strX, strNegX;
            a = 20;
            step=0.2;
            for (double i = 0.2; i < 20; i += 0.2)
            {
                strX = calculateX(i, a);
                strNegX = -strX;
                dataGridView1.Rows.Add(i.ToString("F2"), strX.ToString("F2"), strNegX.ToString("F2"));
                chart1.Series[0].Points.AddXY(Math.Round(strX, 2), Math.Round(i, 2));
                chart1.Series[1].Points.AddXY(Math.Round(strNegX, 2), Math.Round(i, 2));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double y = 0;
            double x, negX;
            #region Ввод входных параметров

            try
            {
                a = Convert.ToDouble(textBox1.Text);
                if (a <= 0)
                {
                    throw new ArgumentException();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Неправильно задан параметр");
                return;
            }

            try
            {
                step = Convert.ToDouble(textBox2.Text);
                if ((step <= 0) || (step >= a))
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неправильно задан шаг");
                return;
            }
            #endregion

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            dataGridView1.Rows.Clear();


            if (Math.Abs(y) + Math.Abs(step) * 2 >= Math.Abs(a))
            {
                MessageBox.Show
                    (
                    text: "График функции вырождается в точку или не может быть построен",
                    caption: "Внимание!",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Warning
                    );
            }

            for (double i = step; i < a; i += step) {
                y = i;
                x = calculateX(y, a);
                negX = -x;
                dataGridView1.Rows.Add(y.ToString("F2"), x.ToString("F2"), negX.ToString("F2"));
                chart1.Series[0].Points.AddXY(Math.Round(x, 2), Math.Round(y, 2));
                chart1.Series[1].Points.AddXY(Math.Round(negX, 2), Math.Round(y, 2));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double x, y, negX;
            var fileContent = string.Empty;
            var filePath = string.Empty;
            filePath = openFileDialog1.FileName;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileStream = openFileDialog1.OpenFile();
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                dataGridView1.Rows.Clear();
                using (StreamReader reader = new StreamReader(fileStream))
                {
                     fileContent = reader.ReadToEnd(); 
                    string[] mas = fileContent.Split(' ', '\r', '\n');
                    List<string> data=new List<string>();
                    for(int k=0; k<mas.Length; k++)
                    {
                        if (mas[k] != "") { data.Add(mas[k]); }
                    }
                   
                    if(checkBox1.Checked==false)
                    for (int i = 0; i < data.Count; i+=3)
                    {
                        
                            try
                            {
                                y = Convert.ToDouble(data[i]);
                                x = Convert.ToDouble(data[i + 1]);
                                negX = Convert.ToDouble(data[i + 2]);
                                if ((x <= 0) || (y <= 0))
                                {
                                    throw new ArgumentException();
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Неправильные данные в файле");
                                    reader.Close();
                                    return;
                            }
                            dataGridView1.Rows.Add(data[i].ToString(), data[i + 1].ToString(), data[i + 2].ToString());
                            chart1.Series[0].Points.AddXY(Math.Round(x, 2), Math.Round(y, 2));
                            chart1.Series[1].Points.AddXY(Math.Round(negX, 2), Math.Round(y, 2));
                        
                    }
                    else {
                        try
                        {
                            a = Convert.ToDouble(data[0]);
                            step = Convert.ToDouble(data[1]);
                            if ((step <= 0) || (step >= a) || (a <= 0)) { throw new ArgumentException(); }
                        }
                        catch (Exception)
                      
                        {
                            MessageBox.Show("Неправильные данные в файле");
                            reader.Close();
                            return;
                        }
                        for (double i = step; i < a; i += step)
                        {
                            y = i;
                            x = calculateX(y, a);
                            negX = -x;
                            dataGridView1.Rows.Add(y.ToString("F2"), x.ToString("F2"), negX.ToString("F2"));
                            chart1.Series[0].Points.AddXY(Math.Round(x, 2), Math.Round(y, 2));
                            chart1.Series[1].Points.AddXY(Math.Round(negX, 2), Math.Round(y, 2));
                        }
                        

                    }

                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            string path;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                if (checkBox1.Checked==false)
                    if (dataGridView1.Rows.Count > 1 && dataGridView1.Rows != null)
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        streamWriter.Write(dataGridView1[j, i].Value + "    ");
                    streamWriter.WriteLine();
                        }
                    else {
                        MessageBox.Show
             (
             text: "Найдены пустые значения",
             caption: "Внимание!",
             buttons: MessageBoxButtons.OK,
             icon: MessageBoxIcon.Warning
             );
                        streamWriter.Close();
                        return;
                    }
                else
                {
                    if ((textBox1.Text!="") && (textBox2.Text!=""))
                    streamWriter.Write(textBox1.Text+"  "+textBox2.Text);
                    else
                    {
                        MessageBox.Show
                (
                text: "Найдены пустые значения",
                caption: "Внимание!",
                buttons: MessageBoxButtons.OK,
                icon: MessageBoxIcon.Warning
                );
                        streamWriter.Close();
                        return;
                    }
                }
                path = saveFileDialog.FileName;
                path = path.Substring(0, path.Length - 3);
                path = path.Insert(path.Length-1, ".jpg");
                this.chart1.SaveImage(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                streamWriter.Close();
            }
        }

        public static double calculateX(double y, double a) {
            return (a * (Math.Log((a + (Math.Sqrt(Math.Pow(a, 2) - Math.Pow(y, 2)))) / y)) - (Math.Sqrt(Math.Pow(a, 2) - Math.Pow(y, 2))));
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default["menuStart"] = checkBox3.Checked;
            Settings.Default.Save();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default["saveChoice"] = checkBox1.Checked;
            Settings.Default.Save();
        }
    }
}
