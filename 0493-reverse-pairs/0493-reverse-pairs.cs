public class Solution {
    public int ReversePairs(int[] nums) {
        var lst = nums.Select(x => (long)x).ToArray();

        return getCount(lst , 0 , lst.Count() - 1);
    }
    
    public int getCount(long[] arr , int low , int high){

        if(low >= high){
            return 0;
        }

        int count = 0;

        int mid = ((low + high) / 2);

        count += getCount(arr , low , mid);
        count += getCount(arr , mid + 1 , high);

        int p1 = low , p2 = mid + 1;



        while(p1 <= mid && p2 <= high){
            if((arr[p2] * 2) < arr[p1]){
                count += (mid - p1 + 1);
                ++p2;

            }
            else{
                ++p1;
            }
        }


        p1 = low ; p2 = mid + 1;

        var temp = new long[high - low + 1];

        while(p1 <= mid && p2 <= high){
            if(arr[p2] <= arr[p1]){
                temp[p1 + p2 - (mid + 1) - low] = arr[p2];
                ++p2;
            }
            else{
                temp[p1 + p2 - (mid + 1) - low] = arr[p1];
                ++p1;
            }
        }

        while(p1 <= mid){
            temp[p1 + p2 - (mid + 1) - low] = arr[p1];
            ++p1;
        }

        while(p2 <= high){
            temp[p1 + p2 - (mid + 1) - low ] = arr[p2];
            ++p2;
        }

        for(int i = low; i <= high; ++i){
            arr[i] = temp[i - low];
        }

        return count;
    }
}