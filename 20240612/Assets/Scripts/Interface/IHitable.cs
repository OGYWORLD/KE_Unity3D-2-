
public interface IHitable
{
    public void Hit(float damage);

    // 이런 것도 가능 (누가 때렸는지)
    //public void destroy(MonoBehaviour destroyer);
}