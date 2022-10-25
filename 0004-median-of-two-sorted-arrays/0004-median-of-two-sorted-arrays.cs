public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        
        var A = nums1;
        var B = nums2;
        
        int n = A.Length;
        int m = B.Length;

        if(m < n){
            var temp = A;
            A = B;
            B = temp;
            n = A.Length;
            m = B.Length;
        }

        int low = 0;
        int high = n - 1;
        double ans = 0;

        int half_length = (n + m + 1) / 2;

        if(n == 0 && m != 0){
            
            if(m % 2 == 0){
                return (1d * B[(m-1)/2] + B[((m -1)/2) + 1]) /2;
            }
            else{
                return B[m/2];
            }
        }

        while(high - low >= -2){
            
            int i = (low + high) / 2;

            if(high == -1){
                i = -1;
            }

            int j = (half_length - i - 2);

            if( i >= 0 &&  A[i] > B[j + 1]){
                high = i - 1;
            }
            else if(j >= 0 && (i < n -1 ) && B[j] > A[i+1]){
                low = i + 1;
            }
            else{
                
                double leftVal = 0;
                
                if(j < 0){
                    leftVal = A[i];
                }   
                else if(i < 0){
                    leftVal = B[j];
                }
                else{
                    leftVal = Math.Max(A[i] , B[j]);
                }

                if((n + m) % 2 != 0){
                    return leftVal;
                }

                double rightVal = 0;
                
                if(j + 1 > m - 1){
                    rightVal = A[i + 1];
                }
                else if(i + 1 > n -1){
                    rightVal = B[j + 1];
                }
                else{
                    rightVal = Math.Min(A[i+1] , B[j+1]);
                }

                return (leftVal + rightVal) / 2;

            }
            
        }
        
        return 0;
    }
}