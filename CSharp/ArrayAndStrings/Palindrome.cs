using System;
using System.Collections;
using System.Collections.Generic;

class MyQueue {

    private LinkedList<char> _items = new LinkedList<char>();

    public void Enqueue(char item) {
        _items.AddLast(item);
    }
    public char Dequeue() {
        var item = _items.First;
        _items.RemoveFirst();
        return item.Value;
    }
}

class MyStack {

    private LinkedList<char> _items = new LinkedList<char>();

    public void Push(char item) {        
        _items.AddLast(item);
    }
    public char Pop(){
        var item =  Peek();
        _items.RemoveLast();
        return item;

    }
    public char Peek() {
        return _items.Last.Value;
    }
}

class Solution {

   private MyStack _stack = new MyStack();
   private MyQueue _queue = new MyQueue();

    public void pushCharacter(char e){
        _stack.Push(e);
    }

    public void enqueueCharacter(char e){
        _queue.Enqueue(e);
    }

    public char popCharacter(){
        return _stack.Pop();
    }

    public char dequeueCharacter(){
        return _queue.Dequeue();
    }

}

class HelloWorld
{
	static void Main(String[] args)
	{

        // read the string s.
        string s = "racecars";
        
        // create the Solution class object p.
        Solution obj = new Solution();
        
        // push/enqueue all the characters of string s to stack.
        foreach (char c in s) {
            obj.pushCharacter(c);
            obj.enqueueCharacter(c);
        }
        
        bool isPalindrome = true;
        
        // pop the top character from stack.
        // dequeue the first character from queue.
        // compare both the characters.
        for (int i = 0; i < s.Length / 2; i++) {
            if (obj.popCharacter() != obj.dequeueCharacter()) {
                isPalindrome = false;
                
                break;
            }
        }
        
        // finally print whether string s is palindrome or not.
        if (isPalindrome) {
            Console.Write("The word, {0}, is a palindrome.", s);
        } else {
            Console.Write("The word, {0}, is not a palindrome.", s);
        }
	}
}
