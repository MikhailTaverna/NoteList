using System;


namespace NoteList
{
    [Serializable]
    public class Note
    {
        public string Head { get; private set; }
        public string Content { get; private set; }
        public DateTime CreationTime { get; private set; }

        public Note()
        {
            Create();
        }
        private void Create()
        {
            Console.WriteLine("Введите заголовок ");
            Head = Console.ReadLine();
            Console.WriteLine("Введите содержимое ");
            Content = Console.ReadLine();
            CreationTime = DateTime.UtcNow;

        }
        public void Redact()
        {
            Console.WriteLine("Введите содержимое ");
            Content = Console.ReadLine();
            CreationTime = DateTime.UtcNow;
        }
        public override string ToString()
        {
            return Head;
        }
    }
}
