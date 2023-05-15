﻿using System;

class Program
{
    static void Main(string[] args)
    {   
        Console.WriteLine("\nWelcome to David's Leetcode Challenge Menu!\n Select an app (number key):\n");
        Console.WriteLine("1. Roman Numerals to Integers\n");
        Console.WriteLine("2. Two Sum Solution\n");
        ConsoleKeyInfo keyInfo = Console.ReadKey();

        switch(keyInfo.Key) {
                case ConsoleKey.D1:
                    RomanToIntMain();
                    break;
                case ConsoleKey.D2:
                    TwoSum();
                    break;
                default:
                    break;
        }
    }

     static void TwoSum(){
        Console.WriteLine("\nWelcome to David's Two Sum Solution!\n");
        Console.WriteLine("\nPlease choose a problem:\n");

        Console.WriteLine("1. nums = [2,7,11,15], target = 9\n");
        Console.WriteLine("2. nums = [3,2,4], target = 6\n");
        Console.WriteLine("3. nums = [3,2,3], target = 6\n");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        int[] answer;
        switch(keyInfo.Key) {
                case ConsoleKey.D1:
                    answer = TwoSumAlgo(new int[]{2,7,11,15}, 9);
                    Console.WriteLine($"The solution for #1 is: {answer[0]},{answer[1]}");
                    break;
                case ConsoleKey.D2:
                    answer = TwoSumAlgo(new int[]{3,2,4}, 6);
                    Console.WriteLine($"The solution for #2 is: {answer[0]},{answer[1]}");
                    break;
                case ConsoleKey.D3:
                    answer = TwoSumAlgo(new int[]{3,2,3}, 6);
                    Console.WriteLine($"The solution for #3 is: {answer[0]},{answer[1]}");
                    break;
                default:
                    break;
        }

       
    }

    static int[] TwoSumAlgo(int[] nums, int target) {
        int[] sumInd = new int[2];
        bool found = false;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if(nums[i] + nums[j] == target){
                    sumInd[0] = i;
                    sumInd[1] = j;
                    found = true;
                    break;
                }
            }
            if(found)
                break;
        }
        return sumInd;
    }

    static void RomanToIntMain(){
        Console.WriteLine("Welcome to David's Roman Numerals to Integer converter!\n Enter a Roman numeral to convert:\n");
        string value = "";
        value = Console.ReadLine() ?? throw new Exception("Error! Nothing entered.");

        int returnedInt = RomanToInt(value);

        Console.WriteLine($"YOUR NUMERAL: {value} EQUALS {returnedInt} in INTEGER");
    }
    static int RomanToInt(string s) {          
        string[,] romanValuePairs = {{"I", "1"}, {"V", "5"}, {"X", "10"}, {"L", "50"}, {"C", "100"}, {"D", "500"}, {"M", "1000"}};
        List<int> values = new List<int>();
        int totalValue = 0;
        foreach (char c in s){
            bool foundMatch = false;
            int valueOfChar = 0;
            string charInString = "";
            for(int col = 0; col < romanValuePairs.GetLength(0); col++){
                for(int row = 0; row < romanValuePairs.GetLength(1); row++){
                    if (romanValuePairs[col,row] == c.ToString()){
                        foundMatch = true;
                        valueOfChar = int.Parse(romanValuePairs[col,row + 1]);
                        charInString = romanValuePairs[col,row].ToString();
                        values.Add(valueOfChar);
                        break;
                    }
                }
                if(foundMatch){
                    break;
                }
            }         
        }
        int previousInt = 0;
        List<int> newVals = new List<int>();
        int indexI = 0;
        for(int i = 0; i < values.Count(); i++){
            int nextInt = 0;
            if(i != values.Count() - 1){
                nextInt = values[i + 1];
            }             
            if (previousInt != 0 && values[i] > previousInt){
                int newVal = (values[i] - previousInt);
                if(newVals.Count() > i){
                    newVals[i - 1] = newVal;
                }
                else{
                    newVals.Add(newVal);
                }             
            }
            else{
                    if(nextInt != 0 && nextInt <= values[i]){
                        newVals.Add(values[i]);
                    }
                    else if(values.Count() - 1 == i){
                        newVals.Add(values[i]);
                    }
                }
            
            previousInt = values[i];
            indexI++;
        }          
        foreach (int val in newVals)
        {
           // Console.WriteLine("Val adding..." + val.ToString());
            totalValue += val;
           // Console.WriteLine("Total Value..." + totalValue.ToString());
        } 
        return totalValue;
    }
}

