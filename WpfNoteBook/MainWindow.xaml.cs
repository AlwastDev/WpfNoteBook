using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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


namespace WpfNoteBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.CommandBindings.Add(new CommandBinding(ApplicationCommands.Delete, this.DeleteExecuted, this.DeleteCanExecute));
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "TXT files(*.txt)|*.txt"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "TXT files(*.txt)|*.txt"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName, Encoding.Default);
                textBox.Focus();
            }
        }

        private void NEW_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
            textBox.Focus();
            
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog openFileDialog = new SaveFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName, Encoding.Default);
                textBox.Focus();
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        public void DeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        public void DeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            textBox.Text = "";
        }

        private void Word_Wrap_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.TextWrapping == TextWrapping.WrapWithOverflow)
            {
                textBox.TextWrapping = TextWrapping.Wrap;
                wrap.IsCheckable = false;
            }
            else
            {
                textBox.TextWrapping = TextWrapping.WrapWithOverflow;
                wrap.IsCheckable = true;
            }
        }
    }
}
