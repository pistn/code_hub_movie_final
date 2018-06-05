using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace movies.hub
{
   
    public class Movie
    {
        public List<string> name=new List<string>();
        public List<double> review = new List<double>();
        public List<double> same = new List<double>();

        //public List<double> Income = new List<double>();
        //public List<string> Actors = new List<string>();

        public List<string> Function(string names)
        {
           
           name.Add(names);
            return name;
        }

        public List<double> Funct(string reviews)
        {
            review.Add(Double.Parse(reviews));
            return review;
        }

        public double Fun(string reviews,string names)
        { for (int i=0; i<name.Count; i++)
                if (name[i] == names)
                {
                    same.Add(review[i]);
                }
            same.Add(Double.Parse(reviews));
            return (same.Sum() / same.Count());
        }
    }
    
        
        
    
    




    class Program
    {
        static void Main(string[] args)
        {
            Movie m = new Movie();
            List<double> order = new List<double>();
            List<string> ord = new List<string>();
            
            int y = 0;
            while (1 == 1)
            {

                Console.WriteLine("Give a movie");

                string a = Console.ReadLine();
                Console.WriteLine("Give review 1-10");
                string b = Console.ReadLine();

                Console.ReadKey();
                
                if (!m.name.Contains(a))
                {
                 /*   Console.WriteLine("Give actors");
                    m.Actors.Add( Console.ReadLine());
                    Console.WriteLine("Give income");
                    m.Income.Add(Double.Parse (Console.ReadLine()));*/

                    ord = (m.Function(a));
                    order = m.Funct(b);

                }

                else
                {
                    for (int i = 0; i < ord.Count; i++)
                        if (ord[i] == a)
                        {
                            order[i] = m.Fun(b, a);
                        }
                   
                }


                var dic = ord.Zip(order, (k, v) => new { k, v })
              .ToDictionary(x => x.k, x => x.v);

               

                var items = from pair in dic
                            orderby pair.Value descending
                            select pair;

               
                Console.WriteLine("top 10 movies");
                
                foreach (KeyValuePair<string, double> pair in items)
                {
                    Console.WriteLine("Movie:{0} Rating:{1}", pair.Key, pair.Value);
                }
                Console.ReadLine();
                

            }


        }
    }
}
