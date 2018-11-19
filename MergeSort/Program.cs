using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
	class Program
	{
		static void Main()
		{
			List<int> TestData = new List<int>() { 38, 27, 43, 3, 3, 9, 82, 10 } ;
			List<int> result = MergeSort(TestData);

			result.ForEach(el => Console.WriteLine(el));

		}
		public static List<int> MergeSort(List<int> IntList)
		{
			if (IntList.Count <= 1)
			{
				return IntList;
			}

			int middle = IntList.Count / 2;
			List<int> LeftHalf = new List<int>();
			List<int> RightHalf = new List<int>();

			for (int i = 0; i < middle; i++)
			{
				LeftHalf.Add(IntList[i]);
			}
			for (int i = middle, n = IntList.Count; i < n; i++)
			{
				RightHalf.Add(IntList[i]);
			}

			LeftHalf = MergeSort(LeftHalf);
			RightHalf = MergeSort(RightHalf);

			return Merge(LeftHalf, RightHalf);
		}

		private static List<int> Merge(List<int> LeftHalf, List<int> RightHalf)
		{
			List<int> merger = new List<int>();

			while(LeftHalf.Count > 0 || RightHalf.Count > 0)
			{
				if (LeftHalf.Count > 0 && RightHalf.Count > 0)
				{
					if (LeftHalf.First() <= RightHalf.First())
					{
						merger.Add(LeftHalf.First());
						LeftHalf.Remove(LeftHalf.First());
					}
					else
					{
						merger.Add(RightHalf.First());
						RightHalf.Remove(RightHalf.First());
					}
				}
				else if (LeftHalf.Count > 0)
				{
					merger.Add(LeftHalf.First());
					LeftHalf.Remove(LeftHalf.First());
				}
				else if (RightHalf.Count > 0)
				{
					merger.Add(RightHalf.First());
					RightHalf.Remove(RightHalf.First());
				}
			}

			return merger;
		}
	}
}
