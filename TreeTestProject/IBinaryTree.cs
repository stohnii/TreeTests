using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Interface
{
    /// <summary>
    /// Defines the standards for a binary tree. Makes no assumptions as to what kind of
    /// binary tree implements this
    /// </summary>
    /// <typeparam name="T">Any object</typeparam>
    public interface IBinaryTree<T>
    {
        /// <summary>
        /// Adds a new element to the tree if it is not already present. Equality checks
        /// should be done using the T type's .Equals()
        /// </summary>
        /// <param name="addition">The element to add to the tree</param>
        /// <returns>Whether or not the element was actually added to the tree</returns>
        bool Add(T addition);

        /// <summary>
        /// Deletes the item out of the tree if it is present. Equality checks
        /// should be done using the T type's .Equals()
        /// </summary>
        /// <param name="target"></param>
        /// <returns>Whether or not the element was actually deleted from the tree</returns>
        bool Delete(T target);

        /// <summary>
        /// Traverses the binary tree using the In Order algorithm
        /// and generates a comma delimited list. Representing the
        /// elements as strings should be done using the T type's .ToString()
        /// A null (empty) tree should still return "[]"
        /// </summary>
        /// <returns>A comma delimited list as a string of the values, e.g. [e1, e2]</returns>
        string InOrderTraversal();
    }
}
