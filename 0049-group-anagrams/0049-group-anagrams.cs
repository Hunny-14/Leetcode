public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        
        int n = strs.Length;
        var newArr = new string[n];
        
        
        for(int i=0; i < n; ++i){
            newArr[i] = CountSort(strs[i]);
        }
        
        var dict = new Dictionary<string,List<int>>();
        
        
        for(int i =0; i < n; ++i){
            if(!dict.ContainsKey(newArr[i])){
                dict[newArr[i]] = new List<int>();
            }
            
            dict[newArr[i]].Add(i);
        }
        
        
        var ans = new List<IList<string>>();
        
        foreach(var keyvalue in dict){
            var groupInd = keyvalue.Value;
            int groupLength = groupInd.Count;
            ans.Add(new List<string>());
            for(int i = 0; i < groupLength; ++i){
                ans[ans.Count-1].Add(strs[groupInd[i]]);
            }
        }
        
        return ans;
    }
    
    public string CountSort(string A){
        int[] charCount = new int[26];
        
        for(int i =0; i < A.Length; ++i){
            charCount[A[i] - 'a'] += 1;
        }
        
        var newString = new StringBuilder();
        
        for(int i =0; i < 26; ++i){
            while(charCount[i] != 0){
                newString.Append((char)('a' + i));
                charCount[i] -= 1;
            }
        }
        
        return newString.ToString();
    }
}