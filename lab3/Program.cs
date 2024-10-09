struct Vector
{
    private double x, y, z;

    public Vector(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static Vector operator*(Vector a, Vector b)
    {
        return new Vector(a.y * b.z - a.z * b.y, 
            a.z * b.x - a.x * b.z,
            a.x * b.y - a.y * b.x);
    }

    public static Vector operator *(Vector a, double c)
    {
        return new Vector(a.x * c, a.y * c, a.z * c);
    }

    public static Vector operator *(double c, Vector a)
    {
        return a * c;
    }

    public double Length()
    {
        return Math.Sqrt(x * x + y * y + z * z);
    }

    public static bool operator <(Vector a, Vector b)
    {
        return a.Length() < b.Length();
    }

    public static bool operator >(Vector a, Vector b)
    {
        return a.Length() > b.Length();
    }

    public override string ToString()
    {
        return $"Координаты: ({x}, {y}, {z})";
    }

}

class Program
{
    static void Main(string[] args)
    {
        Vector v1 = new Vector(3, 4, 5);
        Vector v2 = new Vector(1, 2, 3);

        Console.WriteLine(v1 + v2);
        Console.WriteLine(v1 * v2);
        Console.WriteLine(v1 * 5);
        Console.WriteLine(v1 < v2);
    }
}