using System;
using System.Collections.Generic;
using AspNetCoreCodingExamples.Domain.DataStructures.Interfaces;

namespace AspNetCoreCodingExamples.Domain.DataStructures.Services
{
    public class StackQueueExamples : IStackQueueExamples
    {
        public bool AreBracketsBalanced(string testStr)
        {
            /*
                 Open brackets must be closed in the correct order.

                 Every close bracket has a corresponding open bracket of the same type.
                 Brackets that are checked are: (, [, { 

                 Example 1:
                 Input: s = "()"
                 Output: true

                 Example 2:
                 Input: s = "()[({})]{}"
                 Output: true

                 Example 3:
                 Input: s = "([)]"
                 Output: false
            */

            if (string.IsNullOrWhiteSpace(testStr))
            {
                return false;
            }

            Stack<char> openBrackets = new Stack<char>();
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>()
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            foreach (var chr in testStr)
            {
                if (chr == '(' || chr == '[' || chr == '{')
                {
                    openBrackets.Push(chr);
                }
                else if (chr == ')' || chr == ']' || chr == '}')
                {
                    if (openBrackets.Count <= 0)
                    {
                        return false;
                    }
                    else 
                    {
                        if (openBrackets.Peek() != bracketPairs[chr])
                        {
                            return false;
                        }
                    }
                    openBrackets.Pop();
                }
            }

            return (openBrackets.Count == 0);
        }

        public Queue<T> ReverseQueue<T>(Queue<T> queue)
        {
            if (queue == null) throw new ArgumentNullException(nameof(queue));

            Stack<T> stack = new Stack<T>();

            while (queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }

            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }

            return queue;
        }


    }
}
