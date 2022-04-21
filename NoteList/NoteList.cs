using System;
using System.Collections.Generic;


namespace NoteList
{
    [Serializable]
    public class NoteList
    {
        public List<Note> notes = new List<Note>();
        

        public void Add()
        {
            Note note = new Note();
            notes.Add(note);
        }
        public void Delete(Note note)
        {
            notes.Remove(note);
        }
        public void ShowList()
        {
            int i = 1;
            foreach (var note in notes)
            {
                Console.WriteLine($"\t{i} - {note.Head}");
                i++;
            }
            
        }
        public void ShowNote(Note note)
        {
            Console.WriteLine(note.Head);
            Console.WriteLine($"\n{note.Content}\n");
            Console.WriteLine($"Создано: {note.CreationTime}");
        }
    }
}
