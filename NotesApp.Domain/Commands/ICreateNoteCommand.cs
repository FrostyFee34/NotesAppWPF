using System;
using System.Threading.Tasks;
using NotesApp.Domain.Models;

namespace NotesApp.Domain.Commands
{
    public interface ICreateNoteCommand
    { 
        Task Execute(Note note);

    }
}