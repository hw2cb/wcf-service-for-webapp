using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
        [OperationContract]
        List<Customer> getCustomers();
        [OperationContract]
        List<Order> getOrders(int id);
        // TODO: Добавьте здесь операции служб
    }


    // Используйте контракт данных, как показано в примере ниже, чтобы добавить составные типы к операциям служб.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int id
        { get; set; }
        [DataMember]
        public string Name
        { get; set; }
        [DataMember]
        public string Surname
        { get; set; }
        [DataMember]
        public int YearOfBirth
        { get; set; }

    }
    [DataContract]
    public class Order
    {
        [DataMember]
        public int id
        { get; set; }
        [DataMember]
        public string Title
        { get; set; }
        [DataMember]
        public int idCust
        { get; set; }
        [DataMember]
        public int Price
        { get; set; }
        [DataMember]
        public int Quant
        { get; set; }




    }
}
