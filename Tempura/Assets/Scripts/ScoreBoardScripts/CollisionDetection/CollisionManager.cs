using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.Newtonsoft.Json.Serialization;
public class CollisionManager : MonoBehaviour
{
    private bool _isBat = false;
    private bool _isInTheOil = false;
    private bool _isOnThePlate = false;
    private bool _isFryed = false;
    private bool _isKoromo = false;
    /*
    public bool _isbat = false;
    [SerializeField] public  bool _isInTheOil = false; //手が油の中にあるか反映するフラグ
    public  bool _isOnThePlate = false; //揚げた手んぷらを皿に乗せたか判定するフラグ
    public  bool _isFryed = false; //手を1回でも油から出したことを判定するフラグ
    public  bool _isKoromo = false; 
    */
    private void OnTriggerStay(Collider other)
    {       
        if (other.gameObject.CompareTag("TopOil")) //接触しているオブジェクトが油の表面の時
        {
            _isBat = false;
            _isInTheOil = true;
            Debug.Log("ぶつかった");
        }
        //_totalTime += Time.deltaTime; 
        //_colorChanger.colorchanger(_totalTime);
        //_shakeChanger.shakechanger(_totalTime);*/
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("TopOil")) //油表面からに手が離れたとき．
        {
            //Debug.Log("離れた");
            _isInTheOil = false;
            _isFryed = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("KoromoLiquid")){
            _isBat = true;
            _isKoromo = true;
           // Debug.Log("ぶつかった衣");
        }
        
        if (other.gameObject.CompareTag("Dish") && _isFryed) //手と皿が接触し，かつ，手を一度でも揚げている場合
        {
            _isOnThePlate = true;
            Debug.Log("完了");
        }
        
    }
    public bool isInTheOil()
    {
        return _isInTheOil;
    }
    public bool isBat()
    {
        return _isBat;
    }
    public bool isOnThePlate()
    {
        return _isOnThePlate;
    }
    public bool isFryed()
    {
        return _isFryed;
    }
    public bool isKoromo()
    {
        return _isKoromo;
    }
}
