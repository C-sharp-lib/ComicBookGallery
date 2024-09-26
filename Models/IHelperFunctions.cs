namespace ComicBookGallery.Models
{
    public interface IHelperFunctions
    {
        string ConvertImageUrlToLower(string path);
        string TruncateDescription(string description, int wordLimit);
    }
}
