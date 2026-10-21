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
		Console.Write("\n");
		matrix mat3 = mat1.tensor_concatenate(mat2, 1);
		mat3.print();


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

	public matrix element_multiply(matrix other)
	{
		matrix output = new matrix(data.Length, other.data[0].Length);
		for (int i = 0; i < data.Length; i++)
		{
			for (int j = 0; j < other.data[0].Length; j++)
			{
				output.data[i][j] = data[i][j] * other.data[i][j];
			}
		}

		return output;
	}

	public matrix element_addition(matrix other)
	{
		matrix output = new matrix(data.Length, other.data[0].Length);
		for (int i = 0; i < data.Length; i++)
		{
			for (int j = 0; j < other.data[0].Length; j++)
			{
				output.data[i][j] = data[i][j] + other.data[i][j];
			}
		}

		return output;
	}

	public matrix element_subtraction(matrix other)
	{
		matrix output = new matrix(data.Length, other.data[0].Length);
		for (int i = 0; i < data.Length; i++)
		{
			for (int j = 0; j < other.data[0].Length; j++)
			{
				data[i][j] -= other.data[i][j];
			}
		}

		return output;
	}

	public matrix element_division(matrix other)
	{
		matrix output = new matrix(data.Length, other.data[0].Length);
		for (int i = 0; i < data.Length; i++)
		{
			for (int j = 0; j < other.data[0].Length; j++)
			{
				data[i][j] /= other.data[i][j];
			}
		}

		return output;
	}

	public matrix scale(int scale)
	{
		matrix output = new matrix(data.Length, data[0].Length);
		for (int i = 0; i < data.Length; i++)
		{
			for (int j = 0; j < data[0].Length; j++)
			{
				data[i][j] *= scale;
			}
		}

		return output;
	}

	public matrix power(int power)
	{
		matrix output = new matrix(data.Length, data[0].Length);

		for (int i = 0; i < data.Length; i++)
		{
			for (int j = 0; j < data[0].Length; j++)
			{
				data[i][j] = Math.Pow(data[i][j], power);
			}
		}

		return output;
	}

	public matrix root(int root)
	{
		matrix output = new matrix(data.Length, data[0].Length);

		for (int i = 0; i < data.Length; i++)
		{
			for (int j = 0; j < data[0].Length; j++)
			{
				data[i][j] = Math.Pow(data[i][j], 1.0 / root);
			}
		}

		return output;
	}

	public double sum()
	{
		double sum = 0.0;
		for (int i = 0; i < data.Length; i++)
		{
			for (int j = 0; j < data[0].Length; j++)
			{
				sum += data[i][j];
			}
		}

		return sum;
	}

	public double mean()
	{
		double mean = 0.0;
		for (int i = 0; i < data.Length; i++)
		{
			for (int j = 0; j < data[0].Length; j++)
			{
				mean += data[i][j];
			}
		}

		return mean / (data.Length * data[0].Length);
	}

	public double maximum()
	{
		double maximum = 0.0;
		for (int i = 0; i < data.Length; i++)
		{
			for (int j = 0; j < data[0].Length; j++)
			{
				if (data[i][j] > maximum)
				{
					maximum = data[i][j];
				}
				else
				{
					continue;
				}
			}
		}

		return maximum;
	}

	public double magnitude()
	{
		double magnitude = 0.0;
		for (int i = 0; i < data.Length; i++)
		{
			for (int j = 0; j < data[0].Length; j++)
			{
				magnitude += Math.Pow(data[i][j], 2);
			}
		}

		return Math.Sqrt(magnitude);
	}

	public matrix transpose()
	{
		matrix transposed = new matrix(data[0].Length, data.Length);
		for (int i = 0; i < data.Length; i++)
		{
			for (int j = 0; j < data[i].Length; j++)
			{
				transposed.data[j][i] = data[i][j];
			}
		}

		return transposed;
	}

	public matrix matrix_multiplcation(matrix other)
	{
		matrix output = new matrix(data.Length, other.data[0].Length);
		for (int i = 0; i < data.Length; i++)
		{
			for (int j = 0; j < other.data[0].Length; j++)
			{
				for (int k = 0; k < data[0].Length; k++)
				{
					output.data[i][j] += data[i][k] * other.data[k][j];
				}
			}
		}

		return output;
	}

	public matrix reshape(int newRows, int newCols, matrix input)
	{
		matrix output = new matrix(newRows, newCols);
		for (int i = 0; i < input.data.Length; i++)
		{
			for (int j = 0; j < input.data[0].Length; j++)
			{
				for (int a = 0; a < newCols; a++)
				{
					for (int b = 0; b < newRows; b++)
					{
						output.data[a][b] = input.data[i][j];
					}
				}
			}
		}

		return output;
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

	public matrix tensor_concatenate(matrix input2,int dimension)
	{
		matrix output = null;
		
		if (dimension == 0)
		{
			output = new matrix(data.Length+input2.data.Length, data[0].Length);
			for (int i =0; i < data.Length; i++)
			{
				for (int j = 0; j < data[0].Length; j++)
				{
					output.data[i][j] = data[i][j];
				}
			}

			for (int i = 0; i < input2.data.Length; i++)
			{
				for (int j = 0; j < input2.data[0].Length; j++)
				{
					output.data[i+data.Length][j] = input2.data[i][j];
				}
			}
			
		}
		else if (dimension == 1)
		{
			output = new matrix(data.Length, input2.data[0].Length + data.Length);
			for (int i = 0; i < data.Length; i++)
			{
				for (int j = 0; j < data[0].Length; j++)
				{
					output.data[i][j] = data[i][j];
				}
			}
			for (int i = 0; i < input2.data.Length; i++)
			{
				for (int j = 0; j < input2.data[0].Length; j++)
				{
					output.data[i][j+data[0].Length] = input2.data[i][j];
				}
			}
		}
		return output;
	}

	public matrix tensor_broadcast_mul(matrix input)
	{
		matrix output = new matrix(data.Length, data[0].Length);
		
		if (data.Length == input.data.Length)
		{
			for(int i=0;i<data.Length;i++)
			{
				for(int j=0;j<data[0].Length;j++)
				{
					output.data[i][j] = data[i][j]*input.data[i][0];
				}
			}
		}
		else if (data[0].Length == input.data[0].Length)
		{
			for(int i=0;i<data.Length;i++)
			{
				for(int j=0;j<data[0].Length;j++)
				{
					output.data[i][j] = data[i][j]*input.data[0][j];
				}
			}
		}
		else
		{
			Console.WriteLine("error: dimension mismatch");
		}
		
		
		
		return output;
	}

	public class sigmoid()
	{
		
	}
}