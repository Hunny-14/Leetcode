public class Solution {
    public int EarliestFullBloom(int[] plantTime, int[] growTime) {
        int n = plantTime.Length;
        (int,int)[] arr = new (int,int)[n];
        
        for(int i =0; i < n; ++i){
            arr[i] = (plantTime[i],growTime[i]);
        }
        
        Array.Sort(arr,(x,y) => {
            return -1 * x.Item2.CompareTo(y.Item2);
        });
            
        int total = int.MinValue;
        int currPlantTime = 0;
        
        for(int i =0; i < n; ++i){
            total = Math.Max(total, currPlantTime + arr[i].Item1 + arr[i].Item2);
            currPlantTime += arr[i].Item1;
        }
        
        return total;
    }
}