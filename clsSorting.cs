using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCore
{
    class clsSorting
    {
        //Inplace Sorting
        //Time Compexity - O(n^2). [n*n]
        //Space Compexity - O(1). No additional data structures
        public void InsertionSort(int[] input)
        {
            //Two Pointer
            int i = 0;                  //Element to be sorted
            while (i < input.Length)
            {
                int j = i + 1;
                while (j < input.Length)             //Swap if ith element is greater
                {
                    if (input[i] > input[j])
                    {
                        //swap
                        int temp = input[i];
                        input[i] = input[j];
                        input[j] = temp;
                    }
                    j++;
                }
                i++;
            }

            foreach (int x in input)
            {
                Console.WriteLine(x);
            }
        }

        //Time Complexity - O(n^2)
        //Space Complexity O(n)
        public void SelectionSort(int[] input)
        {
            //Find minimum
            int temp = 0, _min = 0;                 //Element to be sorted

            for (int i = 0; i < input.Length - 1; i++)
            {
                _min = i;                           //Set element index To compare
                //linear scan               
                for (int j = i + 1; j < input.Length; j++)
                {

                    if (input[j] < input[_min])
                    {
                        //set index
                        _min = j;
                    }

                }

                //swap elements
                if (_min != i)
                {
                    temp = input[_min];
                    input[_min] = input[i];
                    input[i] = temp;
                }

            }

            foreach (int x in input)
            {
                Console.WriteLine(x);
            }
        }

        //Generalized insertion sort - for sublist Gap
        //Instead of Comparing next element, compare nth(gap)
        //Use - to sort entries which further away first. https://www.programiz.com/dsa/shell-sort 
        public void ShellSort(int[] input)
        {
            int _len = input.Length;
            //Sublists - Sequece n/3,n/6,n/12...1          
            for (int gap = _len; gap > 0; gap /= 3)
            {
                //Insertion Sort - compare 2 elements
                for (int i = 0; i < _len; i++)
                {
                    for (int j = i + gap-1; j < _len; j++)
                    {
                        //Compare i and jth elements Distance = gap
                        if (input[j] < input[i])
                        {
                            int temp = input[i];
                            input[i] = input[j];
                            input[j] = temp;
                        }
                    }
                }
            }         
        }

        //Divide and Conquer
        //Divide - n/2,n/4,n/8....1
        //Sort. Combine.
        //Used with Linked List
        public void MergeSort(int[] input)
        {
            int[] helper = new int[input.Length];
            divide(0, input.Length-1, input, helper);

            foreach (int x in input)
            {
                Console.WriteLine(x);
            }
        }

        private void divide(int l,int r, int[] nums,int[] helper)
        {
            Console.WriteLine("l:" + l + ",r:" + r);
            if (l < r)                                              //Binary - iterates through all elements only once
            {
                int middle = l + (r - l) / 2;                           
                Console.WriteLine("middle:" + nums[middle]);
                divide(l, middle, nums, helper);
                divide(middle+1, r, nums, helper);
                merge(l, r, middle, nums, helper);
            }
        }

        private void merge(int l,int middle, int r, int[] nums, int[] helper)
        {
            //Add elements into helper
            for(int i = l; i < r; i++)
            {
                helper[i] = nums[i];
            }

            //Sort helper
            int hL = l;
            int hR = middle + 1;
            int current = l;
            //Pick smaller between left and right of helper
            while(hL <= middle && hR <= r)
            {
                if(helper[hL] < helper[hR])
                {
                    nums[current] = helper[hL];
                    hL++;
                }
                else
                {
                    nums[current] = helper[hR];
                    hR++;
                }
                current++;
            }
            //Add remaining
            int remaining = middle - hL;
            for(int i = 0; i <= remaining; i++)
            {
                nums[current + i] = helper[hL + i];
            }
        }

        //Divide and Conquer 
        //Pick  a pivot , Smaller left + lareger right (Not sorted)
        //Compare left elments - Sort, Sort right
        //Complexity - log n.
        public void QuickSort(int[] input)
        {
            //Choose a pivote
            int middle = input.Length / 2;
            int pivot = input[middle];

            if (input.Length == 1)
            {
                if (input[0] > input[1])
                {
                    int temp = input[0];
                    input[0] = input[1];
                    input[1] = temp;
                }
                return;
            }

            int[] firstHalf = new int[middle];
            //input.CopyTo(firstHalf, middle-1);
            int[] secondHalf = new int[middle];
            //input.CopyTo(secondHalf, input.Length);
            Array.Copy(input, middle-1, secondHalf,secondHalf.GetUpperBound(0), input.Length - middle);
            while (firstHalf.Length > 1)
            {
                QuickSort(firstHalf);
                //QuickSort(secondHalf);
            }
            while (secondHalf.Length > 1)
            {
                //QuickSort(firstHalf);
                QuickSort(secondHalf);
            }

            return;
        }

        //Greedy Approach https://www.geeksforgeeks.org/bubble-sort/
        //Repeatedly swap next elements
        //Not for large datasets
        public void BubbleSort(int[] input)
        {            
            for(int x = 0;x < input.Length-1; x++)
            {
                for(int i= 0; i < input.Length - 1;  i++)
                {
                    if (input[i] > input[i + 1])
                    {
                        //Swap
                        int temp = input[i];
                        input[i] = input[i + 1];
                        input[i + 1] = temp;
                    }
                    //Console.Write(":" + input[i] + " " + input[i + 1]);
                }
            }            
        }

        //Binary Heap, in-place sorting https://www.youtube.com/watch?v=2DmK_H7IdTo
        //Find minimum, place it first        
        private void HeapSort(int[] input)
        {
            //Build a max heap
        }
    }

   
}
