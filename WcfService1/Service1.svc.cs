using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;

namespace WcfService1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public List<Customer> getCustomers()
        {
            List<Customer> list = new List<Customer>();
            string str = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(str))
            {
                SqlCommand com = new SqlCommand("SELECT * FROM Customers", con);
                con.Open();
                SqlDataReader r = com.ExecuteReader();
                while(r.Read())
                {
                    Customer c = new Customer();
                    c.id = (int)r["id"];
                    c.Name = r["Name"].ToString();
                    c.Surname = r["Surname"].ToString();
                    c.YearOfBirth = (int)r["YearOfBirth"];
                    list.Add(c);

                }
            }
            return list;
        }
        public List<Order> getOrders(int id)
        {
            List<Order> list = new List<Order>();
            string str = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(str))
            {
                SqlCommand com = new SqlCommand("SELECT * FROM Orders WHERE idCust = @id", con);
                com.Parameters.Add(new SqlParameter("@id", id));
                con.Open();
                SqlDataReader r = com.ExecuteReader();
                while (r.Read())
                {
                    Order o = new Order();
                    o.id = (int)r["id"];
                    o.Title = r["Title"].ToString();
                    o.idCust = (int)r["idCust"];
                    o.Price = (int)r["Price"];
                    o.Quant = (int)r["Quant"];
                    list.Add(o);
                    //https://www.youtube.com/watch?v=ukvr_5CAp5w 
                    // 35:28
                }
            }
            return list;
        }
    }
}
