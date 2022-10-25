public class Solution {
    public int Search(int[] nums, int target) {
        var A = nums;
        var B = target;
        int k = getk(A);

        int n = A.Length;

        if(B <= A[n - 1]){
            return binarySearch(A, k + 1 , n-1 , B);
        }
        else{
            return binarySearch(A , 0 , k, B);
        }
    }
    
    int getk(int[] A){

        int n = A.Length;
        int low = 0;
        int high = A.Length - 1;

        while(low  <= high){
            
            int mid = (low + high) / 2;

            if(mid < n - 1 && A[mid] > A[mid + 1]){
                return mid;
            }

            if(A[mid] <= A[n -1]){
                high = mid - 1;
            }
            else{
                low = mid + 1; 
            }

        }

        return -1;
    }

    int binarySearch(int[] A , int low , int high , int b){

        while(low <= high){
            int mid = (low + high) / 2;

            if(A[mid] == b){
                return mid;
            }
            else if(b > A[mid]){
                low = mid + 1;
            }
            else{
                high = mid - 1;
            }

        }

        return -1;

    }
}