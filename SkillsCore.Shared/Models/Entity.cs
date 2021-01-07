using System;

namespace SkillsCore.Shared.Models
{
    public class Entity
    {
        #region Constructor

        protected Entity()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            LastUpdate = DateTime.UtcNow;
            Active = true;
            Excluded = false;
        }

        #endregion

        #region Properties

        public Guid Id { get; protected set; }
        public DateTime CreationDate { get; protected set; }
        public DateTime LastUpdate { get; protected set; }
        public bool Active { get; protected set; }
        public bool Excluded { get; protected set; }

        #endregion
    }
}
