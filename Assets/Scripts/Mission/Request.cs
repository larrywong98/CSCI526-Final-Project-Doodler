using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Request : MonoBehaviour
{
    // public static string[,] table_requests=new string[1,3];
    public static List<List<string>> table_requests=new List<List<string>>();
    // public static int[] tableRequestsHash=new int[100];
    // public static int prevCount=0;
    //id 任务内容 奖励 状态
    public static List<List<string>> awaitingRequest=new List<List<string>>{
        new List<string>{"0","Kill 5 green bacteria","HP +50","0"},
        new List<string>{"1","Kill 5 bats","SP +50","0"},
        new List<string>{"2","Complete tutorial","HP +100","0"},
        new List<string>{"3","kill 10 bats","Oxygen +50","0"},
        new List<string>{"4","Kill 10 green bacteria","Oxygen +100","0"}
        };

    public void AddRow(string id,string request,string reward,string status){
        List<string> tmp=new List<string>();
        tmp.Add(id);
        tmp.Add(request);
        tmp.Add(reward);
        tmp.Add(status);
        // tableRequestsHash[val]=1;
        table_requests.Add(tmp);
    }
    public void ModifyRow(int rowid,string status){
        // table_requests[rowid-1,1]=status;
    }
    public void show(){
        for(int i=0;i<table_requests.Count;i++){
            for(int j=0;j<table_requests[i].Count;j++){
                Debug.Log(table_requests[i][j]);
            }
        }
    }
    public void delete(){

    }

}
