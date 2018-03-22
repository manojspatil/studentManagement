using studentManagement.Utils;

namespace studentManagement.Business.Interfaces
{
    public interface ILocalFileHelper
    {
        string GetAsyncConnection(string filename = Constants.DATABASE_NAME_SQLITE);
    }
}
