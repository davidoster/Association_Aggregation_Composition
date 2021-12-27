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
        public Soldier(int life, int attack) : base(life, attack) { }
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
        private ChairLeg _leg;
        public Chair(ChairLeg leg)
        {
            _leg = leg;
        }
    }

    #endregion

    #region Aggregation And Association
    class ChairA
    {
        public void Material()
        {
            Console.WriteLine("Wood");
        }
    }
    class DinnerTable
    {
        private ChairA _chair; // aggregation
        public DinnerTable(ChairA chair) // association
        {
            _chair = chair;
        }
    }
    #endregion

   
}
