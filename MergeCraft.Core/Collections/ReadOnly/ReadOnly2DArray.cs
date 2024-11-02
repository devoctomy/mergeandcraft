namespace MergeCraft.Core.Collections.ReadOnly
{
    public class ReadOnly2DArray<T>
    {
        private readonly T[,] array;

        public T this[int row, int column] => array[row, column];

        public ReadOnly2DArray(T[,] array)
        {
            this.array = array;
        }

        public int GetLength(int dimension) => array.GetLength(dimension);
    }
}
