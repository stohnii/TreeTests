using Practice.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeTestProject
{
    public class BinaryTree<T> : IBinaryTree<T>
    {
        public Node<T> Root { get; set; }

        public BinaryTree()
        {
            Root = null;
        }

        #region IBinaryTree methods

        public bool Add(T addition)
        {
            var result = false;

            Node<T> newValue = new Node<T>(addition);
            if (Root == null)
            {
                Root = new Node<T>(addition);
                result = true;
            }

            Node<T> current = Root;
            while (!result)
            {
                if (current.Equals(newValue))
                {
                    result = false;
                    break;
                }
                else if (newValue > current)
                {
                    if (current.Right == null)
                    {
                        current.Right = newValue;
                        newValue.Root = current;
                        result = true;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
                else
                {
                    if (current.Left == null)
                    {
                        current.Left = newValue;
                        newValue.Root = current;
                        result = true;
                    }
                    else
                    {
                        current = current.Left;
                    }
                }
            }

            return result;
        }

        public bool Delete(T target)
        {
            if (Root == null)
                return false;

            Node<T> current = Root;
            Node<T> parent = null;
            Node<T> nodeToDelete = new Node<T>(target);

            GetNodeToDelete(ref current, ref parent, nodeToDelete);

            if (current == null)
                return false;

            if (current.Right == null)
            {
                if (current == Root)
                    Root = current.Left;
                else
                {
                    if (nodeToDelete < current)
                        parent.Left = current.Left;
                    else
                        current.Root = parent;
                        parent.Left = current.Left;
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (current == Root)
                    Root = current.Right;
                else
                {
                    if (nodeToDelete < current)
                        parent.Left = current.Right;
                    else
                    {
                        current.Root = parent;
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                Node<T> min = current.Right.Left, prev = current.Right;
                while (min.Left != null)
                {
                    prev = min;
                    min = min.Left;
                }
                prev.Left = min.Right;
                min.Left = current.Left;
                min.Right = current.Right;

                if (current == Root)
                {
                    min.Root = Root.Root;
                    Root = min;
                }
                else
                {
                    min.Root = parent;

                    if (nodeToDelete < current)
                    {
                        parent.Left.Left.Root = min;
                        parent.Left.Right.Root = min;
                        parent.Left = min;
                    }
                    else
                    {
                        parent.Right.Left.Root = min;
                        parent.Right.Right.Root = min;
                        parent.Right = min;
                    }
                }
            }

            return true;
        }

        public string InOrderTraversal()
        {
            IEnumerable<Node<T>> orderedTree = GetOrderedTree();
            var sb = new StringBuilder();
            sb.Append('[');
            foreach (var node in orderedTree)
            {
                sb.Append(node + ", ");
            }
            return sb.ToString().Trim().Trim(',') + "]";
        }        

        #endregion

        #region Private methods

        private IEnumerable<Node<T>> GetOrderedTree()
        {
            if (Root == null)
                yield break;

            var stack = new List<Node<T>>();
            var node = Root;

            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Last();
                    stack.RemoveAt(stack.Count - 1);
                    yield return node;
                    node = node.Right;
                }
                else
                {
                    stack.Add(node);
                    node = node.Left;
                }
            }
        }

        private static void GetNodeToDelete(ref Node<T> current, ref Node<T> parent, Node<T> nodeToDelete)
        {
            while (current != null)
            {
                if (nodeToDelete.Equals(current))
                {
                    break;
                }

                if (nodeToDelete < current)
                {
                    parent = current;
                    current = current.Left;
                }
                else
                {
                    parent = current;
                    current = current.Right;
                }
            }
        }

        #endregion
    }

    #region Node class

    public class Node<S>
    {
        public S Value { get; set; }

        public Node<S> Root { get; set; }
        public Node<S> Left { get; set; }
        public Node<S> Right { get; set; }

        public Node(S value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            return Value.Equals(((Node<S>)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator <(Node<S> left, Node<S> right)
        {
            return left.Value.GetHashCode() < right.Value.GetHashCode();
        }

        public static bool operator >(Node<S> left, Node<S> right)
        {
            return left.Value.GetHashCode() > right.Value.GetHashCode();
        }
    }

    #endregion
}
