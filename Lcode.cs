using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Timers;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCode
{
    public partial class Program
    {
        public static int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;

            int numberOfIsland = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        numberOfIsland += DFS(grid, i, j);
                    }
                }
            }

            return numberOfIsland;
        }

        public static int DFS(char[][] grid, int i, int j)
        {

            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length || grid[i][j] == '0')
                return 0;

            grid[i][j] = '0';

            DFS(grid, i, j + 1);
            DFS(grid, i + 1, j);
            DFS(grid, i - 1, j);
            DFS(grid, i, j - 1);

            return 1;
        }

        public static TreeNode Connect(TreeNode root)
        {
            if (root == null)
                return null;

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);
            queue.Enqueue(null);

            while (queue.Any())
            {
                TreeNode temp = queue.Dequeue();
                //tree with only root element
                if (temp == null && !queue.Any())
                {
                    return root;
                }
                else if (temp == null)
                {
                    queue.Enqueue(null);
                    continue;
                }
                else
                {
                    temp.next = queue.Peek();
                    /*Enqueue left child */
                    if (temp.left != null)
                    {
                        queue.Enqueue(temp.left);
                    }

                    /*Enqueue right child */
                    if (temp.right != null)
                    {
                        queue.Enqueue(temp.right);
                    }
                }
            }

            //while (qu.Count > 0)
            //{
            //    int cnt = qu.Count;
            //    Node next = null;

            //    for (int i = 0; i < cnt; i++)
            //    {
            //        Node cur = qu.Dequeue();
            //        cur.next = next;
            //        next = cur;

            //        if (cur.right != null)
            //            qu.Enqueue(cur.right);

            //        if (cur.left != null)
            //            qu.Enqueue(cur.left);
            //    }
            //}

            return root;
        }

        //printing all fib number till 9 requires Time cmplx o(2^n) 
        //-> above means calling function from for loop
        //printing only nth fib number till 9 requires cmplx o(2^n)
        public static int fibonacciRecursive(int n)
        {
            //code here;
            if (n < 2)
            {
                return n;
            }

            return fibonacciRecursive(n - 1) + fibonacciRecursive(n - 2);
        }

        //Memoaization Rec
        // Time Complexity is o(n)
        public static int fib(int n, int[] memo)
        {
            if (n < 2) return n;
            else if (memo[n] > 0) return memo[n];

            memo[n] = fib(n - 1, memo) + fib(n - 2, memo);
            return memo[n];
        }

        #region String Problems 

        public static void displayReverse(string str)
        {
            if ((str == null) || (str.Length <= 1))
                Console.Write(str);

            if (str.Length > 0)
            {
                displayReverse(str.Substring(0, str.Length - 1));
            }
        }

        public static string ReverseWords(string s)
        {
            if (s == "")
                return s;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                    continue;

                int start = i;
                while (i < s.Length && s[i] != ' ')
                    i++;

                if (sb.Length == 0)
                    sb.Append(s.Substring(start, i - start));
                else
                    sb.Insert(0, s.Substring(start, i - start) + " ");
            }

            string os = sb.ToString();
            return os;
        }
        public static string ReverseWords1(string s)
        {
            char spliter = ' ';
            char[] array = s.ToCharArray();
            int index = 0,
                startIndex = 0;

            while (index <= array.Length - 1)
            {
                //check if you are at end of workd or string end itself
                if (array[index] == spliter || index == array.Length - 1)
                {
                    int endIndex;
                    if (array[index] == spliter)
                        endIndex = index - 1;
                    else
                        endIndex = index;

                    while (startIndex < endIndex)
                    {
                        //array[startIndex] = (char)(array[startIndex] + array[endIndex]);
                        //array[endIndex] = (char)(array[startIndex] - array[endIndex]);
                        //array[startIndex] = (char)(array[startIndex] - array[endIndex]);
                        char temp = array[startIndex];
                        array[startIndex] = array[endIndex];
                        array[endIndex] = temp;

                        startIndex++;
                        endIndex--;
                    }

                    startIndex = index + 1;
                }

                index++;
            }

            return new string(array);
        }

        //using boolean array T o(n) & S is o(1)
        public static bool isUniqueChars(string str)
        {

            if (str.Length > 128) return false;

            bool[] char_set = new bool[128];

            for (int i = 0; i < str.Length; i++)
            {

                if (char_set[str[i]])
                {
                    //Already found this char in string
                    return false;
                }
                char_set[str[i]] = true;
            }
            return true;
        }
        //using Array.Sort
        static bool uniqueCharacters(string str)
        {
            char[] chArray = str.ToCharArray();

            // Using sorting
            Array.Sort(chArray);

            for (int i = 0; i < chArray.Length - 1; i++)
            {

                // if the adjacent elements are not
                // equal, move to next element
                if (chArray[i] != chArray[i + 1])
                    continue;

                // if at any time, 2 adjacent elements
                // become equal, return false
                else
                    return false;
            }

            return true;
        }

        //using two for loops seperately T : O(n) & S : O(1)
        public static bool isPermutuationUsingCharSet(string str1, string str2)
        {
            if (str1.Length != str1.Length)
                return false;

            bool[] flag = new bool[128];
            //using dictionary will be easy 

            for (int i = 0; i < str1.Length; i++)
            {
                flag[str1[i]] = true;
            }

            for (int i = 0; i < str2.Length; i++)
            {
                if (flag[str2[i]] == false)
                    return false;
            }

            return true;
        }

        public static void urlify(string input, int trueLength)
        {
            var str = input.ToCharArray();
            int spacecount = 0;

            for (int i = 0; i < trueLength; i++)
            {
                if (str[i] == ' ')
                    spacecount++;
            }

            int index = trueLength + spacecount * 2;

            if (trueLength < str.Length)
                str[trueLength] = '\0';

            for (int i = trueLength - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    str[index - 1] = '0';
                    str[index - 2] = '2';
                    str[index - 3] = '%';
                    index = index - 3;
                }
                else
                {
                    str[index - 1] = str[i];
                    index--;
                }


            }
        }

        //T : O(n)
        //S: O(1)
        //palindrome permutuation
        public static bool checkIfstringHasPalindrome(string str)
        {
            if (string.IsNullOrWhiteSpace(str) || str.Length < 2)
                return false;

            Dictionary<char, int> charCount = new Dictionary<char, int>();

            int oddCount = 0;
            foreach (var item in str)
            {
                if (item != ' ')
                {
                    if (charCount.ContainsKey(item))
                    {
                        charCount[item] = charCount[item] + 1;
                    }
                    else
                        charCount.Add(item, 1);

                    if (charCount[item] % 2 == 1)
                        oddCount++;
                    else
                        oddCount--;
                }
            }


            return oddCount <= 1;
        }
        //using hashset
        public bool canPermutePalindrome(string s)
        {
            HashSet<char> app = new HashSet<char>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (app.Contains(c))
                {
                    app.Remove(c);
                }
                else
                {
                    app.Add(c);
                }
            }
            return app.Count() <= 1;
        }
        //T: O(m+n)
        //S : o(1)
        public static bool checkIfOneAway(string str1, string str2)
        {
            int count = 0;

            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (var item in str1)
            {

                if (charCount.ContainsKey(item))
                {
                    charCount[item] += charCount[item]++;
                }
                else
                    charCount.Add(item, 1);
            }


            foreach (var item in str2)
            {
                if (!charCount.ContainsKey(item))
                {
                    count++;
                }

                if (count > 1)
                    return false;
            }

            return true;

        }

        public static string CompareS(string str)
        {
            int count = 0;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                count++;
                if (i + 1 >= str.Length || str[i] != str[i + 1])
                {
                    builder.Append(str[i]);
                    builder.Append(count);
                    count = 0;
                }
            }

            return str.Length < builder.ToString().Length ? str : builder.ToString();
        }

        public static bool isPalindrome(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            }


            return true;
        }

        #endregion String Problems

        #region Array Problems
        //Iterative
        public static int MaxSubArray(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];


            int maxSum = nums[0];
            int sum = maxSum;

            for (int i = 1; i < nums.Length; i++)
            {
                sum = Math.Max(nums[i] + sum, nums[i]);
                maxSum = Math.Max(sum, maxSum);
            }

            return maxSum;
        }
                
        // function to find maximum sum of subarray crossing the middle element
        static int maxCrossingSubarray(int[] ar, int low, int mid, int high)
        {
            /*
              Initial leftSum should be -infinity.
            */
            int leftSum = int.MinValue;
            int sum = 0;

            /*
              iterating from middle
              element to the lowest element
              to find the maximum sum of the left
              subarray containing the middle
              element also.
            */
            for (int i = mid; i >= low; i--)
            {
                sum = sum + ar[i];
                if (sum > leftSum)
                    leftSum = sum;
            }

            /*
              Similarly, finding the maximum
              sum of right subarray containing
              the adjacent right element to the
              middle element.
            */
            int rightSum = int.MinValue;
            sum = 0;

            for (int i = mid + 1; i <= high; i++)
            {
                sum = sum + ar[i];
                if (sum > rightSum)
                    rightSum = sum;
            }

            /*
              returning the maximum sum of the subarray
              containing the middle element.
            */
            return (leftSum + rightSum);
        }

        //Recursive
        // function to calculate the maximum subarray sum
        static int maxSumSubarray(int[] ar, int low, int high)
        {
            if (high == low) // only one element in an array
            {
                return ar[high];
            }

            // middle element of the array
            int mid = (high + low) / 2;

            // maximum sum in the left subarray
            int maximumSumLeftSubarray = maxSumSubarray(ar, low, mid);
            // maximum sum in the right subarray
            int maximumSumRightSubarray = maxSumSubarray(ar, mid + 1, high);
            // maximum sum in the array containing the middle element
            int maximumSumCrossingSubarray = maxCrossingSubarray(ar, low, mid, high);

            // returning the maximum among the above three numbers
            var s = Math.Max(maximumSumLeftSubarray, maximumSumRightSubarray);
            return Math.Max(s, maximumSumCrossingSubarray);
        }

        // T : O(n^2)
        // S : O(1)
        //90 degree clock wise
        static bool rotateMatrixClockWise(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix.Length != matrix[0].Length)
                return false;

            int n = matrix.Length;

            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;
                for (int i = first; i < last; i++)
                {
                    int offset = i - first;
                    int top = matrix[first][i]; // save top

                    // move value from bottom Left to  topleft
                    matrix[first][i] = matrix[last - offset][first];

                    //move value from bottom right to bottom left
                    matrix[last - offset][first] = matrix[last][last - offset];

                    // move value from top right to bottom right
                    matrix[last][last - offset] = matrix[i][last];

                    // move value from top to top right
                    matrix[i][last] = top; //saved top
                }
            }
            return true;
        }

        //Time Complexity:
        //- Each element in the array is visited exactly once during the traversal.
        //- The total number of elements is M* N, where M is the number of rows and N is the number of columns.
        //- Therefore, the overall time complexity is O(M* N).
        // total space complexity is O(M * N).
        static void spiralOrder(int[,] array)
        {
            List<int> result = new List<int>();
            int startRow = 0;
            int endRow = array.GetLength(0) - 1;
            int startCol = 0;
            int endCol = array.GetLength(1) - 1;

            if (array.GetLength(0) == 1 && array.GetLength(1) == 1)
                return;

            int resultSize = array.GetLength(0) * array.GetLength(1);

            while (result.Count < resultSize)
            {
                for (int col = startCol; col <= endCol && result.Count < resultSize; col++)
                {
                    result.Add(array[startRow, col]);
                }

                for (int row = startRow + 1; row <= endRow && result.Count < resultSize; row++)
                {
                    result.Add(array[row, endCol]);
                }

                for (int col = endCol - 1; col >= startCol && result.Count < resultSize; col--)
                {
                    result.Add(array[endRow, col]);
                }

                for (int row = endRow - 1; row > startRow && result.Count < resultSize; row--)
                {
                    result.Add(array[row, startCol]);
                }

                startRow++;
                endRow--;
                startCol++;
                endCol--;
            }        
        }

        // T : O(n^2)
        // S : O(1)
        //90 degree Anti clock wise
        static bool rotateMatrixAntiClockWise(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix.Length != matrix[0].Length)
                return false;

            int n = matrix.Length;
            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;
                for (int i = first; i < last; i++)
                {
                    int offset = i - first;
                    int top = matrix[first][i]; // save top


                    matrix[first][i] = matrix[i][last];

                    matrix[i][last] = matrix[last][last - offset];

                    matrix[last][last - offset] = matrix[last - offset][first];

                    matrix[last - offset][first] = top; // right<-saved top

                }
            }

            return true;
        }

        //1. Check if the first row and first column have any zeros, and set variables rowHasZero and
        //columnHasZero. (We'll nullify the first row and first column later, if necessary.)
        //2. Iterate through the rest of the matrix, setting matrix[i][ 0) and matrix[0) [j] to zero whenever
        //there's a zero in matrix[i] [j ].
        //3. Iterate through rest of matrix, nullifying row i if there's a zero in matrix [ i] [ 0].
        //4. Iterate through rest of matrix, nullifying column j if there's a zero in matrix [ 0] [ j].
        //5. Nullify the first row and first column, if necessary(based on values from Step 1 ). 
        //S : o(1) : Constant Space
        public static void SetZeroesConstantSpace(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return;

            bool rowHasZero = false, colHasZero = false;

            //check if first row has zero
            for (int i = 0; i < matrix[0].Length; i++)
            {
                if (matrix[0][i] == 0)
                {
                    rowHasZero = true;
                    break;
                }
            }

            //check if first column has zero
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    colHasZero = true;
                    break;
                }
            }

            //check for zeros in rest of the array
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }

            //nullyfy values based on values in first column and row
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[i].Length; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            if (rowHasZero)
            {
                for (int i = 0; i < matrix[0].Length; i++)
                {
                    matrix[0][i] = 0;
                }
            }

            if (colHasZero)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i][0] = 0;
                }
            }
        }

        //S : o(N)
        public static void SetZeroesNSpace(int[][] matrix)
        {
            
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return;

            bool[,] rowcolindex = new bool[matrix.Length, matrix[0].Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        rowcolindex[i, j] = true;
                    }
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    for (int r = 0; r < rowcolindex.GetLength(0); r++)
                    {
                        for (int c = 0; c < rowcolindex.GetLength(1); c++)
                        {
                            if (rowcolindex[r, c])
                            {
                                matrix[r][j] = 0;
                                matrix[i][c] = 0;
                            }
                        }
                    }

                }
            }
        }

        public static void ArrayofProducts(int[] array)
        {
            int product = 1;
            int n = array.Length;

            int[] result = new int[n];
            
            //Compute left product 
            // Add products of a number toward its left at index in result

            for (int i = 0; i < n; i++)
            {
                result[i] = product;
                product = product * array[i];   
            }

            product = 1;

            // Compute right product
            // Add products of a number toward its right and and add at index
            for (int i = n-1; i >= 0; i--)
            {
                result[i] = result[i] * product;
                product = product * array[i];
            }

        }

        public static int TaskScheduler(char[] tasks, int n) {
            if (tasks?.Length == 1)
                return 1;

            if (n == 0)
                return tasks.Length;

            int[] char_map = new int[26];

            foreach (char c in tasks)
            {
                char_map[c - 'A']++;
            }

            Array.Sort(char_map);

            //  We consider gaps between the most frequent tasks. If a task occurs 3 times, there are only 2 gaps between them.
            int max_val = char_map[25] - 1;
            //Why subtract 1 ? Because there are only(max frequency -1) actual gaps between the tasks:
            //            A _ _ A _ _ A
            // We only need to fill the two gaps(_) between the three As.
            // This means we need 4 idle slots if we only had task A.

            //Each of these gaps must be at least n = 2 apart.
            //So, we start with idle_slots = 2 * 2 = 4.
            int idle_slots = max_val * n;

            // Reduce Idle Slots by Filling with Other Tasks
            for (int i = 24; i >=
                0; i--){
                idle_slots -=Math.Min(char_map[i], max_val);
            }

            return idle_slots > 0 ? idle_slots + tasks.Length : tasks.Length;
        }

        public static int WaterTrap(int[] height)
        {
            // Each bar can trap water depending on the minimum of the maximum heights to its left and right.
            //Let’s say i is a current index.The water it can trap is:
            // water_at_i = min(max_left[i], max_right[i]) - height[i]
            // But we don’t want to store max_left[] and max_right[] arrays(which use extra space). The two-pointer technique computes this on the fly.


            //At each step:
            //We compute the water at the left or right index by:
            //water += maxLeft - height[left]   // if height[left] < height[right]
            //water += maxRight - height[right] // otherwise
            //This guarantees we're trapping only in valleys, where taller bars exist on both sides.

            if (height.Length == 0) return 0;
            int left = 0;
            int right = height.Length - 1;
            int leftMax = height[left];
            int rightMax = height[right];
            int waterTrapped = 0;

            while (left < right) {
                // if h of left is less than right means maxwater than can be trapped aligns with min values, so if its left then take maxleft value out of current left and leftmax
                if (height[left] < height[right]) {
                    left++;
                    leftMax = Math.Max(leftMax, height[left]);
                    waterTrapped += leftMax - height[left];
                }
                else
                {
                    right--;
                    rightMax = Math.Max(rightMax, height[right]);
                    waterTrapped += rightMax - height[right];
                }
            }
             return waterTrapped;
        }

        public static bool CheckSubarraySum(int[] nums, int k)
        {
            // Key Idea
            //- We use a prefix sum and store its modulo k in a hash map to detect repeated remainders.
            //- If the same remainder occurs at two indices i and j, then the subarray between them has a sum that's divisible by k.

            if (nums == null || nums.Length < 2)
                return false;

            // Special case when k == 0: look for two consecutive 0s
            if (k == 0)
            {
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    if (nums[i] == 0 && nums[i + 1] == 0)
                        return true;
                }
                return false;
            }

            int prefixSum = 0;
            int remainder = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            map[0] = -1;  // To handle full prefix sum being divisible by k

            for (int i = 0; i < nums.Length; i++)
            {
                prefixSum += nums[i];
                remainder = prefixSum % k;

                if (map.ContainsKey(remainder))
                {
                    if (i - map[remainder] > 1)
                        return true;
                }
                else
                {
                    map[remainder] = i;
                }
            }

            return false;
        }

        // Time : 0(n* k logk)
        //Space : o(n*k)
        public static List<List<string>> GroupAnagramsWithSorting(string[] strings)
        {
            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();

            foreach (string s in strings)
            {
                char[] charArray = s.ToCharArray();
                Array.Sort(charArray);
                string sorted = new string(charArray);

                if (!d.ContainsKey(sorted))
                {
                    d.Add(sorted, new List<string>());
                    // or d[sorted] = new List<string>();
                }


                d[sorted].Add(s);
            }

            return new List<List<string>>(d.Values);
        }

        // Time : 0(n* k)
        //Space : o(n*k)
        //With Hash Table
        public static List<List<string>> GroupAnagramsWithOutSorting(string[] strings)
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

            foreach (string str in strings)
            {
                int[] characterCount = new int[26];
                foreach (char character in str.ToCharArray())
                {
                    characterCount[character - 'a']++;
                }

                // Convert count array to a string key
                StringBuilder key = new StringBuilder();
                for (int i = 0; i < 26; i++)
                {
                    key.Append(characterCount[i]).Append('#');  // Add delimiter to separate counts
                }

                if (!result.ContainsKey(key.ToString()))
                {
                    result[key.ToString()] = new List<string>();
                }
                result[key.ToString()].Add(str);
            }

            return result.Values.ToList();
        }

        #endregion Array Problems
    }
}