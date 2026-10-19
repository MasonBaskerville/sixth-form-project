//just need to fill in the other functions from the pc, as this one is just carrying on from where i left off
//so fill in previous functions from othr LLM solution on pc
//once math engine is completed, go through each function and add an error handler so if something goes wrong you know why and where sepcifically.

using System.Xml;

public class  Program
{
	public static void Main()
	{
		matrix mat1 = new matrix(2, 2);
		matrix mat2 = new matrix(2, 2);
		mat2.randomize();
		mat1.randomize();
		mat1.print();
		Console.Write("\n");
		mat2.print();
		ma
		
	}
}

public class matrix
{
	public double[][] data;
	public matrix(int rows,int cols)
	{
		data = new double[rows][];
		for (int i = 0; i < rows; i++)
		{
			data[i] = new double[cols];
		}
	}

	public void randomize()
	{
		Random rand = new Random();
		for (int i = 0; i < data.Length; i++)
		{
			for (int j = 0; j < data[0].Length; j++)
			{
				data[i][j] = rand.NextDouble() * 2 - 1;
			}
		}
	}

	public void print()
	{
		for (int i = 0; i < data.Length; i++)
		{
			for (int j = 0; j < data[0].Length; j++)
			{
				Console.Write(data[i][j]+" ");
			}
			Console.WriteLine();
		}
	}

	public matrix tensor_slice(int rows,int cols)
	{
		matrix output = new matrix(rows, cols);
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < cols; j++)
			{
				output.data[i][j] = data[i][j];
			}
		}

		return output;
	}

	public matrix tensor_concatenate(matrix input,int dimension)
	{
		//needs 2 matrices for input not 1
	}
}