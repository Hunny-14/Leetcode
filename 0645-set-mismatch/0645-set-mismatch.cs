public class Solution {
    public int[] FindErrorNums(int[] nums) {
        var ans = new int[2];
        int n = nums.Length;
        int i =0;
        
        while(i<n){
            int val = nums[i];
            int ind = val - 1;
            
            if(i == ind){
                ++i;
                continue;
            }
            
            if(nums[ind] != val){
                Swap(i,ind,nums);
            }
            else{
                ans[0] = val;
                ++i;
            }
        }
        
        
        for(int j =0; j <n; ++j){
            if(nums[j] != j+1){
                ans[1] = j+1;
            }
        }
        
            
        return ans;
    }
    
    void Swap(int i , int j, int[] A){
        int temp = A[i];
        A[i] = A[j];
        A[j] = temp;
    }
}