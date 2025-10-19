using UnityEngine;

public class InputTextLR : MonoBehaviour
{
    // ボタン入力をさらに他の関数から呼び出したい場合は、
    // 適宜ゲームオブジェクトの変数を用意してそれらの関数を呼び出す
    // このプロジェクトの場合はスクリプト"GrabProjectile"を有する
    // ゲームオブジェクトのみ代入可能となっている

    // Update is called once per frame
    // 毎フレームごとにボタン入力の情報を取得する
    void Update()
    {
        // --- Right Controller ---
        if (InputManagerLR.PrimaryButtonR())
        {
            OnPrimaryButtonR();
        }

        if (InputManagerLR.PrimaryButtonR_OnPress())
        {
            OnPressPrimaryButtonR();
        }

        if (InputManagerLR.PrimaryButtonR_OnRelease())
        {
            OnReleasePrimaryButtonR();
        }

        if (InputManagerLR.SecondaryButtonR())
        {
            OnSecondaryButtonR();
        }

        if (InputManagerLR.SecondaryButtonR_OnPress())
        {
            OnPressSecondaryButtonR();
        }

        if (InputManagerLR.SecondaryButtonR_OnRelease())
        {
            OnReleaseSecondaryButtonR();
        }

        // --- Left Controller ---
        if (InputManagerLR.PrimaryButtonL())
        {
            OnPrimaryButtonL();
        }

        if (InputManagerLR.PrimaryButtonL_OnPress())
        {
            OnPressPrimaryButtonL();
        }

        if (InputManagerLR.PrimaryButtonL_OnRelease())
        {
            OnReleasePrimaryButtonL();
        }

        if (InputManagerLR.SecondaryButtonL())
        {
            OnSecondaryButtonL();
        }

        if (InputManagerLR.SecondaryButtonL_OnPress())
        {
            OnPressSecondaryButtonL();
        }

        if (InputManagerLR.SecondaryButtonL_OnRelease())
        {
            OnReleaseSecondaryButtonL();
        }

        if (InputManagerLR.WasTriggerPressedR())
        {
            OnTriggerPressR();
        }

        if (InputManagerLR.IsTriggerPressR())
        {
            OnTriggerStayR();
        }

        if (InputManagerLR.WasTriggerPressedL())
        {
            OnTriggerPressL();
        }

        if (InputManagerLR.IsTriggerPressL())
        {
            OnTriggerStayL();
        }
    }

    // --- Right Controller Methods ---

    private void OnPrimaryButtonR()
    {
        // 毎フレームごとにログテキストが表示されると邪魔になるためコメントアウト
        // UnityEngine.Debug.Log("PrimaryButtonRを押している");
    }

    private void OnPressPrimaryButtonR()
    {
        UnityEngine.Debug.Log("[MyDebug] PrimaryButtonRを押した瞬間");
    }

    private void OnReleasePrimaryButtonR()
    {
        UnityEngine.Debug.Log("[MyDebug] PrimaryButtonRを離した瞬間");
    }

    private void OnSecondaryButtonR()
    {
        // UnityEngine.Debug.Log("SecondaryButtonRを押している");
    }

    private void OnPressSecondaryButtonR()
    {
        UnityEngine.Debug.Log("[MyDebug] SecondaryButtonRを押した瞬間");
    }

    private void OnReleaseSecondaryButtonR()
    {
        UnityEngine.Debug.Log("[MyDebug] SecondaryButtonRを離した瞬間");
    }

    // --- Left Controller Methods ---

    private void OnPrimaryButtonL()
    {
        // UnityEngine.Debug.Log("PrimaryButtonLを押している");
    }

    private void OnPressPrimaryButtonL()
    {
        UnityEngine.Debug.Log("[MyDebug] PrimaryButtonLを押した瞬間");
    }

    private void OnReleasePrimaryButtonL()
    {
        UnityEngine.Debug.Log("[MyDebug] PrimaryButtonLを離した瞬間");
    }

    private void OnSecondaryButtonL()
    {
        // UnityEngine.Debug.Log("SecondaryButtonLを押している");
    }

    private void OnPressSecondaryButtonL()
    {
        UnityEngine.Debug.Log("[MyDebug] SecondaryButtonLを押した瞬間");
    }

    private void OnReleaseSecondaryButtonL()
    {
        UnityEngine.Debug.Log("[MyDebug] SecondaryButtonLを離した瞬間");
    }

    private void OnTriggerPressR()
    {
        UnityEngine.Debug.Log("[MyDebug] TriggerRを押した瞬間");
    }

    private void OnTriggerStayR()
    {
        // 押し続けている間の処理。毎フレーム呼ばれるためログはコメントアウト推奨
        UnityEngine.Debug.Log("[MyDebug] TriggerRを押し続けている");
    }

    private void OnTriggerPressL()
    {
        UnityEngine.Debug.Log("[MyDebug] TriggerLを押した瞬間");
    }

    private void OnTriggerStayL()
    {
        // 押し続けている間の処理。毎フレーム呼ばれるためログはコメントアウト推奨
        // UnityEngine.Debug.Log("[MyDebug] TriggerLを押し続けている");
    }
}