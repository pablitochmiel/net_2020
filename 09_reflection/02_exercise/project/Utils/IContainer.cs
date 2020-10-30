using System;

namespace Utils
{
    public interface IContainer
    {
        void Map<TFrom, TInto>(string name = "", bool singleton = false)
            where TFrom : class where TInto : TFrom;

        void Map(Type from, Type into, string name = "", bool singleton = false);

        T? Create<T>(string name = "")
            where T : class;

        object? Create(Type? type, string name = "");
    }
}