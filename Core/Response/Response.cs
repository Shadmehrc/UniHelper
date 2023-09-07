namespace Domain.Response
{
    public class Response<T>
    {
        internal Response(bool succeeded, IEnumerable<string> errors, T result)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
            Result = result;
        }

        private Response(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        private Response(bool succeeded)
        {
            Succeeded = succeeded;
        }

        public T Result { get; set; }

        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }


        public static Response<T> Success(T result)
        {
            return new Response<T>(true, new string[] { }, result);
        }

        public static Response<T> Failure(IEnumerable<string> errors)
        {
            return new Response<T>(false, errors);
        }

        public static Response<T> Failure()
        {
            return new(false);
        }

        public static Response<bool> FromResult(bool result, string failMessage)
        {
            return result ? Response<bool>.Success(true) : Response<bool>.Failure(new List<string>() { failMessage });
        }
    }
}