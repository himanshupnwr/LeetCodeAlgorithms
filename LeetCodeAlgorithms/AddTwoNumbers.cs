namespace LeetCodeAlgorithms
{
    internal class AddTwoNumbers
    {
        /*static void Main(string[] args)
        {
            ListNode l1 = new ListNode(2);
            l1.next = new ListNode(4, new ListNode(3));

            ListNode l2 = new ListNode(5);
            l2.next = new ListNode(6, new ListNode(4));

            var result = AddTwoNumberss(l1, l2);
        }*/

        //You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order,
        //and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

        //You may assume the two numbers do not contain any leading zero, except the number 0 itself.

        //Input: l1 = [2, 4, 3], l2 = [5, 6, 4]
        //Output: [7, 0, 8]
        //Explanation: 342 + 465 = 807.

        //Example 2:
        //Input: l1 = [0], l2 = [0]
        //Output: [0]

        //Example 3:
        //Input: l1 = [9, 9, 9, 9, 9, 9, 9], l2 = [9, 9, 9, 9]
        //Output: [8, 9, 9, 9, 0, 0, 0, 1]

        //Constraints
        //The number of nodes in each linked list is in the range[1, 100].
        //0 <= Node.val <= 9
        //It is guaranteed that the list represents a number that does not have leading zeros

        //Time complexity:
        //O(n)

        //using recursion
        public static ListNode AddTwoNumbersSimple(ListNode l1, ListNode l2, int carry = 0)
        {
            if (l1 == null && l2 == null && carry == 0) return null;

            int total = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + carry;
            carry = total / 10;
            return new ListNode(total % 10, AddTwoNumbersSimple(l1?.next, l2?.next, carry));
        }

        public static ListNode AddTwoNumberss(ListNode l1, ListNode l2)
        {
            int remainder = 0;

            int first_val = l1.val + l2.val;
            if(first_val > 9)
            {
                first_val = first_val - 10;
                remainder = 1;
            }

            ListNode first = new ListNode(first_val);

            l1 = l1.next;
            l2 = l2.next;

            ListNode prev = first;

            while (l1 != null || l2 != null || remainder > 0)
            {
                int l1_val = l1?.val ?? 0;
                int l2_val = l2?.val ?? 0;
                int sum = l1_val + l2_val + remainder;

                if (sum > 9)
                {
                    remainder = sum / 10;
                    sum = sum % 10;
                }
                else
                {
                    remainder = 0;
                }

                ListNode nxt = new ListNode(sum);
                prev.next = nxt;

                prev = nxt;

                l1 = l1?.next ?? null;
                l2 = l2?.next ?? null;
            }
            return first;
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
}
