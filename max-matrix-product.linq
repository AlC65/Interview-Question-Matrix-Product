void Main()
{
	int[,] arr = new int[,] { { -1, -20, 3 }, { 4, 5, -6 }, { 7, 8, 9 } };
	int[,] arr2 = new int[,] { { -1, -20, 3 }, { 4, 5, -6 }, { 7, 8, 9 }, { -10, -40, 20 }};
	int[,] arr3 = new int[,] { { -1, -20, 3 }, { 4, 5, -6 }, { 7, 8, 9 }, { -10, -40, 20 }, {10,5,7}};
	Console.WriteLine(matrixProduct(arr3));
}
	
int matrixProduct(int[,]matrix)
{
	int[,] maxCache = new int[matrix.GetLength(0),matrix.GetLength(1)];
	int[,] minCache = new int[matrix.GetLength(0), matrix.GetLength(1)];
	int n1,n2,n3,n4;

	maxCache[0, 0] = minCache[0, 0] = matrix[0, 0];
	for (int i = 1; i < matrix.GetLength(0); i++) {minCache[i,0]=maxCache[i,0]=matrix[i, 0] * minCache[i - 1, 0];}
	for (int j = 1; j < matrix.GetLength(1); j++) {minCache[0, j]=maxCache[0, j] = matrix[0, j] * minCache[0, j - 1];}
	
	for (int i = 1; i < matrix.GetLength(0); i++) 
	{
		for (int j = 1; j < matrix.GetLength(1); j++)
		{
			int mxij =matrix[i,j];
			n1= mxij*maxCache[i - 1,j]; n2=mxij*minCache[i - 1,j];
			n3= mxij*maxCache[i,j - 1]; n4=mxij*minCache[i,j - 1];
			minCache[i,j] = Math.Min(Math.Min(Math.Min(n1, n2) ,n3), n4);
			maxCache[i,j] = Math.Max(Math.Max(Math.Max(n1, n2) ,n3), n4);
		}
	}
	return maxCache[maxCache.GetLength(0) - 1,maxCache.GetLength(1) - 1];
}