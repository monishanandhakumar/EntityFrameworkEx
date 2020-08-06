using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkEx
{
    class RegionDAL
    {
         NorthwindEntities db = new NorthwindEntities();
         Region region = new Region();
        
  public void Insert(int rid,string rdescription)
        {
            //Console.WriteLine("Enter  RegionId");
            //region.RegionID = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter RegionDescription");
            //region.RegionDescription = Console.ReadLine();
            region.RegionID = rid;
            region.RegionDescription = rdescription;
            db.Regions.Add(region);
            db.SaveChanges();
        }
        public List<Region> Displayregion()
        {
            List<Region> reglist = db.Regions.ToList();

            return reglist;
            //Console.WriteLine("RegionId RegionDescription");
            //foreach(var item in reglist)
            //{
            //    Console.WriteLine(item.RegionID + "       " + item.RegionDescription);
            //}


        }
        public void DeleteRegion(int id)
        {
           region= db.Regions.Find(id);
            db.Regions.Remove(region);
            db.SaveChanges();
        }
        public void UpdateRegion(int id,string desc)
        {
            region = db.Regions.Find(id);
            region.RegionDescription =desc;
            db.SaveChanges();

        }

        public void FindRegion(int id)
        {
            region = db.Regions.Find(id);
            Console.WriteLine(region.RegionDescription);
        }


    }
    class Program
       
    {

        RegionDAL regionDAL = new RegionDAL();
        static void Main(string[] args)
        {
            int r;
            string desc;
          
            Program program = new Program();
            int id;
           
                Console.WriteLine("1.Enter the Region");
                Console.WriteLine("2.Display all the customer");
               Console.WriteLine("3.Enter the id to be deleted");
               Console.WriteLine("4.update");
            int ch = Convert.ToInt32(Console.ReadLine());
                
            
                try
                {
                    if (ch == 1)
                    {
                        Console.WriteLine("Enter the RegId and RegDesc");
                        r = Convert.ToInt32(Console.ReadLine());
                        desc = Console.ReadLine();
                       program. regionDAL.Insert(r, desc);

                    }
                    else if (ch == 2)
                    {
                        List<Region> res =program.regionDAL.Displayregion();
                        foreach (var item in res)
                        {
                            Console.WriteLine(item.RegionID + " " + item.RegionDescription);
                        }

                    }
                    else if (ch == 3)
                    {
                        Console.WriteLine("Enter Id to be deleted");
                        id = Convert.ToInt32(Console.ReadLine());
                       // program.regionDAL.DeleteRegion(id);

                    }
                    else if (ch == 4)
                    {
                        //program.regionDAL.UpdateRegion(7, "southwest");
                    }

                else if (ch == 5)
                {
                    program.regionDAL.FindRegion(4);
                }
            }

                catch (Exception e)
                {
                    Console.WriteLine("Please try Again...{0}", e);
                }
            


            Console.Read();
        }
    }
}
