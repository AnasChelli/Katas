using System.Collections.Generic;
using System.Linq;

namespace Katas
{
    public class Solution
    {
        private readonly Dictionary<int, List<Serie>> _indexByValue;

        public Solution()
        {
            _indexByValue = new Dictionary<int, List<Serie>>();
        }
        public int GetIndex(int[] numbers)
        {
            if (!numbers.Any() || numbers == null)
            {
                return -1;
            }

            if (numbers.Length == 1 || numbers.Length == 2)
            {
                return 0;
            }

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (!_indexByValue.ContainsKey(numbers[i]))
                {
                    AddNewItemToDictionnary(numbers[i], i);
                }
                else
                {
                    if (numbers[i] == numbers[i - 1])
                    {
                        IncrementExsitingValue(numbers[i]);
                    }
                    else
                    {
                        AddNewSerie(numbers[i], i);
                    }
                }
            }

            if (numbers.Last() == numbers[numbers.Length - 2])
            {
                IncrementExsitingValue(numbers.Last());
            }
            else
            {
                if (_indexByValue.ContainsKey(numbers.Last()))
                {
                    AddNewSerie(numbers.Last(), numbers.Length - 1);
                }
                else
                {
                    AddNewItemToDictionnary(numbers.Last(), numbers.Length - 1);
                }
            }

            return _indexByValue.Values.SelectMany(x => x).OrderByDescending(x => x.NumberOfRepeatation).First().StartingIndex;
        }

        private void AddNewItemToDictionnary(int value, int index)
        {
            _indexByValue.Add(value, new List<Serie> { new Serie(value, index, 1) });
        }

        private void AddNewSerie(int value, int index)
        {
            _indexByValue[value].Add(new Serie(value, index, 1));
        }

        private void IncrementExsitingValue(int value)
        {
            _indexByValue[value].Last().NumberOfRepeatation++;
        }
    }
}
