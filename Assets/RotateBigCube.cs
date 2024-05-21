using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBigCube : MonoBehaviour
{
    //スワイプが開始された最初の位置で一時停止をするためのベクトル
    Vector2 firstPressPos;
    //スワイプが開始された位置で二番目に一時停止をするためのベクトル
    Vector2 secondPressPos;
    //スワイプが終了し、現在のスワイプにベクトルする
    Vector2 currentSwipe;


    public GameObject target;


    void Start()
    {
        
    }

    void Update()
    {
        Swipe();
    }

    void Swipe()
    {
        if (Input.GetMouseButton(1))
        {
            //最初のマウスクリックの二次元位置を取得
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            print(firstPressPos);
        }
        if (Input.GetMouseButtonUp(1))
        {
            //右ボタンが離れた場合、二番目のマウスクリックの二次元位置を取得
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //最初と二番目にクリックされた位置からベクトルを作成
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //2Dベクトルを正規化
            currentSwipe.Normalize();
            if (LeftSwipe(currentSwipe))
            {
                target.transform.Rotate(0, 90, 0, Space.World);
            }
            else if (RightSwipe(currentSwipe))
            {
                target.transform.Rotate(0, -90, 0, Space.World);
            }

        }

    }

    bool LeftSwipe(Vector2 swipe)
    {
        return currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }

    bool RightSwipe(Vector2 swipe)
    {
        return currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }

}
