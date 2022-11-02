public class Solution {
    
    List<List<int>> adjList;
    
    public int MinMutation(string start, string end, string[] bank) {
        
        bank = bank.Concat(new string[] {start}).ToArray();
        int n = bank.Length;
        
        int dist = 0;
        
        var queue = new Queue<int>();
        queue.Enqueue(n-1);
        bool[] visited = new bool[n];
        
        while(queue.Count != 0){
            
            int queueSize = queue.Count;
            
            for(int i =0; i < queueSize; ++i){
                var gene = queue.Dequeue();
                
                if(bank[gene] == end){
                    return dist;
                }
                
                for(int j = 0; j < n; ++j){
                    
                    if(!visited[j] && IsMutation(bank[gene] , bank[j])){
                        visited[j] = true;
                        queue.Enqueue(j);
                    }
                }
                
            }
            
            dist += 1;
            
        }
        
        return -1;
    }
    
    bool IsMutation(string A, string B){
        int count = 0;
        int n = A.Length;
        for(int i =0; i < n; ++i){
            if(A[i] != B[i]){
                count += 1;
            }
        }
        
        return count == 1;
    }
}