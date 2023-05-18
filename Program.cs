using System;
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
      }
  }
class Program
{
    
    static void Main(string[] args)
    {
        bool mainRunning = true;   
        while(mainRunning){
            Console.WriteLine("\nWelcome to David's Leetcode Challenge Menu!\n Select an app (number key) - Press escape to exit:\n");
            Console.WriteLine("1. Roman Numerals to Integers");
            Console.WriteLine("2. Two Sum Solution");
            Console.WriteLine("3. Reverse Integer Algorithm");
            Console.WriteLine("4. Add Two Numbers");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
        
            switch(keyInfo.Key) {
                    case ConsoleKey.D1:
                        RomanToIntMain();
                        break;
                    case ConsoleKey.D2:
                        TwoSum();
                        break;
                    case ConsoleKey.D3:
                        ReverseInt();
                        break;
                    case ConsoleKey.D4:
                        AddTwoNumbers();
                        break;
                    case ConsoleKey.Escape:
                        mainRunning = false;
                        break;
                    default:
                        mainRunning = false;
                        break;
            }
        }
  
    }
    static void AddTwoNumbers() {
        Console.WriteLine("\nWelcome to David's Add Two Numbers Solution!\nType EXIT to go back to main Menu.\n");
        Console.WriteLine("\nPress any key to solve : l1 = [2,4,3], l2 = [5,6,4]");  //342 + 465 = 807
        Console.ReadKey();
        bool running = true;
        while(running){

            ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(3))); 
            ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4)));

            ListNode answer = AddTwoNumbersAlgo(l1, l2);

            string consoleAnswer = "";

            while(answer.next != null){
                consoleAnswer += answer.val.ToString() + ",";
                answer = answer.next;
            }

            Console.WriteLine("Your Answer is :" + consoleAnswer);
            running = false;

        }
    }
    
    public static ListNode AddTwoNumbersAlgo(ListNode l1, ListNode l2) {        
        string reversed1 = ConvertToString(l1);
        int sum1 = int.Parse(reversed1);

        string reversed2 = ConvertToString(l2);
        int sum2 = int.Parse(reversed2);

        int totalSum = sum1 + sum2;
        Console.WriteLine("TOTAL SUM: " + totalSum.ToString());
        string sumInString = totalSum.ToString();               
        char[] sumCharArray = sumInString.ToCharArray();

        ListNode sumNode = new ListNode((sumCharArray[sumCharArray.Length - 1]));
        Console.WriteLine(sumCharArray.Length.ToString());
        for (int i = sumCharArray.Length - 2; i > -1 ; i--)
        {     
            ListNode nextNode = new ListNode(sumCharArray[i]);
            if( i == sumCharArray.Length - 2){
                sumNode.next = nextNode;
            }         
            if( i > 0){
                nextNode.next = new ListNode(sumCharArray[i - 1]);
            }
            
           
        }
        
        return sumNode;
    }

    static string ConvertToString(ListNode list){    
        string twoNumbers = "";
        while(list.next != null)
        {
            Console.WriteLine(list.val.ToString());
            twoNumbers += list.val.ToString();
            list = list.next;
        }
        char[] chars = twoNumbers.ToCharArray();
        string reversed = "";
        for (int i = chars.Length - 1; i > -1 ; i--)
        {
            reversed+= chars[i].ToString();
        }
         Console.WriteLine("Reversed string:" + reversed);
        return reversed;
    }

    static void ReverseInt() {
        Console.WriteLine("\nWelcome to David's Reverse Integer Solution!\nType EXIT to go back to main Menu.\n");

        bool running = true;
        while(running){
            Console.WriteLine("\nPlease enter an integer:");        
            string value = Console.ReadLine() ?? "";
            int test = 0;
            if(value != null && value.ToUpper() == "EXIT"){
              running = false;
              continue;
            }
            if(value == "" || value == null || !int.TryParse(value, out test)){
                Console.WriteLine("No integer entered.");
                continue;
            }      
            else if (value != "" && value != null){               
                int chosenInt = int.Parse(value);
                int answer = ReverseAlgo(chosenInt);
                Console.WriteLine("\nThis is your integer in reverse: " + answer.ToString());
            }

        }
 
    }

    //TODO: MAKE LOOPABLE
    static int ReverseAlgo(int x) {
        int answer = 0;
        string conv = x.ToString();
        char[] convChars = conv.ToCharArray();
        string reverseConv = "";
        bool negative = false;
        for (int i = convChars.Length - 1; i >= 0; i--)
        {
            string singleChar = convChars[i].ToString();
            int c = 0;
            if(int.TryParse(singleChar, out c)){
                reverseConv = reverseConv + singleChar;
            }
            else {
                negative = true;
            }
            
        }     
        int.TryParse(reverseConv, out answer);

        if(negative){
            answer *= -1;
        }
        return answer;
    }

    // TO DO: ADD INPUT functionality to allow any valid num/target instead of choosing a predetermined list

    //TO DO: MAKE LOOPABLE
     static void TwoSum(){
        Console.WriteLine("\nWelcome to David's Two Sum Solution!\nType EXIT to return to menu.\n");
        bool running = true;
        
        while(running){
            string errorMsg = "";
            Console.WriteLine("\nPlease enter a Two-Sum problem using the following format:\n");
            Console.WriteLine("[numbers]=[target]  e.g. 1,2,3=4");
            string value = Console.ReadLine() ?? "";
            if(value != null && value.ToUpper() == "EXIT"){
              running = false;
            }
            else if(value != "" && value != null)
            {
                string numbers = value.Split("=")[0];
                string[] numsSplit = numbers.Split(',');
                string target = value.Split("=")[1];

                int[] toFuncNums = new int[numsSplit.Length];
                for (int i = 0; i < numsSplit.Length; i++)
                {
                    int outTest = 0;
                    if(int.TryParse(numsSplit[i], out outTest)){
                        toFuncNums[i] = outTest;
                    }
                    else{
                        errorMsg = $"Value: {numsSplit[i]} is not a valid integer for the input numbers.";
                    }
                }
                int outTestTarget = 0;
                int toFuncTarget = 0;
                if(int.TryParse(target, out outTestTarget)){
                    toFuncTarget = outTestTarget;
                }
                else{
                    errorMsg += $"\nValue: {outTestTarget} is not a valid integer for the target sum.";
                }

                if(errorMsg != ""){
                    Console.WriteLine(errorMsg);
                } 
                //success
                else{
                    int[] answer = TwoSumAlgo(toFuncNums,toFuncTarget);
                    Console.WriteLine($"The answer to your Two-Sum problem of {value} is : {numsSplit[answer[0]]} + {numsSplit[answer[1]]} = {target}");
                }

            } 
          
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
        bool running = true;
        while(running){
            Console.WriteLine("\nWelcome to David's Roman Numerals to Integer converter!\nType EXIT to return to menu.\nEnter a Roman numeral to convert:\n");
            string errorMsg = "";
            string value = "";
            value = Console.ReadLine() ?? "";
            if(value == null || value == ""){
                errorMsg = "No value entered.\n";
            }
            else if(value.ToUpper() == "EXIT"){
                running = false;
            }
            else{
                int returnedInt = RomanToInt(value);
                Console.WriteLine($"YOUR NUMERAL: {value} EQUALS {returnedInt} in INTEGER");
            }

            if(errorMsg != null && errorMsg != ""){
                Console.WriteLine(errorMsg);
            }           

        }

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

