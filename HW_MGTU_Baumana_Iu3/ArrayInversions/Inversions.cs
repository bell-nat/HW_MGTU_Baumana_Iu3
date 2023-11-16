namespace HW_MGTU_Baumana_Iu3.ArrayInversions;

public class Inversions
{
    public int CheckInversions(int[] array)
    {
        int count = 0;
        bool repeat = false;
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] < array[i + 1])
            {
                (array[i], array[i + 1]) = (array[i + 1], array[i]);
                count++;
                repeat = true;
            }

            if (i == array.Length - 2 && repeat)
            {
                i = -1;
                repeat = false;
            }
        }

        return count;
    }
}