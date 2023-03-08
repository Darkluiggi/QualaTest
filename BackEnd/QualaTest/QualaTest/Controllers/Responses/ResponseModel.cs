namespace QualaTest.Controllers.Responses;

public class ResponseModel<T> where T : class
{
    public bool Status { get; set; }
    public string Description { get; set; }
    public T Result { get; set; }
}
