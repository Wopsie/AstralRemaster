using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//this class will resort a list and put the value of index at the top of the list if it isnt already
public class SwitchTarget<T> {

    private int index = 0;

    public T SwitchTargets(List<T> objs, bool countDown)
    {
        //when countDown is true this will return the next object down on the list
        if(countDown){
            index++;
        }else{
            index--;
        }

        if(index > objs.Count){
            index = 0;
        }

        if(index < 0){
            index = objs.Count;
        }
        Debug.Log(index);
        T g = objs[index];

        return g;
    }
}
