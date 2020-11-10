using JobPortal.Models.Contract;
using System;
using System.Runtime.Serialization;

namespace JobPortal.Models.Implementation
{
    [Serializable]
    [DataContract]
    public class Entity : IEntity
    {
        public virtual long ID
        {
            get;
            set;
        }
        public virtual DateTime DateCreated { get; set; } = DateTime.Now;
        public virtual DateTime DateModified { get; set; } = DateTime.Now;
    }
}
