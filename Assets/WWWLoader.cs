using UnityEngine;
using System.Collections;

public class WWWLoader : MonoBehaviour
{
    public string BundleURL;
    public string AssetName;
    public int version;
    public AssetBundle bundle;

    public IEnumerator Start()
    {
        yield return StartCoroutine(DownloadAndCache());

    }

IEnumerator DownloadAndCache()
    {
        // ダウンロード処理
        var www = WWW.LoadFromCacheOrDownload(BundleURL, 1);
        while (!www.isDone)
        {

            yield return null;
        }

        // TODO エラー処理とか

        // Asset Bundleをキャッシュ
        bundle = www.assetBundle;

        // リクエストは開放
        www.Dispose();
    }
        //Destroy(gameObject);
        //メモリーがwebstreamから解放(www.Disposeが強制的に呼ばれる)
}
