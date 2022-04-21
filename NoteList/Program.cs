using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace NoteList
{
    [Serializable]
    class Program
    {
        static void Main(string[] args)
        {
            Note selectedNote;
            NoteList notes = new NoteList();
            int index;
            int command = -1;
            bool isOperationCorrect;


            Load();
            while (true)
            {                               
                notes.ShowList();
                
                Console.WriteLine("Выберите действие:\n1 - Добавить запись\n2 - Выбрать запись\n0 - Выход");
                isOperationCorrect = int.TryParse(Console.ReadLine(), out command);
                if (isOperationCorrect == false)
                {
                    Console.Clear();
                    Console.WriteLine("Неверный формат ввода");
                    continue;
                }
                switch (command)
                {
                    case 1:
                        notes.Add();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Введите номер записи");
                        index = int.Parse(Console.ReadLine());
                        Console.Clear();
                        SelectNote(index);
                        break;
                    case 0:
                        Save();
                        return;
                    default:                        
                        Console.Clear();
                        Console.WriteLine("Дейтсвие не найдено");
                        break;
                }
            }
            void SelectNote(int selectedIndex)
            {
                if(selectedIndex > notes.notes.Count)
                {
                    Console.WriteLine("Записи с таким номером нет");
                    return;
                }
                selectedNote = notes.notes[selectedIndex - 1];
                notes.ShowNote(selectedNote);
                ManageNote(selectedNote);
            }
            void ManageNote(Note note)
            {
                int noteCommand = -1;
                while (true)
                {
                    Console.WriteLine("Выберите действие:\t1 - Редактировать запись\t2 - Удалить запись\t0 - Выход");
                    isOperationCorrect = int.TryParse(Console.ReadLine(), out noteCommand);
                    if (isOperationCorrect == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Неверный формат ввода");
                        continue;
                    }
                    switch (noteCommand)
                    {
                        case 1:
                            note.Redact();
                            Console.Clear();
                            notes.ShowNote(note);
                            break;
                        case 2:
                            notes.Delete(note);
                            Console.Clear();
                            return;
                        case 0:
                            Console.Clear();
                            return;
                        default:
                            Console.WriteLine("Команда не найдена");
                            break;
                    }
                }
            }
            void Save()
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using(FileStream fs = new FileStream("notes.dat", FileMode.Create))
                {
                    formatter.Serialize(fs, notes);
                }
            }
            void Load()
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream("notes.dat", FileMode.OpenOrCreate))
                {

                    if(fs.Length != 0)
                    {
                        notes = (NoteList)formatter.Deserialize(fs);
                    }
                    
                }
            }
        }
    }
}
