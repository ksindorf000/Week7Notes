using Day2Server.Controllers;
using Day2Server.Models;
using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Web;

namespace Day2Server.Migrations
{

    public partial class AddCSVData : DbMigration
    {
        public override void Up()
        {
            var csvPath = AppDomain.CurrentDomain.BaseDirectory + @"..\App_Data\Data.csv";
            var openFile = File.ReadAllLines(csvPath);
            
            using (var db = new ApplicationContext()) {
                foreach (string row in openFile)
                {
                    var data = row.Split(',');
                    Cereal newCereal = new Cereal
                    {
                        Name = data[0],
                        Manufacturer = data[1]
                    };
                    db.Cereals.Add(newCereal);
                }
                db.SaveChanges();
            }

            //---------------//
            //throw new Exception("cookies");
        }
        
        public override void Down()
        {
        }
    }
}
