public class Solution {
    public int LargestOverlap(int[][] img1, int[][] img2) {
        
        int n = img1.Length;
        
        List<(int,int)> bitsA = new();
        List<(int,int)> bitsB = new();
        
        for(int i =0; i < n; ++i){
            for(int j =0; j < n; ++j){
                if(img1[i][j] == 1){
                    bitsA.Add((i,j));
                }
                
                if(img2[i][j] == 1){
                    bitsB.Add((i,j));
                }
            }
        }
        
        n = bitsA.Count;
        int m = bitsB.Count;
        
        Dictionary<(int,int),int> diffToCountMap = new();
        
        for(int i =0; i < n; ++i){
            int x1,y1;
            x1 = bitsA[i].Item1;
            y1 = bitsA[i].Item2;
            
            for(int j =0; j < m; ++j){
                
                int x2,y2;
                x2 = bitsB[j].Item1;
                y2 = bitsB[j].Item2;
                
                int xdiff = x2 - x1;
                int ydiff = y2- y1;
                
                if(!diffToCountMap.ContainsKey((xdiff,ydiff))){
                    diffToCountMap[(xdiff,ydiff)] = 0;
                }
                
                diffToCountMap[(xdiff,ydiff)] += 1;
                
            }
        }
        
        int ans = 0;
        foreach(var keyvalue in diffToCountMap){
            ans = Math.Max(ans , keyvalue.Value);
        }
        
        return ans;
        
    }
}