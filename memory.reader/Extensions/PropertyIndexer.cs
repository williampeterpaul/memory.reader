using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memory.reader.Extensions
{
    public interface IPropertyIndexer<T>
    {
        T this[int index] { get; set; }
    }

    public class StringPropertyIndexer : IPropertyIndexer<string>
    {
        public string this[int header] { get => (string)this.GetProperty(header); set => this.SetProperty(header, value); }
    }

    public class IntegerPropretyIndexer : IPropertyIndexer<int>
    {
        public int this[int header] { get => (int)this.GetProperty(header); set => this.SetProperty(header, value); }
    }
}
