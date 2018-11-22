namespace NooBIT.Asserts
{
    public class Be<T> : IBe<T>
    {
        public Be(IShould<T> should)
        {
            Should = should;
        }

        public IShould<T> Should { get; }
    }

    public interface IBe<T>
    {
        IShould<T> Should { get; }
    }
}
