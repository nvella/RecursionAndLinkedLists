namespace Exercises
{
    public class ListNode
    {
        public string Data;
        public ListNode Next;

        public ListNode(string data, ListNode next = null) {
            this.Data = data;
            this.Next = null;
        }
    }

    public class LinkedList {
        public ListNode Head;

        public LinkedList() {
            Head = null;
        }

        public void AddToEnd(string newData) {
            ListNode newNode = new ListNode(newData, null);
            
            if (Head == null) {
                Head = newNode;
                return;
            } 
            
            ListNode current = Head;

            while (current.Next != null) {
                current = current.Next;
            }

                current.Next = newNode;
        }
        
        public ListNode GetNodeAt(int index, ListNode currentNode = null) {
            if (index < 0) return null;
            if (currentNode == null) currentNode = Head;
            if (index == 0) return currentNode;
            if (currentNode.Next == null) return null;
            return GetNodeAt(index - 1, currentNode.Next);
        }

        public bool Find(string searchTerm) {
            ListNode current = Head;

            while (current != null) {
                if (current.Data == searchTerm) {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Returns the number of nodes in the Linked List
        /// </summary>
        /// <returns>int: count</returns>
        public int Count(ListNode node = null, int count = 0) {
            if (node == null) node = Head;
            if (node.Next == null) return count + 1;
            return Count(node.Next, count + 1);
        }

        /// <summary>
        /// Adds a node to the start of the list.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>success: true</returns>
        public bool AddToStart(string data) {
            var node = new ListNode(data);
            node.Next = Head;
            Head = node;
            return true;
        }

        /// <summary>
        /// Add new node at index.  If index specified is greater than the size of the current list,
        /// adds nodes with null data in between.  Negative index will return false.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool AddNodeAt(string data, int index, int count = 0, ListNode node = null, ListNode previous = null) {
            if (index < 0) return false;
            if (node == null) node = Head;

            if (index == count || index == 0)
            {
                var newNode = new ListNode(data);
                newNode.Next = node;
                if (previous != null) previous.Next = newNode;
                return true;
            } else
            {
                if(node.Next == null) node.Next = new ListNode(null);
                return AddNodeAt(data, index, count + 1, node.Next, node);
            }
        }

        /// <summary>
        /// Delete node at index.  return false if node does not exist
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool DeleteNodeAt(int index) {
            int count = 0;

            if (index < 0) return false;
            if (Count() < 1) return false;
            if (index == 0)
            {
                Head = Head.Next;
                return true;
            }

            ListNode current = Head;
            while (count < index - 1)
            {
                if (current.Next != null)
                {
                    current = current.Next;
                }
                else
                {
                    return false;
                }
                count++;
            }

            if (current.Next == null) return false;
            current.Next = current.Next.Next;
            return true;
        }
    }
}