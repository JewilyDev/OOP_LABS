namespace _3DArray;

public class Array3D<T>
{
    public int M { get; }
    public int N { get; }
    public int K { get; }
    
    private const int Dim0 = 0;
    
    private const int Dim1 = 1;
    
    private const int Dim2 = 2;

    private T[] _cernel;
    
    public Array3D(int m, int n, int k)
    {
        if (m <= 0 || n <= 0 || k <= 0)
            throw new Exception("Unable to create 3DArray : Given dimensions are incorrect");
        M = m;
        N = n;
        K = k;
        _cernel = new T[M * N * K];
    }
    public T this[int i, int j, int k]
    {
        get
        {
            if(!IsValidRange(i, j, k))
                throw new Exception("Indexation error: given bounds are incorrect");
           return _cernel [k * M * N + j * M + i]; 
        }
        set
        {
            if(!IsValidRange(i, j, k))
                throw new Exception("Indexation error: given bounds are incorrect");
            _cernel[k * M * N  + j * M + i] = value;
        } 
    }

    private bool IsValidRange(int? i, int? j, int? k)
    {
        int m = i ?? Int32.MinValue;
        int n = j ?? Int32.MinValue;
        int p = k ?? Int32.MinValue;

        return m < M && n < N && p < K;
    }
    public dynamic? GetValues(int? i, int? j, int? k)
    {
        if (!i.HasValue && !j.HasValue && !k.HasValue)
            throw new Exception("Invalid args: at least one index should not be null");

        if (!IsValidRange(i, j, k))
            throw new Exception("Invalid args: given bounds are incorrect");
        
        if (i.HasValue && j.HasValue && k.HasValue)
            return this[(int)i, (int)j, (int)k];
        
        int fDimensionValue = !i.HasValue ? M : (!j.HasValue ? N : K);
        int fDimensionNumber = !i.HasValue ? Dim0 : (!j.HasValue ? Dim1 : Dim2);
        int? sDimensionValue = !j.HasValue && fDimensionValue != N ? N : (!k.HasValue ? K : null);
        int? sDimensionNumber = !j.HasValue && fDimensionNumber != Dim1 ? Dim1 : (!k.HasValue ? Dim2 : null);
        if (!sDimensionValue.HasValue)
        {
            T[] result = new T[fDimensionValue];
            for (int index = 0; index < fDimensionValue; index++)
            {
                if (fDimensionNumber == Dim0)
                {
                    result[index] = this[index, (int)j, (int)k];
                }
                if (fDimensionNumber == Dim1)
                {
                    result[index] = this[(int)i, index,(int)k];
                }
                if (fDimensionNumber == Dim2)
                {
                    result[index] = this[(int) i, (int)j, index];
                }
            }

            return result;
        }
        else
        {
            T[,] result = new T[fDimensionValue, (int) sDimensionValue]; 
            for (int fIndex = 0; fIndex < fDimensionValue; fIndex++)
            {
                for (int sIndex = 0; sIndex < sDimensionValue; sIndex++)
                {
                    if (fDimensionNumber == Dim0 && sDimensionNumber == Dim1)
                    {
                        result[fIndex,sIndex] = this[fIndex, sIndex, (int) k];
                    }
                    else if (fDimensionNumber == Dim1 && sDimensionNumber == Dim2)
                    {
                        result[fIndex,sIndex] = this[(int) i, fIndex, sIndex];
                    }
                    else if (fDimensionNumber == Dim0 && sDimensionValue == Dim2)
                    {
                        result[fIndex,sIndex] =  this[fIndex,(int) j, sIndex];
                    }
                }
            }
            return result;
        }
    }

    public void SetValues(int i, int j, int k, T value)
    {
        if(!IsValidRange(i, j,k))
            throw new Exception("Invalid args: given bounds are incorrect");
        this[i,j,k] = value;
    }
    
    public void SetValues(int? i,int? j, int? k, IList<T> values)
    {
        
        if (!i.HasValue && !j.HasValue && !k.HasValue)
            throw new Exception("Invalid args: at least one index should not be null");

        if (!IsValidRange(i, j, k))
            throw new Exception("Invalid args: given bounds are incorrect");
        
        
        int dimensionValue = !i.HasValue ? M : (!j.HasValue ? N : K);
        
        if(values.Count > dimensionValue || i > dimensionValue || j > dimensionValue && k > dimensionValue)
            throw new Exception("Given values range is out of the array bounds");
        
        int dimensionNumber = !i.HasValue ? Dim0 : (!j.HasValue ? Dim1: Dim2);
        for (int index = 0; index <  values.Count; index++)
        {
            if (dimensionNumber == Dim0)
            {
                this[index, (int) j, (int) k] = values[index];
            }
            else if (dimensionNumber == Dim1)
            {
                this[(int) i, index, (int) k] = values[index];
            }
            else
            {
                this[(int) i, (int) j, index] = values[index];
            }
        }
    }
    public void SetValues(int? i,int? j, int? k, IList<IList<T>> values)
    {
        if (!i.HasValue && !j.HasValue && !k.HasValue)
            throw new Exception("Invalid args: at least one index should not be null");
        if(!IsValidRange(i, j, k))
            throw new Exception("Invalid args: given bounds are incorrect");
        
        int fDimensionValue = !i.HasValue ? M : (!j.HasValue ? N : K);
        int fDimensionNumber = !i.HasValue ? Dim0 : (!j.HasValue ? Dim1 : Dim2);
        int sDimensionValue = !j.HasValue && fDimensionValue != N ? N : K;

        if(values.Count > fDimensionValue || values[0].Count > sDimensionValue)
            throw new Exception("Given values range is out of the array bounds");
        int? sDimensionNumber = !j.HasValue && fDimensionNumber != Dim1 ? Dim1 : (!k.HasValue ? Dim2 : null);
        for (int fIndex = 0; fIndex < values.Count; fIndex++)
        {
            for (int sIndex = 0; sIndex < values[fIndex].Count; sIndex++)
            {
                if (fDimensionNumber == Dim0 && sDimensionNumber == Dim1)
                {
                    this[fIndex, sIndex, (int) k] = values[fIndex][sIndex];
                }
                else if (fDimensionNumber == Dim1 && sDimensionNumber == Dim2)
                {                   
                    this[(int) i, fIndex, sIndex] = values[fIndex][sIndex];
                }
                else if (fDimensionNumber == Dim0 && sDimensionNumber == Dim2)
                {
                    this[fIndex,(int) j, sIndex] = values[fIndex][sIndex];
                }
            }
        }
    }

    public void Fill(T val)
    {
        for (int i = 0; i < M * N * K; i++)
        {
            _cernel[i] = val;
        }
    }
}