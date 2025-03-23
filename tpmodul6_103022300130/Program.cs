using System;
using System.Diagnostics;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        try
        {
            Debug.Assert(!string.IsNullOrEmpty(title), "Title tidak boleh kosong");
            Debug.Assert(title.Length <= 100, "Title video tidak boleh lebih dari 100 karakter");

            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("Title tidak boleh kosong");

            if (title.Length > 100)
                throw new ArgumentException("Title terlalu panjang! Maksimum 100 karakter.");

            this.id = new Random().Next(10000, 100000);
            this.title = title;
            this.playCount = 0;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saat membuat video: {e.Message}");
            this.title = "Judul Tidak Valid";
            this.playCount = 0;
        }
    }

    public void IncreasePlayCount(int num)
    {
        try
        {
            Debug.Assert(num < 10_000_000, "Nilai playcount tidak boleh lebih dari 10.000.000");

            if (num >= 10_000_000)
                throw new ArgumentOutOfRangeException("Nilai playcount terlalu besar!");

            checked
            {
                playCount += num;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: Play count mengalami overflow!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saat menambah play count: {e.Message}");
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID: {id} | Title: {title} | Play Count: {playCount}");
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - Rakha Fatih Athallah_103022300130");
        video.PrintVideoDetails();

        try
        {
            for (int i = 0; i < 10; i++) 
            {
                video.IncreasePlayCount(1_000_000);
                video.PrintVideoDetails();
            }

            video.IncreasePlayCount(int.MaxValue - 1);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Test selesai: Play count mengalami overflow!");
        }
    }
}
