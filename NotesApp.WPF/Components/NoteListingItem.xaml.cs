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

namespace NotesApp.WPF.Components
{
    /// <summary>
    /// Interaction logic for NoteListingItem.xaml
    /// </summary>
    public partial class NoteListingItem : UserControl
    {
        public NoteListingItem()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            DropdownMenu.IsOpen = false;
        }
    }
}
