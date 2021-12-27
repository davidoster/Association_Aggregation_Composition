using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Soldier soldier = new Soldier(10, 1);
            int life = soldier.GetLife();
            Console.WriteLine(life); // 10

            Soldier s2 = new Soldier();
            Console.WriteLine(s2.GetLife() + " " + s2.Name);
            //s2.Name = "XXX";

            Fighter f = new Soldier();
            Console.WriteLine((f as Soldier).Name);
            
            Soldier s3 = (Soldier)f;
            Console.WriteLine(s3.Name);

            Chair chair = new Chair();
        }
    }

    #region Inheritance
    class Fighter
    {
        private int _life;
        private int _attack;
        public Fighter(int life, int attack)
        {
            _life = life;
            _attack = attack;
        }

        public int GetLife()
        {
            return _life;
        }
    }

    class Soldier : Fighter
    {
        private string _name;
        public string Name { get { return _name; } }
        public Soldier() : base(10, 1) 
        {
            _name = "Soldier";
        }

        public Soldier(int life, int attack) : base(CalcLife(life), attack) 
        {

         
        
        }

        private static int CalcLife(int life) { return (life + 5 * 2);  }
    }
    #endregion

    #region Composition
    class ChairLeg
    {
        public void Material()
        {
            Console.WriteLine("Wood");
        }
    }

    class Chair
    {
        // <"Leg1", new ChairLeg()>
        
        private Dictionary<string, ChairLeg> Legs;
        private IDictionary<string, ChairLeg> Legs2;

        private ChairLeg[] _legs;
        public Chair()
        {
            _legs = new ChairLeg[] { new ChairLeg(), new ChairLeg(), new ChairLeg(), new ChairLeg() };
            
            Legs = new Dictionary<string, ChairLeg>();
            
            Legs.Add("Leg1", new ChairLeg());

            //Legs2 = new IDictionary<string, ChairLeg>(); // can't do it
            Legs2 = new Dictionary<string, ChairLeg>();
            Legs2.Add("Leg1", new ChairLeg());

            DinnerTable dinnerTable = new DinnerTable();
        }

        public Chair(ChairLeg[] legs)
        {
            _legs = legs;
        }
    }

    #endregion

    #region Aggregation And Association
    class ChairA
    {
        public ChairA()
        {
            Console.WriteLine("New ChairA");
        }
        public void Material()
        {
            Console.WriteLine("Wood");
        }
    }
    class DinnerTable
    {
        private ChairA _chair = new ChairA(); // aggregation means that we don't instantiate on the default / overloaded
        // constructor
        public DinnerTable()
        {
            Console.WriteLine("Inside DinnerTable ctor");
        }
        public DinnerTable(ChairA chair) // association
            // we need to instatiate
        {
            Console.WriteLine("Inside DinnerTable ctor");
            _chair = chair;
        }
    }
    #endregion

   
}
