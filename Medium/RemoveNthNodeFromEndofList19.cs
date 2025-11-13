using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main()
        {
            int[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ListNode head = new ListNode(values[0]);
            ListNode current = head;

            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;
            }


            Print(RemoveNthFromEnd1Run(head, 7));
        }

        public static void Print(ListNode head)
        {
            ListNode current = head;

            while(current.next != null)
            {
                Console.WriteLine(current.val);
                current = current.next;
            }
            Console.WriteLine(current.val);
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

        public static ListNode RemoveNthFromEnd2Run(ListNode head, int n)
        {
            ListNode current = head;
            int len = 1;
            for (; current.next != null; len++)
            {
                current = current.next;
            }

            int indToRemove = len - n;

            if (n > len)
                return head;

            if (indToRemove == 0)
                return head.next;

            current = head;
            for (int i = 0; ; i++)
            {
                if (i >= indToRemove - 1)
                {
                    current.next = current.next.next;
                    break;
                }
                current = current.next;
            }

            return head;
        }



        public static ListNode RemoveNthFromEnd1Run(ListNode head, int n)
        {
            ListNode leftNode = head, rightNode = head;
            int skippedRight, skippedLeft;
            bool firstRun = true;

            while (true)
            {
                (rightNode, skippedRight) = SkipNNodes(rightNode, n * 2);

                if (skippedRight == n * 2)
                {
                    int skipLeftGoal = firstRun ? n : n * 2;
                    (leftNode, skippedLeft) = SkipNNodes(leftNode, skipLeftGoal);
                }
                else
                {
                    if (firstRun)
                    {
                        if (leftNode == head && n - skippedRight - 1 == 0)
                            return head.next;

                        (leftNode, skippedLeft) = SkipNNodes(leftNode, skippedRight - n);
                    }
                    else
                        (leftNode, skippedLeft) = SkipNNodes(leftNode, skippedRight);

                    leftNode.next = leftNode.next.next;
                    return head;
                }
                firstRun = false;
            }
        }

        public static (ListNode, int) SkipNNodes(ListNode node, int amountToSkip)
        {
            int i = 0;
            for (; i < amountToSkip && node.next != null; i++)
            {
                node = node.next;
            }

            return (node, i);
        }
    }
}
