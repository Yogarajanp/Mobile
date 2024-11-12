namespace MobileRepository.Base.DTO
{
    public class Result<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        // Return this instance to allow chaining
        public Result<T> AddError(string error)
        {
            Errors.Add(error);
            return this;
        }
    }


}
