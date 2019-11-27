
namespace AppSecrect.Domain.ValueObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    /// <summary>
    /// ValueObject
    /// </summary>
    public abstract class ValueObject<T>
    {

        public T Value { get; protected set; }
        protected ValueObject() { }

        public ValueObject(T value)
        {
            this.Value = value;
        }

        public abstract bool IsValid();
    }
}
