namespace Domain
{
    public class Currency: ModelBase
    {
        /// <summary>
        /// Class initializer
        /// </summary>
        /// <param name="id">Currency id</param>
        /// <param name="name">Currency name</param>
        /// <param name="symbol">Currency symbol</param>
        public Currency(Guid id, string name, char symbol)
        {
            Id = id;
            Name = name;
            Symbol = symbol;
        }

        /// <summary>
        /// Class initializer
        /// </summary>
        public Currency()
        {

        }

        /// <summary>
        /// Currency name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Currency symbol
        /// </summary>
        public char Symbol { get; set; }
    }

}