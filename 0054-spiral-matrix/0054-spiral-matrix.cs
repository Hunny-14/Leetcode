public class Solution {
    public IList<int> SpiralOrder(int[][] inputMatrix) {
        var ans = new List<int>();
      
        int row = inputMatrix.Length;
        int column = inputMatrix[0].Length;

        for(int i =0; i < Math.Min((row+1)/2,(column +1)/2); ++i){   // i -> 0 to 1;

        int firstRow = i;
        int lastRow = row -1 - i;
        int firstColumn = i;
        int lastColumn = column - 1 - i;



        // Top
        for(int j = firstColumn; j <= lastColumn; ++j){     
          ans.Add(inputMatrix[i][j]);
        }

        // right
        for(int j = firstRow + 1 ; j <=  lastRow; ++j){
          ans.Add(inputMatrix[j][lastColumn]);
        }



        // Bottom
        if(firstRow != lastRow){
          for(int j = lastColumn - 1 ; j >= firstColumn; --j ){
            ans.Add(inputMatrix[lastRow][j]);
          }
        }

        //Left
        if(lastColumn != firstColumn){
          for(int j = lastRow - 1; j > firstRow; --j){
            ans.Add(inputMatrix[j][firstColumn]);
          }
        }


        }

        return ans.ToArray();
    }
}