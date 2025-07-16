using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode
{
    public partial class Program
    {
        static char[] count = new char[256];
        static void Main(string[] args)
        {
            string[] ss = { "Hello", "World" };

            //isPalindrome("sagar");
            //isUniqueChars("sager");
            //var s= isPermutuationUsingCharSet("ab", "eidaboo");
            //urlify("Mr John Smith     ", 13);
            //checkIfstringHasPalindrome("abcccba");
            //checkIfOneAway("pall", "pale");
            //CompareS("aabcccccaaa");
            //ReverseWords1("Hello world");

            // Rec Fibo
            //for (int i = 0; i <= 5; i++)
            //{
            //    Console.Write("{0} ", fibonacciRecursive(i));
            //}

            //memo
            //for (int i = 0; i <= 5; i++)
            //{
            //    Console.WriteLine(5 + ":" + fib(i, new int[6]));
            //}

            TreeNode left = new TreeNode(1);
            TreeNode right = new TreeNode(3);
            TreeNode root = new TreeNode(2, left, right);
            //left.left = new TreeNode(4);
            //left.right = new TreeNode(5);
            //right.left = new TreeNode(6);
            //right.right = new TreeNode(7);
            //inorderTraversal(root);

            //Single Linked List
            SLL llist = new SLL();
            //SLL[] lists = new SLL[4];

            //lists[0] = new SLL();
            //lists[0].AddDataToLast(1);
            //lists[0].AddDataToLast(4);
            //lists[0].AddDataToLast(5);

            //lists[1] = new SLL();
            //lists[1].AddDataToLast(1);
            //lists[1].AddDataToLast(3);
            //lists[1].AddDataToLast(4);

            //lists[2] = new SLL();
            //lists[2].AddDataToLast(2);
            //lists[2].AddDataToLast(6);

            //lists[3] = new SLL();
            //lists[3].AddDataToLast(9);
            //lists[3].AddDataToLast(1);

            //llist.MergeKLists(lists);
            //llist.push(1);
            //llist.push(2);
            //llist.push(3);
            //llist.Peek();
            //llist.Pop();
            //llist.AddDataHead(4);
            // llist.DeleteAtIndex(1);
            ////llist.AddDataToLast(1);
            //llist.AddDataToLast(0);

            //llist.AddDataToLast(4);
            //llist.AddDataToLast(1);
            //llist.AddDataToLast(8);
            //llist.AddDataToLast(4);            
            //llist.AddDataToLast(5);

            SLL llist2 = new SLL();
            llist2.AddDataToLast(1);
            llist2.AddDataToLast(2);
            llist2.AddDataToLast(2);
            llist2.AddDataToLast(1);
            //llist2.RemoveZeroSumSublists(llist2.head);
            llist2.IsPalindrome(llist2.head);
            //llist.GetIntersectionNodeHashSet(llist.head, llist2.head);
            //llist.AddDataToLast(5);
            //llist.AddDataToLast(6);
            //llist.AddDataHead(2);
            //llist.AddDataHead(5);
            //llist.RotateRight(llist.head, 3);
            //llist.AddDataToLast(5);
            //llist.DeleteAtIndex(2);
            //llist.AddDataHead(6);
            //llist.AddDataToLast(4);
            //llist.GetValueAtIndex(5);
            //llist.DeleteAtIndex(6);
            //llist.DeleteAtIndex(4);
            //llist.GetValueAtIndex(0);
            //llist.AddAtIndex(5, 0);
            //llist.AddDataHead(6);
            //llist.AddAtIndex(0, 0);
            //llist.AddAtIndex(9, 100);
            // llist.PrintAllNodes();

            //var s= llist2.ReorderList(llist2.head);
            //llist.reverse(llist.head);
            //llist.PrintAllNodes(s);
            //llist.NumComponents(llist.head, new int[] { 0, 1, 3 });
            //end Single Linked List

            //Console.WriteLine("Hello World!");
            int x = 3;

            //bool[] boolArray = new bool[116];
            //string s = "sagar";
            //boolArray[s[0]] = true;
            //When we use square bracket with string like s[i] it gives you character at the location as well as ascii value of character
            //you can use boolArray[s[0]] as index in arrays to store value at that index/ascii value location

            int[] nums = { -10, -3, 0, 5, 9 };
            //MaxSubArray(nums);
            //maxSumSubarray(nums, 0, nums.Length-1);
            int[] input = { 3, 2, 3 };

            int numOfProducts = 6;
            int[] products_from = { 1, 2, 2, 3, 4, 5 };
            int[] products_to = { 2, 4, 5, 5, 5, 6 };
            //getShoppingPatternsTrioMinimum(numOfProducts, products_from, products_to);
            //firstNonRepeating("leetcode");
            //SingleNumber(nums);
            // titleToNumber("YZ");

            int[] array = { 5, 1, 4, 2 };
            //ArrayofProducts(array);
            //SortedArrayToBST(nums);
            //sortedArrayToBSTRecursion(nums, 0, nums.Length - 1);

            //TwoSum(nums, 9);
            // MajorityElement(input);
            int numb = 1234;
            //maximumSwap(2736);
            //MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });
            //maxSumSubarray(new int[] { 5, 4, -1, 7, 8 }, 0, 4);

            BinaryTree tree = new BinaryTree();
            tree.root = new TreeNode(1);
            tree.root.left = new TreeNode(2);
            tree.root.right = new TreeNode(3);
            tree.root.left.left = new TreeNode(4);
            tree.root.left.right = new TreeNode(5);
            //tree.root.left.right.left = new TreeNode(6);
            // tree.root.left.right.right = new TreeNode(7);
            tree.root.right.right = new TreeNode(7);
            tree.root.right.left = new TreeNode(6);
            //Connect(tree.root);

            //Console.WriteLine("Height of tree is : " + IsValidBST(tree.root));
            //LowestCommonAncestor(tree.root, tree.root.left, tree.root.right.left);

            //BinaryTree tree = new BinaryTree();
            //tree.root = new TreeNode(4);
            //tree.root.left = new TreeNode(1);
            //tree.root.left.left = new TreeNode(0);
            //tree.root.left.right = new TreeNode(2);
            //tree.root.left.right.right = new TreeNode(3);

            //tree.root.right = new TreeNode(6);
            //tree.root.right.left = new TreeNode(5);
            //tree.root.right.right = new TreeNode(7);
            //tree.root.right.right.right = new TreeNode(8);
            //tree.convertBST(tree.root);
            //tree.ConvertBST(tree.root);


            //generateParenthesis(3);            
            //generateParenthesisBruteForce(3);
            //generateParenthesisHash(3);

            MergeList llist1 = new MergeList();
            //MergeList llist2 = new MergeList();

            //// Node head1 = new Node(5);  
            llist1.addToTheLast(new ListNode(1));
            llist1.addToTheLast(new ListNode(2));
            llist1.addToTheLast(new ListNode(3));
            llist1.addToTheLast(new ListNode(4));
            llist1.addToTheLast(new ListNode(5));
            //ReverseBetween(llist1.head, 1, 4);
            //RotateRight(llist1.head, 3);

            //// Node head2 = new Node(2);  
            //llist2.addToTheLast(new ListNode(1));
            //llist2.addToTheLast(new ListNode(4));
            //llist2.addToTheLast(new ListNode(6));

            List<int> inOrder = new List<int>();

            //MergeTwoLists(llist1.head, llist2.head);

            //Generate(5);

            //MinStack minStack = new MinStack();
            //minStack.Push(-2);
            //minStack.Push(0);
            //minStack.Push(-3);
            //minStack.GetMin(); // return -3
            //minStack.Pop();
            //minStack.Top();    // return 0
            //minStack.GetMin(); // return -2

            //StrStr("hello","ll");

            //TrailingZeroes(13);

            string[] str = { "flower", "flow", "flight" };

            //LongestCommonPrefix(str);
            //longestCommonPrefix(str);






            //Contains duplicate III LeetCode
            //ContainsNearbyAlmostDuplicate(new int[] { -2147483648, 2147483647 }, 1, 1);

            //RoundingEg();

            // Creating a graph with 5 vertices
            int V = 3;
            LinkedList<int>[] adj = new LinkedList<int>[V];

            for (int i = 0; i < V; i++)
                adj[i] = new LinkedList<int>();

            // Adding edges one by one
            //addEdge(adj, 0, 1);
            //addEdge(adj, 0, 4);
            //addEdge(adj, 1, 2);
            //addEdge(adj, 1, 3);
            //addEdge(adj, 1, 4);
            //addEdge(adj, 2, 3);
            //addEdge(adj, 3, 4);

            addEdgedirected(adj, 0, 1);
            addEdgedirected(adj, 1, 2);
            addEdgedirected(adj, 2, 0);
            //addEdgedirected(adj, 3, 2);
            //addEdgedirected(adj, 4, 3);
            bool val = isCyclic(V, adj);
            //BFS(adj, 2);
            //DFS(adj, 2);

            //printGraph(adj);

            //Console.ReadKey();

            //List<int> unsorted = new List<int>();
            //List<int> sorted;

            //Random random = new Random();

            //Console.WriteLine("Original array elements:");
            //for (int i = 0; i < 5; i++)
            //{
            //    unsorted.Add(random.Next(0, 100));
            //    Console.Write(unsorted[i] + " ");
            //}
            //Console.WriteLine();

            //sorted = MergeSort(unsorted);

            //Console.WriteLine("Sorted array elements: ");
            //foreach (int aa in sorted)
            //{
            //    Console.Write(aa + " ");
            //}
            //Console.Write("\n");

            //ReverseWords("sagar is mad");
            char[][] board = new char[3][] {
                new char[4]{ 'A', 'B', 'C', 'E' },
                new char[4]{ 'S', 'F', 'C', 'S' },
                new char[4]{ 'A', 'D', 'E', 'E' }
            };
            string word = "ABCCED";
            //Exist(board, word);

            //FirstMissingPositive1(new int[]  { 1, 2, 0 });
            string[] source = new string[] { "/*Test program */", "int main()", "{ ", "  // variable declaration ", "int a, b, c;", "/* This is a test", "   multiline  ", "   comment for ", "   testing */", "a = b + c;", "}" };
            //RemoveComments(source);

            int[][] spiralNum = new int[4][] {
                new int[2]{ 1,2 },
                new int[1]{3},
                new int[1]{3 },
                new int[]{  }
            };
            int[][] build = new int[5][] {
                new int[]{ },
                new int[1]{2},
                new int[1]{1},
                new int[2]{ 1,2 },
                new int[1]{ 3 }
            };
            //SpiralOrder(spiralNum);

            //BuildOrder(build);
            char[][] island = new char[1][] {
                new char[1]{'1'}
            };

            //     string[,] array = new string[,]
            //{
            //     {"cat", "dog","f"},
            //     {"bird", "fish","s"},
            //};      


            // ... A two-dimensional array.
            //int[,] two = new int[2, 2];
            //two[0, 0] = 0;
            //two[1, 0] = 1;
            //two[0, 1] = 2;
            //two[1, 1] = 3;

            //NumIslands(island);

            int[][] rotatem = new int[][]
            { new int[]{ 1,2,3,4},
              new int[]{ 12, 13, 14,5 },
              new int[]{ 11,16,15,6 },
              new int[]{ 10,9,8,7 },
            };
            // rotateMatrixClockWise(rotatem);

            int[,] twoDArrayInt1 = {
            {1,2,3,4 },
            {12,13,14,5},
            { 11,16,15,6},
            {10,9,8,7 }
       };

            int[,] twoDtwo = {
            {1,2, 3, 4},
            {10,11,12,5 },
            { 9,8,7,6}
            };
            //spiralOrder(twoDtwo);
            //SetZeroesConstantSpace(rotatem);
            //SetZeroesNSpace(rotatem);

            //MergeSort(new List<int>() { 5,7,23,9,1,50,0});

            char[] tasks = { 'A', 'A', 'A', 'B', 'B', 'B', };
            //TaskScheduler(tasks, 2);

            int[] height = [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1];
            //WaterTrap(height);

            string[] strs = ["act", "pots", "tops", "cat", "stop", "hat"];
            GroupAnagramsWithOutSorting(strs);

        }

        #region Problems 
        //Shopping Pattern
        private static int getShoppingPatternsTrioMinimum(int numOfProducts, int[] products_from, int[] products_to)
        {
            if (numOfProducts < 1 || products_from == null || products_to == null || products_to.Count() != products_from.Count())
                return -1;

            Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();

            for (int i = 1; i <= numOfProducts; i++)
            {
                graph.Add(i, (new HashSet<int>()));
            }

            for (int i = 0; i < products_from.Count(); i++)
            {
                //since its undirected
                graph[products_from[i]].Add(products_to[i]);
                graph[products_to[i]].Add(products_from[i]);
            }

            int count = int.MaxValue;
            for (int i = 1; i <= numOfProducts; i++)
            {
                for (int j = i + 1; j <= numOfProducts; j++)
                {
                    for (int k = j + 1; k <= numOfProducts; k++)
                    {
                        if (graph[i].Contains(j) && graph[j].Contains(k) && graph[k].Contains(i))
                        {
                            // these vertices forms a TRio
                            int val = (graph[i].Count() + graph[j].Count() + graph[k].Count()) - 6;
                            count = Math.Min(count, val);
                        }
                    }
                }
            }

            return count;
        }

        //Merge two sorted single linked list
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
                return null;

            if (l1 == null && l2 != null)
            {
                return l2;
            }
            else if (l1 != null && l2 == null)
            {
                return l1;
            }

            var newHead = new ListNode(0);
            ListNode resultNode = newHead;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    resultNode.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    resultNode.next = l2;
                    l2 = l2.next;
                }

                resultNode = resultNode.next;
            }

            if (l1 != null) resultNode.next = l1;
            if (l2 != null) resultNode.next = l2;

            return newHead.next;
        }

        /// <summary>
        /// Pascal Traingle
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public static IList<IList<int>> Generate(int numRows)
        {
            List<int>[] results = new List<int>[numRows];

            if (numRows != 0)
            {
                results[0] = new List<int>();
                results[0].Add(1);
                for (int row = 1; row <= numRows - 1; row++)
                {
                    results[row] = new List<int>();

                    results[row].Add(1);//Add 1 as first element

                    if (row > 1)
                        for (int i = 1; i <= row - 1; i++)
                            results[row].Add(results[row - 1][i - 1] + results[row - 1][i]);

                    results[row].Add(1);//Add 1 as last element
                }
            }

            return results;
        }

        //Maximum Swap ( 2swaps allowed)
        public static int maximumSwap(int num)
        {
            char[] A = Convert.ToString(num).ToCharArray();
            char[] ans = new char[A.Length];

            Array.Copy(A, ans, A.Length);

            for (int i = 0; i < A.Length; i++)
            {
                for (int j = i + 1; j < A.Length; j++)
                {
                    char tmp = A[i];
                    A[i] = A[j];
                    A[j] = tmp;
                    for (int k = 0; k < A.Length; k++)
                    {
                        if (A[k] != ans[k])
                        {
                            if (A[k] > ans[k])
                            {
                                Array.Copy(A, ans, A.Length);
                            }
                            break;
                        }
                    }
                    A[j] = A[i];
                    A[i] = tmp;
                }
            }

            return Convert.ToInt32(ans);
        }

        //Container with most water
        public static int MaxArea(int[] height)
        {

            if (height == null)
                return 0;
            int water = 0;

            for (int i = 0; i < height.Length; i++)
            {

                for (int j = i + 1; j < height.Length; j++)
                {
                    int min = Math.Min(height[i], height[j]);
                    water = Math.Max(water, min * (j - i));

                }
            }

            return water;

        }

        #region General Parenthesis Backtracking Approach
        public static List<String> generateParenthesis(int n)
        {
            List<String> ans = new List<String>();
            backtrack(ans, "", 0, 0, n);
            return ans;
        }

        public static void backtrack(List<String> ans, string cur, int open, int close, int max)
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

        #endregion General Parenthesis Backtracking Approach

        #region General Parenthesis Brute Force Approach
        public static List<String> generateParenthesisBruteForce(int n)
        {
            List<String> combinations = new List<String>();
            generateAll(new char[2 * n], 0, combinations);
            return combinations;
        }

        public static void generateAll(char[] current, int pos, List<String> result)
        {
            if (pos == current.Length)
            {
                if (valid(current))
                    result.Add(new String(current));
            }
            else
            {
                current[pos] = '(';
                generateAll(current, pos + 1, result);
                current[pos] = ')';
                generateAll(current, pos + 1, result);
            }
        }

        public static Boolean valid(char[] current)
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

        #region General Parenthesis Substring Approach
        public static List<String> generateParenthesisHash(int n)
        {
            if (n == 1) return new List<String>() { "()" };

            HashSet<String> set = new HashSet<String>();

            foreach (String str in generateParenthesisHash(n - 1))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    set.Add(str.Substring(0, i + 1) + "()" + str.Substring(i + 1, (str.Length - (i + 1))));
                }
            }

            return new List<string>(set);
        }
        #endregion

        public static bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (t < 0) return false;
            SortedSet<long> ss = new SortedSet<long>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (ss.GetViewBetween((long)nums[i] - t, (long)nums[i] + t).Count > 0) return true;
                ss.Add(nums[i]);
                if (i >= k) ss.Remove(nums[i - k]);
            }
            return false;
        }

        private static async Task<string> StartAsyncOperation()
        {
            try
            {
                await OperationAsync1();
                Console.WriteLine("6000");
                // await OperationAsync2();
                // Console.WriteLine("5000");
                // await OperationAsync3();
                // Console.WriteLine("3000");
                return "Rascala..";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static async Task OperationAsync3()
        {
            await Task.Delay(3000);

        }

        private static async Task OperationAsync2()
        {

            await Task.Delay(5000);

        }

        private static async Task OperationAsync1()
        {
            //Console.WriteLine("1");
            await Task.Delay(6000);
            // Console.WriteLine("2");

        }
        #endregion Problems
    }}

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode next;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null, TreeNode next = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
            this.next = next;
        }
    }

    public class BinaryTree
    {
        public TreeNode root;

        //Maximum depth of a tree Recursive



    }

    public class MergeList
    {

        public ListNode head;
        public void addToTheLast(ListNode node)
        {
            if (head == null)
            {
                head = node;
            }
            else
            {
                ListNode temp = head;
                while (temp.next != null)
                    temp = temp.next;
                temp.next = node;
            }
        }
    }

    //stack Get Min with tuple
    public class MinStack
    {
        private Stack<(int Value, int Min)> _stack;

        public MinStack()
        {
            _stack = new Stack<(int, int)>();
        }

        public void Push(int x)
        {
            var min = _stack.Any() ? Math.Min(x, GetMin()) : x;
            _stack.Push(new ValueTuple<int, int>(x, min));
        }

        public void Pop()
        {
            _stack.Pop();
        }

        public int Top()
        {
            return _stack.Peek().Value;
        }

        public int GetMin()
        {
            return _stack.Peek().Min;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class DllNode
    {
        public int val;
        public DllNode next;
        public DllNode prev;
        public DllNode(int val = 0, DllNode next = null, DllNode prev = null)
        {
            this.val = val;
            this.next = next;
            this.prev = prev;
        }
    }