using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement {
    public Movement () {
        
    }
    public Vector3 CalculatePosition(float verticalInput,float speed, float deltaT){
        float translation = verticalInput * speed * deltaT;
        return new Vector3(0, 0, translation);
    }

    public Vector3 CalculateRotation(float horizontalInput,float rotationSpeed, float deltaT){
        float rotation = horizontalInput * rotationSpeed * deltaT;
        return new Vector3(0, rotation, 0);
    }
}
