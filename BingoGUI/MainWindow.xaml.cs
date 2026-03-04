using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BingoGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBox[,] mezok = new TextBox[5, 5];
        Random rand = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnGeneral_Click(object sender, RoutedEventArgs e)
        {
            gridKartya.Children.Clear();

            for (int oszlop = 0; oszlop < 5; oszlop++)
            {
                List<int> szamok = new List<int>();

                int also = oszlop * 15 + 1;
                int felso = oszlop * 15 + 15;

                while (szamok.Count < 5)
                {
                    int szam = rand.Next(also, felso + 1);
                    if (!szamok.Contains(szam))
                        szamok.Add(szam);
                }

                for (int sor = 0; sor < 5; sor++)
                {
                    TextBox txt = new TextBox();
                    txt.TextAlignment = TextAlignment.Center;
                    txt.FontSize = 16;
                    txt.Margin = new Thickness(2);

                    if (sor == 2 && oszlop == 2)
                    {
                        txt.Text = "X";
                        txt.IsReadOnly = true;
                    }
                    else
                    {
                        txt.Text = szamok[sor].ToString();
                    }

                    mezok[sor, oszlop] = txt;
                    gridKartya.Children.Add(txt);
                }
            }
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(txtFajlnev.Text))
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        sw.Write(mezok[i, j].Text);

                        if (j < 4)
                            sw.Write(";");
                    }
                    sw.WriteLine();
                }
            }
            MessageBox.Show("Sikeres mentés!");
        }
    }
}