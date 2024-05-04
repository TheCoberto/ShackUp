using ShackUp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShackUp.Models.Tables;
using System.Data.SqlClient;
using System.Data;

namespace ShackUp.Data.ADO
{
    public class BathroomTypesRepositoryADO : IBathroomTypesRepository
    {
        public List<BathroomType> GetAll()
        {
            List<BathroomType> bathroomTypes = new List<BathroomType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BathroomTypesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BathroomType currentRow = new BathroomType();
                        currentRow.BathroomTypeId = (int)dr["BathroomTypeId"];
                        currentRow.BathroomTypeName = dr["BathroomTypeName"].ToString();

                        bathroomTypes.Add(currentRow);
                    }
                }
            }

            return bathroomTypes;
        }
    }
}
