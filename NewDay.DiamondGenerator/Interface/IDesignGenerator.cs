namespace NewDay.DiamondGenerator
{
    public interface IDesignGenerator
    {
        Task<string> Create(char input);
    }
}
