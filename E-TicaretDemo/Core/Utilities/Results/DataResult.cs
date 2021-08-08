using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool Succes, string message) : base(Succes, message)
        {
            Data = data;
        }

        public DataResult(T data, bool Succes) : base(Succes)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
