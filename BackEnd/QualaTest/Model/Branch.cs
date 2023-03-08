using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Branch: ModelBase
    {
        /// <summary>
        /// Class initializer
        /// </summary>
        /// <param name="id">Branch Id</param>
        /// <param name="code">Branch code</param>
        /// <param name="description">Branch description</param>
        /// <param name="address">Branch address</param>
        /// <param name="identification">Branch identification</param>
        /// <param name="createdTime">Branch created time</param>
        /// <param name="currency">Branch currency</param>
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

        /// <summary>
        /// Class initializer
        /// </summary>
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
