public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        
        int n = gas.Length;
        
        int length = 0;
        
        int i =0;
        int j = 0;
        int sum = 0;
        
        while(i < n){
            Console.WriteLine(i);
            sum += (gas[j] - cost[j]);
            
            if(sum < 0){
                if(j >= i && j < n-1 ){
                    i = j + 1;
                    j = i;
                    sum = 0;
                    length = 0;
                }
                else{
                    break;
                }
            }
            else{
               j = ((j == n-1) ? 0 : j + 1);
               length += 1;
            }
            
            if(length == n){
                if(sum >= 0){
                    return i;    
                }
                else{
                    break;
                }
            }
        }
        
        return -1;
        
    }
}