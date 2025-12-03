namespace Domain.Definitions.Methods
{
    public static class GenerateOrderCode
    {
        public static string GenerateCode()
        {
            string datePart = DateTime.Now.ToString("yyMMdd"); 
            string randomPart = GenerateRandomString(6);
            return randomPart + datePart;
        }

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

}
