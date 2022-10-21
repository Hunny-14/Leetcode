public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        var valToIndexMap = new Dictionary<int,int>();
        int n = nums.Length;
        
        for(int i = 0; i < n; ++i){
                if(valToIndexMap.ContainsKey(nums[i])){
                    if(i - valToIndexMap[nums[i]] <= k ){
                        return true;
                    }
                }
            
            valToIndexMap[nums[i]] = i;
        }
        
        return false;
    }
}