public class Solution {
    public int[] FindBall(int[][] grid) {
        int n = grid.Length;
        int m = grid[0].Length;
        
        int[] ans = new int[m];
        
        for(int j = 0; j < m; ++j){
            
            int inColumn = j;
            int outColumn = j;
            
            for(int i =0; i < n; ++i){
                outColumn = GetOutCOlumn(i,inColumn,grid);
                
                if(outColumn == -1){
                    ans[j] = -1;
                    break;
                }
                
                inColumn = outColumn;
            }
            
            ans[j] = outColumn;
        }
        
        return ans;
    }
    
    int GetOutCOlumn(int row,int inColumn,int[][] grid){
        
        int n = grid.Length;
        int m = grid[0].Length;
        
        int inDirection = grid[row][inColumn];
        
        if(inDirection == 1){ //right
            if(inColumn == m-1 || grid[row][inColumn + 1] == -1){
                return -1;
            }
            
            return inColumn+1;
        }
        else{   //left
            if(inColumn == 0 || grid[row][inColumn -1] == 1){
                return -1;
            }
            
            return inColumn - 1;
        }
    }
    
    
}