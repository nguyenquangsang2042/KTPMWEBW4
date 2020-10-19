using KTPMWEBW4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KTPMWEBW4.DAO
{
    class MouseDAO
    {
        DataClasses1DataContext db = new DataClasses1DataContext("SERVER = den1.mssql7.gear.host; DATABASE =mousektpm;USER=mousektpm;PASSWORD=QA@162293");

        public List<Mouse> SelectAll()
        {
            /*List<Game> games = new List<Game>();
            String strCon = "SERVER=den1.mssql7.gear.host;DATABASE=gamemngt;USER=gamemngt;PASSWORD=Jz6L0E4zF_?q";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "SELECT * FROM Game";
            SqlCommand com = new SqlCommand(strCom, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                Game game = new Game()
                {
                    Code = (int)dr["Code"],
                    Name = (string)dr["Name"],
                    Price = (int)dr["Price"],
                    Developers = (string)dr["Developers"],
                    Rate = (string)dr["Rate"]
                };
                games.Add(game);              
            }
            return games;*/

            List<Mouse> games = db.Mouses.ToList();
            return games;
        }

        public bool Delete(int code)
        {
            /*String strCon = "SERVER=den1.mssql7.gear.host;DATABASE=gamemngt;USER=gamemngt;PASSWORD=Jz6L0E4zF_?q";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            string strCom = "DELETE From Game Where Code=@Code";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Code", code));
            try { return com.ExecuteNonQuery() > 0; }
            catch { return false; }*/

            Mouse dbGame = db.Mouses.SingleOrDefault(x => x.Code == code);
            if( dbGame != null)
            {
                try
                {
                    db.Mouses.DeleteOnSubmit(dbGame);
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;

        }

        public List<Mouse> SelectByName(String colum,String keyword)
        {
            /*List<Game1> games = new List<Game1>();
            String strCon = "SERVER=den1.mssql7.gear.host;DATABASE=gamemngt;USER=gamemngt;PASSWORD=Jz6L0E4zF_?q";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "SELECT * FROM Game WHERE Name LIKE '%" + keyword + "%'";
            SqlCommand com = new SqlCommand(strCom, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                Game1 game = new Game1()
                {
                    Code = (int)dr["Code"],
                    Name = (string)dr["Name"],
                    Price = (int)dr["Price"],
                    Developers = (string)dr["Developers"],
                    Rate = (string)dr["Rate"]
                };
                games.Add(game);
            }
            return games;*/
            List<Mouse> mouse;
            if (colum.Equals("Code"))
                {
                 mouse = db.Mouses.Where(x => x.Code.ToString().Contains(keyword)).ToList();
                return mouse;
            }
            if (colum.Equals("Name"))
            {
                mouse = db.Mouses.Where(x => x.Name.ToString().Contains(keyword)).ToList();
                return mouse;
            }
            if (colum.Equals("Manufacturer"))
            {
                mouse = db.Mouses.Where(x => x.Manufacturer.ToString().Contains(keyword)).ToList();
                return mouse;
            }
            if (colum.Equals("ProductionTime"))
            {
                mouse = db.Mouses.Where(x => x.Price.ToString().Contains(keyword)).ToList();
                return mouse;
            }
            if (colum.Equals("MinDPI"))
            {
                mouse = db.Mouses.Where(x => x.MinDPI.ToString().Contains(keyword)).ToList();
                return mouse;
            }
            if (colum.Equals("MaxDPI"))
            {
                mouse = db.Mouses.Where(x => x.MaxDPI.ToString().Contains(keyword)).ToList();
                return mouse;
            }
            if (colum.Equals("Type"))
            {
                mouse = db.Mouses.Where(x => x.Type.ToString().Contains(keyword)).ToList();
                return mouse;
            }
            return null;

        }

        public Mouse SelectByCode(int Code)
        {
            

            Mouse mouse = db.Mouses.SingleOrDefault(x => x.Code == Code);
            return mouse;
        }

        public bool Update(Mouse newMouse)
        {
            var query = from Mouse in db.Mouses where Mouse.Code == newMouse.Code select Mouse;
            foreach(Mouse mouse in query)
            {
                mouse.Name = newMouse.Name;
                mouse.Price = newMouse.Price;
                mouse.ProductionTime = newMouse.ProductionTime;
                mouse.Manufacturer = newMouse.Manufacturer;
                mouse.MaxDPI = newMouse.MaxDPI;
                mouse.MinDPI = newMouse.MinDPI;
            }
            try
            {
                db.SubmitChanges();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public bool AddGame(Mouse newGame)
        {
           
            try
            {
                db.Mouses.InsertOnSubmit(newGame);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }           
            
        }
    }   
    
}
