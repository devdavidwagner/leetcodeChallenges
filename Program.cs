using System;

class Program
{
    static void Main(string[] args)
    {   
        Console.WriteLine("\nWelcome to David's Leetcode Challenge Menu!\n Select an app (number key):\n");
        Console.WriteLine("1. Roman Numerals to Integers\n");
        Console.WriteLine("2. Climbing Stairs Algorithm\n");
        ConsoleKeyInfo keyInfo = Console.ReadKey();

        switch(keyInfo.Key) {
                case ConsoleKey.D1:
                    RomanToIntMain();
                    break;
                case ConsoleKey.D2:
                    ClimbStairsMan();
                    break;
                default:
                    break;
        }
    }

     static void ClimbStairsMan(){
        Console.WriteLine("\nWelcome to David's Climbing Stairs Problem!\n");
        //string value = "";
       // value = Console.ReadLine() ?? throw new Exception("Error! Nothing entered.");

       // int returnedInt = ClimbStairs(value);
    }

    static int ClimbStairs(int n) {
        int s = 0;

        return s;
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

