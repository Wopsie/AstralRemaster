using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//this class "scrolls" up and down through a generic list depending on the value of the boolean "countDown"
//and returns the 
public class ListScroller<T> {

    private int index = 0;

    public T SwitchTargets(List<T> objs, bool countDown)
    {
        //when countDown is true this will return the next object down on the list
        if(countDown){
            index++;
        }else{
            index--;
        }

        //resets the index so it doest go out of range
        if(index > objs.Count -1){
            index = 0;
        }else if(index < 0){
            index = objs.Count - 1;
        }

        T g = objs[index];

        return g;
    }
}
