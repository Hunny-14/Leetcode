public class Solution {
    public int[] SecondGreaterElement(int[] nums) {
        Stack<int> s1 = new() , s2 = new() , temp = new();
        
        int n = nums.Length;
        int[] res = new int[n];
        
        //Initialize
        for(int i =0; i < n; ++i){
            res[i] = -1;
        }
        
        for(int i =0; i < n; ++i){
            
            while(s2.Count > 0 && nums[s2.Peek()] < nums[i] ){
                res[s2.Pop()] = nums[i];
            }
            
            while(s1.Count > 0 && nums[s1.Peek()] < nums[i]){
                temp.Push(s1.Pop());
            }
            
            while(temp.Count > 0){
                s2.Push(temp.Pop());
            }
            
            s1.Push(i);
        }
        
        
        return res;
        
    }
}