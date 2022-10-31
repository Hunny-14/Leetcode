public class Solution {
    public bool IsToeplitzMatrix(int[][] matrix) {
        int n = matrix.Length;
        int m = matrix[0].Length;
        for(int k = 0; k < m; ++k){
            int i = 1;
            int j = k + 1;
            while(i < n && j < m){
                if(matrix[i-1][j-1] != matrix[i][j]){
                    return false;
                }
                
                ++i;
                ++j;
            }
        }
        
        for(int k = 1; k < n; ++k){
            int i = k+1;
            int j = 1;
            
            while(i<n && j < m){
                if(matrix[i-1][j-1] != matrix[i][j]){
                    return false;
                }
                
                ++i;
                ++j;
            }
        }
        
        return true;
    }
}