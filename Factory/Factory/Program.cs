using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {
        public static void Main(string[] args)
        {

        }
    }
    public class ShapeFactory
    {
        private Dictionary<string, IShapeFactoryWorker> workers = new Dictionary<string, IShapeFactoryWorker>();

        public ShapeFactory()
        {
            this.RegisterWorker(new SquareFactoryWorker());
        }

        public void RegisterWorker(IShapeFactoryWorker worker)
        {
            this.workers.Add(worker.GetName(), worker);
        }

        public IShape CreateShape(string shape, params object[] parameters)
        {
            return this.workers[shape].Create(parameters);
        }
    }
    public interface IShapeFactoryWorker
    {
        string GetName();
        IShape Create(params object[] parameters);
    }
    public class SquareFactoryWorker : IShapeFactoryWorker
    {
        private readonly string name = "Square";
        public string GetName()
        {
            return name;
        }
        public IShape Create(params object[] parameters)
        {
            return new Square((int)parameters[0]);
        }
    }
    public class RectangleFactoryWorker : IShapeFactoryWorker
    {
        private readonly string name = "Rectangle";
        public string GetName()
        {
            return name;
        }
        public IShape Create(params object[] parameters)
        {
            return new Rectangle((int)parameters[0], (int)parameters[1]);
        }
    }
    public interface IShape
    {

    }
    public class Square : IShape
    {
        int a;
        public Square(int a)
        {
            this.a = a;
        }
    }
    public class Rectangle : IShape
    {
        int a;
        int b;
        public Rectangle(int a, int b)
        {
            this.a = a; this.b = b;
        }
    }
}
