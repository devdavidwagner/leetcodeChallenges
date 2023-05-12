using System;

class Program
{
    static void Main(string[] args)
    {   
        
        Console.WriteLine("Welcome to David's Roman Numerals to Integer converter!\n Enter a Roman numeral to convert:\n");
        string value = "";
        value = Console.ReadLine() ?? throw new Exception("Error! Nothing entered.");

        int returnedInt = RomanToInt(value);

        Console.WriteLine($"YOUR NUMERAL: {value} EQUALS {returnedInt} in INTEGER");
        


    }
    static int RomanToInt(string s) {   
        
        string[,] romanValuePairs = {{"I", "1"}, {"V", "5"}, {"X", "10"}, {"L", "50"}, {"C", "100"}, {"D", "500"}, {"M", "1000"}};
        string[] subtractors = {"I","X","C"};
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
        int previousInt = 1;
        bool usesSubtraction = false;
        foreach (int val in values)
        {
            Console.WriteLine(val.ToString());
            if (val > previousInt){
                totalValue += val;
            }
            else{

            }
            previousInt = val;
        }          

        return totalValue;
    }
}

