using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber.Service
{
    public interface IPrimeNumberService
    {

        string GenerateMultidimensionArray(int[] arr);
        int Check_Prime(int number);
        int[] Recursive(int value, int cnt, int[] a, int totalnumber);
    }
}
