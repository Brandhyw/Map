namespace Map2D
{
    public interface IMap<T>
    {
        T this[params int[] indices]
        { get; set; }

        int GetLength(int dimension);
        T GetValue(params int[] indices);
        void SetValue(T value, params int[] indices);
        bool InBounds(params int[] indices);
        void CopyTo(IMap<T> map);
        IMap<T> Clone();
    }
}
