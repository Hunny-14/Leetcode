public class Solution {
    public int FindPeakElement(int[] nums) {
        var A = nums;
        int n = A.Length;
        
        if(n == 1){
            return 0;
        }

        int low =  0;
        int high = A.Length - 1;

        int ans = 0;
        

        while(low <= high){

            int mid = (low + high) / 2;

            if(mid == 0 && A[mid+1] <= A[mid] ){
                ans =  mid;
                break;
            }
            else if(mid == n - 1 && A[mid - 1] <= A[mid]){
                ans = mid;
                break;
            }

            else if(mid != 0 && mid != n - 1 && A[mid - 1] <= A[mid] && A[mid+1] <= A[mid]){
                ans  = mid;
                break;
            }

            else if(mid != 0 && A[mid - 1] >= A[mid]){
                high = mid - 1;
            }

            else if(mid != n - 1 && A[mid + 1] >= A[mid]){
                low = mid + 1;
            }

        }

        return ans;
    }
}