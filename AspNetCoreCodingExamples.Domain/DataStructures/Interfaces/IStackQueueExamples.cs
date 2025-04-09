using System.Collections.Generic;

namespace AspNetCoreCodingExamples.Domain.DataStructures.Interfaces
{
    public interface IStackQueueExamples
    {
        /*
        Balanced parentheses checker
        Queue reversal
        Evaluate postfix expression
        */

        bool AreBracketsBalanced(string testStr);
        Queue<T> ReverseQueue<T>(Queue<T> queue);

    }
}
