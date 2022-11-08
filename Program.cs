using static System.Console;
using System;
using System.Collections.Generic;
using System.Collections;
List<Book> listbooks = new List<Book>()
{
    new Book()
    {
        inx=0,
        Title="Медный всадник",
        Author="А.С. Пушкин",
        Genre = "Роман",
        ReleaseYear = new DateTime(1833,10,20),
    }
};
Book();
int BookIndex(int c)
{
    for (int i = 0; i < listbooks.Count; i++)
    {
        if (listbooks[i].inx == c)
            return i;
    }
    return -1;
}
int BookSelection()
{
    string str;
    int choice;
    do
    {
        str = ReadLine();
        if (Int32.TryParse(str, out choice) && choice < listbooks.Count)
        {
            if (BookIndex(choice) != -1)
                return BookIndex(choice);
        }
        WriteLine("Книги с таким индексом нет в списке!");
    } while (true);
}
void ShowAllBooks()
{
    Clear();
    WriteLine("Список книг:\n");
    if (listbooks.Count == 0)
    {
        WriteLine("У вас нет книг в списке.\n");
    }
    else
    {
        foreach (Book i in listbooks)
        {
            i.show();
        }
    }
    
}
void Add()
{
    Clear();
    string title, author, genre;
    DateTime year;
    WriteLine("Введите название книги: ");
    title = ReadLine();
    WriteLine("Введите автора книги: ");
    author = ReadLine();
    WriteLine("Введите жанр книги: ");
    genre = ReadLine();
    WriteLine("Введите год выпуска: ");
    year = date_in();
    listbooks.Add(
        new Book
        {
            inx = listbooks.Last().inx + 1,
            Author = author,
            Title = title,
            Genre = genre,
            ReleaseYear = year
        }) ;

}
void Delete()
{
    Clear();
    ShowAllBooks();
    WriteLine("Введите индекс книги, которую хотите удалить:");
    listbooks.RemoveAt(BookSelection());
    WriteLine("Вы успешно удалили книгу.");
}

//void FindBook()
//{
//    Clear();
//    int c;
//    Book book=new Book();
//    WriteLine("Введите индекс книги, которую хотите найти:");
//    c = Convert.ToInt32(ReadLine());
//    foreach(Book i in listbooks)
//    {
//        if (listbooks.Contains(i))
//        {
//            i.show();
//        }
//    }
//}

DateTime date_in()
{
    int year;
    int m = Convert.ToInt32(DateTime.Now.Month),
        d = Convert.ToInt32(DateTime.Now.Day);
    string str;
    do
    {
        str = ReadLine();
        if (Int32.TryParse(str, out year) && year >= DateTime.Now.Year)
            break;
        else
            WriteLine("Вы ввели год больше чем сейчас!");
    } while (true);
    return new DateTime(year,m,d);
}
void Book()
{
    int choice;
    
    do
    {
        WriteLine("Для продолжения нажмите любую клавишу...");
        ReadKey(true);
        Clear();
        WriteLine("Введите пункт меню:\n" +
        "1-Добавить книгу\n" +
        "2-Удалить книгу\n" +
        "3-Вывести все книги\n" +
        "0-Выйти\n");
        choice = Convert.ToInt32(ReadLine());

        switch (choice)
        {
            case 1:
                Add();
                break;
            case 2:
                Delete();
                break;
            case 3:
                ShowAllBooks();
                break;
            case 0:
                break;
            default:
                WriteLine("Ошибка");
                break;
        }
    } while (choice != 0);
    Clear();
}
class Book
{
    public int inx;
    public string Author { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime ReleaseYear { get; set; }
    public void show()
    {

        WriteLine($"Индекс книги: {inx}\n" +
            $"Название книги: {Title}\n" +
            $"Автор книги: {Author}\n" +
            $"Жанр книги: {Genre}\n" +
            $"Год выпуска: {ReleaseYear.Year} год\n"
            );
    }
}
