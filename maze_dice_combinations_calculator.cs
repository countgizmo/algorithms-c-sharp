void Main()
{
	Console.WriteLine(Calculate(610));
}

// If you only need the number of partitions
// (since that's what we're actually looking for)
// you can use a simple recursive dependency and calculate
// simple values first and then use them to calculate bigger values.
//
// Please note: for better support and optimization I would do a check fo
// max (input number) first and then use ints, ulongs or BigIntegers variant
// of the function. The algorithm stays the same though, only the data types
// change. For the purpose of this demostration I chose not to bore you with
// a generic function and its implementations for different types.
ulong Calculate(int max)
{
	if (max < 0) { return 0; }
	
	int size = Math.Max(max + 1, 7);
	ulong[] partials = new ulong[size];
	Array.Clear(partials, 0, partials.Length);
	
	// Used my backtrack algorithm (or calculator) to calculate once
	// as the base for everything else. This simplifies and improves
	// performance significantly. And we don't need recursion - just
	// some dynamic programming techniques.
	partials[0] = 0;
	partials[1] = 1;
	partials[2] = 2;
	partials[3] = 4;
	partials[4] = 8;
	partials[5] = 16;
	partials[6] = 32;

	for (int i = 1; i <= max; i++)
	{
		if (partials[i] == 0)
		{
			partials[i] = 
			 partials[i-1] +
			 partials[i-2] +
			 partials[i-3] +
			 partials[i-4] +
			 partials[i-5] +
			 partials[i-6];
		}
	}
	
	return partials[max];
}