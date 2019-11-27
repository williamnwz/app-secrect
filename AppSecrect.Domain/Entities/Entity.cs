namespace AppSecrect.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    /// <summary>
    /// Entity
    /// </summary>
    public class Entity
    {
        public Guid Id { get; protected set; }

        public void GenerateId()
        {
            this.Id = Guid.NewGuid();
        }

        public bool HasId()
        {
            return (Guid.Empty != this.Id);
        }
    }
}
