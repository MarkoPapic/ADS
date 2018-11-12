using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ADS.DataStructures.Tests.Stack
{
    public class Stack_Push
    {
        [Fact]
        public void HappyPath_ElementAdded()
        {
            //Arrange
            int[] elements = new int[] { 1, 50, -342, 1000, -5, 2, 40 };
            Stack<int> stack = new Stack<int>();

            //Act & assert
            for (int i = 0; i < elements.Length; i++)
            {
                int elToInsert = elements[i];
                stack.Push(elToInsert);
                int lastEl = stack.Peek();
                Assert.Equal(elToInsert, lastEl);
            }
        }

        [Fact]
        public void HappyPath_LengthUpdated()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            Stack<int> stack = new Stack<int>();

            //Act && assert
            for (int i = 0; i < elements.Length; i++)
            {
                stack.Push(elements[i]);
                Assert.Equal(i + 1, stack.Count);
            }
        }
    }
}
