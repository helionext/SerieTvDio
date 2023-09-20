namespace SeriesTv.Classes
{
    public class EntidadeBase
    {
        public int Id { get; protected set; } 

        public EntidadeBase(int id)
        {
            Id = id;
        }      
    }
}