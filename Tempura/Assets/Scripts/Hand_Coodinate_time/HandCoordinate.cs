using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandCoordinate : MonoBehaviour
{
    ArrayList distance = new ArrayList();
    List<float> distance_list = new List<float>();
    float[] distance_array = new float[10];//�v�Z�p�̔z��
    float[] hand_coordinate = new float[10000];//�ŏI�I�Ȓl���i�[����z��

    private float timeElapsed;
    private int k = 0, i = 0;
    private float median_coordinate;
    private Vector3 _tmp;
    void start()
    {
        Vector3 _tmp = GameObject.Find("WhiteHand_old").transform.position;

        StartCoroutine("ReadHandPosition");
    }

    /*void Update()
    {
        
        //distance_array[0] = 0;
        //distance_array[1] = 6;
        //distance_array[2] = 2;
        //Debug.Log(findMedian(distance_array));
        

        timeElapsed += Time.deltaTime;
        if (timeElapsed < 0.1f) return;
        timeElapsed = 0.0f;

        //Vector3 _tmp = GameObject.Find("hand").transform.position;

        float _x = _tmp.x, _y = _tmp.y, _z = _tmp.z ; //���_��oil������ꍇ
        float _dis = (float)Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(_y, 2) + Math.Pow(_z, 2));
        Debug.Log("_dis= " + _dis);
        distance_array[i]=_dis;
        //Debug.Log("distance_list[i]=" + distance_list[i]);
        i++;

        if (i == 9)
        {
            median_coordinate = (float)findMedian(distance_array);
            hand_coordinate[k] = median_coordinate;//�ŏI�I�Ȏ�̍��W
            Debug.Log("hand_coordinate[k] =" + hand_coordinate[k]);
            ++k;
            i = 0;
        }
        
    } */

    public static double findMedian(float[] a)//�擾�����l�̒����l���Ƃ�֐�
    {
        var count = a.Length;
        Array.Sort(a);
       
        //��̏ꍇ
        if (count % 2 != 0)
            return (double)a[count / 2];

        //�����̏ꍇ
        return (double)(a[(count - 1) / 2] + a[count / 2]) / 2.0;
    }

    //1秒ごとに実行する関数
    public void handposition(float _time)
    {
        /*
        timeElapsed += _totaltime;
        if (timeElapsed < 0.1f) return;
        timeElapsed = 0.0f;
        */
        
        if(_time >= 1f +i)
        {
            Vector3 _tmp = GameObject.Find("WhiteHand_old").transform.position;

            float _x = _tmp.x, _y = _tmp.y, _z = _tmp.z;
            float _dis = (float)Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(_y, 2) + Math.Pow(_z, 2));
        
            Debug.Log("_dis= " + _dis);

            hand_coordinate[k] = _dis;

            Debug.Log("hand_coordinate[" + k + "] =" + hand_coordinate[k]);

            ++k;

            i++;
        }

        /*
        distance_array[i]=_dis;
        
        i++;
        Debug.Log("i=" + i);
        if (i == 9)
        {
            median_coordinate = (float)findMedian(distance_array);
            hand_coordinate[k] = median_coordinate;//�ŏI�I�Ȏ�̍��W
            //Debug.Log("k="+k);
            Debug.Log("hand_coordinate[" + k + "] =" + hand_coordinate[k]);
            ++k;
            i = 0;
        }
        */
    }


    public void allscore()// 手の距離の一覧を表示するプログラム．デバッグ用（板倉）
    {
        for (int i = 0; i < k; i++)
        {
            //Debug.Log("hand_coordinate=" + hand_coordinate[i]);
        }
    }
    public int numberofscore()//とったデータの個数を返す関数（板倉）
    {
        return k - 1;
    }
}
