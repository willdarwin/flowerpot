using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TTA.Model;
using System.Data;
using log4net;
using System.Reflection;

namespace TTA.DAL.DataAccess
{
    public class AddressDA
    {
        IDataAccess dataAcess = null;

        public AddressDA()
        {
            dataAcess = TTA.DAL.DataAccess.DataAccessFactory.CreateDataAccess();
        }

        public AddressBE Insert(AddressBE address)
        {
            dataAcess.Open();
            try
            {
                QueryParameter[] list = new QueryParameter[4];
                list[0] = new QueryParameter("AddressId", address.AddressId, DbType.Int32);
                list[1] = new QueryParameter("Country", address.Country, DbType.String);
                list[2] = new QueryParameter("Province", address.Province, DbType.String);
                list[3] = new QueryParameter("Address", address.DetailAddress, DbType.String);
                string sql = "insert into Address(AddressId, Country, Province, Address) OUTPUT inserted.AddressId values(@AddressId,@Country,@Province,@Address)";
                address.AddressId = Convert.ToInt32(dataAcess.ExecuteScalar(sql, list));
            }
            catch (Exception e)
            {
                //创建日志记录组件实例
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                //记录错误日志
                log.Error("error", e);
            }
            finally
            {
                dataAcess.Close();
            }
            return address;
        }

        public bool Update(AddressBE address)
        {
            bool result = true;
            dataAcess.Open();
            try
            {
                string sql = "update Address set Country=@Country, Province=@Province, Address=@Address where AddressId=@AddressId";
                QueryParameter[] list = new QueryParameter[4];
               
                list[0] = new QueryParameter("Country", address.Country, DbType.String);
                list[1] = new QueryParameter("Province", address.Province, DbType.String);
                list[2] = new QueryParameter("Address", address.DetailAddress, DbType.String);
                list[3] = new QueryParameter("AddressId", address.AddressId, DbType.Int32);
                int i = dataAcess.ExecuteNonQuery(sql, list);
                if (i == 0)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                //创建日志记录组件实例
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                //记录错误日志
                log.Error("error", e);
            }
            finally
            {
                dataAcess.Close();
            }
            return result;
        }

        public List<AddressBE> GetAllAddresses()
        {
            List<AddressBE> list = new List<AddressBE>();
            dataAcess.Open();
            try
            {
                string sql = "select * from Address";
                IDataReader reader = dataAcess.GetReader(sql);
                while (reader.Read())
                {
                    AddressBE address = new AddressBE();
                    address.AddressId = reader.GetInt32(0);
                    address.Country = reader.GetString(1);
                    address.Province = reader.GetString(2);
                    address.DetailAddress = reader.GetString(3);
                    list.Add(address);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                dataAcess.Close();
            }
            return list;
        }

        public AddressBE GetById(int id)
        {
            AddressBE address = new AddressBE();
            dataAcess.Open();
            try
            {
                string sql = "select * from Address where AddressId=@AddressId";
                QueryParameter p = new QueryParameter("AddressId", id, DbType.Int32);
                IDataReader reader = dataAcess.GetReader(sql, p);
                while (reader.Read())
                {
                    address.AddressId = id;
                    address.Country = reader.GetString(1);
                    
                }
            }
            catch (Exception e)
            {

                //创建日志记录组件实例
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                //记录错误日志
                log.Error("error", e);
            }
            finally
            {
                dataAcess.Close();
            }
            return address;

        }
    }
}
