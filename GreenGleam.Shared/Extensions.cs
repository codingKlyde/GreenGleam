namespace GreenGleam.Shared
{
    public static class Extensions
    {
        public static int GetUserId(this ClaimsPrincipal claimsPrincipal) => Convert.ToInt32(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
}