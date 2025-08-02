namespace GreenGleam.Shared.Dtos
{
    public record ApiResultDto(bool  IsSuccess, string? Error)
    {
        public static ApiResultDto Success() => new(true, null);
        public static ApiResultDto Fail(string errorMessage) => new(false, errorMessage);
    }

    public record ApiResultDto<TData>(bool IsSuccess, TData Data, string? Error)
    {
        public static ApiResultDto<TData> Success(TData data) => new(true, data, null);
        public static ApiResultDto<TData> Fail(string errorMessage) => new(false, default!, errorMessage);
    }
}