namespace AspNetCoreCodingExamples.Domain.DataStructures.Interfaces
{
    public interface IArrayAlgorithms
    {
        int[] Reverse(int[] input);
        int[] ReverseManual(int[] input);

        int FindMin(int[] input);
        int FindMinManual(int[] input);

        int FindMax(int[] input);
        int FindMaxManual(int[] input);

        int Sum(int[] input);
        int SumManual(int[] input);

        int[] FindDuplicates(int[] input);
        int[] FindDuplicatesManual(int[] input);
    }
}
