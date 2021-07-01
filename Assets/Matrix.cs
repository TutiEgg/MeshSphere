using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix {

/**
 * Matrix Object Class
 * 
 * @author Luca
 *
 */
	private float[,] matrix;

	public int rows;
	public int cols;

	/**
	 * Matrix instantiation with column and row passing
	 * 
	 * @param rows
	 * @param cols
	 * @throws Exception
	 */
	public Matrix(int rows, int cols) {

		if (rows < 0 || cols < 0) {
			//throw new ArgumentException("Negative index values.");
		} else {
            this.rows = rows;
		    this.cols = cols;
        }
		
	}

	/**
	 * Assign matrix values
	 * 
	 * @param args [float,float,float,...]
	 */
	public void init(float[] args) {
		// Check if too many values have been passed
		if (args.Length > this.cols * this.rows) {
			//throw new ArgumentException("Transfer count is greater than column*row");
		} else {
			this.matrix = new float[rows,cols];
			int index = 0;
			for (int i = 0; i < this.rows; i++) {
				for (int j = 0; j < this.cols; j++) {
					// if e.g. only three elements were entered for a 3x3 matrix
					if (index + 1 > args.Length) {
						break;
					}
					this.matrix[i,j] = args[index];
					index++;
				}
			}
		}
	}

	// Matrix setter/getter Method
	// *********************************************************************
	/**
	 * get Matrix as an 2 Dimensional Array
	 * 
	 * @return Array[][]
	 */
	public float[,] getMatrix() {
		if (matrix == null) {
			//throw new ArgumentException("The matrix has not yet been declared");
		}
		return matrix;
	}

	/**
	 * get value in a specific column,row
	 * 
	 * @param rows
	 * @param cols
	 * @return float value
	 * @throws Exception
	 */
	public float get(int rows, int cols) {
		check(rows, cols);
		return this.matrix[rows - 1,cols - 1];
	}

	/**
	 * set a value in a specific column,row
	 * 
	 * @param rows
	 * @param cols
	 * @param value float
	 * @throws Exception
	 */
	public void set(int rows, int cols, float value) {
		check(rows, cols);
		this.matrix[rows - 1,cols - 1] = value;
	}

	/**
	 * set a value in a specific column,row and initialize
	 * 
	 * @param rows
	 * @param cols
	 * @param value float
	 * @throws Exception
	 */
	public void setWithInit(int rows, int cols, float value) {
		check(rows, cols);
		if (this.matrix == null)
			this.matrix = new float[this.rows,this.cols];
		this.matrix[rows - 1,cols - 1] = value;
	}

	// ******************************************************************************************************
	/**
	 * Check Matrix rows and Cols
	 * 
	 * @param rows
	 * @param cols
	 * @throws Exception
	 */
	public void check(int rows, int cols){
		if (rows < 0 || cols < 0) {
			//throw new ArgumentException("Negative index values.");
		}
		if (rows > this.rows || cols > this.cols) {
			//throw new ArgumentException("too high index for the matrix");
		}
	}


}