/*
You are given integers K, M and a non-empty array A consisting of N integers. Every element of the array is not greater than M.

You should divide this array into K blocks of consecutive elements. The size of the block is any integer between 0 and N. Every element of the array should belong to some block.

The sum of the block from X to Y equals A[X] + A[X + 1] + ... + A[Y]. The sum of empty block equals 0.

The large sum is the maximal sum of any block.

For example, you are given integers K = 3, M = 5 and array A such that:

  A[0] = 2
  A[1] = 1
  A[2] = 5
  A[3] = 1
  A[4] = 2
  A[5] = 2
  A[6] = 2
The array can be divided, for example, into the following blocks:

[2, 1, 5, 1, 2, 2, 2], [], [] with a large sum of 15;
[2], [1, 5, 1, 2], [2, 2] with a large sum of 9;
[2, 1, 5], [], [1, 2, 2, 2] with a large sum of 8;
[2, 1], [5, 1], [2, 2, 2] with a large sum of 6.
The goal is to minimize the large sum. In the above example, 6 is the minimal large sum.

Write a function:

class Solution { public int solution(int K, int M, int[] A); }

that, given integers K, M and a non-empty array A consisting of N integers, returns the minimal large sum.

For example, given K = 3, M = 5 and array A such that:

  A[0] = 2
  A[1] = 1
  A[2] = 5
  A[3] = 1
  A[4] = 2
  A[5] = 2
  A[6] = 2
the function should return 6, as explained above.

Write an efficient algorithm for the following assumptions:

N and K are integers within the range [1..100,000];
M is an integer within the range [0..10,000];
each element of array A is an integer within the range [0..M].
*/

using System;

namespace Codility14._1
{
    class Solution
    {
        public int solution(int K, int M, int[] A)
        {
            int s = 0;
            int sum = 0;
            foreach (int a in A)
                sum += a;
            int start = 0;
            int end = sum;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                int k = 1;
                int tempSum = 0;
                for (int i = 0; i < A.Length;)
                    if (tempSum + A[i] <= mid)
                    {
                        tempSum += A[i];
                        i++;
                    }
                    else
                    {
                        tempSum = 0;
                        k++;
                        if (k > K)
                            break;
                    }
                if (k <= K)
                {
                    s = mid;
                    end = mid - 1;
                }
                else
                    start = mid + 1;
            }
            return s;
        }
    }

    class Program
    {
        static void Main()
        {
            Solution sol = new Solution();
            int K = 3;
            int M = 5;
            //int[] A = { 2, 1, 5, 1, 2, 2, 2 };
            int[] A = { 5, 3 };
            int s = sol.solution(K, M, A);
            Console.WriteLine("Solution: " + s);
            //Console.WriteLine("Solution: " + string.Join(", ", s));
        }
    }
}
