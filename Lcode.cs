using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public partial class Program
    {
        #region other
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
            if (n <= 1)
            {
                return 1;
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

        private static Dictionary<int, int> memo = new Dictionary<int, int>();
        public static int Fib(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            if (!memo.ContainsKey(n))
            {
                memo[n] = Fib(n - 1) + Fib(n - 2);
            }
            return memo[n];
        }

        List<int> FindPrimesIterative(int n)
        {
            List<int> result = new List<int>();

            for (int i = 2; i <= n; i++)
            {
                if (IsPrimeIterative(i))      // uses the iterative prime checker
                    result.Add(i);
            }

            return result;
        }
        bool IsPrimeIterative(int num)
        {
            if (num < 2) return false;

            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                    return false;  // found divisor → not prime
            }
            return true;            // no divisor found → prime
        }

        List<int> FindPrimesRecursive(int n)
        {
            if (n < 2)
                return new List<int>();       // base case: no primes below 2

            // recursive call for all smaller numbers
            List<int> result = FindPrimesRecursive(n - 1);

            if (IsPrimeRecursive(n))          // uses the recursive prime checker
                result.Add(n);                // add current number if prime

            return result;
        }
        bool IsPrimeRecursive(int num, int i = 2)
        {
            if (num < 2) return false;
            if (i * i > num) return true;     // base case: checked all possible divisors
            if (num % i == 0) return false;   // found divisor → not prime

            return IsPrimeRecursive(num, i + 1);  // recursive step: try next i
        }


        //Without memoization(pure recursion):
        //Time complexity → O(2ⁿ) (explodes fast)
        //With DP(top-down memoization) :
        //Each(i, cap) solved once → O(n × cap)
        public static int knapsack(int[] weight, int[] values, int cap)
        {
            int n = weight.Length;
            int[,] dp = new int[n + 1, cap + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= cap; j++)
                {
                    dp[i, j] = -1;
                }
            }

            return knapsackRecursive(weight, values, n, cap, dp);
        }

        private static int knapsackRecursive(int[] weight, int[] values, int n, int cap, int[,] dp)
        {
            if (n == 0 || cap == 0)
                return 0;

            if (dp[n, cap] != -1)
                return dp[n, cap];


            if (weight[n - 1] > cap)
                return dp[n, cap] = knapsackRecursive(weight, values, n - 1, cap, dp);
            else
            {
                int include = values[n - 1] + knapsackRecursive(weight, values, n - 1, cap - weight[n - 1], dp);
                int exclude = knapsackRecursive(weight, values, n - 1, cap, dp);
                return dp[n, cap] = Math.Max(include, exclude);
            }

            // OR
            //int result;
            //if (weight[n - 1] > cap)
            //    result = knapsackRecursive(weight, values, n - 1, cap, dp);
            //else
            //{
            //    int include = values[n - 1] + knapsackRecursive(weight, values, n - 1, cap - weight[n - 1], dp);
            //    int exclude = knapsackRecursive(weight, values, n - 1, cap, dp);
            //    result = Math.Max(include, exclude);
            //}
            //dp[n, cap] = result;
            //return result;
        }

        #endregion other

        #region string Problems 

        // dlrow olleh
        public static string displayReverse(string str)
        {
            if (string.IsNullOrEmpty(str) || str.Length == 1)
                return str;

            return str[str.Length - 1] + displayReverse(str.Substring(0, str.Length - 1));
        }

        public void ReverseString(char[] s)
        {

            int start = 0;
            int end = s.Length - 1;
            while (start < end)
            {
                char temp = s[start];
                s[start] = s[end];
                s[end] = temp;
                start++;
                end--;
            }
        }

        public void ReverseStringRecursive(char[] s)
        {
            ReverseHelper(s, 0, s.Length - 1);
        }

        private void ReverseHelper(char[] s, int start, int end)
        {
            // Base case: stop when pointers cross
            if (start >= end) return;

            // Swap characters
            char temp = s[start];
            s[start] = s[end];
            s[end] = temp;

            // Move pointers inward and recurse
            ReverseHelper(s, start + 1, end - 1);
        }

        //The i += 2*k handles the block structure, and Math.Min(i + k - 1, n - 1)
        //ensures we reverse only the valid range — this naturally satisfies both “fewer than k” and “between k and 2k” cases.
        //Time Complexity: O(n)
            //Each character is visited and possibly swapped at most once during reversal.
            //The outer loop runs in steps of 2k, so total iterations still cover the entire string once → linear time.
        // Space: o(1)
        public string ReverseStr(string s, int k)
        {
            char[] arr = s.ToCharArray();
            int n = arr.Length;

            for (int i = 0; i < n; i += 2 * k)
            {
                int left = i;
                int right = Math.Min(i + k - 1, n - 1); // reverse up to k chars or end
                Reverse(arr, left, right);
            }

            return new string(arr);
        }

        private void Reverse(char[] arr, int left, int right)
        {
            while (left < right)
            {
                char temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
                left++;
                right--;
            }
        }

        // world hello
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
                {
                    i++;
                }

                if (sb.Length == 0)
                    sb.Append(s.Substring(start, i - start));
                else
                    sb.Insert(0, s.Substring(start, i - start) + " ");
            }

            string os = sb.ToString();
            return os;
        }

        // dlrow olleh
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

        // This is case senetive palindrome logic A is different from a
        // Considers non-alphanumeric characters as well like spaces, punctuatins, symbols
        public static bool isPalindrome(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            }


            return true;
        }

        // This is case insenetive palindrome logic
        // Considers alphanumeric only
        public static bool isPalindromestring(string s)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in s.ToLower())
            {
                if (char.IsLetterOrDigit(c))
                {
                    builder.Append(c);
                }
            }

            string filtered = builder.ToString();

            if (string.IsNullOrWhiteSpace(filtered))
            {
                return false;
            }

            for (int i = 0; i < filtered.Length / 2; i++)
            {
                if (filtered[i] != filtered[filtered.Length - 1 - i])
                    return false;
            }

            return true;
        }

        // TC : O(n2)
        // Brute Force
        public static string LongestPalindromeSubstring(string s)
        {
            int n = s.Length;
            List<string> substrings = new List<string>();

            for (int start = 0; start < n; start++)
            {
                for (int end = start + 1; end <= n; end++)
                {
                    substrings.Add(s.Substring(start, end - start));
                }
            }

            string result = null;

            foreach (string substring in substrings)
            {
                bool flag = true;
                for (int i = 0; i < substring.Length / 2; i++)
                {
                    if (substring[i] != substring[substring.Length - 1 - i])
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag && result?.Length < substring.Length)
                {
                    result = substring;
                }

            }

            return result;
        }

        // TC : O(n2)
        // Expand Around Center
        public static string LongestPalindromeSubstringExp(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";

            int start = 0, maxLength = 1;

            for (int center = 0; center < s.Length; center++)
            {
                // Odd-length palindrome
                int len1 = ExpandFromCenter(s, center, center);

                // Even-length palindrome
                int len2 = ExpandFromCenter(s, center, center + 1);

                int len = Math.Max(len1, len2);

                if (len > maxLength)
                {
                    //                    This line calculates the starting index of the palindrome when a new longer one is found.
                    //                    Why this works:
                    //                    When expanding around center:
                    //                    The palindrome's total length is len
                    //                    So its starting index should be:
                    //                    center - (len - 1) / 2

                    //This formula works for both odd and even - length palindromes.
                    //Example:

                    //Let’s say:
                    //    center = 5
                    //    len = 6(even length)
                    //Then:
                    //    start = 5 - (6 - 1) / 2 = 5 - 2 = 3
                    //That means the palindrome starts at index 3 and spans 6 characters.
                    //It works similarly for odd - length palindromes too.

                    start = center - (len - 1) / 2;
                    maxLength = len;
                }
            }

            return s.Substring(start, maxLength);
        }

        private static int ExpandFromCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length)
            {
                if (s[left] != s[right])
                {
                    break;
                }

                left--;
                right++;
            }

            // Return length of the palindrome

            //When the while loop ends, it’s because s[left] != s[right] or the bounds were exceeded.
            //But we had already expanded one step too far, so:
            //The last valid palindrome had:
            //left + 1 as its start index
            //right - 1 as its end index
            //So:
            //The length = (right - 1) - (left + 1) + 1 = right - left - 1
            //That’s why we return right - left - 1.
            return right - left - 1;
        }

        // Serialize: Convert list of strings to a single string
        public static string Serialize(List<string> strs)
        {
            var sb = new StringBuilder();

            foreach (var s in strs)
            {
                if (s.Length > 65535)
                    throw new ArgumentException("string length exceeds 65535.");

                // Append 2-byte big-endian length prefix
                char highByte = (char)(s.Length >> 8);     // Get high 8 bits
                char lowByte = (char)(s.Length & 0xFF);    // Get low 8 bits

                //0xFF is hexadecimal literal which represents binary value : 11111111
                // In decimal it is 255
                // e.g. Suppose string length is 300
                // In Binary : 300 = 00000001 00101100 (16bits)
                //                   HighByte Lowbyte
                // s.length >> 8 gets the hight byte = 1
                // so 300 = 00000001 00101100 >> 8 = 00000000 00000001 -->result 1
                // low byte 300 & 0xFF = 300  = 00000001 00101100
                //                       0xFF = 00000000 11111111
                //                       Result = 00000000 00101100  --> result 44
                // This is bit mask to keep lower bits


                sb.Append(highByte);  // First char = high byte
                sb.Append(lowByte);   // Second char = low byte

                sb.Append(s);         // Then the actual string
            }

            return sb.ToString();
        }

        // Deserialize: Convert single string back into list of strings
        public static List<string> Deserialize(string data)
        {
            var result = new List<string>();
            int i = 0;

            while (i < data.Length)
            {
                if (i + 2 > data.Length)
                    throw new ArgumentException("Corrupted data: incomplete length prefix.");

                // Read 2-byte length prefix (big-endian)
                int highByte = data[i];
                int lowByte = data[i + 1];
                int length = (highByte << 8) + lowByte;

                // while decoding length = (1 << 8) + 44 = 300

                i += 2; // this is to move pass the 2 byte prefix

                // string does not run pass the end of data
                if (i + length > data.Length)
                    throw new ArgumentException("Corrupted data: string length exceeds available data.");

                // Extract the original string
                string s = data.Substring(i, length);
                result.Add(s);

                i += length; // move to next string prefix
            }

            return result;
        }

        // T.C. = o(n) where n is the length of string + substring extraction occurs at each iteration which takes o(k) time 
        // where k is the lengh of substring,since this happens in each iteration total substring extracion cost can be considered as o(n2)
        // over all dominant factor is substring extraction leading to avg time complexity of o(n2)
        // S.C. = o(n)
        public static string LongestSubstringWithoutDuplicationWithSubstringFunc(string str)
        {
            string result = "";
            string sub = "";
            int startIndex = 0;

            if (string.IsNullOrWhiteSpace(str))
                return result;

            var dict = new Dictionary<char, int>();

            for (int i = 0; i < str.Length; i++)
            {
                if (dict.ContainsKey(str[i]))
                {
                    startIndex = Math.Max(startIndex, dict[str[i]] + 1);
                }

                dict[str[i]] = i;

                // So i + 1 - startIndex gives the length of the current substring (from startIndex to i inclusive).
                // Let’s say startIndex = 3, i = 6, the substring should include characters at index 3, 4, 5, and 6.
                //So its length is 6 + 1 - 3 = 4
                sub = str.Substring(startIndex, i + 1 - startIndex);

                if (sub.Length > result.Length)
                    result = sub;
            }
            return result;
        }

        // Time: O(n)
        // Space: O(k), where k = number of unique characters in the string
        public static string LongestSubstringWithoutDuplication(string str)
        {

            if (string.IsNullOrWhiteSpace(str))
                return "";

            var dict = new Dictionary<char, int>();
            int startIndex = 0;      // Start index of current window
            int maxLength = 0;       // Length of longest substring
            int longestStart = 0;    // Start index of longest substring

            for (int i = 0; i < str.Length; i++)
            {
                char currentChar = str[i];

                if (dict.ContainsKey(currentChar))
                {
                    // Ensure we don't move startIndex backwards
                    startIndex = Math.Max(startIndex, dict[currentChar] + 1);
                }

                dict[currentChar] = i;

                // Update the max length and starting point if this window is the longest so far
                int currentLength = i + 1 - startIndex;

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    longestStart = startIndex;
                }
            }

            return str.Substring(longestStart, maxLength);
        }

        public static int LengthOfLongestSubstring_HashSet(string s)
        {
            // Edge case: empty string
            if (s.Length == 0)
                return 0;

            var charSet = new HashSet<char>();
            int left = 0;
            int maxLength = 0;

            // Expand window with right pointer
            for (int right = 0; right < s.Length; right++)
            {
                // If duplicate found, shrink window from left
                while (charSet.Contains(s[right]))
                {
                    charSet.Remove(s[left]);
                    left++;
                }

                // Add current character to window
                charSet.Add(s[right]);

                // Update maximum length
                // Current window: s[left...right]
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }

        public int LengthOfLongestSubstring_Dictionary(string s)
        {
            // Edge case: empty string
            if (s.Length == 0)
                return 0;

            // Dictionary stores: character -> last seen index
            var charIndexMap = new Dictionary<char, int>();
            int left = 0;
            int maxLength = 0;

            for (int right = 0; right < s.Length; right++)
            {
                char currentChar = s[right];

                // If character exists in current window
                if (charIndexMap.ContainsKey(currentChar))
                {
                    // Jump left pointer to right of previous occurrence
                    // Use Math.Max to avoid moving left backwards
                    left = Math.Max(left, charIndexMap[currentChar] + 1);
                }

                // Update/Add character's latest index
                charIndexMap[currentChar] = right;

                // Calculate maximum length
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }

        public static string RemoveDuplicates(string s, int k)
        {
            StringBuilder sb = new StringBuilder();
            Stack<(char letter, int freq)> stack = new Stack<(char letter, int freq)>();

            for (int i = 0; i < s.Length; i++)
            {
                if (stack.Count > 0 && stack.Peek().letter == s[i])
                {
                    var item = stack.Pop();
                    item.freq++;
                    stack.Push(item);
                }
                else
                {
                    stack.Push((s[i], 1));
                }

                if (stack.Count > 0 && stack.Peek().freq == k)
                {
                    stack.Pop();
                }
            }

            while (stack.Count > 0)
            {
                var item = stack.Pop();
                sb.Insert(0, item.letter.ToString(), item.freq);
            }

            return sb.ToString();
        }

        #region Generate Parenthesis Backtracking Approach
        public static List<string> generateParenthesis(int n)
        {
            List<string> ans = new List<string>();
            backtrack(ans, "", 0, 0, n);
            return ans;
        }

        //        Time Complexity:
        //- The total number of valid parentheses combinations for n pairs is given by the nth Catalan number, which is approximately O(4^n / (n^(3/2))) for large n.
        //- Since the algorithm explores all these combinations, the overall time complexity is exponential, roughly O(4^n / sqrt(n)), dominated by the number of valid sequences.
        //- Each recursive call performs constant work aside from the recursive calls themselves, so the total work is proportional to the number of generated sequences.

        // S.C. : Each sequence has length 2n, so total space for storing all sequences is O(n * number_of_sequences).
        public static void backtrack(List<string> ans, string cur, int open, int close, int max)
        {
            if (cur.Length == max * 2)
            {
                ans.Add(cur);
                return;
            }

            if (open < max)
                backtrack(ans, cur + "(", open + 1, close, max);
            if (close < open)
                backtrack(ans, cur + ")", open, close + 1, max);
        }

        #endregion

        #region Generate Parenthesis Brute Force Approach
        public static List<string> generateParenthesisBruteForce(int n)
        {
            List<string> combinations = new List<string>();
            generateAll(new char[2 * n], 0, combinations);
            return combinations;
        }

        public static void generateAll(char[] current, int pos, List<string> result)
        {
            if (pos == current.Length)
            {
                if (valid(current))
                    result.Add(new string(current));
            }
            else
            {
                current[pos] = '(';
                generateAll(current, pos + 1, result);
                current[pos] = ')';
                generateAll(current, pos + 1, result);
            }
        }

        public static bool valid(char[] current)
        {
            int balance = 0;
            foreach (char c in current)
            {
                if (c == '(') balance++;
                else balance--;
                if (balance < 0) return false;
            }
            return (balance == 0);
        }
        #endregion

        #region Generate Parenthesis Substring Approach
        public static List<string> generateParenthesisHash(int n)
        {
            if (n == 1) return new List<string>() { "()" };

            HashSet<string> set = new HashSet<string>();

            foreach (string str in generateParenthesisHash(n - 1))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    set.Add(str.Substring(0, i + 1) + "()" + str.Substring(i + 1, (str.Length - (i + 1))));
                }
            }

            return new List<string>(set);
        }
        #endregion

        //https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/description/

        #endregion string Problems

        #region Recursion and BackTracking 
        public static IList<IList<int>> Subsets(int[] nums)
        {
            var result = new List<IList<int>>();
            var path = new List<int>();
            Backtrack(path, 0, nums, result);
            return result;
        }

        public static void Backtrack(List<int> path, int start, int[] nums, List<IList<int>> result)
        {
            // 1. Record current state if needed
            result.Add(new List<int>(path));

            // 2. Explore choices
            for (int i = start; i < nums.Length; i++)
            {
                // Choose
                path.Add(nums[i]);

                // Explore
                Backtrack(path, i + 1, nums, result);

                // Un-choose (backtrack)
                path.RemoveAt(path.Count - 1);
            }
        }

        public static int GetCheapestCost(Node node)
        {
            if (node == null) return 0;
            if (node.children == null || node.children.Length == 0) return node.cost;

            var minChild = int.MaxValue;
            foreach (var child in node.children)
                minChild = Math.Min(minChild, GetCheapestCost(child));

            return node.cost + minChild;
        }

        public static double Calc(string expr)
        {
            if (string.IsNullOrEmpty(expr)) return 0;

            Stack<double> numStack = new Stack<double>();
            Stack<char> opStack = new Stack<char>();
            string number = "";

            foreach (char c in expr)
            {
                if (c == ' ') continue;

                if (char.IsDigit(c))
                {
                    number += c; // build multi-digit number
                }
                else // operator
                {
                    // push number before handling operator
                    if (number.Length > 0)
                    {
                        numStack.Push(double.Parse(number));
                        number = "";
                    }

                    // handle operator precedence
                    while (opStack.Count > 0 && Precedence(opStack.Peek()) >= Precedence(c))
                    {
                        EvalTop(numStack, opStack);
                    }

                    opStack.Push(c);
                }
            }

            // push the last number
            if (number.Length > 0)
                numStack.Push(double.Parse(number));

            // evaluate remaining operators
            while (opStack.Count > 0)
            {
                EvalTop(numStack, opStack);
            }

            return numStack.Pop(); // final result
        }

        private static int Precedence(char op)
        {
            if (op == '+' || op == '-') return 1;
            if (op == '*' || op == '/') return 2;
            return 0;
        }

        private static void EvalTop(Stack<double> nums, Stack<char> ops)
        {
            double right = nums.Pop();
            double left = nums.Pop();
            char op = ops.Pop();

            double val = 0;
            switch (op)
            {
                case '+': val = left + right; break;
                case '-': val = left - right; break;
                case '*': val = left * right; break;
                case '/': val = left / right; break;
            }

            nums.Push(val);
        }

        public static IList<IList<int>> Permute(int[] nums)
        {
            // in case of duplicate elements in array 
            // Array.Sort(nums);

            IList<IList<int>> result = new List<IList<int>>();
            List<int> path = new List<int>();
            bool[] used = new bool[nums.Length];
            Backtrack(path, used, nums, result);
            return result;
        }

        public static void Backtrack(List<int> path, bool[] used, int[] nums, IList<IList<int>> result)
        {
            if (path.Count() == nums.Count())
            {
                result.Add(new List<int>(path));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i] == true)
                    continue;
                // in case of duplicate elements in array 
                // Skip rule: if same value as previous and previous not used
                // at this depth, skip to avoid duplicate branches.
                //if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1]) continue;

                used[i] = true;

                path.Add(nums[i]);
                Backtrack(path, used, nums, result);

                path.RemoveAt(path.Count - 1);
                used[i] = false;
            }
        }


        // Let n = candidates.Length, K = # of unique combos output, L = avg length of a combo.
        //Time
        //Sort: O(n log n)
        //Search(worst case) : O(n · 2^n) nodes/overhead for take/skip decisions(duplicates/pruning help constants, not the worst-case bound)
        //Emit results: O(K · L) (copy each found combo)
        //Overall: O(n log n + n · 2^n + K · L)

        //Space(auxiliary)
        //Recursion + path: O(n)
        //(Plus output): O(K · L) if you store all results
        //Total including output: O(n + K · L)
        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            if (candidates == null || candidates.Length == 0) return null;
            Array.Sort(candidates);
            IList<IList<int>> result = new List<IList<int>>();
            List<int> path = new List<int>();
            BacktrackCSUM(0, target, candidates, new List<int>(), result);
            return result;
        }
        public static void BacktrackCSUM(int start, int remainder, int[] candidates, List<int> path, IList<IList<int>> res)
        {
            if (remainder == 0)
            {
                res.Add(new List<int>(path)); // record a copy
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                // Skip duplicate values at the SAME depth to avoid duplicate combinations
                if (i > start && candidates[i] == candidates[i - 1]) continue;

                int val = candidates[i];

                // Since sorted & non-negative, nothing beyond this can fit
                if (val > remainder) break;

                // Choose
                path.Add(val);

                // i+1 enforces "use each element at most once"
                BacktrackCSUM(i + 1, remainder - val, candidates, path, res);

                // Un-choose (backtrack)
                path.RemoveAt(path.Count - 1);
            }
        }

        #endregion

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
            for (int i = n - 1; i >= 0; i--)
            {
                result[i] = result[i] * product;
                product = product * array[i];
            }

        }

        public static int TaskScheduler(char[] tasks, int n)
        {
            if (tasks?.Length == 1)
                return 1;

            if (n == 0)
                return tasks.Length;

            int[] char_map = new int[26];

            //  counts how many times each task appears
            foreach (char c in tasks)
            {
                char_map[c - 'A']++;
            }

            // Ascenidng sort, then most frequently occuring task will be placed at the end of char_map i.e. at index 25
            Array.Sort(char_map);

            //  We consider gaps between the most frequent tasks. If a task occurs 3 times, there are only 2 gaps between them.
            //This subtraction is done to calculate the number of "gaps" between the most frequent tasks.
            int gaps = char_map[25] - 1;
            //Why subtract 1 ? Because there are only(max frequency -1) actual gaps between the tasks:
            //            A _ _ A _ _ A
            // We only need to fill the two gaps(_) between the three As.
            // This means we need 4 idle slots if we only had task A.

            //Each of these gaps must be at least n = 2 apart.
            //So, we start with idle_slots = 2 * 2 = 4.
            int idle_slots = gaps * n;

            // A _ _ A _ _ A
            // Now we try to fill those 4 idle positions with other tasks.
            // We can only place at most one of the same task per gap:
            //We cannot place the same task twice in the same gap, or the cooldown rule would be violated.
            //So even if another task(say B) appears 4 times, we can only use it once per gap.
            // That’s why we use: idle_slots -=Math.Min(char_map[i], gaps);

            // Reduce Idle Slots by Filling with Other Tasks
            for (int i = 24; i >= 0; i--)
            {
                // take min between no of gaps to fill and frequency of char at index i
                idle_slots -= Math.Min(char_map[i], gaps);
                // so lets say B has 3 frequency
                // After first iteration of lopp : idel_slots(4) - = Math.Min(3,2) = 4-2  = 2
                // 2 idle slots filled by 2 Bs out of 3
                // so Array will look like this AB_AB_A
                // at the end of loop idle slots value will be still 2 so add it in result
                //AB_AB_AB
            }

            return idle_slots > 0 ? idle_slots + tasks.Length : tasks.Length;
        }

        public static int WaterTrap(int[] height)
        {
            // Each bar can trap water depending on the minimum of the maximum heights to its left and right.
            // Let’s say i is a current index.The water it can trap is:
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

            while (left < right)
            {
                // if h of left is less than right means maxwater than can be trapped aligns with min values, so if its left then take maxleft value out of current left and leftmax
                if (height[left] < height[right])
                {
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
        //With Hash MAp
        public static List<List<string>> GroupAnagramsWithOutSorting(string[] strings)
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

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
                    if (characterCount[i] > 0)
                    {
                        key.Append(characterCount[i]).Append('#');  // Add delimiter to separate counts
                                                                    //OR
                       // Append character and count
                       // key.Append((char)(i + 'a')).Append(characterCount[i]);
                    }
                }

                if (!result.ContainsKey(key.ToString()))
                {
                    result[key.ToString()] = new List<string>();
                }

                result[key.ToString()].Add(str);
            }

            return result.Values.ToList();
        }

        // Time Complexity : O(n * k + m log m).
        // 1. Iterating through the logs: O(n), where n is the number of log entries.
        // 2. Splitting each log string: O(k), where k is the maximum length of a log string.
        // 3. Dictionary operations (ContainsKey, Add, Increment): O(1)
        // 4 . . Sorting the result list: O(m log m), where m is the number of unique entries in tFreq.

        // Space Complexity : o(m)
        // The dictionary tFreq, which stores counts for each unique sender/receiver: O(m), where m is the number of unique senders/receivers.        // The result list, which can hold up to m entries: O(m).
        public static List<string> processLogs(List<string> logs, int threshold)
        {
            if (logs == null || logs.Count == 0)
                return new List<string>();

            Dictionary<string, int> tFreq = new Dictionary<string, int>();

            foreach (string log in logs)
            {
                string[] transaction = log.Split(' ');

                string sender = transaction[0];
                string receiver = transaction[1];

                if (sender == receiver)
                {
                    if (!tFreq.ContainsKey(sender))
                        tFreq[sender] = 0;

                    tFreq[sender]++;
                }
                else
                {
                    if (!tFreq.ContainsKey(sender))
                        tFreq[sender] = 0;

                    tFreq[sender]++;

                    if (!tFreq.ContainsKey(receiver))
                        tFreq[receiver] = 0;

                    tFreq[receiver]++;
                }
            }

            List<string> result = new List<string>();

            foreach (var entry in tFreq)
            {
                if (entry.Value >= threshold)
                    result.Add(entry.Key);
            }

            result.Sort((a, b) => int.Parse(a).CompareTo(int.Parse(b)));
            return result;
        }

        // TC : o(n)
        // SC : o(1)
        public static int BestSeat(int[] seats)
        {
            int currentStretch = 0;
            int highestStretch = 0;
            int bestSeatIndex = -1;

            for (int i = 1; i <= seats.Length - 1; i++)
            {
                if (seats[i] == 0)
                {
                    currentStretch++;
                }
                else
                {
                    if (currentStretch > highestStretch)
                    {
                        highestStretch = currentStretch;
                        //The first index of the stretch is i - currentStretch.
                        // the last index of the 0 stretch is i - 1.
                        //The middle(ideal seat) is halfway between the start and end:
                        // mid=start + length​/2
                        //=(i−currentStretch+i−1)/2=(2i−1−currentStretch)/2=i−1−currentStretch/2
                        //So:
                        //mid = (i−currentStretch)+currentStretch/2 = i−1−currentStretch/2

                        bestSeatIndex = i - 1 - currentStretch / 2;
                    }

                    currentStretch = 0;
                }
            }

            return bestSeatIndex;
        }

        public int[] TwoSumIndices(int[] nums, int target)
        {
            var dictionary = new Dictionary<int, int>();

            for (int index = 0; index < nums.Length; index++)
            {
                int complement = target - nums[index];
                if (dictionary.ContainsKey(complement))
                {
                    return new int[] { index, dictionary[complement] };
                }

                if (!dictionary.ContainsKey(nums[index]))
                {
                    dictionary.Add(nums[index], index);
                }

            }

            return null;
        }

        public List<(int, int)> AllTwoSumIndices(int[] nums, int target)
        {
            var result = new List<(int, int)>();
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (dict.ContainsKey(complement))
                {
                    result.Add((dict[complement], i));
                }

                // Store only if value not already present, to prevent duplicates
                if (!dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]] = i;
                }
            }

            return result;
        }

        public static IList<(int, int)> TwoSum(int[] nums, int target)
        {
            if(nums.Length == 0)
                return new List<(int, int)>();

            var seen = new HashSet<int>();
            var output = new HashSet<(int,int)>();

            foreach (int i in nums) {
                int complement = target - i;

                if (seen.Contains(complement)) {
                    //ensures each pair is stored in ascending order (e.g., (2, 7) instead of (7, 2)),
                    //which helps avoid duplicates when storing pairs in a HashSet.
                    var pair = i < complement ? (i, complement) : (complement, i);
                    output.Add(pair);
                }

                seen.Add(i);
            }

            return output.ToList();

        }

        public List<List<int>> TwoSumAllPairs(int[] nums, int target)
        {
            var result = new List<List<int>>();
            var seen = new HashSet<int>();

            foreach (var num in nums)
            {
                int complement = target - num;
                if (seen.Contains(complement))
                {
                    result.Add(new List<int> { Math.Min(num, complement), Math.Max(num, complement) });
                }

                seen.Add(num);
            }

            return result;
        }

        //The time complexity is O(n²) — due to the nested two-pointer traversal for each element in the outer loop,
        //after sorting the array in O(n log n) time.
        // The space complexity is O(n) in average case,
        // but it can go up to O(n²) in worst case if all combinations are valid and added to the HashSet to ensure uniqueness.
        public IList<IList<int>> ThreeSumWithHashSet(int[] nums)
        {
            if (nums.Length < 3)
                return new List<IList<int>>();

            Array.Sort(nums);

            // HashSet to track unique triplets
            var uniqueTriplets = new HashSet<(int, int, int)>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum == 0)
                    {
                        // Add as tuple to HashSet
                        uniqueTriplets.Add((nums[i], nums[left], nums[right]));
                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            // Convert HashSet to List<IList<int>>
            var result = new List<IList<int>>();
            foreach (var triplet in uniqueTriplets)
            {
                result.Add(new List<int> { triplet.Item1, triplet.Item2, triplet.Item3 });
            }

            return result;
        }

        //Time complexity remains O(n²) — even though I skip duplicates, the two-pointer structure dominates.
        //The space complexity is O(k), where k is the number of unique triplets in the result —
        //this version is slightly more space efficient than the HashSet version because it avoids the need to track intermediate tuples."
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3)
                return new List<IList<int>>();

            Array.Sort(nums);  // MUST sort first!
            var result = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                // Skip duplicate values for i
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum == 0)
                    {
                        result.Add(new List<int> { nums[i], nums[left], nums[right] });

                        // Skip duplicates for left pointer
                        while (left < right && nums[left] == nums[left + 1])
                            left++;

                        // Skip duplicates for right pointer
                        while (left < right && nums[right] == nums[right - 1])
                            right--;

                        // Move both pointers
                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return result;
        }

        //Subarray Sum (from index i to j):
        // Sum(i to j)=prefix[j]−prefix[i−1]
        //The difference between two cumulative sums tells me the sum of elements between those two points
        //A prefix sum is the running (cumulative) total of array elements from the start up to a given index.
        //Example
        //nums = [3, 4, 5, 2]
        //prefixSum = [3, 7, 12, 14]
        //Find sum of subarray nums[1..3] → [4, 5, 2]
        public static int SubarraySum(int[] nums, int k)
        {
            var prefixSums = new Dictionary<int, int>();
            prefixSums[0] = 1;  // Base case: one way to get sum 0
            int currentSum = 0;
            int count = 0;

            foreach (int num in nums)
            {
                currentSum += num;

                // Check if there is a prefix sum that would make currentSum - k
                if (prefixSums.ContainsKey(currentSum - k))
                {
                    count += prefixSums[currentSum - k];
                }

                // Update prefixSums
                if (!prefixSums.ContainsKey(currentSum))
                    prefixSums[currentSum] = 0;

                prefixSums[currentSum]++;
            }

            return count;
        }


        // T : o(log n)
        // S : o(1) moduleo approach vs O(log n) string conversion approach
        //Each step computes the sum of the squares of digits of the number.
            /*For a number n, let’s say it has d digits.That means:
            You do d operations to extract digits.
            Extracting digits from n (either via string conversion or modulo/division) takes O(log n) time(since d = number of digits = log₁₀n).
            So one full iteration = O(log n)*/
        public bool IsHappy(int n)
        {
            if (n == 1)
                return true;
            int number = 0;
            HashSet<int> seen = new HashSet<int>();

            while (number != 1)
            {
                number = 0;
                foreach (char c in n.ToString())
                {
                    int s = c - '0';
                    number += s * s;
                }

                /*while (n > 0)
                {
                    int digit = n % 10;      // get last digit
                    sum += digit * digit;    // do something with digit (e.g., square it)
                    n = n / 10;              // remove last digit
                }*/
                if (seen.Contains(number))
                    return false;

                seen.Add(number);
                n = number;
            }

            return true;
        }

        private int GetDigitSquareSum(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                int digit = n % 10;
                sum += digit * digit;
                n /= 10;
            }
            return sum;
        }

        // T : O(log n)
        // S : O(1)

        //Do we return true only when we reach 1, or are there other base cases?
        // Can the input number be zero or negative?
        // What’s the expected input range for the number?
        public bool IsHappyCycleDetection(int n)
        {
            int slow = n;
            int fast = GetDigitSquareSum(n);

            while (fast != 1 && slow != fast)
            {
                slow = GetDigitSquareSum(slow);
                fast = GetDigitSquareSum(GetDigitSquareSum(fast));
            }

            return fast == 1;
        }


        #endregion Array Problems
    }
}