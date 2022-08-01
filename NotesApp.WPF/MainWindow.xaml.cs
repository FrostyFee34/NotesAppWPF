using System.Windows;
using Microsoft.EntityFrameworkCore;
using NotesApp.Domain.Commands;
using NotesApp.Domain.Queries;
using NotesApp.EF;
using NotesApp.EF.Commands;
using NotesApp.EF.Queries;
using NotesApp.WPF.Stores;
using NotesApp.WPF.ViewModels;

namespace NotesApp.WPF
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICreateNoteCommand _createNoteCommand;
        private readonly NotesAppDbContextFactory _dbContextFactory;
        private readonly IDeleteNoteCommand _deleteNoteCommand;
        private readonly IGetAllNotesQuery _getAllNotesQuery;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly NotesStore _notesStore;
        private readonly SelectedNoteStore _selectedNoteStore;
        private readonly IUpdateNoteCommand _updateNoteCommand;

        public MainWindow()
        {
            var connectionString = "Data source=NotesApp.db";
            _dbContextFactory =
                new NotesAppDbContextFactory(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);

            using (var dbContext = _dbContextFactory.Create())
            {
                dbContext.Database.Migrate();
            }

            _updateNoteCommand = new UpdateNoteCommand(_dbContextFactory);
            _deleteNoteCommand = new DeleteNoteCommand(_dbContextFactory);
            _createNoteCommand = new CreateNoteCommand(_dbContextFactory);
            _getAllNotesQuery = new GetAllNotesQuery(_dbContextFactory);

            _modalNavigationStore = new ModalNavigationStore();
            _notesStore = new NotesStore(_updateNoteCommand, _createNoteCommand, _deleteNoteCommand, _getAllNotesQuery);
            _selectedNoteStore = new SelectedNoteStore(_notesStore);


            DataContext = new MainViewModel(_modalNavigationStore,
                new NotesViewModel(_notesStore, _selectedNoteStore, _modalNavigationStore));

            InitializeComponent();
        }
    }
}