public class Solution {
    public bool ArrayStringsAreEqual(string[] word1, string[] word2) {
        var string1 =  string.Join("",word1);  // Check
        var string2 = string.Join("",word2);
        
        return string1.CompareTo(string2) == 0;
    }
}