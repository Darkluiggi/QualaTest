using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Branch: ModelBase
    {
        public Branch(Guid id, int code, string description, string address, string identification, DateTime createdTime, Currency currency)
        {
            Id = id;
            Code = code;
            Description = description;
            Address = address;
            Identification = identification;
            CreatedTime = createdTime;
            Currency = currency;
            CurrencyId = currency.Id;
        }
        public Branch()
        {
                
        }

        /// <summary>
        /// Branch code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Branch description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Branch address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Branch identification
        /// </summary>
        public string Identification { get; set; }

        /// <summary>
        /// Branch created time
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Foreign key for branch currency
        /// </summary>
        [ForeignKey("Currency")]
        public Guid CurrencyId { get; set; }
        /// <summary>
        /// Branch currency
        /// </summary>
        public virtual Currency Currency { get; set; }
    }

}
