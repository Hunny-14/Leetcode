public class Solution {
    
    Dictionary<int,int>[] dp;
    
    public int MaxLength(IList<string> arr) {
        
        
        int n = arr.Count;
        
//         var prev = new int[1 << n];
//         var curr = new int[1 << n];
        
//         for(int i = 0; i < n; ++i){
            
//             for(int j = 0; j < (1 << n); ++j){
                
//                 int ans =0;
//                 if(IsPossibleToUse(i,j,arr)){
                    
//                     int newVisited = (j | (1 << i));
//                     ans = Math.Max((arr[i].Length +  prev[newVisited]) , prev[j]);
//                 } 
//                 else{
//                     ans = prev[j];
//                 }
                
//                 curr[j] = ans;
//             }
            
//             prev = curr;
//             curr = new int[1 << n];
//         }
        
//         return prev[0];
        
        
        
        dp = new Dictionary<int,int>[n];
        
        for(int i =0; i < n; ++i){
            dp[i] = new Dictionary<int,int>();
        }
        
        return ML(n-1,0,arr);
    }
    
    int ML(int i , int visited , IList<string> arr){
        
        if(i < 0){
            return 0;
        }
        
        if(dp[i].ContainsKey(visited)){
            return dp[i][visited];
        }
        
        int ans = 0;
        if(IsPossible(i , visited, arr)){
            
            int newVisited = visited;
            var word = arr[i];
            for(int j = 0; j < word.Length; ++j){
                newVisited |= (1 << (word[j] - 'a'));
            }
            
            ans = Math.Max((word.Length +  ML(i-1,newVisited,arr)) , ML(i-1,visited,arr) );
        }
        else{
            ans = ML(i-1,visited,arr);
        }
        
        dp[i][visited] = ans;
        return ans;
        
    }
    
    bool IsPossible(int i , int visited, IList<string> arr){
        var word = arr[i];
        int n = word.Length;
        
        var hset = new HashSet<int>();
        
        for(int j =0; j < n; ++j){
            char c = word[j];
            if(hset.Contains(c)){
                return false;
            }
            
            if((visited & (1 << (c-'a'))) != 0){
                return false;
            }
            
            hset.Add(c);
        }
        
        return true;
        

    }
    
    bool IsPossibleToUse(int i , int visited, IList<string> arr){
        
        var word = arr[i];
        
        if(IsDuplicate(word)){
            return false;
        }
        
        
        
        for(int k = 0; k < arr.Count; ++k){
            if((visited & (1 << k)) != 0){
                
                var wordToCompare = arr[k];
                
                if(isConflict(word,wordToCompare)){
                    return false;
                }
            }
        }

        return true;
    }
    
    bool isConflict(string a, string b){
        var hset = new HashSet<char>();
        
        for(int i =0; i < a.Length; ++i){
            hset.Add(a[i]);
        }
        
        for(int i = 0; i < b.Length; ++i){
            if(hset.Contains(b[i])){
                return true;
            }
        }
        
        return false;
    }
    
    bool IsDuplicate(string a){
        var hset = new HashSet<char>();
        
        for(int i =0; i < a.Length; ++i){
            if(hset.Contains(a[i])){
                return true;
            }
            
            hset.Add(a[i]);
        }
        
        return false;
    }
}