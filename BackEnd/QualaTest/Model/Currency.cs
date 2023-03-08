namespace Model
{
    public class Currency: ModelBase
    {
        public Currency(Guid id, string name, char symbol)
        {
            Id = id;
            Name = name;
            Symbol = symbol;
        }
        public Currency()
        {

        }
        public string Name { get; set; }
        public char Symbol { get; set; }
    }

}