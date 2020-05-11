using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary
{
    class Helpers
    {
        internal List<Tuple<int, int>> Combinations(List<int> items, bool repetitions = false, int k = 2)
        {
            if (repetitions || k != 2)
                throw new NotImplementedException();

            var combinations = new List<Tuple<int, int>>();

            for (int i = 0; i < items.Count; i++)
                for (int j = i + 1; j < items.Count; j++)
                    combinations.Add(new Tuple<int, int>(items[i], items[j]));

            return combinations;
        }
    }
}
