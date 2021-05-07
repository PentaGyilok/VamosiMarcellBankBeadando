using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Első bankszámla
        /// </summary>
        public static Szamla Elso = new Szamla("Beta",2500);
        /// <summary>
        /// Második bankszámla
        /// </summary>
        public static Szamla Masodik = new Szamla("Alfa",3500);
        /// <summary>
        /// Main window code, indításkor ez fut le legelőször. Létrehozza az ablakot és feltölti a szükséges mezőket a kezdőadatokkal
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            FeltoltoStart();
        }

        /// <summary>
        /// A program indulásakor a négy readonly mezőt tölti fel a számlák adataival.
        /// </summary>
        public void FeltoltoStart()
        {
            Tulaj1.Text = Elso.Tulajnev;
            Egyenleg1.Text = Convert.ToString(Elso.Egyenleg);

            Tulaj2.Text = Masodik.Tulajnev;
            Egyenleg2.Text = Convert.ToString(Masodik.Egyenleg);
        }

        /// <summary>
        /// Ha az első számlára akarjuk a beviteli mezőbe beírt összeget feltölteni, akkor ez a függvény fogja hozzáadni az összeget a számlához.
        /// A Hibás megadott adatok esetén hibaüzenetet ír a usernek.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Feltolt1(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Box1.Text, out int g))
            {
                if (g >= 0)
                {
                    Elso.Egyenleg += g;
                    Egyenleg1.Text = Convert.ToString(Elso.Egyenleg);
                }
                else
                {
                    MessageBox.Show("Negatív összeg nem lehetséges!");
                }
            }
            else
            {
                MessageBox.Show("Az input nem szám!");
            }
        }
        /// <summary>
        /// Utaló függvény az első számlához. A beírt összeget levonja az első számláról és hozzáadja a második számlához.
        /// Nem fogad el olyan összeget, ami negatívba vinné az első számlát és csak pozitív összeget értelmez.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Utal1(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Box1.Text, out int g))
            {
                if (g >= 0)
                {
                    if (Elso.Egyenleg - g >= 0)
                    {
                        Elso.Egyenleg -= g;
                        Egyenleg1.Text = Convert.ToString(Elso.Egyenleg);
                        Masodik.Egyenleg += g;
                        Egyenleg2.Text = Convert.ToString(Masodik.Egyenleg);
                    }
                    else
                    {
                        MessageBox.Show("Nincs elég pénz a számlán!");
                    }
                }
                else
                {
                    MessageBox.Show("Negatív összeg nem lehetséges!");
                }
            }
            else
            {
                MessageBox.Show("Az input nem szám!");
            }
        }
        /// <summary>
        /// Ha az első számláról akarunk pénzt kivenni, akkor a beviteli mezőbe beírt összeget ez a függvény vonja le egyenlegből.
        /// A Hibás megadott adatok esetén hibaüzenetet ír a usernek, illetve ha a kivétel után negatívba fordulna a számlánk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kivet1(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Box1.Text, out int g)) //g a beviteli mezőbe beírt adat, itt nézzük meg, hogy szám-e, vagy új adatot kell bekérni
            {
                if (g >= 0)
                {
                    if (Elso.Egyenleg - g >= 0)
                    {
                        Elso.Egyenleg -= g;
                        Egyenleg1.Text = Convert.ToString(Elso.Egyenleg);
                    }
                    else
                    {
                        MessageBox.Show("Nincs elég pénz a számlán!");
                    }
                }
                else
                {
                    MessageBox.Show("Negatív összeg nem lehetséges!");
                }
            }
            else
            {
                MessageBox.Show("Az input nem szám!");
            }
        }
        /// <summary>
        /// A beviteli mező tartalmát beírja az elso számla tulajdonosának nevéhez.
        /// Csak számokat nem lehet névnek megadni.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TulajNevValt1(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(Box1.Text, out int g))
            {
                Elso.Tulajnev = Box1.Text;
                Tulaj1.Text = Elso.Tulajnev;
            }
            else
            {
                MessageBox.Show("Csak számot nem lehet névnek megadni!");
            }
        }






        /// <summary>
        /// Ha a második számlára akarjuk a beviteli mezőbe beírt összeget feltölteni, akkor ez a függvény fogja hozzáadni az összeget a számlához.
        /// A Hibás megadott adatok esetén hibaüzenetet ír a usernek.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Feltolt2(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Box2.Text, out int g))
            {
                if (g >= 0)
                {
                    Masodik.Egyenleg += g;
                    Egyenleg2.Text = Convert.ToString(Masodik.Egyenleg);
                }
                else
                {
                    MessageBox.Show("Negatív összeg nem lehetséges!");
                }
            }
            else
            {
                MessageBox.Show("Az input nem szám!");
            }
        }
        /// <summary>
        /// Utaló függvény a második számlához. A beírt összeget levonja a második számláról és hozzáadja az első számlához.
        /// Nem fogad el olyan összeget, ami negatívba vinné az első számlát és csak pozitív összeget értelmez.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Utal2(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Box2.Text, out int g))
            {
                if (g >= 0)
                {
                    if (Masodik.Egyenleg - g >= 0)
                    {
                        Masodik.Egyenleg -= g;
                        Egyenleg2.Text = Convert.ToString(Masodik.Egyenleg);
                        Elso.Egyenleg += g;
                        Egyenleg1.Text = Convert.ToString(Elso.Egyenleg);
                    }
                    else
                    {
                        MessageBox.Show("Nincs elég pénz a számlán!");
                    }
                }
                else
                {
                    MessageBox.Show("Negatív összeg nem lehetséges!");
                }
            }
            else
            {
                MessageBox.Show("Az input nem szám!");
            }
        }
        /// <summary>
        /// Ha a második számláról akarunk pénzt kivenni, akkor a beviteli mezőbe beírt összeget ez a függvény vonja le egyenlegből.
        /// A Hibás megadott adatok esetén hibaüzenetet ír a usernek, illetve ha a kivétel után negatívba fordulna a számlánk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kivet2(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Box2.Text, out int g))
            {
                if (g >= 0)
                {
                    if (Masodik.Egyenleg - g >= 0)
                    {
                        Masodik.Egyenleg -= g;
                        Egyenleg2.Text = Convert.ToString(Masodik.Egyenleg);
                    }
                    else
                    {
                        MessageBox.Show("Nincs elég pénz a számlán!");
                    }
                }
                else
                {
                    MessageBox.Show("Negatív összeg nem lehetséges!");
                }
            }
            else
            {
                MessageBox.Show("Az input nem szám!");
            }
        }
        /// <summary>
        /// A beviteli mező tartalmát beírja a második számla tulajdonosának nevéhez.
        /// Csak számokat nem lehet névnek megadni.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TulajNevValt2(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(Box2.Text, out int g))
            {
                Masodik.Tulajnev = Box2.Text;
                Tulaj2.Text = Masodik.Tulajnev;
            }
            else
            {
                MessageBox.Show("Csak számot nem lehet névnek megadni!");
            }
        }
    }
}
