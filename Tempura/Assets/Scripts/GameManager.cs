using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private bool _calibrated = false;
   // [SerializeField] private bool _inTheOil = false;
   // [SerializeField] private bool _fryed = false;
    //[SerializeField] private bool _onThePlate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
/*やりたいこと
フラグ変数の取得
必要なフラグ　１キャリブレーション　２鍋の中か　3皿の上か

スタート　キャリブレーション　鍋の中に手を移動　手を揚げる（視覚・聴覚・触覚関数＋データの取得）　鍋から手を出す　手を皿の上に置く　採点結果を表示．

手を揚げる監督　手が入ったことを判定（油の表面に円形の当たり判定を設定．）　揚げている時間を各感覚提示関数に引き渡す．


フラグによって呼び出す関数を選択

*/