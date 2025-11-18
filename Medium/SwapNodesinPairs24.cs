using System;
using System.Collections.Generic;
using System.Data;
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
            ListNode fourth = new ListNode(4, null);
            ListNode third = new ListNode(3, fourth);
            ListNode second = new ListNode(2, third);
            ListNode first = new ListNode(1, null);

            Print(SwapPairs(first));
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
            Console.WriteLine("null");
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

        public static ListNode SwapPairs(ListNode head)
        {
            if (head == null)
                return null;
            if (head.next == null)
                return head;
            ListNode odd = head;
            ListNode even = head.next;
            ListNode first = even;

            ListNode nextOdd, nextEven;
            while (true)
            {
                if (even.next == null)
                {
                    even.next = odd;
                    odd.next = null;
                    break;
                }
                if (even.next.next == null)
                {
                    ListNode lastNode = even.next;
                    even.next = odd;
                    odd.next = lastNode;
                    odd.next.next = null;
                    break;
                }
                nextOdd = even.next;
                nextEven = nextOdd.next;

                odd.next = nextOdd.next;
                even.next = odd;

                odd = nextOdd;
                even = nextEven;
            }

            return first;
        }
    }
}
