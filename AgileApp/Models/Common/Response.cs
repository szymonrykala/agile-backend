namespace AgileApp.Models.Common
{
    public class Response
    {
        public bool IsSuccess { get; set; }

        public static Response Succeeded()
            => new Response
            {
                IsSuccess = true
            };

        public static Response Failed()
            => new Response
            {
                IsSuccess = false
            };
    }

    public class Response<T>
    {
        public bool IsSuccess { get; set; }

        public T Data { get; set; }

        public static Response<T> Succeeded(T data)
            => new Response<T>
            {
                IsSuccess = true,
                Data = data
            };

        public static Response<T> Failed()
            => new Response<T>
            {
                IsSuccess = false
            };
    }
}
