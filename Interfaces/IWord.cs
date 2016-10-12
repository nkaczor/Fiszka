namespace Interfaces
{
    public interface IWord
    {
        int WordId { get; set; }
        string OriginWord { get; set; }
        string Translation { get; set; }
        int WasShowedCounter { get; set; }
        int Successes { get; set; }
        int Losses { get; set; }
    }
}