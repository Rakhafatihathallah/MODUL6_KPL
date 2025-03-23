using System;


class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;
    
    public SayaTubeVideo(string title)
    {
        this.id = new Random().Next(10000, 100000);
        this.title = title;
        this.playCount = 0;
    }

    public void increasePlayCount(int num)
    {
        playCount += num;
    }

    public void printVideoDetails()
    {
        Console.WriteLine($"ID: [{id}] Title: [{title}] Play Count: [{playCount}]");
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        SayaTubeVideo sayaTubeVideo = new SayaTubeVideo("Tutorial Design By Contract - RakhaFatihAthallah_103022300130");
        sayaTubeVideo.increasePlayCount(10);
        sayaTubeVideo.printVideoDetails();
    }
}

