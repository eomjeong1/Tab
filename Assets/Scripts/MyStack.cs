using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MyStack : MonoBehaviour
{
    public int Count;
    public int[] ar;

    Stack<int> ints = new Stack<int>();
    public MyStack(int size)
    {
        ar = new int[size];
        

        // size 크기만큼 배열을 생성
        // int[]생성
    }

    // 스택의 사이즈를 초과해서 Push를 하려고 하면 에러 = Stack Overflow

    public void Push(int data)
    {
        if (Count < ar.Length)

            ar[Count++] = data;
    
        else if(Count >= ar.Length)
        {
            Debug.Log("Stack is Overflow");
        }
    }

    // 스택에 데이터가 없는데 Pop를 하려고 하면 에러 = Stack is Empty
    public int Pop()
    {   int CountH = 0;

        if (Count > 0)
        {
            CountH = ar[--Count];
            
        }
        else if (Count <= 0)
        {
            Debug.Log("Stack is Empty");
        }
        return Count;
    }

    public void Clear()
    {
        for (int i = 0; i < ar.Length; i++)
        { 
            ar[i] = 0;
        }
        Count = 0;

    }
}

