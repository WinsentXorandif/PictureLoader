using Cysharp.Threading.Tasks;
using UnityEngine;
public class NoneLoad : ILoadOperation
{

    public NoneLoad() { }

    public async UniTask LoadOperation()
    {
    }

    public void ONCansel()
    {
        Debug.Log("ONCansel");
    }

}
