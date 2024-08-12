namespace WEB_API_1_Paskaita.Utilities
{
    public static class FileUtility
    {
        public static async Task<byte[]> ConvertToByte(IFormFile file)
        {
            using var memorystream = new MemoryStream();
            await file.CopyToAsync(memorystream);
            return memorystream.ToArray();
        }
    }
}
