using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionStatus : MonoBehaviour
{
    //killed index reference
    //0  green bacteria
    //1  bat
    public static int[] killed=new int[100];
    //任务目标0-50 regular
    //51-100 main
    public static int[] expectedNum=new int [100];
    private void Start(){
        //deliver oxygen
        expectedNum[0]=5;
        expectedNum[1]=10;
        // for(int i=0;i<2;i++){
        //     expectedNum[i]=5;
        // }
        // for(int i=2;i<4;i++){
        //     expectedNum[i]=10;
        // }
        // for(int i=4;i<50;i++){
        //     expectedNum[i]=20;
        // }
    }
    public static int TaskMap(int expect){
        // //green
        // if(expect==0 || expect==2 || expect==4){
        //     return 0;
        // }
        // //bat
        // if(expect==1 || expect==3){
        //     return 1;
        // }
        if(expect==0){
            return 0;
        }
        if(expect==1){
            return 1;
        }
        return -1;
    }
    public static void CheckComplete() {
        // new List<string>{"0","Kill 5 green bacteria","5","0"},
        // new List<string>{"1","kill 5 bats","5","0"},
        // new List<string>{"2","Kill 10 green bacteria","10","0"},
        // new List<string>{"3","Kill 10 bats","10","0"},
        // new List<string>{"4","Kill 20 green bacteria","20","0"}

        //killed index reference
        ////0  green bacteria
        ////1  bat
        //0 oxygen
        // if(Request.table_requests.Count==0) return;
        // if(FullControl.collectOxygen==expectedNum[0]){
        //     TreasureChest.canOpen[int.Parse(Request.table_requests[0][4])]=1;
        // }
        killed[0]=FullControl.collectOxygen;
        killed[1]=FullControl.deadGreenBacteria;
        // Debug.Log(FullControl.collectOxygen);
        // Debug.Log(expectedNum[0]);
        for(int i=0;i<Request.table_requests.Count;i++){
            if(killed[TaskMap(i)]>=expectedNum[i]){
                TreasureChest.canOpen[int.Parse(Request.table_requests[i][4])]=1;
            }
        }
    }
    // private void Update() {
    //     CheckComplete();
    // }

}
