using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloresTareaMVVM.ViewModels
{
    internal class JFNoteViewModel : ObservableObject, IQueryAttributable
    {
        private Models.JFNote _note;
        public JFNoteViewModel()
        {
            _note = new Models.JFNote();
            SaveCommand = new AsyncRelayCommand(Save);
            DeleteCommand = new AsyncRelayCommand(Delete);
        }

        private async Task Save()
        {
            _note.Date = DateTime.Now;
            _note.Save();
            await Shell.Current.GoToAsync($"..?saved={_note.Filename}");
        }

        private async Task Delete()
        {
            _note.Delete();
            await Shell.Current.GoToAsync($"..?deleted={_note.Filename}");
        }
        public JFNoteViewModel(Models.JFNote note)
        {
            _note = note;
            SaveCommand = new AsyncRelayCommand(Save);
            DeleteCommand = new AsyncRelayCommand(Delete);
        }
        public string Text
        {
            get => _note.Text;
            set
            {
                if (_note.Text != value)
                {
                    _note.Text = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Date => _note.Date;

        public string Identifier => _note.Filename;
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("load"))
            {
                _note = Models.JFNote.Load(query["load"].ToString());
                RefreshProperties();
            }
        }

        public void Reload()
        {
            _note = Models.JFNote.Load(_note.Filename);
            RefreshProperties();
        }

        private void RefreshProperties()
        {
            OnPropertyChanged(nameof(Text));
            OnPropertyChanged(nameof(Date));
        }
    }
}
