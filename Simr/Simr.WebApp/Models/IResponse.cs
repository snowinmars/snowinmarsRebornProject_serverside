namespace Simr.WebApp.Models
{
    public interface IResponse<T>
    {
        int Code { get; set; }
        T Data { get; set; }
        bool IsSuccess { get; }

        string ToJson();
    }
}