	public class Solution {
    public int ArrangeCoins(int n) {
        long sum = 0;
        int result = 0;
        if (n == 1 || n == 2) return 1;
        if (n == 3) return 2;
        int i = 1;
        while (sum <= n){
            result = i - 1;
            sum = (long)(i)*(i+1)/2;
            i++;
        }
        return result;
    }
}