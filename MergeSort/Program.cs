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

		private static List<int> Merge(List<int> leftHalf, List<int> rightHalf)
		{
			List<int> merger = new List<int>();

			while(leftHalf.Count > 0 || rightHalf.Count > 0)
			{
				if (leftHalf.Count > 0 && rightHalf.Count > 0)
				{
					if (leftHalf.First() <= rightHalf.First())
					{
						merger.Add(leftHalf.First());
						leftHalf.Remove(leftHalf.First());
					}
					else
					{
						merger.Add(rightHalf.First());
						rightHalf.Remove(rightHalf.First());
					}
				}
				else if (leftHalf.Count > 0)
				{
					merger.Add(leftHalf.First());
					leftHalf.Remove(leftHalf.First());
				}
				else if (rightHalf.Count > 0)
				{
					merger.Add(rightHalf.First());
					rightHalf.Remove(rightHalf.First());
				}
			}

			return merger;
		}
	}
}
