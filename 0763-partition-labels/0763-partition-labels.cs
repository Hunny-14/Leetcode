public class Solution {
    public IList<int> PartitionLabels(string s) {
        
        int n = s.Length;
        int[] lastPos;
        List<int> ans = new();
        
        //Get Last Pos filled
        lastPos = GetLastPosArray(s);
        
        int currLastPos = lastPos[s[0] - 'a'];
        int length = 0;
        
        for(int i =0; i < n; ++i){
            ++length;
            currLastPos = Math.Max(currLastPos, lastPos[s[i] - 'a']);
            
            if(i == n -1){
                ans.Add(length);
                continue;
            }
            
            if(i == currLastPos){
                ans.Add(length);
                currLastPos = lastPos[s[i+1] - 'a'];
                length = 0;
                
            }
        }
        
        return ans;
        
        
    }
    
    
    int[] GetLastPosArray(string s){
        
        int[] ans = new int[26];
        int n = s.Length;
        
        for(int i = 0; i < n; ++i){
            ans[s[i] - 'a'] = i;
        }
        
        return ans;
        
    }
    
    
}