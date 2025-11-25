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

namespace konyvtaribeiratkozas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		private string filePath = "olvasok.txt";

		public MainWindow()
        {
			Betoltes();
			InitializeComponent();
        }

		private void Betoltes()
		{
			if (File.Exists(filePath))
			{
				string[] sorok = File.ReadAllLines(filePath);
				foreach (string sor in sorok)
				{
					string[] adatok = sor.Split(';');
					if (adatok.Length >= 5)
					{
						lstOlvasok.Items.Add(adatok[0]);
					}
				}
			}
		}

		private void btnMentes_Click(object sender, RoutedEventArgs e)
		{
			if (!int.TryParse(txtEletkor.Text, out int eletkor))
			{
				MessageBox.Show("Az életkor csak szám lehet!");
				return;
			}

			string mufaj = (cmbMufaj.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content.ToString() ?? "nincs kiválasztva";

			string ertesitesek = "";
			if (chkHirlevel.IsChecked == true) ertesitesek += "Hírlevél ";
			if (chkSms.IsChecked == true) ertesitesek += "SMS ";
			if (string.IsNullOrEmpty(ertesitesek)) ertesitesek = "nincs";

			string tagsag = rbNormal.IsChecked == true ? "Normál" :
							rbDiak.IsChecked == true ? "Diák" :
							rbNyugdijas.IsChecked == true ? "Nyugdíjas" :
							"nincs kiválasztva";

			Olvaso ujOlvaso = new Olvaso
			{
				Nev = txtNev.Text,
				Eletkor = eletkor,
				Mufaj = mufaj,
				Ertesitesek = ertesitesek,
				Tagsag = tagsag
			};

			File.AppendAllText(filePath, ujOlvaso.ToString() + Environment.NewLine);
			txtVisszajelzes.Text = "Regisztráció sikeres volt!";
			lstOlvasok.Items.Add(ujOlvaso.Nev);
		}
	}
}