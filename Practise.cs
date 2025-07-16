using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public partial class Program
    {

        #region Single Linked List Implementation
        internal class SLL
        {
            public ListNode head = null;
            //int length = 0;

            public void AddDataHead(int x)
            {
                ListNode TreeNode = new ListNode(x);
                TreeNode.next = head;
                head = TreeNode;
            }

            //stack Push
            public void push(int x)
            {
                ListNode TreeNode = new ListNode(x);
                TreeNode.next = head;
                head = TreeNode;
            }

            public void AddDataToLast(int x)
            {

                ListNode current = head;
                ListNode prev = null;

                while (current != null)
                {
                    prev = current;
                    current = current.next;
                }

                if (prev == null)
                    head = new ListNode(x);
                else
                    prev.next = new ListNode(x);
            }

            public void AddAtIndex(int index, int v)
            {
                if (index < 0)
                    return;

                if (index == 0)
                    AddDataHead(v);
                else
                {
                    var leaderTreeNode = GetLeaderTreeNode(index);
                    ListNode n = new ListNode(v);
                    n.next = leaderTreeNode.next;
                    leaderTreeNode.next = n;

                }
            }

            public void DeleteAtIndex(int index)
            {
                if (index < 0)
                {
                    return;
                }

                if (index == 0)
                {
                    head = head.next;
                    return;
                }

                var leaderTreeNode = GetLeaderTreeNode(index);
                var deleteTreeNode = leaderTreeNode.next;
                leaderTreeNode.next = deleteTreeNode?.next;
            }

            //stack Pop
            public int Pop()
            {
                int val = -1;
                if (this.head == null)
                    return val;
                else
                {
                    val = head.val;
                    head = head.next;
                }
                return val;
            }

            //stack Peek
            public void Peek()
            {
                int val = -1;
                if (this.head != null)
                    val = head.val;

                Console.WriteLine("Peek:{0}", val);
            }

            public void GetValueAtIndex(int index)
            {
                if (index < 0)
                {
                    return;
                }

                if (index == 0)
                {
                    Console.Write(head.val);
                    return;
                }

                var leaderTreeNode = GetLeaderTreeNode(index);
                Console.Write((leaderTreeNode != null && leaderTreeNode.next != null) ? leaderTreeNode.next.val : -1);
            }

            public ListNode GetLeaderTreeNode(int index)
            {
                var current = head;
                ListNode leaderTreeNode = null;

                var counter = 0;

                while (current != null && counter < index)
                {
                    leaderTreeNode = current;
                    current = current.next;
                    counter++;
                }

                return leaderTreeNode;
            }

            public void PrintAllTreeNodes(ListNode head1 = null)
            {
                //Traverse from head 
                Console.Write("Head ->");
                ListNode curr = head1 == null ? head : head1;
                while (curr != null)
                {
                    Console.Write(curr.val);
                    curr = curr.next;
                    Console.Write("->");
                }

                Console.Write("null");
            }
            //Iterative
            public void Reverse()
            {
                if (head == null)
                {
                    return;
                }
                ListNode current = head;
                ListNode previous = null;


                while (current != null)
                {
                    ListNode temp = current.next;
                    current.next = previous;
                    previous = current;
                    current = temp;
                }

                head.next = null;
                head = previous;
            }
            //Recursive
            public ListNode reverse(ListNode head)
            {
                if (head == null)
                {
                    return head;
                }

                // last node or only one node
                if (head.next == null)
                {
                    return head;
                }

                ListNode newHeadNode = reverse(head.next);

                // change references for middle chain
                head.next.next = head;
                head.next = null;

                // send back new head 
                // node in every recursion
                return newHeadNode;
            }

            public bool HasCycle(ListNode head)
            {
                HashSet<ListNode> TreeNodeVisited = new HashSet<ListNode>();
                while (head != null)
                {
                    if (TreeNodeVisited.Contains(head))
                    {
                        return true;
                    }
                    else
                        TreeNodeVisited.Add(head);

                    head = head.next;
                }

                return false;

            }

            
            //Check recursive version of reorder
            #region reorderList
            public ListNode ReorderList1(ListNode head)
            {
                ListNode tailprev = head;
                ListNode current = head.next;

                while (current.next != null)
                {
                    tailprev = tailprev.next;
                    current = current.next;
                }

                ListNode temp = head.next;
                head.next = current;
                current.next = temp;
                tailprev.next = null;

                ReorderList1(temp);

                return head;
            }

            public ListNode ReorderList(ListNode head)
            {
                if (head == null || head.next == null)
                    return head;

                //head of the first half
                ListNode l1 = head;


                //head of the  second half
                ListNode slow = head;
                //tail of the second half
                ListNode fast = head;
                //tail of the first half
                ListNode prev = null;


                while (fast != null && fast.next != null)
                {
                    prev = slow;
                    slow = slow.next;
                    fast = fast.next.next;
                }

                //last element of the first half points to null
                prev.next = null;

                //reverse second half
                ListNode l2 = Reverse(slow);
                merge(l1, l2);

                return head;
            }

            //didnt get this
            private void merge(ListNode l1, ListNode l2)
            {
                while (l2 != null)
                {
                    ListNode nxt = l1.next;
                    l1.next = l2;
                    l1 = l2;
                    l2 = nxt;
                }
            }

            //didnt get this
            private void merge1(ListNode l1, ListNode l2)
            {
                while (l1 != null)
                {
                    ListNode l1nxt = l1.next;
                    ListNode l2nxt = l2.next;

                    l1.next = l2;

                    if (l1nxt == null)
                        break;

                    l2.next = l1nxt;
                    l1 = l1nxt;
                    l2 = l2nxt;
                }
            }

            private ListNode Reverse(ListNode head)
            {
                ListNode prev = null;
                ListNode current = head;
                while (current != null)
                {
                    ListNode temp = current.next;
                    current.next = prev;
                    prev = current;
                    current = temp;
                }

                head.next = null;
                return prev;
            }

            public void ReorderListRec(ListNode head)
            {
                if (head == null)
                {
                    return;
                }
                ReorderList(head.next, head);
            }

            private ListNode ReorderList(ListNode curr, ListNode parent)
            {
                /* Base case - reaching end of the list, returning the parent (root) TreeNode passed in */
                if (curr == null)
                {
                    return parent;
                }

                /* Otherwise, keep traversing to the end of the list first */
                ListNode nextParent = ReorderList(curr.next, parent);

                /* Result is null, meaning list is already in order, so keep returning null */
                if (nextParent == null)
                {
                    return null;
                }

                /* Unlink the current TreeNode to its original next TreeNode to avoid cycle */
                curr.next = null;

                /* If the resulting parent TreeNode or its next TreeNode equals the current TreeNode in the call stack,
                 * it means we have reached the middle of the list, returning null to end the traversal */
                if (curr == nextParent || curr == nextParent.next)
                {
                    return null;
                }

                /* Otherwise, re-link the current TreeNode with the resulting parent TreeNode */
                curr.next = nextParent.next;
                nextParent.next = curr;

                // Return the next parent TreeNode to the previous call stack
                return curr.next;
            }
            #endregion reorderList 

            #region merge K List
            public SLL MergeKLists(SLL[] lists)
            {
                if (lists.Length == 0)
                    return null;

                int interval = 1;
                int len = lists.Length;

                while (interval < len)
                {
                    for (int i = 0; i + interval < len; i += (interval * 2))
                    {
                        mergeforSorting(lists, i, interval + i);
                    }

                    interval *= 2;
                }


                return lists[0];
            }

            private void mergeforSorting(SLL[] lists, int index1, int index2)
            {
                ListNode dummy = new ListNode(0);
                ListNode ptr = dummy;

                SLL l1 = lists[index1];
                SLL l2 = lists[index2];

                while (l1.head != null || l2.head != null)
                {
                    if (l1.head == null)
                    {
                        ptr.next = l2.head;
                        break;
                    }


                    if (l2.head == null)
                    {
                        ptr.next = l1.head;
                        break;
                    }

                    if (l1.head.val < l2.head.val)
                    {
                        ptr.next = l1.head;
                        l1.head = l1.head.next;
                    }
                    else
                    {
                        ptr.next = l2.head;
                        l2.head = l2.head.next;
                    }

                    ptr = ptr.next;
                }

                lists[index1].head = dummy.next;
            }

            //another approach
            public ListNode Partition(ListNode[] ListNodes, int start, int end)
            {
                if (start > end) return null;
                if (start == end) return ListNodes[start];
                int mid = start + (end - start) / 2;
                ListNode l1 = Partition(ListNodes, start, mid);
                ListNode l2 = Partition(ListNodes, mid + 1, end);
                return Merge(l1, l2);
            }

            public ListNode Merge(ListNode l1, ListNode l2)
            {
                if (l1 == null) return l2;
                if (l2 == null) return l1;
                if (l1.val < l2.val)
                {
                    l1.next = Merge(l1.next, l2);
                    return l1;
                }
                else
                {
                    l2.next = Merge(l1, l2.next);
                    return l2;
                }
            }
            #endregion merge K List

            //using HashSet
            // T: O(n)
            public void DeleteDuplicateFromUnsortedList(ListNode head)
            {
                HashSet<int> set = new HashSet<int>();
                ListNode previous = null;
                while (head != null)
                {
                    if (set.Contains(head.val))
                    {
                        previous.next = head.next;
                    }
                    else
                    {
                        set.Add(head.val);
                        previous = head;
                    }

                    head = head.next;
                }
            }

            //wihtout HashSet
            // T: O(n^2)
            // S: o(1)
            public void DeleteDuplicateUnsortedList(ListNode head)
            {
                ListNode current = head;

                while (current != null)
                {
                    /* Remove all future nodes that have the same value */
                    ListNode runner = current;
                    while (runner.next != null)
                    {
                        if (runner.next.val == current.val)
                        {
                            runner.next = runner.next.next;
                        }
                        else
                        {
                            runner = runner.next;
                        }
                    }
                    current = current.next;
                }
            }

            //T : O(n)
            //S : O(1)
            public ListNode FindNthFromEndIterative(ListNode head, int n)
            {
                if (head == null || head.next == null)
                    return null;

                ListNode p1 = head;
                ListNode p2 = head;

                for (int i = 0; i < n; i++)
                {
                    p1 = p1.next;
                }
                while (p1 != null)
                {
                    p1 = p1.next;

                    p2 = p2.next;
                }

                return p2;
            }

            //T : O(n)
            //S : O(1)
            public int FindNthFromEndRecursive(ListNode head, int n)
            {
                if (head.next == null)
                {
                    return 1;
                }
                int index = FindNthFromEndRecursive(head.next, n) + 1;
                if (index == n)
                {
                    Console.WriteLine(head.val);
                }

                return index;
            }

            //T : O(n)
            //S : O(1)
            public ListNode RemoveNthFromEndIterative(ListNode head, int n)
            {
                if (head == null || head.next == null)
                    return null;

                ListNode p1 = head;
                ListNode p2 = head;

                for (int i = 0; i < n; i++)
                {
                    p1 = p1.next;
                }

                ListNode prev = null;
                while (p1 != null)
                {
                    p1 = p1.next;
                    prev = p2;
                    p2 = p2.next;
                }

                if (prev == null)//THis may happen if linked list size is 2 and n=2
                    head = p2.next;
                else
                    prev.next = p2.next;

                return head;
            }

            //T : O(n)
            //S : O(n)
            public ListNode RemoveNthFromEndRecursive(ListNode head, int n)
            {

                RemoveNthFromEnd(head, n);

                return head;
            }

            private int RemoveNthFromEnd(ListNode p1, int n)
            {
                if (p1 == null)
                    return 0;

                int index = RemoveNthFromEnd(p1.next, n) + 1;
                if (index == n + 1)
                {
                    p1.next = p1.next.next;
                }

                return index;
            }

            int m = 0;
            public ListNode RemoveNthFromEndRec(ListNode head, int n)
            {

                if (head == null)
                {
                    return null;
                }

                var h = RemoveNthFromEndRec(head.next, n);

                m++;
                if (m == n) return h;

                head.next = h;
                return head;
            }

            //T : O(n)
            //if you have access to head node
            public ListNode DeleteMiddleNode(ListNode head)
            {
                if (head == null)
                    return null;

                ListNode slow = head;
                ListNode fast = head;
                ListNode prev = null;

                while (fast != null && fast.next != null)
                {
                    prev = slow;
                    slow = slow.next;
                    fast = fast.next.next;
                }

                //check for linked list with 1 element 
                if (prev != null)
                    prev.next = slow.next;
                else
                    return null;

                return head;
            }

            //T : O(1)
            //if you do have access to head node but to middle node itself
            public void DeleteMiddleNoden(ListNode n)
            {
                if (n == null)
                    return;

                ListNode next = n.next;
                n.val = next.val;
                n.next = next.next;
            }

            public ListNode Partition(ListNode head, int x)
            {
                if (head == null || head.next == null)
                    return head;

                ListNode beforeHead = new ListNode();
                ListNode afterHead = new ListNode();

                ListNode before = beforeHead;
                ListNode after = afterHead;

                while (head != null)
                {

                    if (head.val < x)
                    {
                        before.next = head;
                        before = before.next;
                    }
                    else
                    {
                        after.next = head;
                        after = after.next;
                    }

                    head = head.next;
                }

                after.next = null;
                before.next = afterHead.next;

                return beforeHead.next;

            }
            //2 pointer solution
            //public void partition(ListNode head, int x)
            //{
            //    ListNode start = head;
            //    ListNode tail = head;

            //    while (head != null)
            //    {
            //        ListNode next = head.next;
            //        if (head.val < x)
            //        {
            //            /* Insert node at head. */
            //            head.next = start;
            //            start = head;
            //        }
            //        else
            //        {
            //            /* Insert node at tail. */
            //            tail.next = head;
            //            tail = head;
            //        }

            //        head = next;
            //    }

            //    tail.next = null;
            //}

            public bool IsPalindrome(ListNode head)
            {
                if (head == null || head.next == null)
                    return true;


                ListNode slow = head;
                ListNode fast = head;
                Stack<int> stack = new Stack<int>();

                while (fast != null && fast.next != null)
                {
                    stack.Push(slow.val);
                    slow = slow.next;
                    fast = fast.next.next;
                }

                //for odd lenth Linked List (do not need to check middle element)
                if (fast != null)
                    slow = slow.next;

                while (slow != null)
                {
                    int n = stack.Pop();
                    if (slow.val != n)
                        return false;

                    slow = slow.next;
                }

                return true;
            }

            public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
            {
                if (headA == null || headB == null)
                    return null;

                int sizeA, sizeB;
                ListNode tailA = GetTailNodeSize(headA, out sizeA);
                ListNode tailB = GetTailNodeSize(headB, out sizeB);

                if (tailA.val != tailB.val)
                    return null;

                //Find Shorter and Longer List

                ListNode shorter = sizeA < sizeB ? headA : headB;
                ListNode longer = sizeA < sizeB ? headB : headA;

                //so advance pointer of longer liked list by kth Node (diff between size)

                int size = Math.Abs(sizeA - sizeB);

                while (size != 0)
                {
                    longer = longer.next;
                    size--;
                }

                while (shorter != longer)
                {
                    shorter = shorter.next;
                    longer = longer.next;
                }

                return longer; //return either
            }

            public ListNode GetIntersectionNodeHashSet(ListNode headA, ListNode headB)
            {
                if (headA == null || headB == null)
                    return null;

                HashSet<ListNode> nodes = new HashSet<ListNode>();
                ListNode pointerA = headA;

                while (pointerA != null)
                {
                    nodes.Add(pointerA);
                    pointerA = pointerA.next;
                }

                ListNode pointerB = headB;
                while (pointerB != null)
                {
                    if (nodes.Contains(pointerB))
                    {
                        return pointerB;
                    }
                    pointerB = pointerB.next;
                }

                return null;
            }

            //Using fast and slow pointer to find loop cycle start node
            public ListNode FindBeginning(ListNode head)
            {
                ListNode slow = head;
                ListNode fast = head;

                /* Find meeting point. This will be LOOP_SIZE - k steps into the linked list. */
                while (fast != null && fast.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                    if (slow == fast)
                    {//Collision
                        break;
                    }
                }

                /* Error check - no meeting point, and therefore no loop*/
                if (fast == null || fast.next == null)
                {
                    return null;
                }

                /* Move slow to Head. Keep fast at Meeting Point. Each are k steps from the
                * Loop Start. If they move at the same pace, they must meet at Loop Start. */
                slow = head;
                while (slow != fast)
                {
                    slow = slow.next;
                    fast = fast.next;
                }

                /* Both now point to the start of the loop. */
                return fast;
            }

            public ListNode GetTailNodeSize(ListNode head, out int size)
            {

                ListNode tail = head;
                size = 0;

                while (tail.next != null)
                {
                    tail = tail.next;
                    size++;
                }

                return tail;
            }

            public int NumComponents(ListNode head, int[] G)
            {
                int[] s = { 1, 2, 3, 4 };

                int[] arr = new int[] { 1, 2, 3, 4 };
                Queue<int> myStack = new Queue<int>(arr);


                var set = new HashSet<int>(G);
                var connected = false;
                var count = 0;
                while (head != null)
                {
                    if (set.Contains(head.val))
                    {
                        if (!connected)
                        {
                            connected = true;
                            count++;
                        }
                    }
                    else
                    {
                        connected = false;
                    }
                    head = head.next;
                }

                return count;
            }
        }
        #endregion Single Linked List Implementation

        #region Doubly Linked List Implementation
        internal class DLL
        {
            DllNode head = null;
            //int length = 0;

            public void AddDataHead(int x)
            {
                DllNode TreeNode = new DllNode(x);
                TreeNode.next = head;

                if (head != null)
                    head.prev = TreeNode;

                head = TreeNode;
            }

            public void AddDataToLast(int x)
            {
                DllNode current = head;
                DllNode previous = null;

                while (current != null)
                {
                    previous = current;
                    current = current.next;
                }

                if (previous == null)
                    head = new DllNode(x);
                else
                {
                    var newTreeNode = new DllNode(x);
                    previous.next = newTreeNode;
                    newTreeNode.prev = previous;
                }
            }

            public void AddAtIndex(int index, int v)
            {
                if (index < 0)
                    return;

                if (index == 0)
                    AddDataHead(v);
                else
                {
                    var leaderTreeNode = GetLeaderTreeNode(index);
                    DllNode n = new DllNode(v);
                    var lnext = leaderTreeNode.next;
                    n.next = lnext;
                    leaderTreeNode.next = n;
                    n.prev = leaderTreeNode;
                    lnext.prev = n;
                }
            }

            public void DeleteAtIndex(int index)
            {
                if (index < 0)
                {
                    return;
                }

                if (index == 0)
                {
                    head = head.next;
                    return;
                }

                var leaderTreeNode = GetLeaderTreeNode(index);
                var deleteTreeNode = leaderTreeNode.next;
                var delTreeNodeNext = deleteTreeNode?.next;
                leaderTreeNode.next = delTreeNodeNext;
                if (delTreeNodeNext != null)
                    delTreeNodeNext.prev = leaderTreeNode;
            }

            public void GetValueAtIndex(int index)
            {
                if (index < 0)
                {
                    return;
                }

                if (index == 0)
                {
                    Console.Write(head.val);
                    return;
                }

                var leaderTreeNode = GetLeaderTreeNode(index);
                Console.Write((leaderTreeNode != null && leaderTreeNode.next != null) ? leaderTreeNode.next.val : -1);
            }

            public DllNode GetLeaderTreeNode(int index)
            {
                var current = head;
                DllNode leaderTreeNode = null;

                var counter = 0;

                while (current != null && counter < index)
                {
                    leaderTreeNode = current;
                    current = current.next;
                    counter++;
                }

                return leaderTreeNode;
            }

            public void PrintAllTreeNodes()
            {
                //Traverse from head 
                Console.Write("Head ->");
                DllNode curr = head;
                while (curr != null)
                {
                    Console.Write(curr.val);
                    curr = curr.next;
                    Console.Write("->");
                    Console.Write("<-");
                }

                Console.Write(" null");
            }

            public void Reverse()
            {
                DllNode current = head;
                DllNode previous = null;


                while (current != null)
                {
                    DllNode temp = current.next;
                    current.next = previous;
                    if (previous != null)
                        previous.prev = current;

                    previous = current;
                    current = temp;
                }

                head.next = null;
                head.prev = null;
                head = previous;
            }
        }
        #endregion Double Linked List Implementation       

        #region Binary Search Tree

        public void Insert(TreeNode root, int i)
        {
            TreeNode newTreeNode = new TreeNode();
            newTreeNode.val = i;
            if (root == null)
                root = newTreeNode;
            else
            {
                TreeNode current = root;
                TreeNode parent;
                while (true)
                {
                    parent = current;
                    if (i < current.val)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newTreeNode;
                            break;
                        }
                        else
                        {
                            current = current.right;
                            if (current == null)
                            {
                                parent.right = newTreeNode;
                                break;
                            }
                        }
                    }
                }
            }
        }

        TreeNode insertRec(TreeNode root, int key)
        {

            /* If the tree is empty or you reached end of left or right node
               return a new TreeNode */
            if (root == null)
            {
                root = new TreeNode(key);
                return root;
            }

            /* Otherwise, recur down the tree */
            if (key < root.val)
                root.left = insertRec(root.left, key);
            else if (key > root.val)
                root.right = insertRec(root.right, key);

            /* return the (unchanged) TreeNode pointer */
            return root;
        }

        public TreeNode searchrec(TreeNode root, int key)
        {
            // Base Cases: root is null
            // or key is present at root
            if (root == null || root.val == key)
                return root;

            // Key is greater than root's key
            if (root.val < key)
                return searchrec(root.right, key);

            // Key is smaller than root's key
            return searchrec(root.left, key);
        }

        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
                return root;

            TreeNode currentNode = root;
            TreeNode parentNode = null;
            while (currentNode != null)
            {
                parentNode = currentNode;
                if (key < currentNode.val)
                {   
                    currentNode = currentNode.left;
                }
                else if (key > currentNode.val)
                {   
                    currentNode = currentNode.right;
                }
                else if (key == currentNode.val)
                    break;
            }

            return DeleteNodeFromTree(root, parentNode, currentNode);
        }

        public TreeNode DeleteNodeFromTree(TreeNode root, TreeNode parentNode, TreeNode deleteNode)
        {
            while (deleteNode != null)
            {

                //OPTION 1:  NO RIGHT CHILD
                if (deleteNode.right == null)
                {
                    if (parentNode == null)
                    {
                        root = deleteNode.left;
                    }
                    else
                    {
                        if (deleteNode.val < parentNode.val)
                        {
                            parentNode.left = deleteNode.left;
                        }
                        else if (deleteNode.val > parentNode.val)
                        {
                            parentNode.right = deleteNode.left;
                        }
                    }
                }
                else if (deleteNode.right.left == null)
                {  //Option 2: Right child which doesnt have a left child
                    deleteNode.right.left = deleteNode.left;
                    if (parentNode == null)
                    {
                        root = deleteNode.right;
                    }
                    else
                    {
                        if (deleteNode.val < parentNode.val)
                        {
                            parentNode.left = deleteNode.right;
                        }
                        else if (deleteNode.val > parentNode.val)
                        {
                            parentNode.right = deleteNode.right;
                        }
                    }
                }
                else
                {   //Option 3: Right child that has a left child
                    //find the Right child's left most child
                    var leftmost = deleteNode.right.left;
                    var leftmostParent = deleteNode.right;
                    while (leftmost.left != null)
                    {
                        leftmostParent = leftmost;
                        leftmost = leftmost.left;
                    }

                    //Parent's left subtree is now leftmost's right subtree
                    leftmostParent.left = leftmost.right;
                    leftmost.left = deleteNode.left;
                    leftmost.right = deleteNode.right;

                    if (parentNode == null)
                    {
                        root = leftmost;
                    }
                    else
                    {
                        if (deleteNode.val < parentNode.val)
                        {
                            parentNode.left = leftmost;
                        }
                        else if (deleteNode.val > parentNode.val)
                        {
                            parentNode.right = leftmost;
                        }
                    }
                }
                return root;
            }

            return root;
        }

        //node doesn't have left or right - return null
        //node only has left subtree- return the left subtree
        //node only has right subtree- return the right subtree
        //node has both left and right - find the minimum value in the right subtree, 
        //set that value to the currently found node, then recursively delete the minimum value in the right subtree
        public TreeNode deleteNoderec(TreeNode root, int key)
        {
            if (root == null)
            {
                return null;
            }
            if (key < root.val)
            {
                root.left = deleteNoderec(root.left, key);
            }
            else if (key > root.val)
            {
                root.right = deleteNoderec(root.right, key);
            }
            else
            {
                if (root.left == null)
                {
                    return root.right;
                }
                else if (root.right == null)
                {
                    return root.left;
                }

                TreeNode minNode = findMin(root.right);
                root.val = minNode.val;
                root.right = deleteNoderec(root.right, root.val);
            }
            return root;
        }

        private TreeNode findMin(TreeNode node)
        {
            while (node.left != null)
            {
                node = node.left;
            }
            return node;
        }

        //Recursive Sorted Array to BST
        public static TreeNode sortedArrayToBSTRecursion(int[] num, int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            var mid = (left + right) / 2;

            var newRoot = new TreeNode(num[mid])
            {
                left = sortedArrayToBSTRecursion(num, left, mid - 1),
                right = sortedArrayToBSTRecursion(num, mid + 1, right)
            };

            return newRoot;
        }

        //Iterative SortedArray to BST
        public static TreeNode SortedArrayToBST(int[] nums)
        {

            int len = nums.Length;
            if (len == 0) { return null; }

            // 0 as a placeholder
            TreeNode head = new TreeNode(0);

            Stack<TreeNode> nodeStack = new Stack<TreeNode>();
            nodeStack.Push(head);


            Stack<int> leftIndexStack = new Stack<int>();
            leftIndexStack.Push(0);


            Stack<int> rightIndexStack = new Stack<int>();
            rightIndexStack.Push(len);

            while (nodeStack.Any())
            {
                TreeNode currNode = nodeStack.Pop();
                int left = leftIndexStack.Pop();
                int right = rightIndexStack.Pop();
                int mid = left + (right - left) / 2; // avoid overflow
                currNode.val = nums[mid];
                if (left <= mid - 1)
                {
                    currNode.left = new TreeNode(0);
                    nodeStack.Push(currNode.left);
                    leftIndexStack.Push(left);
                    rightIndexStack.Push(mid - 1);
                }
                if (mid + 1 <= right)
                {
                    currNode.right = new TreeNode(0);
                    nodeStack.Push(currNode.right);
                    leftIndexStack.Push(mid + 1);
                    rightIndexStack.Push(right);
                }
            }
            return head;
        }

        #region Recursive Convert BST to Greater Tree

        private int sum = 0;
        public TreeNode ConvertBST(TreeNode root)
        {

            if (root != null)
            {
                ConvertBST(root.right);
                sum += root.val;
                root.val = sum;
                ConvertBST(root.left);
            }

            return root;

        }

        #endregion

        #region Iterative Convert BST to Greater Tree
        public TreeNode convertBST(TreeNode root)
        {
            int sum = 0;
            TreeNode node = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();

            while (stack.Any() || node != null)
            {
                /* push all nodes up to (and including) this subtree's maximum on
                 * the stack. */
                while (node != null)
                {
                    stack.Push(node);
                    node = node.right;
                }

                node = stack.Pop();
                sum += node.val;
                node.val = sum;

                /* all nodes with values between the current and its parent lie in
                 * the left subtree. */
                node = node.left;
            }

            return root;
        }
        #endregion

        #endregion Binary Search Tree

        #region Binary Tree

        //T :O(N)
        // S: O(H) where H is height of the Tree
        public static bool IsBalanced(TreeNode root)
        {
            return dfs(root) != -1;
        }

        private static int dfs(TreeNode root)
        {
            if (root == null) return 0;//base case

            int left = dfs(root.left);
            if (left == -1)
                return -1;

            int right = dfs(root.right);
            if (right == -1)
                return -1;

            if (Math.Abs(left - right) > 1)
                return -1;

            return Math.Max(left, right) + 1;
         }

        public static bool IsValidBST(TreeNode root)
        {

            if (root == null)
                return true;

            return IsValidBST(root, null, null);
        }

        //recursive
        //T : O(n)
        // S : O(log n)
        public static bool IsValidBST(TreeNode node, int? min = null, int? max = null)
        {
            if (node == null)
                return true;
                        

            if ((min != null && node.val <= min) || (max != null && node.val >= max))
                return false;

            return IsValidBST(node.left, min, node.val) && IsValidBST(node.right, node.val, max);
        }

        //iterative
        int index = 0;
        void copyBST(TreeNode root, List<int> array)
        {
            if (root == null) return;
            copyBST(root.left, array);
            array[index] = root.val;
            index++;
            copyBST(root.right, array);
        }

        bool checkBST(TreeNode root)
        {
            List<int> array = new List<int>();
            copyBST(root, array);
            for (int i = 1; i < array.Count; i++)
            {
                if (array[i] <= array[i - 1]) return false;
            }
            return true;
        }

        public static int MaxDepth(TreeNode root)
        {
            
            int depthleft = 1;
            int depthright = 1;

            if (root == null)
                return 0;

            if (root.left == null && root.right == null)
                return 1;


            depthleft += MaxDepth(root.left);
            depthright += MaxDepth(root.right);

            return depthleft > depthright ? depthleft : depthright;
        }

        public int InOrderSuccessorBST(TreeNode root, TreeNode p)
        {
            if (root == null || p == null)
                return -1;

            //case 1 : if the node has right subtree then find the least value in right subtree
            //least value will be leftmost leaf node
            if (p.right != null)
            {
                TreeNode temp = p.right;
                while (temp.left != null)
                {
                    temp = temp.left;
                }

                return temp.val;
            }
            else
            {
                int v = 0;
                //Case 2 : if the node does not have right subtree
                //Search p from root and node from where we take last left is the answer
                TreeNode s = root;
                while (s.val != p.val)
                {
                    if (p.val < s.val)
                    {
                        v = s.val;
                        s = s.left;
                    }
                    else
                    {
                        s = s.right;
                    }
                }
                return v;
            }
        }

        //for binary search tree : https://www.youtube.com/watch?v=kulWKd3BUcI&ab_channel=KevinNaughtonJr.
        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;


            if (root.val == p.val || root.val == q.val)
                return root;

            TreeNode l = LowestCommonAncestor(root.left, p, q);
            TreeNode r = LowestCommonAncestor(root.right, p, q);

            if (l != null && r != null)
                return root;
            else if (l != null)
            {
                return l;
            }
            else
            {
                return r;
            }
        }

        public bool IsSubtree(TreeNode s, TreeNode t)
        {

            if (s == null && t == null)
                return true;

            Stack<TreeNode> queue = new Stack<TreeNode>();
            queue.Push(s);

            while (queue.Count > 0)
            {
                var node = queue.Pop();

                if (node.val == t.val)
                {
                    if (IsSameTree(node, t))
                        return true;
                }

                if (node.left != null)
                    queue.Push(node.left);

                if (node.right != null)
                    queue.Push(node.right);
            }

            return false;
        }

        private bool IsSameTree(TreeNode s, TreeNode t)
        {
            if (s == null && t == null)
                return true;

            if (s == null && t != null)
                return false;

            if (s != null && t == null)
                return false;

            if (s.val != t.val)
                return false;

            return IsSameTree(s.left, t.left) && IsSameTree(s.right, t.right);
        }

        //path sum from root to leaf
        // path II -> https://www.youtube.com/watch?v=3B5gnrwRmOA
        // path III ???
        public bool HasPathSum(TreeNode root, int targetSum)
        {

            if (root == null)
            {
                return false;
            }
            else if (root.left == null && root.right == null && root.val - targetSum == 0)
            {
                return true;
            }
            else
            {
                return HasPathSum(root.left, targetSum - root.val) || HasPathSum(root.right, targetSum - root.val);
            }

        }

        #endregion Binary Tree

        #region Traversals

        #region Recursive InOrder BST Traversal
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> inOrder = new List<int>();
            traverseInOrder(root, inOrder);
            return inOrder;
        }

        private static void traverseInOrder(TreeNode root, List<int> inOrder)
        {
            if (root != null)
            {

                if (root.left != null)
                {
                    traverseInOrder(root.left, inOrder);
                }

                inOrder.Add(root.val);

                if (root.right != null)
                {
                    traverseInOrder(root.right, inOrder);
                }
            }

        }
        #endregion Recursive InOrder BST Traversal

        //https://github.com/Algorithms-Made-Easy/Tree/blob/master/Iterative-Inorder_Preorder_PostOrder_Traversal
        #region Iterative InOrder BST Traversal
        public static List<int> inorderTraversal(TreeNode root)
        {
            List<int> res = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode curr = root;
            int maxnode = int.MaxValue;
            while (curr != null || stack.Any())
            {
                while (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }
                curr = stack.Pop();
                res.Add(curr.val);
                if (curr.val < maxnode)
                {

                }
                maxnode = curr.val;
                curr = curr.right;
            }
            return res;
        }
        #endregion Iterative InOrder BST Traversal

        //post order ITerative
        private static List<int> postorderTraversal(TreeNode root)
        {
            var result = new List<int>();

            if (root == null) return result;           


            var stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Any())
            {
                var cur = stack.Pop();
                result.Add(cur.val);

                if (cur.left != null)
                {
                    stack.Push(cur.left);
                }

                if (cur.right != null)
                {
                    stack.Push(cur.right);
                }
            }

            result.Reverse();

            return result;
        }

        //instead of adding to list just display the nodes
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null)
                return new List<IList<int>>();

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            IList<int> node;
            IList<IList<int>> result = new List<IList<int>>();

            while (queue.Any())
            {
                int levelNodes = queue.Count;
                node = new List<int>();

                while (levelNodes > 0)
                {
                    var n = queue.Dequeue();
                    node.Add(n.val);
                    if (n.left != null) queue.Enqueue(n.left);
                    if (n.right != null) queue.Enqueue(n.right);
                    levelNodes--;
                }

                result.Add(node);
            }

            return result;
        }

        #endregion Traversals

        #region Graph

        // A utility function to add an edge in an
        // undirected graph
        static void addEdge(LinkedList<int>[] adj,
                            int u, int v)
        {
            adj[u].AddLast(v);
            adj[v].AddLast(u);
        }
        static void addEdgedirected(LinkedList<int>[] adj, int v, int u)
        {
            adj[v].AddLast(u);
        }

        public static void BFS(LinkedList<int>[] adj, int s)
        {

            // Mark all the vertices as not
            // visited(By default set as false)
            bool[] visited = new bool[4];


            // Create a queue for BFS
            Queue<int> queue = new Queue<int>();

            // Mark the current node as
            // visited and enqueue it
            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count > 0)
            {
                // Dequeue a vertex from queue
                // and print it
                s = queue.Dequeue();
                Console.Write(s + " ");

                // Get all adjacent vertices of the
                // dequeued vertex s. If a adjacent
                // has not been visited, then mark it
                // visited and enqueue it
                LinkedList<int> list = adj[s];

                foreach (var val in list)
                {
                    if (!visited[val])
                    {
                        visited[val] = true;
                        queue.Enqueue(val);
                    }
                }
            }
        }

        static void DFSUtil(LinkedList<int>[] adj, int v, bool[] visited)
        {
            // Mark the current node as visited
            // and print it
            visited[v] = true;
            Console.Write(v + " ");

            // Recur for all the vertices
            // adjacent to this vertex
            LinkedList<int> vList = adj[v];
            foreach (var n in vList)
            {
                if (!visited[n])
                    DFSUtil(adj, n, visited);
            }

        }

        // The function to do DFS traversal.
        // It uses recursive DFSUtil()
        static void DFS(LinkedList<int>[] adj, int v)
        {
            // Mark all the vertices as not visited
            // (set as false by default in c#)
            bool[] visited = new bool[4];

            // Call the recursive helper function
            // to print DFS traversal
            DFSUtil(adj, v, visited);
        }

        //detect cycle in undirected graph : https://www.geeksforgeeks.org/detect-cycle-undirected-graph/
        //detect cycle in directed graph : https://www.geeksforgeeks.org/detect-cycle-in-a-graph/
        //toplogical sort : https://www.geeksforgeeks.org/topological-sorting/
        public static List<int> BuildOrder(int[][] processes)
        {
            if (processes == null || processes.Length == 0)
                return null;

            HashSet<int> tempMarks = new HashSet<int>();
            HashSet<int> permMarks = new HashSet<int>();
            List<int> results = new List<int>();

            for (int i = 0; i < processes.Length; i++)
            {
                if (!permMarks.Contains(i))
                {
                    Visit(i, processes, tempMarks, permMarks, results);
                }
            }

            return results;
        }

        private static void Visit(int i, int[][] processes, HashSet<int> tempMarks,
                                   HashSet<int> permMarks, List<int> results)
        {
            if (tempMarks.Contains(i)) throw new Exception();
            if (!permMarks.Contains(i))
            {
                tempMarks.Add(i);
                var n = processes[i];

                for (int j = 0; j < n.Length; j++)
                {
                    Visit(j, processes, tempMarks, permMarks, results);
                }

                permMarks.Add(i);
                tempMarks.Remove(i);
                results.Add(i);
            }

        }

        public static bool isCyclicUtil(int i, bool[] visited,
                                   bool[] recStack, LinkedList<int>[] adj)
        {

            // Mark the current node as visited and
            // part of recursion stack
            if (recStack[i])
                return true;

            if (visited[i])
                return false;

            visited[i] = true;
            recStack[i] = true;

            LinkedList<int> children = adj[i];

            foreach (int c in children)
            {
                if (isCyclicUtil(c, visited, recStack, adj))
                    return true;
            }


            recStack[i] = false;
            return false;
        }

        public static bool isCyclic(int V, LinkedList<int>[] adj)
        {

            // Mark all the vertices as not visited and
            // not part of recursion stack
            bool[] visited = new bool[V];
            bool[] recStack = new bool[V]; // we need second stack here as only visited array is not sufficient 
                                           // to determine if there is cycle in graph or not


            // Call the recursive helper function to
            // detect cycle in different DFS trees
            for (int i = 0; i < V; i++)
                if (isCyclicUtil(i, visited, recStack, adj))
                    return true;

            return false;
        }

        // A utility function to print the adjacency list
        // representation of graph
        static void printGraph(LinkedList<int>[] adj)
        {
            for (int i = 0; i < adj.Length; i++)
            {
                Console.WriteLine("\nAdjacency list of vertex " + i);
                Console.Write("head");

                foreach (var item in adj[i])
                {
                    Console.Write(" -> " + item);
                }
                Console.WriteLine();
            }
        }

        #endregion

        #region MergeSort
        public static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }
        #endregion MergeSort       
    }
}