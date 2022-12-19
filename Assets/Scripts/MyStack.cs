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
        

        // size ũ�⸸ŭ �迭�� ����
        // int[]����
    }

    // ������ ����� �ʰ��ؼ� Push�� �Ϸ��� �ϸ� ���� = Stack Overflow

    public void Push(int data)
    {
        if (Count < ar.Length)

            ar[Count++] = data;
    
        else if(Count >= ar.Length)
        {
            Debug.Log("Stack is Overflow");
        }
    }

    // ���ÿ� �����Ͱ� ���µ� Pop�� �Ϸ��� �ϸ� ���� = Stack is Empty
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

