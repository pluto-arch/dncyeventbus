using System;
using System.Threading.Tasks;

namespace Pluto.EventBus.Abstract
{
    public interface IMessageSerializeProvider
    {
        string Serialize(object obj);


        T Deserialize<T>(string objStr);


        object Deserialize(string objStr,Type type);
    }
}