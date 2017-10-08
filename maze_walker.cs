// Find all the combinations of dice rolls you can get in order to
// finish a generic maze game.
void Main()
{
	int numberOfSpaces = 10;
	ulong counter = 0;
	WalkAndCount(0, 0, numberOfSpaces, ref counter);
	Console.WriteLine("Number of ways: " + counter);  
}

// Use this algorithm if you need to actually find all the paths.
// Instead of the counter increment we can use any function to process
// another result.
// Warning: the algorithm's complexity grows exponentionally, so it's not really
// useful after a certain point.
// Basically done to prove that we can do backtracking for a restricted set of variants.
void WalkAndCount(int currentSum, int currentStep, int maxLenghth, ref ulong counter)
{
	if (currentSum == maxLenghth)
	{
		counter++;
	}
	else if (currentSum + 2 == maxLenghth)
	{
		// When 2 steps left we can only have 2 combinations:
		// 2 and 1, 1
		// If we needed to list them we would just add process additional
		// combination. But right now we only count it and move on.
		// This optimization allows to improve the running time of the algorithm
		// quite significantly. (2x on my laptop).
		counter += 2;
	}
	else
	{
		List<int> candidates = GetCandidates(currentSum, maxLenghth);
		
		foreach(int candidate in candidates)
		{
			currentSum += candidate;
			WalkAndCount(currentSum, currentStep+1, maxLenghth, ref counter);
			currentSum -= candidate;
		}
	}
}

// All possible dice values
List<int> GetCandidates(int currentSum, int maxLength)
{
	List<int> result = new List<int>();
	
	for (int i = 6; i > 0; i--)
	{
		if (currentSum + i <= maxLength)
		{
			result.Add(i);
		}
	}
	
	return result;
}