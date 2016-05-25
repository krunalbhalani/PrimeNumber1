using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PrimeNumber.Service
{
    public class PrimeNumberService:IPrimeNumberService
    {

        public string GenerateMultidimensionArray(int[] listprimenumbers)
        {
            int acount = listprimenumbers.Length;
            int dimension = (acount + 1) * (acount + 1);

            int[,] arrPrimeNumberTable = new int[acount + 1, acount + 1];


            for (int i = 0; i <= acount; i++)
            {
                for (int z = 0; z <= acount; z++)
                {
                    
                    if (i == 0 && z > 0)
                    {
                        arrPrimeNumberTable[i, z] = listprimenumbers[z - 1];
                    }
                    if (i > 0)
                    {
                        if (z == 0)
                        {
                            arrPrimeNumberTable[i, z] = arrPrimeNumberTable[0, i];
                        }
                        else
                        {
                            arrPrimeNumberTable[i, z] = arrPrimeNumberTable[i, 0] * arrPrimeNumberTable[0, z];

                        }

                    }
                }
            }

            return JsonConvert.SerializeObject(arrPrimeNumberTable);
        }

        public int Check_Prime(int number)
        {
            int i;
            for (i = 2; i <= number - 1; i++)
            {
                if (number % i == 0)
                {
                    return 0;
                }
            }
            if (i == number)
            {
                return 1;
            }
            return 0;
        }

        public int[] Recursive(int value, int cnt, int[] a, int totalnumber)
        {

            int x = Check_Prime(value);

            if (x == 1)
            {
                a[cnt] = value;
                cnt++;
            }
            if (cnt < totalnumber)
            {
                return Recursive(value + 1, cnt, a, totalnumber);
            }
            return a;
        }

    }
}