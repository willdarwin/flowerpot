using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TTA.Model;
using System.Reflection;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace TTA.DAL.DataAccess
{
    public class CustomerDA
    {
        private const string Id = "CustomerId";
        private const string Name = "CustomerName";
        private const string Gender = "CustomerGender";
        private const string AddressId = "AddressId";

        IDataAccess _mDataAcess = null;
        AddressDA _mAddressDA = new AddressDA();

        public CustomerDA()
        {
            _mDataAcess = TTA.DAL.DataAccess.DataAccessFactory.CreateDataAccess();
        }

        public CustomerBE Insert(CustomerBE customer)
        {
            _mDataAcess.Open();
            try
            {
                QueryParameter[] list = new QueryParameter[4];
                list[0] = new QueryParameter(Id, customer.CustomerId, DbType.Int32);
                list[1] = new QueryParameter(Name, customer.CustomerName, DbType.String);
                list[2] = new QueryParameter(Gender, customer.CustomerGender, DbType.String);
                list[3] = new QueryParameter(AddressId, customer.Address.AddressId, DbType.Int32);
                string sql = "insert into Customer(CustomerName,CustomerGender, AddressId) OUTPUT inserted.CustomerId values(@CustomerName,@CustomerGender,@AddressId)";
                customer.CustomerId = Convert.ToInt32(_mDataAcess.ExecuteScalar(sql, list));
            }
            catch (Exception e)
            {
                
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("error", e);
            }
            finally
            {
                _mDataAcess.Close();
            }
            return customer;
        }

        public bool Update(CustomerBE customer)
        {
            bool result = true;
            _mDataAcess.Open();
            try
            {
                string sql = "update Customer set CustomerName=@CustomerName, CustomerGender=@CustomerGender, AddressId=@AddressId where CustomerId=@CustomerId";
                QueryParameter[] list = new QueryParameter[4];

                list[0] = new QueryParameter(Name, customer.CustomerName, DbType.String);
                list[1] = new QueryParameter(Gender, customer.CustomerGender, DbType.Boolean);
                list[2] = new QueryParameter(AddressId, customer.Address.AddressId, DbType.Int32);
                list[3] = new QueryParameter(Id, customer.CustomerId, DbType.Int32);
                int i = _mDataAcess.ExecuteNonQuery(sql, list);
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
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("error", e);
            }
            finally
            {
                _mDataAcess.Close();
            }
            return result;
        }

        public List<CustomerBE> GetAllCustomers()
        {
            List<CustomerBE> list = new List<CustomerBE>();
            _mDataAcess.Open();
            try
            {
                string sql = "select * from Customer";
                IDataReader reader = _mDataAcess.GetReader(sql);
                while (reader.Read())
                {
                    CustomerBE customer = new CustomerBE();
                    customer.CustomerId = reader.GetInt32(0);
                    customer.CustomerName = reader.GetString(1);
                    customer.CustomerGender = reader.GetBoolean(2);
                    int addressId = reader.GetInt32(3);
                    AddressBE address = (new AddressDA()).GetById(addressId);
                    customer.Address = address;
                    list.Add(customer);
                }
            }
            catch (Exception e)
            {

                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("error", e);
            }
            finally
            {
                _mDataAcess.Close();
            }
            return list;
        }

        public bool Delete(int id)
        {
            bool result = true;
            _mDataAcess.Open();
            try
            {
                string sql = "delete from Customer where CustomerId=@CustomerId";
                QueryParameter p = new QueryParameter("CustomerId", id, DbType.UInt32);
                int i = _mDataAcess.ExecuteNonQuery(sql, p);
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

                throw e;
            }
            finally
            {
                _mDataAcess.Close();
            }
            return result;
        }

        public CustomerBE GetById(int id)
        {
            CustomerBE customer = new CustomerBE();
            _mDataAcess.Open();
            try
            {
                string sql = "select * from Customer where CustomerId=@CustomerId";
                QueryParameter p = new QueryParameter(Id, id, DbType.Int32);
                IDataReader reader = _mDataAcess.GetReader(sql, p);
                while (reader.Read())
                {
                    customer.CustomerId = id;
                    customer.CustomerName = reader.GetString(1);
                    customer.CustomerGender = reader.GetBoolean(2);
                    int addressId = reader.GetInt32(3);
                    AddressBE address = _mAddressDA.GetById(addressId);
                    customer.Address = address;
                }
            }
            catch (Exception e)
            {
                ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("error", e);
            }
            finally
            {
                _mDataAcess.Close();
            }
            return customer;
           
        }

    }
}

   
