// Koleksiyonlar

/*
 *Stack -       Stack<>         LIFO
 *Queue -       Queue<>         FIFO
 *Hashtable -   Dictionary<,>
 */

using System.Collections;

Console.WriteLine("--------------------------------------------------------");
Stack<int> stack = new Stack<int>();

stack.Push(12);
stack.Push(2);
stack.Push(145);

Console.WriteLine(stack.Peek());
Console.WriteLine(stack.Count());

Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Count());

Console.WriteLine("--------------------------------------------------------");

Queue<string> queue = new();

queue.Enqueue("İstanbul");
queue.Enqueue("Ankara");
queue.Enqueue("İzmir");

Console.WriteLine(queue.Dequeue());
Console.WriteLine(queue.Count());

Console.WriteLine(queue.Peek());
Console.WriteLine(queue.Count());

Console.WriteLine("--------------------------------------------------------");

Dictionary<int, string> dictionary = new();

dictionary.Add(1, "Adana");
dictionary.Add(6, "Ankara");
dictionary.Add(34, "İstanbul");

Console.WriteLine(dictionary[34]);
Console.WriteLine("--------------------------------------------------------");