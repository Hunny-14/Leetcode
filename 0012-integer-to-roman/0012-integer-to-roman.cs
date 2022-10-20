public class Solution {
    
    SortedDictionary<int,string> numToRomanMap = new() {
        
        {1 , "I"},
        {4 , "IV"},
        {5 , "V"},
        {9 , "IX"},
        {10 , "X"},
        {40 , "XL"},
        {50 , "L"},
        {90 , "XC"},
        {100 , "C"},
        {400 , "CD"},
        {500 , "D"},
        {900 , "CM"},
        {1000 , "M"}
    };  // check this
    
    public string IntToRoman(int num) {
        
        if(num == 0){
            return "";
        }
        
        int maxNum = 1;
        
        foreach(var knownNum in numToRomanMap){
            if(num >= knownNum.Key){
                maxNum = knownNum.Key;
            }
        }
        
        return numToRomanMap[maxNum] + IntToRoman(num - maxNum);
        
    }
    
    
    
    
}