using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

class MulveySean_Lab1
{
    static void Main(string[] args)
    {
        Start();
            
        

        

       /* List<VideoGame> pubList = new List<VideoGame>();

        foreach (VideoGame vg in vgList)
        {
            totalCount++;
            if (vg.Publisher == "Namco Bandai Games")
            {
                pubCount++;
                pubList.Add(vg);
                Console.WriteLine(vg.Name);
            }
            
        }
        double pubPercent = Math.Round((pubCount / totalCount) * 100, 2);
        Console.WriteLine("Out of "+ totalCount + " Games, " + pubCount + " are developed by Bandai Namco, which is " + pubPercent + "%");

        Console.WriteLine("Press Enter to Continue");
        Console.ReadKey();

        double genCount = 0;
        List<VideoGame> genList = new List<VideoGame>();
        foreach (VideoGame vg in vgList)
        {
            if (vg.Genre == "Role-Playing")
            {
                genCount++;
                genList.Add(vg);
                Console.WriteLine(vg.Name);

            }
        }
        double genPercent = Math.Round((genCount/totalCount)* 100, 2);
        Console.WriteLine("Out of " + totalCount + " Games, " + genCount + " are Role-Playing games, which is " + genPercent + "%");
       */





    }

    public static void Start()
    {
        List<VideoGame> vgList = File.ReadAllLines("videogames.csv").Select(v => CreateVideoGame(v)).ToList();

        vgList.Sort();
        




        Console.WriteLine("Choose How to Filter: \n 1. Publisher \n 2. Genre");

        var filterChoice = Console.ReadLine();

        switch (filterChoice)
        {
            case "1":
                PublisherData(vgList);
                break;
            case "2":
                GenChoice(vgList);
                break;
            default:
                Console.WriteLine("Invalid Choice. Please Try Agan.");
                Start();
                break;

        }
    }
    

    public static void GenChoice(List<VideoGame> list)
    {
        GenreData(list);
    }

    public static void PublisherData(List<VideoGame> list)
    {
        List<VideoGame> pubGames = new List<VideoGame>();
        Console.WriteLine("Choose A Publisher: ");
        var input = Console.ReadLine();
        foreach (var vg in list)
        {
            if (vg.Publisher == input)
            {
                pubGames.Add(vg);
            }
        }
        if (pubGames.Count == 0)
        {
            Console.WriteLine("Publisher not in list. Please try again.");
            Start();
        }
        foreach (var vg in pubGames)
        {
            Console.WriteLine(vg.Name);
        }
        double conPubCount = Convert.ToDouble(pubGames.Count);
        double conlistCount = Convert.ToDouble(list.Count);
        double calc = Math.Round((conPubCount / conlistCount) * 100, 2);
        Console.WriteLine("Out of " + list.Count + " Games, " + pubGames.Count + " are developed by " + input + " , which is " + calc + "%");




    }

    public static void GenreData(List<VideoGame> list) 
    {
        List<VideoGame> genGames = new List<VideoGame>();
        Console.WriteLine("Choose A Genre: ");
        var input = Console.ReadLine();
        foreach (var vg in list)
        {
            if (vg.Genre == input)
            {
                genGames.Add(vg);
            }
        }
        if (genGames.Count == 0)
        {
            Console.WriteLine("Genre not in list. Please try again.");
            Start();
        }
        foreach (var vg in genGames)
        {
            Console.WriteLine(vg.Name);
        }
        double conGenCount = Convert.ToDouble(genGames.Count);
        double conlistCount = Convert.ToDouble(list.Count);
        double calc = Math.Round((conGenCount / conlistCount) * 100, 2);
        Console.WriteLine("Out of " + list.Count + " Games, " + genGames.Count + " are " + input + " Games, which is " + calc + "%");
    }

    public static VideoGame CreateVideoGame(string line)
    {
        string[] values = line.Split(',');
        VideoGame videoGame = new VideoGame();
        videoGame.Name = values[0];
        

        videoGame.Platform = values[1];
        

        videoGame.Year = Convert.ToInt32(values[2]);
        

        videoGame.Genre = values[3];
        

        videoGame.Publisher = values[4];
        


        videoGame.NASales = Convert.ToDouble(values[5]);
        videoGame.EUSales = Convert.ToDouble(values[6]);
        videoGame.JPSales = Convert.ToDouble(values[7]);
        videoGame.OtherSales = Convert.ToDouble(values[8]);
        videoGame.GlobalSales = Convert.ToDouble(values[9]);
        return videoGame;
    }

  

    
        



}

public class VideoGame : IComparable<VideoGame> 
{
    
    private string name;
    private string platform;
    private string genre;
    private string publisher;
    private int year;
    private double NA_Sales;
    private double EU_Sales;
    private double JP_Sales;
    private double Other_Sales;
    private double Global_Sales;

    public VideoGame()
    {

    }

    public VideoGame(string _name, string _platform, string _genre, string _publisher,
    int _year, double naSales, double euSales, double jpSales, double otherSales, double globalSales)
    {
        name = _name;
        platform = _platform;
        genre = _genre;
        publisher = _publisher;
        year = _year;
        NA_Sales = naSales;
        EU_Sales = euSales;
        JP_Sales = jpSales;
        Other_Sales = otherSales;
        Global_Sales = globalSales;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Platform
    {
        get => platform;
        set => platform = value;
    }

    public string Genre
    {
        get => genre;
        set => genre = value;
    }


    public string Publisher
    {
        get => publisher;
        set => publisher = value;
    }

    public int Year
    {
        get => year;
        set => year = value;
    }

    public double NASales
    {
        get => NA_Sales;
        set => NA_Sales = value;
    }

    public double EUSales
    {
        get => EU_Sales;
        set => EU_Sales = value;

    }

    public double JPSales
    {
        get => JP_Sales;
        set => JP_Sales = value;

    }

    public double OtherSales
    {
        get => Other_Sales;
        set => Other_Sales = value;

    }

    public double GlobalSales
    {
        get => Global_Sales;
        set => Global_Sales = value;
    }
    

    public int CompareTo(VideoGame? other)
    {
        if (other == null)
        {
            return 1;
        }
        return Name.CompareTo(other.Name);
    }
}