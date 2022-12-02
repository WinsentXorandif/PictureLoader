using Cysharp.Threading.Tasks;

public interface ILoadOperation
{
    UniTask LoadOperation();
    public void ONCansel();

}
