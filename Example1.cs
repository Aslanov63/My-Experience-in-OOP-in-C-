using System;
using System.Configuration.Assemblies;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
enum CarModification
{
    Economy,
    Medium,
    Sport,
    Suv,
    Luxury,
    Truck
}

class Cars{

    static Cars()
    {
        Console.WriteLine("Welcome to the Car Wiki!");
        Console.WriteLine("Country of Origin: " + country);
        Console.WriteLine("Time: " + DateTime.Now);

    }
    public Cars(string brand, string model, CarModification type, string EngineType)
    {
        this.brand = brand;
        this.model = model;
        this.type = type;
        this.EngineType = EngineType;
        this.age = 10;
        print();
     
    }

    public Cars()
    {

    }
        public string brand;
    public const string country = "Germany";
    public string model;
    public CarModification type;
    public string EngineType = "Unknown";
    private static string CustomerNumber = "#232";
   
   public static string Custmernumber
    {
        get
        {
            return CustomerNumber;
        }
     
      
    }

    private static string Transport_Type = "Automobile";
    public static string TransportType
    {
            get
        {
                return Transport_Type;
            }
            set
         {
                Transport_Type = value;
            }
        }


    private int age;




    public int MyProperty
    {
        get { return age; }
        set { age = value; }

    }


    protected const string error_01 = "Car is not started!";
    protected const string error_02 = "Car is already started!";

    protected bool engineStatus = false;
    public void print(){   
        Console.WriteLine($"Brand: {brand} Model: {model} Type: {type} Engine: {EngineType} With the age of: {age}");
    }
    public void StartEngine()
    {
        if (engineStatus)
        {
            Console.WriteLine(error_02);
            return;
        }
        Console.WriteLine($"{EngineType} started");
    }
    public void StopEngine()
    {
        if (!engineStatus)
        {
            Console.WriteLine(error_01);
            return;
        }
        Console.WriteLine($"{EngineType} stopped");
    }
}
class Trucks : Cars
{
    public int loadCapacity;
    public void liftLoad()
    {
        
        if (engineStatus)
        {
            
           Console.WriteLine($"Lifting load with capacity of {loadCapacity} kg");
        }
        else
        {
            Console.WriteLine(error_01);
        }
    }
    public Trucks(string brand, string model, CarModification type, string EngineType, int loadCapacity) : base(brand, model, type, EngineType)
    {
        this.loadCapacity = loadCapacity;
        
    }
    




}
class Program
{



    static void Main(string[] args)
    {
        Cars e_class = new Cars("Mercedes-Benz", "E-class", CarModification.Medium, "Diesel I4");
        int currentAge = e_class.MyProperty;
        string Transport_Type = "Automobile";
       
        string customerNumber = Cars.Custmernumber;
        Console.WriteLine($"Customer Number: {customerNumber}");

        Console.WriteLine($"Current Age: {currentAge}");
        Console.WriteLine($"Transport Type: {Cars.TransportType}");
        Cars.TransportType = "Truck";
        Console.WriteLine($"New Transport Type: {Cars.TransportType}");

        Trucks actros = new Trucks("Mercedes-Benz", "Actros", CarModification.Truck, "Diesel I6", 18000);
        actros.StopEngine();
        actros.liftLoad();

    }
}