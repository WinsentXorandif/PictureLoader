using UnityEngine;
using Cysharp.Threading.Tasks;

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
