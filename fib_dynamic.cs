// Calculate big fib numbers without hanging your computer :)
void Main()
{
	BigInteger result = fib(8181);
	Console.WriteLine(result);
}

// Unlike recursive implementation the dynamic programming implementation
// will run in N time. (The recursive would've been N^2 since you need to call
// the function twice for each iteration.
// I think it's also easier for even a beginner to read. It's just a loop.
// Just make sure you find the correct data type. Fib numbers can grow big very fast.
public BigInteger fib(int num)
{
	BigInteger[] prevPair = new BigInteger[2];
	BigInteger result = 0;

	if (num < 1) { return result; }

	prevPair[0] = 0;
	prevPair[1] = 1;
	
	for (int i = 2; i <= num; i++)
	{
		result = prevPair[0] + prevPair[1];
		prevPair[0] = prevPair[1];
		prevPair[1] = result;
	}
	
	return result;
}