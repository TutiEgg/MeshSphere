using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixVector {

    public Vector3 multiply(Vector3 vector, Matrix matrix){
        
			
			float[] values = new float[matrix.rows];

			for (int i = 0; i < matrix.rows; i++) {

				float rowResult = 0;
                rowResult = rowResult + (matrix.get(i + 1, 1) * vector.x) + (matrix.get(i + 1, 2) * vector.y) + (matrix.get(i + 1, 3) * vector.z) ; // +1 da die rows and cols bei 1 anfangen nicht 0
				values[i] = rowResult;
				
			}
            Vector3 returnVector = new Vector3(values[0], values[1], values[2]);
			return returnVector;
	}
}