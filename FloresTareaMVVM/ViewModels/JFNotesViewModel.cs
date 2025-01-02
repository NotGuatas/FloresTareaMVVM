using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using FloresTareaMVVM.Models;
using System.Collections.ObjectModel;


namespace FloresTareaMVVM.ViewModels
{
    internal class JFNotesViewModel : IQueryAttributable
    {
        public ObservableCollection<ViewModels.JFNoteViewModel> AllNotes { get; }
        public ICommand NewCommand { get; }
        public ICommand SelectNoteCommand { get; }

        public JFNotesViewModel()
        {
            AllNotes = new ObservableCollection<ViewModels.JFNoteViewModel>(Models.JFNote.LoadAll().Select(n => new JFNoteViewModel(n)));
            NewCommand = new AsyncRelayCommand(NewNoteAsync);
            SelectNoteCommand = new AsyncRelayCommand<ViewModels.JFNoteViewModel>(SelectNoteAsync);
        }
        private async Task NewNoteAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.JFNotePage));
        }

        private async Task SelectNoteAsync(ViewModels.JFNoteViewModel note)
        {
            if (note != null)
                await Shell.Current.GoToAsync($"{nameof(Views.JFNotePage)}?load={note.Identifier}");
        }
        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("deleted"))
            {
                string noteId = query["deleted"].ToString();
                JFNoteViewModel matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

                // If note exists, delete it
                if (matchedNote != null)
                    AllNotes.Remove(matchedNote);
            }
            else if (query.ContainsKey("saved"))
            {
                string noteId = query["saved"].ToString();
                JFNoteViewModel matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

                // If note is found, update it
                if (matchedNote != null)
                {
                    matchedNote.Reload();
                    AllNotes.Move(AllNotes.IndexOf(matchedNote), 0);
                }

                // If note isn't found, it's new; add it.
                else
                    AllNotes.Insert(0, new JFNoteViewModel(Models.JFNote.Load(noteId)));
            }
        }
    }
}
