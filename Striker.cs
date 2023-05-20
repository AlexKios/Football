using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    public class Striker : FootballPlayer
    {
        public Striker(string name, int age, int number, int height)
        {
            Name = name;
            Age = age;
            Number = number;
            Height = height;
        }
    }
}
