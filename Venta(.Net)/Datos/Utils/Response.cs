using System.Collections.Generic;

namespace Utils
{
    public class Response<T> where T : class, new()
    {
        public Response()
        {
            this.Lista = new List<T>();
            this.Entity = new T();
        }

        public int CodigoError { get; set; }

        public string Mensaje { get; set; }

        public IList<T> Lista { get; set; }

        public T Entity { get; set; }

        public int CantidadElementos { get; set; }

    }
}
