namespace Map2D
{
    public interface IMap2D<T> : IMap<T>
    {
        T this[int index0, int index1]
        { get; set; }

        T GetValue(int index0, int index1);
        void SetValue(T value, int index0, int index1);
        void Clamp(ref int index0, ref int index1);
        bool InBounds(int index0, int index1);
        void CopyTo(IMap2D<T> map);
        new IMap2D<T> Clone();
    }
}
