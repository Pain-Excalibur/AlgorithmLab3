using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Bubble
    {
        public static int[] Sort(List<int> listInput)
        {
            for (int i = 0; i < listInput.Count; i++)
            {
                for (int j = 0; j < listInput.Count; j++)
                {
                    if (listInput[i] < listInput[j])
                    {
                        var temp = listInput[i];
                        listInput[i] = listInput[j];
                        listInput[j] = temp;
                    }
                }
            }

            return listInput.ToArray();
        }
    }
}
