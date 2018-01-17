using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Proiect_DPO.Model.Produs;
using Proiect_DPO.Evenimente;
using Newtonsoft.Json;
using Proiect_DPO.Model;
using System.Text.RegularExpressions;

namespace Proiect_DPO
{
    public class ReadRepository
    {
        public bool CautaProdus(string idRadacina)
        {
            using (var cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename" +
             @"='D:\An4\PSSC\PSSC Proiect Nou\Proiect_DPO\Interfata\App_Data\ProduseDB.mdf';Integrated Security=True"))
            {
                string _sql = @"SELECT * FROM [dbo].[CatalogProduse] WHERE [IdRadacina]=@idRadacina";


                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@idRadacina", SqlDbType.NVarChar))
                    .Value = idRadacina;

                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
            }

        }

        public string UpdateProdus(string idRadacina)
        {
            string stare = "";
            using (var cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename" +
             @"='D:\An4\PSSC\PSSC Proiect Nou\Proiect_DPO\Interfata\App_Data\ProduseDB.mdf';Integrated Security=True"))
            {
                string _sql = @"SELECT * FROM [dbo].[CatalogProduse] WHERE [IdRadacina]=@idRadacina";


                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@idRadacina", SqlDbType.NVarChar))
                    .Value = idRadacina;
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    string[] tokens = reader["DetaliiEveniment"].ToString().Split(':');  // de modificat, de pus brakepoint
                    string[] stareProdus = tokens[19].Split(',');
                    stare = stareProdus[0];
                }


            }
            return stare;

        }

        public List<Produs> IncarcaListaDeEvenimente()
        {
            List<string> marca = new List<string>();
            List<Produs> produs = new List<Produs>();

            using (var cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename" +
              @"='D:\An4\PSSC\PSSC Proiect Nou\Proiect_DPO\Interfata\App_Data\ProduseDB.mdf';Integrated Security=True"))
            {
                string _sql = @"SELECT * FROM [dbo].[CatalogProduse] ";
                var cmd = new SqlCommand(_sql, cn);
                cn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string[] tokens = reader["DetaliiEveniment"].ToString().Split('"');
                        string tip = Regex.Match(tokens[20], @"\d+").Value;
                        string stare = Regex.Match(tokens[52], @"\d+").Value;
                        //resultString = Regex.Match(subjectString, @"\d+").Value;
                        Produs p = new Produs(new PlainText(tokens[5]), new PlainText(tokens[11]), new PlainText(tokens[17]), (TipProdus)Enum.Parse(typeof(TipProdus), tip), new PlainText(tokens[25]), new PlainText(tokens[31]), new PlainText(tokens[37]), new PlainText(tokens[43]), new PlainText(tokens[49]), (StareProdus)Enum.Parse(typeof(StareProdus), stare));
                       // Produs p = new Produs(new PlainText(tokens[5]), new PlainText(tokens[11]), new PlainText(tokens[17]), 0,  new PlainText(tokens[25]), new PlainText(tokens[31]), new PlainText(tokens[37]), new PlainText(tokens[43]), new PlainText(tokens[49]), 0);

                        produs.Add(p);
                    }
                }
            }
            return produs;
        }
    }
}
