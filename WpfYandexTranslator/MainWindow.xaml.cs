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
using TranslatorLibrary;

namespace WpfYandexTranslator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Translator translator = new XmlTranslator();

        public MainWindow()
        {
            InitializeComponent();

            ComboBoxFromLang.ItemsSource = Translator.AvaliableLanguages.Values;
            ComboBoxFromLang.SelectedItem = Translator.AvaliableLanguages["en"];

            ComboBoxToLang.ItemsSource = Translator.AvaliableLanguages.Values;
            ComboBoxToLang.SelectedItem = Translator.AvaliableLanguages["ru"];
        }

        private void TextBoxOriginal_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxTranslated.Text = translator.Translate(TextBoxOriginal.Text,
                Translator.AvaliableLanguages.ElementAt(ComboBoxToLang.SelectedIndex).Key,
                Translator.AvaliableLanguages.ElementAt(ComboBoxFromLang.SelectedIndex).Key);
        }
    }
}
