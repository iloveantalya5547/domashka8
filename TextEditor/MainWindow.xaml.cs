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
using Microsoft.Win32;
using System.IO;
using System.ComponentModel;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        

       
        public MainWindow()
        {
            InitializeComponent();
            
            
        }

        private bool isDirty = false;
        private void txt_TextChanged(object sender, RoutedEventArgs e)
        {
            isDirty = true;
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            txtEditor.Text = "";
        }
        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
        }
        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }

        private void mnuopen_click(object sender, RoutedEventArgs e)
        {
            
            if (openFileDialog.ShowDialog() == true)
                txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
            
        }
        private void mnusave_as_click(object sender, RoutedEventArgs e)
        {
            
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);
            
        }
        private void mnusave_click(object sender, RoutedEventArgs e)
        {
            
        }
        private void mnuexit_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void txtEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int row = txtEditor.GetLineIndexFromCharacterIndex(txtEditor.CaretIndex);
            int col = txtEditor.CaretIndex - txtEditor.GetCharacterIndexFromLineIndex(row);
            lblCursorPosition.Text = "Line " + (row + 1) + ", Char " + (col + 1);
        }
        
    }
}
