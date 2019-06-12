using System;

namespace Map2D
{
    public class Map2D<T> : IMap2D<T>
    {
        //Jagged array of the map values. 
        //Faster than multi-dimensional array of values.
        private readonly T[][] m_values;

        public T this[int index0, int index1]
        {
            get
            {
                return GetValue(index0, index1);
            }

            set
            {
                SetValue(value, index0, index1);
            }
        }

        public T this[params int[] indices]
        {
            get
            {
                return GetValue(indices);
            }

            set
            {
                SetValue(value, indices);
            }
        }

        public Map2D(int width, int height)
            : this(width, height, default)
        {
        }

        public Map2D(int width, int height, T startValue)
        {
            m_values = new T[width][];
            for (int x = 0; x < width; x++)
            {
                m_values[x] = new T[height];
                for (int y = 0; y < height; y++)
                {
                    m_values[x][y] = startValue;
                }
            }
        }

        public Map2D(T[,] values)
        {
            m_values = new T[values.GetLength(0)][];
            for (int x = 0; x < values.GetLength(0); x++)
            {
                m_values[x] = new T[values.GetLength(1)];
                for (int y = 0; y < values.GetLength(1); y++)
                {
                    m_values[x][y] = values[x, y];
                }
            }
        }

        public Map2D(T[][] values)
        {
            m_values = values;
        }

        public Map2D(Map2D<T> map)
            : this(map.m_values)
        {
        }

        public T GetValue(int index0, int index1)
        {
            return m_values[index0][index1];
        }

        public T GetValue(params int[] indices)
        {
            return GetValue(indices[0], indices[1]);
        }

        public void SetValue(T value, int index0, int index1)
        {
            m_values[index0][index1] = value;
        }

        public void SetValue(T value, params int[] indices)
        {
            SetValue(value, indices[0], indices[1]);
        }

        public int GetLength(int dimension)
        {
            return m_values.GetLength(dimension);
        }

        public void Clamp(ref int index0, ref int index1)
        {
            if (index0 < 0)
            {
                index0 = 0;
            }
            else if (index0 >= GetLength(0))
            {
                index0 = GetLength(0) - 1;
            }

            if (index1 < 0)
            {
                index1 = 0;
            }
            else if (index1 >= m_values[0].GetLength(1))
            {
                index1 = m_values[0].GetLength(1) - 1;
            }
        }

        public bool InBounds(int index0, int index1)
        {
            return
                index0 >= 0 && index0 < GetLength(0) &&
                index1 >= 0 && index1 < GetLength(1);
        }

        public bool InBounds(params int[] indices)
        {
            return InBounds(indices[0], indices[1]);
        }

        public IMap2D<T> Clone()
        {
            return new Map2D<T>(this);
        }

        IMap<T> IMap<T>.Clone()
        {
            return Clone();
        }

        public void CopyTo(IMap2D<T> map)
        {
            CopyTo(map);
        }

        public void CopyTo(IMap<T> map)
        {
            for (int x = 0; x < GetLength(0); x++)
            {
                for (int y = 0; y < m_values[0].GetLength(1); y++)
                {
                    map.SetValue(GetValue(x, y), x, y);
                }
            }
        }
    }
}
