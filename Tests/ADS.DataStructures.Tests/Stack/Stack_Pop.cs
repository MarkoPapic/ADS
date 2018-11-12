using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ADS.DataStructures.Tests.Stack
{
    public class Stack_Pop
    {
        [Fact]
        public void EmptyStack_ExceptionThrown()
        {
            //Arrange
            Stack<int> stack = new Stack<int>();

            //Act
            Action act = () => stack.Pop();

            //Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void HappyPath_LastReturned()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            Stack<int> stack = new Stack<int>();

            foreach (int el in elements)
                stack.Push(el);

            //Act && assert
            for (int i = elements.Length - 1; i >= 0; i--)
            {
                int actualLastEl = elements[i];
                int lastEl = stack.Pop();
                Assert.Equal(actualLastEl, lastEl);
            }
        }

        [Fact]
        public void HappyPath_CountUpdated()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            Stack<int> stack = new Stack<int>();

            foreach (int el in elements)
                stack.Push(el);

            //Act
            int lastEl = stack.Pop();

            //Assert
            Assert.Equal(9, stack.Count);
        }
    }
}
