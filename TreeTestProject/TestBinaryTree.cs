using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice.Interface;
using System;
using TreeTestProject;

namespace Practice.Test
{
    /// <summary>
    /// Unit tests the various functions of <Concrete Binary Tree type name goes here>
    /// </summary>
    [TestClass]
    public class TestBinaryTree
    {
        private IBinaryTree<Int32> _mock;

        [TestInitialize]
        public void TestInit()
        {
            _mock = new BinaryTree<Int32>(); // TODO set this to an instance of the Concrete type
        }

        [TestMethod]
        public void TestAdd()
        {
            _mock = new BinaryTree<Int32>(); 
            _mock.Add(0);

            bool additionSuccess1 = _mock.Add(0);
            bool additionSuccess2 = _mock.Add(-1);
            bool additionSuccess3 = _mock.Add(1);
            bool additionSuccess4 = _mock.Add(-1);

            Assert.IsFalse(additionSuccess1);
            Assert.IsTrue(additionSuccess2);
            Assert.IsTrue(additionSuccess3);
            Assert.IsFalse(additionSuccess4);
        }

        [TestMethod]
        public void TestDelete()
        {
            _mock = new BinaryTree<Int32>();

            bool deletionSuccess = _mock.Delete(0);
            Assert.IsFalse(deletionSuccess);

            _mock.Add(0);
            deletionSuccess = _mock.Delete(0);
            Assert.IsTrue(deletionSuccess);

            _mock = new BinaryTree<Int32>();
            _mock.Add(0);
            _mock.Add(10);
            _mock.Add(-10);

            deletionSuccess = _mock.Delete(0);
            Assert.IsTrue(deletionSuccess);
            Assert.AreEqual(((BinaryTree<Int32>)_mock).Root, new Node<Int32>(10));

            _mock = new BinaryTree<Int32>();
            _mock.Add(1);
            _mock.Add(2);
            _mock.Add(3);
            _mock.Add(4);

            deletionSuccess = _mock.Delete(2);
            Assert.IsTrue(deletionSuccess);
            Assert.AreEqual(((BinaryTree<Int32>)_mock).Root, new Node<Int32>(1));
            Assert.AreEqual(((BinaryTree<Int32>)_mock).Root.Right, new Node<Int32>(3));
            Assert.AreEqual(((BinaryTree<Int32>)_mock).Root.Right.Right, new Node<Int32>(4));

            _mock = new BinaryTree<Int32>();
            _mock.Add(1);
            _mock.Add(3);
            _mock.Add(2);
            _mock.Add(4);
            _mock.Add(6);

            deletionSuccess = _mock.Delete(3);
            Assert.IsTrue(deletionSuccess);
            Assert.AreEqual(((BinaryTree<Int32>)_mock).Root, new Node<Int32>(1));
            Assert.AreEqual(((BinaryTree<Int32>)_mock).Root.Right, new Node<Int32>(4));
            Assert.AreEqual(((BinaryTree<Int32>)_mock).Root.Right.Right, new Node<Int32>(6));
            Assert.AreEqual(((BinaryTree<Int32>)_mock).Root.Right.Left, new Node<Int32>(2));

            _mock = new BinaryTree<Int32>();
            _mock.Add(1);
            _mock.Add(3);
            _mock.Add(2);
            _mock.Add(4);
            _mock.Add(6);

            deletionSuccess = _mock.Delete(2);
            Assert.IsTrue(deletionSuccess);
            Assert.AreEqual(((BinaryTree<Int32>)_mock).Root, new Node<Int32>(1));
            Assert.AreEqual(((BinaryTree<Int32>)_mock).Root.Right, new Node<Int32>(3));
            Assert.AreEqual(((BinaryTree<Int32>)_mock).Root.Right.Right, new Node<Int32>(4));
            Assert.AreEqual(((BinaryTree<Int32>)_mock).Root.Right.Right.Right, new Node<Int32>(6));
        }

        [TestMethod]
        public void TestInOrderTravesal()
        {
            // Arrange (TODO add a few test integers here)
            _mock = new BinaryTree<Int32>();

            string result = _mock.InOrderTraversal();
            Assert.AreEqual(result, "[]");

            _mock = new BinaryTree<Int32>();
            _mock.Add(0);

            result = _mock.InOrderTraversal();
            Assert.AreEqual(result, "[0]");

            _mock = new BinaryTree<Int32>();
            _mock.Add(0);
            _mock.Add(10);
            _mock.Add(-10);

            result = _mock.InOrderTraversal();
            Assert.AreEqual(result, "[-10, 0, 10]");

            _mock = new BinaryTree<Int32>();
            _mock.Add(1);
            _mock.Add(2);
            _mock.Add(3);

            result = _mock.InOrderTraversal();
            Assert.AreEqual(result, "[1, 2, 3]");

            _mock = new BinaryTree<Int32>();
            _mock.Add(3);
            _mock.Add(2);
            _mock.Add(1);

            result = _mock.InOrderTraversal();
            Assert.AreEqual(result, "[1, 2, 3]");

            result = _mock.InOrderTraversal();
            Assert.AreEqual(result, "[1, 2, 3]");

            _mock = new BinaryTree<Int32>();
            _mock.Add(30);
            _mock.Add(20);
            _mock.Add(40);
            _mock.Add(25);
            _mock.Add(35);

            result = _mock.InOrderTraversal();
            Assert.AreEqual(result, "[20, 25, 30, 35, 40]");
        }
    }
}
