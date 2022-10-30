public class Solution {
    
    public int ShortestPath(int[][] grid, int k) {
        int n = grid.Length;
        int m = grid[0].Length;
        
        var visited = new HashSet<int>[n][];
        
        //Initialize
        for(int i = 0; i < n; ++i){
            visited[i] = new HashSet<int>[m];
            for(int j=0; j < m; ++j){
                visited[i][j] = new HashSet<int>();
            }
        }
        
        var queue = new Queue<Info>();
        
        var obs = grid[0][0] == 1 ? 1 : 0;
        queue.Enqueue(new Info(0,0,0,obs));
        visited[0][0].Add(obs);
        
        
        var di  = new int[] {-1,0,1,0};
        var dj = new int[] {0,1,0,-1};
        
        while(queue.Count > 0){
            var curr = queue.Dequeue();
            
            if(curr.i == n-1 && curr.j == m-1){
                return curr.dist;
            }
            
            for(int i =0; i < di.Length; ++i){
                int newI = curr.i + di[i];
                int newJ = curr.j + dj[i];
                
                if(IsValid(newI,newJ,grid)){    
                    int newObs = grid[newI][newJ] == 1 ? curr.obs + 1 : curr.obs;
                    
                    if(!visited[newI][newJ].Contains(newObs) && newObs <= k){
                         queue.Enqueue(new Info(newI,newJ,curr.dist + 1,newObs));
                         visited[newI][newJ].Add(newObs);
                    }
                }
            }
            
        }
        
        return -1;
    }
    
    public bool IsValid(int i , int j, int[][] grid){
        int n = grid.Length;
        int m = grid[0].Length;
        if(i >=0 && i < n && j >= 0 && j < m){
            return true;
        }
        
        return false;
    }
    
    public class Info{
        public int i;
        public int j;
        public int dist;
        public int obs;
        
        public Info(int a, int b, int c, int d){
            i = a; j = b; dist = c; obs = d;
        }
    }
}