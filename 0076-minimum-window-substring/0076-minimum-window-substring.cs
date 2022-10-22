public class Solution {
    public string MinWindow(string s, string t) {
        
        var rMap = new Dictionary<char , int>();
        var currMap = new Dictionary<char , int>();
        int target = 0;
        for(int i =0 ; i < t.Length; ++i){
            if(rMap.ContainsKey(t[i])){
                rMap[t[i]] += 1;
            }
            else{
                rMap[t[i]] = 1;
            }
            currMap[t[i]] = 0;
        }
        
        target = t.Length;

        
        int p1 = 0;
        int n = s.Length;
        int ans = int.MaxValue;
        int l = -1 , r = -1;
        
        while(p1 < n && !rMap.ContainsKey(s[p1])){
            ++p1;
        }
        
        if(p1 >= n){
            return "";
        }
        
        int count = 1;
        currMap[s[p1]] += 1;
        int p2 = p1;
        
        while(p2 < n){
            
            if(count == target){
                if(ans > (p2 - p1 + 1)){
                    ans = p2 - p1 + 1;
                    l = p1;
                    r = p2;
                }
                 
                if(currMap[s[p1]] <= rMap[s[p1]]){
                    count -= 1;
                }
                
                currMap[s[p1]] -= 1;
                p1 += 1;
                while(p1 < n && !rMap.ContainsKey(s[p1])){
                    ++p1;
                }
                
                if(p2 < p1){
                    p2 = p1;
                }
            }
            else{
                
                ++p2;    
                
                if(p2 < n && rMap.ContainsKey(s[p2])){
                
                    if(currMap[s[p2]] < rMap[s[p2]]){
                        count += 1;
                    }

                    currMap[s[p2]] += 1;
                }
                
            }
        
        }
        
        if(l >= 0){
            return s.Substring(l , ans);
        }
        return "";
    }
}