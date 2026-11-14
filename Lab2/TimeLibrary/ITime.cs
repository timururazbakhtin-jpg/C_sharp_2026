namespace TimeLibrary
{
    public interface ITime
    {
        int Hours { get; set; }
        int Minutes { get; set; }
        int Seconds { get; set; }
        void Input();
    }
}