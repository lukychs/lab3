class Car : IEquatable<Car>
{
    public string Name { get; set; }
    public string Engine { get; set; }
    public double MaxSpeed { get; set; }

    public Car(string Name, string Engine, double MaxSpeed)
    {
        this.Name = Name;
        this.Engine = Engine;
        this.MaxSpeed = MaxSpeed;
    }

    public bool Equals (Car other)
    {
        if (Name == other.Name && Engine == other.Engine && MaxSpeed == other.MaxSpeed)
        {
            return true;
        }
        else
        {  
            return false; 
        }
    }

    public override string ToString()
    {
        return Name;
    }

}

class CarsCatalog
{
    List<Car> cars = new List<Car>();  

    public string this[int index]
    {
        get
        {
            if (index >= 0 && index  < cars.Count)
            {
                return $"Название машины: {cars[index].Name}, тип двигателя: {cars[index].Engine}";
            }
            else
                throw new ArgumentOutOfRangeException();
        }
    }

    public void AddCar(Car car)
    {
        cars.Add(car);
    }
}

class Program
{
    static void Main(string[] args)
    {
        CarsCatalog catalog = new CarsCatalog();

        Car car1 = new Car ("Chevrolet Camaro", "6.2 L LT4", 150);
        Car car2 = new Car("Nissan Skyline", "Galla 12", 250);
        Car car3 = new Car("DeLorean DMC-12", "MisterFusion", 88);
        Car car4 = new Car("DeLorean DMC-12", "MisterFusion", 88);

        catalog.AddCar(car1);
        catalog.AddCar(car2);
        catalog.AddCar(car3);

        Console.WriteLine(catalog[0]);
        Console.WriteLine(catalog[1]);
        Console.WriteLine(catalog[2]);

        Console.WriteLine(car1.Equals(car2));
        Console.WriteLine (car3.Equals(car1));
        Console.WriteLine(car3.Equals(car4));
    }
}