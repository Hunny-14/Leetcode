public class Solution {
    public int LongestPalindrome(string[] words) {
        
        int n = words.Length;
        
        var freqMap = new Dictionary<string,int>();
        
        int ans = 0;
        int pairs = 0;
        
        for(int i = 0;i < n; ++i){
            var rev = new string(words[i].Reverse().ToArray());
            if(freqMap.ContainsKey(rev)){
                pairs += 1;
                freqMap[rev] -= 1;
                
                if(freqMap[rev] == 0){
                    freqMap.Remove(rev);
                }
            }
            else{
                if(!freqMap.ContainsKey(words[i])){
                    freqMap[words[i]] = 0;
                }
                
                freqMap[words[i]] += 1;
            }
        }
        
        ans += (pairs * 4);
        
        
        foreach(var keyValue in freqMap){
            
            var word = keyValue.Key;
            //Console.Write(word);
            if(word[0] == word[1]){
                ans += 2;
                break;
            }
        }
        
        return ans;
    }
}