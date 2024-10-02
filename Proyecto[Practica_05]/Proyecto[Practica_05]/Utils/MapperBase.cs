using Proyecto_Practica_05_.Interfaces;
using System.Reflection;

namespace Proyecto_Practica_05_.Utils
{
    public class MapperBase<Input, Output> : IMapper<Input, Output>
        where Input : new()
        where Output : new()
    {
        private void TransferProperty(PropertyInfo property, object fromValue, object whereToValue)
        {
            try
            {
                string propName = property.Name;
                var propValue = property.GetValue(fromValue);
                //las propiedades de ambas clases deben tener el mismo nombre
                whereToValue.GetType().GetProperty(propName).SetValue(whereToValue, propValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Output? Set(Input entity)
        {
            if(entity == null) { return default; }
            Output oValue = new Output();
            PropertyInfo[] properties = typeof(Input).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                TransferProperty(property, entity, oValue);
            }
            return oValue;
        }
        public Input? Get(Output oValue)
        {
            if (oValue == null) { return default; }
            Input entity = new Input();
            PropertyInfo[] properties = typeof(Output).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                TransferProperty(property, oValue, entity);
            }
            return entity;
        }
        public List<Output>? Set(List<Input> entitylist)
        {
            if (entitylist == null || entitylist.Count == 0) { return default; }
            List<Output> lst = new List<Output>();
            foreach (Input entity in entitylist)
            {
                lst.Add(Set(entity));
            }
            return lst;
        }
        public List<Input> Get(List<Output> oValueList)
        {
            List<Input> lst = new List<Input>();
            foreach (Output oValue in oValueList)
            {
                lst.Add(Get(oValue));
            }
            return lst;
        }
    }
}
