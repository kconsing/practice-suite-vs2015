using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_LINQ
{
    class sith
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public int Wisdom { get; set; }

        public sith(string name = "None", int power = 0, int wisdom = 0)
        {
            Name = name;
            Power = power;
            Wisdom = wisdom;
        }

        public override string ToString()
        {
            return string.Format("{Sith Lord {0}, has power level of {1}, and a wisdom level of {2}", Name, Power, Wisdom);
        }
    }

    partial class jedi
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public int Wisdom { get; set; }

        public jedi(string name="None", int power=0,int wisdom=0)
        {
            Name = name;
            Power = power;
            Wisdom = wisdom;
        }

        public override string ToString()
        {
            return string.Format("{Jedi Master {0}, has power level of {1}, and a wisdom level of {2}", Name,Power,Wisdom);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // QueryStringArray();

            // QueryIntegerArray();

            // QueryArrayList();

            // QueryCollection();

            QueryJediData();


            Console.ReadLine();
        }

        static void QueryStringArray()
        {
            string[] jedis = {"Obiwan", "Kit Fisto", "Luke", "Qui Gon", "Mace Windu",
            "Plo Koon", "Annakin", "Ki-Adi-Mundi", "Adi", "Rey"};

            var jediSpaces = from jedi in jedis
                             where jedi.Contains(" ")
                             orderby jedi descending
                             select jedi;

            foreach(var i in jediSpaces)
            { 
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }

        static int[] QueryIntegerArray()
        {
            int[] nums = { 23, 4, 32, 1, 3, 13, 0, 26, 9 };

            var gt20 = from num in nums
                       where num > 20
                       orderby num
                       select num;
            foreach(var i in gt20)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            Console.WriteLine($"Get Type : {gt20.GetType()}");

            var listGT20 = gt20.ToList<int>();
            var arrayGT20 = gt20.ToArray();

            nums[0] = 40;

            foreach(var i in gt20)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            return arrayGT20;
        }

        
        static void QueryArrayList()
        {
            ArrayList sithLords = new ArrayList()
            {
                new sith { Name="Kylo Ren", Power =13, Wisdom =10, ID=0},        //23
                new sith { Name="Darth Vader", Power=18, Wisdom=12, ID=0},     //30
                new sith { Name="Darth Maul", Power=17, Wisdom=7, ID=0 },      //24
                new sith { Name="Darth Tyranus", Power=16, Wisdom=10, ID=0 },  //26
                new sith { Name="Darth Siddious", Power=12, Wisdom=16, ID=0 }, //28
                new sith { Name="Snoke"         , Power=7, Wisdom=20, ID=0 }   //27
            };


            // Convert arraylist to an enumerable
            var sithLordsEnum = sithLords.OfType<sith>();

            // Issue query
            var sithMasters = from sith in sithLordsEnum
                              where sith.Power + sith.Wisdom > 25
                              orderby sith.Name
                              select sith;

            foreach(var sith in sithMasters)
            {
                Console.WriteLine(sith.ToString());
            }
        } 
    
        // Selecting Collections
        static void QueryCollection()
        {
            var sithList = new List<sith>()
            {
                new sith { Name="Kylo Ren", Power =13, Wisdom =10, ID=3},
                new sith { Name="Darth Vader", Power=18, Wisdom=12, ID=2},
                new sith { Name="Darth Maul", Power=16, Wisdom=8, ID=1},
                new sith { Name="Darth Tyranus", Power=16, Wisdom=10, ID=1},
                new sith { Name="Darth Siddious", Power=12, Wisdom=16, ID=2},
                new sith { Name="Snoke"         , Power=7, Wisdom=20, ID=3}
            };

            var apprentice = from sith in sithList
                             where sith.Power + sith.Wisdom > 25
                             orderby sith.Name
                             select sith;

            foreach(var sith in apprentice)
            {
                Console.WriteLine(sith.ToString());
            }

            Console.WriteLine();
        }

        // Different things you can do with Select
        // Inner Join and Group Joins
        static void QueryJediData()
        {
            jedi[] jedis = new[]
            {
                new jedi {Name = "Ki-Adi-Mundi",      Power=12, Wisdom=8, ID=3 },  // 20
                new jedi {Name = "Kit Fisto",         Power=9, Wisdom=10, ID=3 },  // 19
                new jedi {Name = "Plo Koon",          Power=13, Wisdom =8, ID=3 },// 21
                new jedi {Name = "Annakin Skywalker", Power=16, Wisdom=10 , ID=3},// 26
                new jedi {Name = "Obiwan Kenobi",     Power=15, Wisdom=12, ID=3 },// 27
                new jedi {Name = "Ben Kenobi",        Power=11, Wisdom=16, ID=4 },// 27
                new jedi {Name = "Luke Skywalker",    Power=14, Wisdom=15, ID=6 },// 29
                new jedi {Name = "Yoda",              Power=9, Wisdom=18, ID=5 }, // 27
                new jedi {Name = "Yoda",              Power=12, Wisdom=16, ID=3 },// 28      
                new jedi {Name = "QuiGon Jin",        Power=15, Wisdom=10, ID=1 },// 25
                new jedi {Name = "Mace Windu",        Power=16, Wisdom=9,  ID=2}, // 25
                new jedi {Name = "Rey",               Power=10, Wisdom=12, ID=8 } //22
            };

            Episode[] episodes = new[]
            {
                new Episode {Number = 1, Title= "The Phantom Menace" },
                new Episode {Number = 2, Title= "Attack Of The Clones" },
                new Episode {Number = 3, Title= "Revenge Of The Sith" },
                new Episode {Number = 4, Title= "A New Hope" },
                new Episode {Number = 5, Title= "Empire Strikes Back" },
                new Episode {Number = 6, Title= "Return Of The Jedi" },
                new Episode {Number = 7, Title= "The Force Awakens" },
                new Episode {Number = 8, Title= "The Last Jedi" },
            };

            foreach (var j in jedis)
            {
                j.Level = j.Power + j.Wisdom;
            }

            // Creating a new Collection
            var nameTotalLevel = from j in jedis
                                 select new
                                 {
                                     j.Name,
                                     j.Level
                                 };

            Array arrNameLevel = nameTotalLevel.ToArray();

            foreach(var i in nameTotalLevel)
            {
                Console.WriteLine(i.ToString());
            }

            // INNER JOINS EXAMPLE 1
            var innerJoin = from jedi in jedis
                            join ep in episodes on jedi.ID equals ep.Number // **** IMPORTANT ****
                            select new
                            {
                                jediName = jedi.Name,
                                jediLevel = jedi.Level,
                                epNumber = ep.Number,
                            };

            foreach(var i in innerJoin)
            {
                Console.WriteLine($"Episode {i.epNumber} {i.jediName} has a combat level of {i.jediLevel}.");
            }


            // GROUP JOIN
            var groupJoin = from e in episodes
                            orderby e.Number
                            join j in jedis on e.Number equals j.ID // JOIN on WHICH columns to COMPARE
                            into episodeGroup // THE NEW TABLE
                            select new // WHAT DO YOU WANT TO GRAB FROM THE NEW TABLE
                            {
                                EP = e.Title,
                                Jedis = from ep in episodeGroup
                                       orderby ep.Name
                                       select ep
                            };

            int totalJedis = 0 ;

            foreach(var episodeGroup in groupJoin)
            {
                Console.WriteLine(episodeGroup.EP);
                foreach (var jedi in episodeGroup.Jedis)
                {
                    totalJedis++;
                    Console.WriteLine("* {0}", jedi.Name);
                }
            }
        }
    }

    public partial class jedi
    {
        public int Level { get; set; }
    }

    class Episode
    {
        public int Number { get; set; }
        public string Title { get; set; }

        public Episode(string title = "None", int epnumber = 0)
        {
            Title = title;
            Number = epnumber;
        }

        public override string ToString()
        {
            return string.Format("Episode {0}: {1}", Title, Number);
        }
    }

}
