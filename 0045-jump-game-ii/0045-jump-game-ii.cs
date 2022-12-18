public class Solution {
    public int Jump(int[] nums) {
        
        int n = nums.Length;
        int i = 0; 
        int j = 1;
        
        int jump = 0;
        
        while(i < n-1){

            int score = 0;
            int nextInd = 0;
        
            while( j <= (i + nums[i]) && j < n){
                //Decide which to take
                if(j == n-1){
                    jump +=1;
                    return jump;
                }
                
                if((j + nums[j]) >= score){
                    score = j + nums[j];
                    nextInd = j;
                }
                
                ++j;
            }
            
            jump += 1;
            i = nextInd;
            Console.WriteLine(i);
        }
        
        return jump;
        
    }
}  