using System;

//
// Abstract base to demonstrate abstract method/class concept
//
public abstract class BaseVector
{
    // abstract method to demonstrate abstraction (must be implemented by concrete descendant)
    public abstract int GetDimension();
}

//
// Concrete base class that contains members shared by 3D and 4D vectors.
// Provides virtual Info() to be overridden by descendants.
//
public class VectorFoundation : BaseVector
{
    protected float coordinateX;
    protected float coordinateY;
    protected float coordinateZ;

    // constructor
    public VectorFoundation(float xVal = 0, float yVal = 0, float zVal = 0)
    {
        coordinateX = xVal;
        coordinateY = yVal;
        coordinateZ = zVal;
    }

    // properties (encapsulation)
    public float PropX { get => coordinateX; set => coordinateX = value; }
    public float PropY { get => coordinateY; set => coordinateY = value; }
    public float PropZ { get => coordinateZ; set => coordinateZ = value; }

    // virtual Info — default behaviour for base class
    public virtual void ShowInfo()
    {
        Console.WriteLine("[Base Info] Type: {0}", this.GetType().Name);
        Console.WriteLine($" Components: X={coordinateX} Y={coordinateY} Z={coordinateZ}");
        Console.WriteLine($" Dimension: {GetDimension()}");
        Console.WriteLine($" Magnitude(3D): {CalculateLength():F3}");
    }

    // virtual length for 3D magnitude (can be overridden by 4D)
    public virtual float CalculateLength()
    {
        return (float)Math.Sqrt(coordinateX * coordinateX + coordinateY * coordinateY + coordinateZ * coordinateZ);
    }

    // implement abstract method
    public override int GetDimension() => 3;
}

//
// 3D vector: inherits from VectorFoundation and overrides ShowInfo() (polymorphism).
//
public class Vector3D : VectorFoundation
{
    // constructors
    public Vector3D(float xVal = 0, float yVal = 0, float zVal = 0) : base(xVal, yVal, zVal) { }

    // override ShowInfo and call base.ShowInfo() to show both implementations
    public override void ShowInfo()
    {
        // call base implementation (demonstrates default behaviour)
        base.ShowInfo();
        // add derived-specific info
        Console.WriteLine("[Vector3D Info] Additional 3D-specific info:");
        Console.WriteLine($" X+Y+Z = {PropX + PropY + PropZ}");
    }

    // operators and methods using inherited fields/properties
    public static Vector3D operator +(Vector3D vectorA, Vector3D vectorB)
        => new Vector3D(vectorA.PropX + vectorB.PropX, vectorA.PropY + vectorB.PropY, vectorA.PropZ + vectorB.PropZ);

    public static Vector3D operator -(Vector3D vectorA, Vector3D vectorB)
        => new Vector3D(vectorA.PropX - vectorB.PropX, vectorA.PropY - vectorB.PropY, vectorA.PropZ - vectorB.PropZ);

    public static Vector3D operator *(Vector3D vectorA, Vector3D vectorB)
        => new Vector3D(vectorA.PropX * vectorB.PropX, vectorA.PropY * vectorB.PropY, vectorA.PropZ * vectorB.PropZ);

    public Vector3D CrossProduct(Vector3D otherVector)
        => new Vector3D(
            PropY * otherVector.PropZ - PropZ * otherVector.PropY,
            PropZ * otherVector.PropX - PropX * otherVector.PropZ,
            PropX * otherVector.PropY - PropY * otherVector.PropX
        );

    public float Get3DLength() => CalculateLength();

    public bool IsEqual(Vector3D otherVector)
        => PropX == otherVector.PropX && PropY == otherVector.PropY && PropZ == otherVector.PropZ;

    // convenience print that uses ShowInfo
    public void DisplayData() => ShowInfo();
}

//
// 4D vector: inherits from VectorFoundation, adds W and overrides ShowInfo/CalculateLength/GetDimension.
//
public class Vector4D : VectorFoundation
{
    protected float coordinateW;

    public Vector4D() : base(0, 0, 0) { coordinateW = 0; }
    public Vector4D(float xVal, float yVal, float zVal, float wVal) : base(xVal, yVal, zVal) { coordinateW = wVal; }

    public float PropW { get => coordinateW; set => coordinateW = value; }

    // override dimension to 4
    public override int GetDimension() => 4;

    // override length to include W
    public override float CalculateLength() => (float)Math.Sqrt(PropX * PropX + PropY * PropY + PropZ * PropZ + coordinateW * coordinateW);

    // override ShowInfo and call base.ShowInfo() to include base implementation output too
    public override void ShowInfo()
    {
        base.ShowInfo(); // prints base info (components X,Y,Z etc.)
        Console.WriteLine("[Vector4D Info] 4D-specific data:");
        Console.WriteLine($" W = {coordinateW}");
        Console.WriteLine($" Dimension (override) = {GetDimension()}");
        Console.WriteLine($" Magnitude(4D) = {CalculateLength():F3}");
    }

    // methods to set values (overloads)
    public void AssignValues(float xVal, float yVal, float zVal) => AssignValues(xVal, yVal, zVal, 0);
    public void AssignValues(float xVal, float yVal, float zVal, float wVal)
    {
        PropX = xVal; PropY = yVal; PropZ = zVal; coordinateW = wVal;
    }

    public void DisplayData() => ShowInfo();
}

class MainProgram
{
    static void Main()
    {
        // Program identification
        Console.WriteLine("Program: Lab2 - Inheritance and Polymorphism demo");
        Console.WriteLine("Author: (Aslanov63)");
        Console.WriteLine("Start time: " + DateTime.Now);
        Console.WriteLine();

        // Demonstrate base class instance (shows base ShowInfo implementation)
        VectorFoundation baseVector = new VectorFoundation(1, 1, 1);
        Console.WriteLine(">>> Calling baseVector.ShowInfo() (base implementation):");
        baseVector.ShowInfo();
        Console.WriteLine();

        // Demonstrate Vector3D — override calls base.ShowInfo() then derived info
        Vector3D firstVector = new Vector3D(1, 2, 3);
        Vector3D secondVector = new Vector3D(4, 5, 6);

        Console.WriteLine(">>> Vector3D firstVector and secondVector:");
        firstVector.DisplayData();
        secondVector.DisplayData();
        Console.WriteLine();

        Console.WriteLine(">>> firstVector + secondVector:");
        var resultVector = firstVector + secondVector;
        resultVector.DisplayData();
        Console.WriteLine();

        Console.WriteLine(">>> cross firstVector x secondVector:");
        var crossResult = firstVector.CrossProduct(secondVector);
        crossResult.DisplayData();
        Console.WriteLine();

        // Demonstrate Vector4D — override includes base.ShowInfo() output as well
        Vector4D vector4D = new Vector4D(2, 3, 4, 5);
        Console.WriteLine(">>> Vector4D vector4D:");
        vector4D.DisplayData();
        Console.WriteLine();

        // Show that both base and derived implementations are visible:
        Console.WriteLine(">>> Demonstration: calling derived.ShowInfo() shows base.ShowInfo() inside it (both outputs visible above).");
        
        ///Comments were written by support  of AI
        /// also,for better readibility, some parts were reformatted.
        /// LOGIC AND CODE WERE NOT CHANGED.
    }
}