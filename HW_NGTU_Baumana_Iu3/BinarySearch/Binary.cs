﻿namespace HW_NGTU_Baumana_Iu3.BinarySearch;

public class Binary
{
    public int Search(List<int> array, int x, int index = 0)
    {
        int centre = array.Count / 2;
        int value = array[centre];

        if (value < x)
        {
            index += centre;
            return Search(array.GetRange(centre, array.Count - centre), x, index);
        }

        if (value > x)
        {
            return Search(array.GetRange(0, centre), x, index);
        }

        index += centre;
        return index;
    }
}