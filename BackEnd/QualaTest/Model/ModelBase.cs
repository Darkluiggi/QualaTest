using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelBase
    {
        /// <summary>
        /// Id for the entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Set is active or inactive
        /// </summary>
        public bool isActive { get; set; }
        public ModelBase()
        {
            isActive = true;
        }
    }
}
